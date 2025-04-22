namespace Agenda.UIDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblContatoNovo = new Label();
            txtContatoNovo = new TextBox();
            lblContatoSalvo = new Label();
            txtContatoSalvo = new TextBox();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // lblContatoNovo
            // 
            lblContatoNovo.AutoSize = true;
            lblContatoNovo.Location = new Point(29, 28);
            lblContatoNovo.Name = "lblContatoNovo";
            lblContatoNovo.Size = new Size(102, 20);
            lblContatoNovo.TabIndex = 0;
            lblContatoNovo.Text = "Contato Novo";
            // 
            // txtContatoNovo
            // 
            txtContatoNovo.Location = new Point(29, 51);
            txtContatoNovo.Name = "txtContatoNovo";
            txtContatoNovo.Size = new Size(363, 27);
            txtContatoNovo.TabIndex = 1;
            // 
            // lblContatoSalvo
            // 
            lblContatoSalvo.AutoSize = true;
            lblContatoSalvo.Location = new Point(29, 93);
            lblContatoSalvo.Name = "lblContatoSalvo";
            lblContatoSalvo.Size = new Size(102, 20);
            lblContatoSalvo.TabIndex = 2;
            lblContatoSalvo.Text = "Contato Salvo";
            // 
            // txtContatoSalvo
            // 
            txtContatoSalvo.Location = new Point(29, 125);
            txtContatoSalvo.Name = "txtContatoSalvo";
            txtContatoSalvo.Size = new Size(371, 27);
            txtContatoSalvo.TabIndex = 3;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(41, 191);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvar);
            Controls.Add(txtContatoSalvo);
            Controls.Add(lblContatoSalvo);
            Controls.Add(txtContatoNovo);
            Controls.Add(lblContatoNovo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblContatoNovo;
        private TextBox txtContatoNovo;
        private Label lblContatoSalvo;
        private TextBox txtContatoSalvo;
        private Button btnSalvar;
    }
}
