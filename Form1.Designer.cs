namespace memory
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblTentativas = new System.Windows.Forms.Label();
            this.txtPontos = new System.Windows.Forms.TextBox();
            this.btnModoNormal = new System.Windows.Forms.Button();
            this.btnModoDificil = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(492, 65);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(75, 23);
            this.btnReiniciar.TabIndex = 1;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(492, 123);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(128, 16);
            this.lblTempo.TabIndex = 1;
            this.lblTempo.Text = "Tempo Restante: 30";
            this.lblTempo.Click += new System.EventHandler(this.lblTempo_Click);
            // 
            // lblTentativas
            // 
            this.lblTentativas.AutoSize = true;
            this.lblTentativas.Location = new System.Drawing.Point(492, 161);
            this.lblTentativas.Name = "lblTentativas";
            this.lblTentativas.Size = new System.Drawing.Size(73, 16);
            this.lblTentativas.TabIndex = 2;
            this.lblTentativas.Text = "Tentativas:";
            this.lblTentativas.Click += new System.EventHandler(this.lblPontos_Click);
            // 
            // txtPontos
            // 
            this.txtPontos.Location = new System.Drawing.Point(573, 161);
            this.txtPontos.Name = "txtPontos";
            this.txtPontos.ReadOnly = true;
            this.txtPontos.Size = new System.Drawing.Size(100, 22);
            this.txtPontos.TabIndex = 3;
            this.txtPontos.TextChanged += new System.EventHandler(this.txtPontos_TextChanged);
            // 
            // btnModoNormal
            // 
            this.btnModoNormal.Location = new System.Drawing.Point(513, 241);
            this.btnModoNormal.Name = "btnModoNormal";
            this.btnModoNormal.Size = new System.Drawing.Size(114, 23);
            this.btnModoNormal.TabIndex = 1;
            this.btnModoNormal.Text = "Modo Normal";
            this.btnModoNormal.UseVisualStyleBackColor = true;
            this.btnModoNormal.Click += new System.EventHandler(this.btnModoNormal_Click);
            // 
            // btnModoDificil
            // 
            this.btnModoDificil.Location = new System.Drawing.Point(513, 284);
            this.btnModoDificil.Name = "btnModoDificil";
            this.btnModoDificil.Size = new System.Drawing.Size(114, 23);
            this.btnModoDificil.TabIndex = 1;
            this.btnModoDificil.Text = "Modo Dificil";
            this.btnModoDificil.UseVisualStyleBackColor = true;
            this.btnModoDificil.Click += new System.EventHandler(this.btnModoDificil_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.lblTempo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnModoDificil);
            this.Controls.Add(this.btnModoNormal);
            this.Controls.Add(this.txtPontos);
            this.Controls.Add(this.lblTentativas);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.btnReiniciar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblTentativas;
        private System.Windows.Forms.TextBox txtPontos;
        private System.Windows.Forms.Button btnModoNormal;
        private System.Windows.Forms.Button btnModoDificil;
        private System.Windows.Forms.Timer timer1;
    }
}

