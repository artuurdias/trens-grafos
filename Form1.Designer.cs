
namespace Trem1
{
    partial class frmRotasTrem
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.cbbOrigem = new System.Windows.Forms.ComboBox();
            this.cbbDestino = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lsbSaida = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaisCidade = new System.Windows.Forms.Button();
            this.btnMenosCidade = new System.Windows.Forms.Button();
            this.btnMaisCaminho = new System.Windows.Forms.Button();
            this.txtManutencaoMaisCidade = new System.Windows.Forms.TextBox();
            this.txtManutencaoMenosCidade = new System.Windows.Forms.TextBox();
            this.txtManutencaoMaisCaminho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dlgCidades = new System.Windows.Forms.OpenFileDialog();
            this.dlgTrens = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMapa
            // 
            this.pbMapa.BackgroundImage = global::Trem1.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.Image = global::Trem1.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.InitialImage = global::Trem1.Properties.Resources.mapaEspanhaPortugal;
            this.pbMapa.Location = new System.Drawing.Point(12, 194);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(718, 541);
            this.pbMapa.TabIndex = 0;
            this.pbMapa.TabStop = false;
            // 
            // cbbOrigem
            // 
            this.cbbOrigem.FormattingEnabled = true;
            this.cbbOrigem.Location = new System.Drawing.Point(11, 12);
            this.cbbOrigem.Name = "cbbOrigem";
            this.cbbOrigem.Size = new System.Drawing.Size(183, 37);
            this.cbbOrigem.TabIndex = 1;
            // 
            // cbbDestino
            // 
            this.cbbDestino.FormattingEnabled = true;
            this.cbbDestino.Location = new System.Drawing.Point(11, 142);
            this.cbbDestino.Name = "cbbDestino";
            this.cbbDestino.Size = new System.Drawing.Size(183, 37);
            this.cbbDestino.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(21, 66);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(161, 58);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBuscar_MouseDown);
            // 
            // lsbSaida
            // 
            this.lsbSaida.FormattingEnabled = true;
            this.lsbSaida.ItemHeight = 29;
            this.lsbSaida.Location = new System.Drawing.Point(229, 36);
            this.lsbSaida.Name = "lsbSaida";
            this.lsbSaida.Size = new System.Drawing.Size(1021, 149);
            this.lsbSaida.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Resultados:";
            // 
            // btnMaisCidade
            // 
            this.btnMaisCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaisCidade.Location = new System.Drawing.Point(736, 197);
            this.btnMaisCidade.Name = "btnMaisCidade";
            this.btnMaisCidade.Size = new System.Drawing.Size(173, 58);
            this.btnMaisCidade.TabIndex = 6;
            this.btnMaisCidade.Text = "+ Cidade";
            this.btnMaisCidade.UseVisualStyleBackColor = true;
            this.btnMaisCidade.Click += new System.EventHandler(this.btnMaisCidade_Click);
            // 
            // btnMenosCidade
            // 
            this.btnMenosCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenosCidade.Location = new System.Drawing.Point(736, 394);
            this.btnMenosCidade.Name = "btnMenosCidade";
            this.btnMenosCidade.Size = new System.Drawing.Size(173, 58);
            this.btnMenosCidade.TabIndex = 7;
            this.btnMenosCidade.Text = "- Cidade";
            this.btnMenosCidade.UseVisualStyleBackColor = true;
            this.btnMenosCidade.Click += new System.EventHandler(this.btnMenosCidade_Click);
            // 
            // btnMaisCaminho
            // 
            this.btnMaisCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaisCaminho.Location = new System.Drawing.Point(736, 606);
            this.btnMaisCaminho.Name = "btnMaisCaminho";
            this.btnMaisCaminho.Size = new System.Drawing.Size(173, 58);
            this.btnMaisCaminho.TabIndex = 8;
            this.btnMaisCaminho.Text = "+ Caminho";
            this.btnMaisCaminho.UseVisualStyleBackColor = true;
            this.btnMaisCaminho.Click += new System.EventHandler(this.btnMaisCaminho_Click);
            // 
            // txtManutencaoMaisCidade
            // 
            this.txtManutencaoMaisCidade.Location = new System.Drawing.Point(736, 290);
            this.txtManutencaoMaisCidade.Name = "txtManutencaoMaisCidade";
            this.txtManutencaoMaisCidade.Size = new System.Drawing.Size(514, 34);
            this.txtManutencaoMaisCidade.TabIndex = 9;
            // 
            // txtManutencaoMenosCidade
            // 
            this.txtManutencaoMenosCidade.Location = new System.Drawing.Point(737, 487);
            this.txtManutencaoMenosCidade.Name = "txtManutencaoMenosCidade";
            this.txtManutencaoMenosCidade.Size = new System.Drawing.Size(513, 34);
            this.txtManutencaoMenosCidade.TabIndex = 11;
            // 
            // txtManutencaoMaisCaminho
            // 
            this.txtManutencaoMaisCaminho.Location = new System.Drawing.Point(736, 699);
            this.txtManutencaoMaisCaminho.Name = "txtManutencaoMaisCaminho";
            this.txtManutencaoMaisCaminho.Size = new System.Drawing.Size(514, 34);
            this.txtManutencaoMaisCaminho.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(736, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(494, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "Informe os dados da cidade separados por hífens:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(737, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(452, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Informe o nome da cidade que deseja excluir:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(737, 667);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(513, 26);
            this.label4.TabIndex = 15;
            this.label4.Text = "Informe os dados do caminho separados por hífens:";
            // 
            // dlgCidades
            // 
            this.dlgCidades.InitialDirectory = "C:\\temp";
            this.dlgCidades.Title = "Selecione o arquivo de cidades:";
            // 
            // dlgTrens
            // 
            this.dlgTrens.InitialDirectory = "C:\\temp";
            this.dlgTrens.Title = "Selecione o arquivo de viagens:";
            // 
            // frmRotasTrem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 744);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManutencaoMaisCaminho);
            this.Controls.Add(this.txtManutencaoMenosCidade);
            this.Controls.Add(this.txtManutencaoMaisCidade);
            this.Controls.Add(this.btnMaisCaminho);
            this.Controls.Add(this.btnMenosCidade);
            this.Controls.Add(this.btnMaisCidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbSaida);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbbDestino);
            this.Controls.Add(this.cbbOrigem);
            this.Controls.Add(this.pbMapa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmRotasTrem";
            this.Text = "Formulário sobre rotas de trem -  Estrutura de Dados II";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRotasTrem_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.ComboBox cbbOrigem;
        private System.Windows.Forms.ComboBox cbbDestino;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lsbSaida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMaisCidade;
        private System.Windows.Forms.Button btnMenosCidade;
        private System.Windows.Forms.Button btnMaisCaminho;
        private System.Windows.Forms.TextBox txtManutencaoMaisCidade;
        private System.Windows.Forms.TextBox txtManutencaoMenosCidade;
        private System.Windows.Forms.TextBox txtManutencaoMaisCaminho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog dlgCidades;
        private System.Windows.Forms.OpenFileDialog dlgTrens;
    }
}

