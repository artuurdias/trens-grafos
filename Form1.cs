using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using static System.Environment;
using System.IO;
using System.Windows.Forms;

namespace Trem1
{
    public partial class frmRotasTrem : Form
    {
        // DESENVOLVEDORES DO PROGRAMA
        // Artur Dias de Oliveira - 20124
        // Gustavo Waki Teles     - 20137

        private Grafo oGrafo;
        private Arvore<Cidade> arvoreC;
        private Arvore<Viagem> arvoreV;
        private Image imagem = Properties.Resources.mapaEspanhaPortugal;
        private Graphics gg;
        //inicializa as variaveis que precisam ser usadas em diferentes ações

        public frmRotasTrem()
        {
            InitializeComponent();
            Inicializar();
            gg = pbMapa.CreateGraphics();//cria o Graphics a partir da picturBox, para usar apenas uma classe Graphics e não ocorrer confusões
        }

        private void LimpaMapa()
        {
            gg.Clear(Color.Transparent);
            pbMapa.Image = imagem;
            //método de limpar as linhas do mapa
        }

        private void Inicializar()
        {
            arvoreC = new Arvore<Cidade>();
            arvoreV = new Arvore<Viagem>();

            string[] cidades = null;
            if (dlgCidades.ShowDialog() == DialogResult.OK)
            {
                cidades = File.ReadAllLines(dlgCidades.FileName);
                arvoreC.LerArquivoDeRegistros(cidades);
            }
            else
            {
                MessageBox.Show("Houve um problema na especificação do arquivo.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Exit(ExitCode);
            }

            if (dlgTrens.ShowDialog() == DialogResult.OK)
            {
                string[] viagens = File.ReadAllLines(dlgTrens.FileName).OrderBy(i => i).ToArray();
                arvoreV.LerArquivoDeRegistros(viagens);
            }
            else
            {
                MessageBox.Show("Houve um problema na especificação do arquivo.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Exit(ExitCode);
            }
            
            //chama os métodos para criar arvores e criar os nós com valores das cidades

            oGrafo = new Grafo(cidades.Length);

            Queue<NoArvore<Cidade>> qCidades = arvoreC.PercursoPorNiveis();//cria uma fila para armazenar o retorno do método da classe Arvore
            NoArvore<Cidade> no = null;//nó auxiliar para o while
            while (qCidades.Count != 0)//enquanto a fila tiver elementos o programa adiciona uma cidade  
            {
                no = qCidades.Dequeue();
                oGrafo.NovoVertice(no.Info, no.Indice);//no grafo
                cbbOrigem.Items.Add(no.Info.Nome.Trim());//e em cada comboBox
                cbbDestino.Items.Add(no.Info.Nome.Trim());
            }

            Queue<NoArvore<Viagem>> qViagens = arvoreV.PercursoPorNiveis();//cria fia para armazenar o retorno do método da classe Arvore
            NoArvore<Viagem> v = null;//cria um no de viagem auxiliar
            Cidade aux = new Cidade();//cria uma cidade para checar se as viagens são entre cidades válidas
            while (qViagens.Count != 0)
            {
                v = qViagens.Dequeue();

                int iOrigem = 0, iDestino = 0;

                aux.Nome = v.Info.NomeOrigem;//atribui nome a cidade auxiliar, já que o nome é a chave comparada entre cidades
                if (arvoreC.Existe(aux))//checa se a cidade existe
                    iOrigem = arvoreC.Atual.Indice;//pega o indice da cidade

                aux.Nome = v.Info.NomeDestino;
                if (arvoreC.Existe(aux))
                    iDestino = arvoreC.Atual.Indice;

                //declara uma nova aresta com os atributos
                // indice da 1a cidade, indice da 2a cidade, distancia da viagem
                oGrafo.NovaAresta(iOrigem, iDestino, int.Parse(v.Info.Distancia), int.Parse(v.Info.Preco));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbbOrigem.SelectedItem == null || cbbDestino.SelectedItem == null)
                MessageBox.Show("Selecione 2 cidades!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cbbOrigem.SelectedItem.ToString().Equals(cbbDestino.SelectedItem.ToString()))
                MessageBox.Show("Selecione 2 cidades diferentes!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);//checa se a passagem de dados foi errada
            else
            {
                lsbSaida.Items.Clear();//limpa as listBox de saida

                if (cbbOrigem.SelectedItem == cbbDestino.SelectedItem)
                {
                    MessageBox.Show("Selecione 2 cidades diferentes!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Cidade aux = new Cidade(cbbOrigem.SelectedItem.ToString());//gera cidade e atribui o nome como o nome da origem

                NoArvore<Cidade> noOrigem = null;
                if (arvoreC.ExisteRegistro(aux))//usa o auxiliar pra ver se 
                    noOrigem = new NoArvore<Cidade>(arvoreC.Atual);//cria um No com o valor da cidade auxiliar

                NoArvore<Cidade> noDestino = null;
                aux.Nome = cbbDestino.SelectedItem.ToString();
                if (arvoreC.ExisteRegistro(aux))
                    noDestino = new NoArvore<Cidade>(arvoreC.Atual);
                //nó destino recebe as informações da cidade destino

                var caminho = oGrafo.Caminho(noOrigem.Indice, noDestino.Indice, lsbSaida);
                //caminho é armazenado na variável, para em seguida desenharmos uma linha entre as cidades armazenadas

                if (caminho == null)
                {
                    //se o retorno for nulo, significa que não há caminho entre as cidades informadas
                    lsbSaida.Items.Add("Não há caminho entre essas cidades!");
                    return;
                }

                Image imagem = pbMapa.Image;
                Graphics g = Graphics.FromImage(imagem);
                Pen caneta = new Pen(Color.Red, 2);
                //declarados objetos para desenho no mapa

                Cidade origem = null;
                Cidade destino = null;

                bool primeiraVez = true;

                while (caminho.Count >= 0)
                {
                    if (primeiraVez)
                    {
                        //se for a primeira vez, são desenfileirados os dois primeiros nós para começar como origem e destino
                        origem = caminho.Dequeue();
                        destino = caminho.Dequeue();
                        primeiraVez = false;
                    }

                    gg.DrawLine(caneta, (float.Parse(origem.CoordenadaX) * imagem.Width), (float.Parse(origem.CoordenadaY) * imagem.Height),
                                    (float.Parse(destino.CoordenadaX) * imagem.Width), (float.Parse(destino.CoordenadaY) * imagem.Height));
                    //linha traçada entre cidade origem e cidade destino

                    if (caminho.Count > 0)
                    {
                        //se ainda houver cidades no caminho, a origem recebe o destino e o destino recebe uma nova cidade desenfileirada
                        origem = destino;
                        destino = caminho.Dequeue();
                    }
                    else break; // se não houver mais cidades no caminho sai do while
                }
                gg.Flush();
            }
        }

        private void btnMaisCidade_Click(object sender, EventArgs e)
        {
            if (txtManutencaoMaisCidade.Text != "")
            {
                string[] dados = txtManutencaoMaisCidade.Text.Split('-');
                if (dados.Length != 3)//verifica se os dados foram passados de forma correta
                {
                    MessageBox.Show("Dados informados de maneira errada.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cidade novaCidade = new Cidade(dados[0], dados[1], dados[2]);
                //nova cidade é criada com os dados passados

                if (arvoreC.Existe(novaCidade))//se a cidade existir o usuário é alertado e o método abortado
                {
                    MessageBox.Show("Cidade repetida.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int quantosNos = arvoreC.QtosNos();
                arvoreC.IncluirNovoRegistro(quantosNos, novaCidade);
                //o nó é incluido com o índice correspondente à quantidade de nós da árvore

                oGrafo.NovoVertice(novaCidade, quantosNos);//é criado o vértice no grafo

                cbbOrigem.Items.Add(novaCidade.Nome.Trim());//adicionada a cidade no combobox
                cbbDestino.Items.Add(novaCidade.Nome.Trim());//adicionada a cidade no combobox

                MessageBox.Show("Dados incluídos com sucesso!", "ÊXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtManutencaoMaisCidade.Clear();
            }
            else if (txtManutencaoMenosCidade.Text != "" || txtManutencaoMaisCaminho.Text != "")
                MessageBox.Show("Preencha o textbox correto!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Informe os dados da cidade!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMenosCidade_Click(object sender, EventArgs e)
        {
            if (txtManutencaoMenosCidade.Text != "")
            {
                Cidade c = new Cidade(txtManutencaoMenosCidade.Text);
                if (arvoreC.Existe(c))//se a cidade informada existe na árvore
                {
                    NoArvore<Cidade> noAtual = arvoreC.Atual;

                    oGrafo.RemoverVertice(noAtual.Indice);//vertice é removido do grafo
                    arvoreC.ApagarNo(noAtual.Info);//nó é removido da árvore

                    var nos = arvoreC.PercursoPorNiveis().ToList();
                    for (int i = 0; i < nos.Count; i++)
                        if (nos[i].Indice > noAtual.Indice)
                            arvoreC.DiminuirIndice(nos[i].Info);//para cada nó de índice maior que o removido, seu índice diminui 1

                    cbbOrigem.Items.Remove(noAtual.Info.Nome.Trim());//removida a cidade do combobox
                    cbbDestino.Items.Remove(noAtual.Info.Nome.Trim());//removida a cidade do combobox

                    MessageBox.Show("Dados excluídos com sucesso!", "ÊXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtManutencaoMenosCidade.Clear();
                }
                else
                    MessageBox.Show("A cidade informada não existe!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtManutencaoMaisCidade.Text != "" || txtManutencaoMaisCaminho.Text != "")
                MessageBox.Show("Preencha o textbox correto!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Informe o nome da cidade!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnMaisCaminho_Click(object sender, EventArgs e)
        {
            if (txtManutencaoMaisCaminho.Text != "")
            {
                string[] dados = txtManutencaoMaisCaminho.Text.Split('-');
                if (dados.Length != 4)//verifica se os dados foram passados de forma correta
                {
                    MessageBox.Show("Dados informados de maneira errada.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Viagem viagem = new Viagem(dados[0], dados[1], dados[2], dados[3]);//cria viagem com os dados

                Cidade aux = new Cidade(dados[0]);//variavel auxiliar para buscar dados das cidades envolvidas

                

                NoArvore<Cidade> noOrigem = null;
                if (arvoreC.Existe(aux))//se a cidade existir o no de origem é atribuido, se não, o usuário é alertado e o método abortado
                    noOrigem = new NoArvore<Cidade>(arvoreC.Atual);
                else
                {
                    MessageBox.Show("A cidade informada não existe!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                aux.Nome = dados[1];

                NoArvore<Cidade> noDestino = null;
                if (arvoreC.Existe(aux))//se a cidade existir o no de destino é atribuido, se não, o usuário é alertado e o método abortado
                    noDestino = new NoArvore<Cidade>(arvoreC.Atual);
                else
                {
                    MessageBox.Show("A cidade informada não existe!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int quantosNos = arvoreV.QtosNos();
                try
                {
                    arvoreV.IncluirNovoRegistro(quantosNos, viagem);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Caminho já existente.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //incluido o nó do caminho na árvore

                oGrafo.NovaAresta(noOrigem.Indice, noDestino.Indice, int.Parse(dados[2]), int.Parse(dados[3]));
                //criada a aresta com os dados

                MessageBox.Show("Dados adicionados com sucesso!", "ÊXITO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtManutencaoMaisCaminho.Clear();
            }
            else if (txtManutencaoMenosCidade.Text != "" || txtManutencaoMaisCidade.Text != "")
                MessageBox.Show("Preencha o textbox correto!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Informe os dados do caminho!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmRotasTrem_FormClosed(object sender, FormClosedEventArgs e)
        {
            var cidades = arvoreC.PercursoPorNiveis().OrderBy(i => i.Info.Nome).ToList();
            var viagens = arvoreV.PercursoPorNiveis().OrderBy(i => i.Indice).ToList();
            //listadas as cidades e viagens

            StreamWriter arqCidades = new StreamWriter(dlgCidades.FileName);
            for (int i = 0; i < cidades.Count; i++)
                arqCidades.WriteLine(cidades[i].Info);
            //cada cidade da lista é escrita no arquivo

            StreamWriter arqViagens = new StreamWriter(dlgTrens.FileName);
            for (int i = 0; i < viagens.Count; i++)
                if (arvoreC.ExisteRegistro(new Cidade(viagens[i].Info.NomeOrigem))
                 && arvoreC.ExisteRegistro(new Cidade(viagens[i].Info.NomeDestino)))
                    arqViagens.WriteLine(viagens[i].Info);
            //cada viagem da lista é escrita no arquivo (se as cidades origem e destino existirem)

            arqCidades.Close();
            arqViagens.Close();
        }

        private void btnBuscar_MouseDown(object sender, MouseEventArgs e) => LimpaMapa();
    }
}
