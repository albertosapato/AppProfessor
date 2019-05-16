namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using DevExpress.XtraEditors;
    using System;
    using System.Windows.Forms;
    public partial class frmRecovery : XtraForm
    {
        private bool mover;
        private int cX, cY;

        #region Instancias
        private static frmRecovery instancia;
        public static frmRecovery GetInstancia()
        {
            if (instancia == null)
                instancia = new frmRecovery();
            return instancia;
        }
        #endregion
        public frmRecovery()
        {
            InitializeComponent();

            this.btnClose.Click += delegate { this.Close();  };

            FormClosing += delegate {

                #region 
                DialogResult = DialogResult.OK;
                #endregion
            };
            btnCancelar.Click += delegate
            {
                if (MessageBox.Show("Tens a Certeza de que queres mesmo sair destes registos?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    this.Close();
            };

            txtUsuários.TextChanged += TxtUsuários_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;
            btnEntrar.Click += delegate { Entrar_Login(); };
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim().Equals(string.Empty))
                errorProvider1.SetError(txtPassword, "Este campo não permite valores nulos");
            else
                errorProvider1.Clear();
        }
        private void TxtUsuários_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuários.Text.Trim().Equals(string.Empty))
                errorProvider1.SetError(txtUsuários, "Este campo não permite valores nulos");
            else
                errorProvider1.Clear();
        }

        #region Mover formulátios
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - panel1.Left);
                this.Top += e.Y - (cY - panel1.Top);
            }
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }
        #endregion

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.Enter)
            {
                Entrar_Login();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion
        async void Entrar_Login()
        {
            if (Validar())
            {
                if (await UsuariosControllers.GetInstacia().Actualizar(txtUsuários.Text,
                                                                txtPassword.Text,
                                                                txtpassword_Nova.Text
                                                                ) > 0)
                {
                    MessageBox.Show("As suas credencias foram alteradas com Sucesso!... Tente fazer login!", "Mudar Password!...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtUsuários.Text = String.Empty;
                    txtPassword.Text = string.Empty;
                    txtpassword_Nova.Text = string.Empty;
                    txtpassowrd_Nova_.Text = string.Empty;

                    txtUsuários.Focus();
                }
                else
                    MessageBox.Show("Tentativa falhada!... Tente fazer login!", "Mudar Password!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var t = new frmRecoveryForce())
            {
                t.ShowDialog();
            }
        }

        bool Validar()
        {
            if (txtUsuários.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Este campo encontra-se vazio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtUsuários, "Usuário invalido");
                txtUsuários.Focus();
                return false;
            }
            else if (txtPassword.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Este campo encontra-se vazio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtPassword, "Password inválido");
                txtPassword.Focus();
                return false;
            }
            else if (txtpassowrd_Nova_.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Este campo encontra-se vazio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtpassowrd_Nova_, "Usuário invalido");
                txtpassowrd_Nova_.Focus();
                return false;
            }
            else if (txtpassword_Nova.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Este campo encontra-se vazio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtpassword_Nova, "Usuário invalido");
                txtpassword_Nova.Focus();
                return false;
            }
            else if (!txtpassword_Nova.Text.Trim().Equals(txtpassword_Nova.Text.Trim()))
            {
                MessageBox.Show("Os 2 campos não conscidem!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtpassword_Nova, "Usuário invalido");
                txtpassword_Nova.SelectAll();
                txtpassowrd_Nova_.SelectAll();
                txtpassword_Nova.Focus();
                return false;
            }
            else if (txtpassword_Nova.Text.Trim().Length <= 4)
            {
                MessageBox.Show("Desculpe não é permitido palavra passe com menos de 6 Caracter\n tente colocar uma com mais caracter!...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtpassword_Nova, "Usuário invalido");
                errorProvider1.SetError(txtpassowrd_Nova_, "Usuário invalido");
                txtpassword_Nova.SelectAll();
                txtpassowrd_Nova_.SelectAll();
                txtpassword_Nova.Focus();
                return false;
            }
            else
                return true;
        }
    }
}
