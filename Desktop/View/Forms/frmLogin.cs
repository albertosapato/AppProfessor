namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using Desktop.Hels;
    using Desktop.Hels.Settings;
    using DevExpress.XtraEditors;
    using System;
    using System.Windows.Forms;

    public partial class frmLogin : XtraForm
    {
        private bool mover;
        private int cX, cY;

        #region Instancias
        private static frmLogin instancia;
        public static frmLogin GetInstancia()
        {
            if (instancia == null)
                instancia = new frmLogin();
            return instancia;
        }
        #endregion
        public frmLogin()
        {
            InitializeComponent();

            ArredondarFormas.BordasCurvas(btnCancelar);
            ArredondarFormas.BordasCurvas(btnEntrar);

            #region Inicar Relogio
            this.CenterToScreen();

            #endregion

            this.btnClose.Click += BtnClose_Click;
            this.FormClosing += FrmLogin_FormClosing;

            btnCancelar.Click += delegate
            {
                txtPassword.Text = string.Empty;
                txtUsuários.Text = string.Empty;
                txtUsuários.Focus();
            };

            txtUsuários.TextChanged += TxtUsuários_TextChanged;
            txtPassword.TextChanged += TxtPassword_TextChanged;

            txtPassword.ButtonClick += BtnVer_Click;

            btnMudar_Password.Click += BtnMudar_Password_Click;

            Load += delegate
            {
                if (ObjectoLogin.Default.Estado)
                {
                    toggleSwitch1.EditValue = (bool)ObjectoLogin.Default.Estado;
                    txtUsuários.Text = ObjectoLogin.Default.Nome;
                    txtPassword.Text = ObjectoLogin.Default.Senha;
                    btnEntrar.Focus();
                }
            };
            btnEntrar.Click += delegate
            {
                Entrar_Login();
            };
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ObjectoLogin.Default.Estado = (bool)toggleSwitch1.EditValue;
                ObjectoLogin.Default.Save();
            }
            catch (System.Exception)
            {
                return;
            }
        }
        private void BtnMudar_Password_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var f = new frmRecovery())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    this.Visible = true;
            }
        }
        private void BtnVer_Click(object sender, EventArgs e)
        {
            if (txtPassword.Properties.UseSystemPasswordChar == true)
                txtPassword.Properties.UseSystemPasswordChar = false;
            else
                txtPassword.Properties.UseSystemPasswordChar = true;
        }
        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim().Equals(string.Empty))
                errorProvider1.SetError(txtPassword, 
                    "Este campo não permite valores nulos");
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
                this.Left += e.X - (cX - panelControl1.Left);
                this.Top += e.Y - (cY - panelControl1.Top);
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
                BtnClose_Click(new object(), new EventArgs());
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                txtPassword.Text = string.Empty;
                txtUsuários.Text = string.Empty;
                txtUsuários.Focus();

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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Tens a Certeza de que queres mesmo sair destes registos?", 
                                    "Confirmação", MessageBoxButtons.OKCancel, 
                                                   MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }
        bool Validar()
        {
            if (!string.IsNullOrWhiteSpace(txtUsuários.Text) 
                             && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtUsuários.Text)
                             && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtUsuários.Focus();
                return false;
            }
            else
                return true;
        }
        async void Entrar_Login()
        {
            if (Validar())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    btnEntrar.Enabled = false;
                    btnCancelar.Enabled = false;
                    try
                    {
                        var instancia = LoginControllers.GetInstancia();
                        switch (await instancia.GetLogin(txtUsuários.Text, txtPassword.Text))
                        {
                            case 0:
                                if (XtraMessageBox.Show("Notamos que não existe ainda nenhum usuário Associado à filiar configurada cadastrado no sistema pretendes fazelo agora? ", "inexistencia de Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                {
                                    try
                                    {
                                        Cursor = Cursors.WaitCursor;

                                        using (var usuarios = new frmInicialWizardForm())
                                        {
                                            usuarios.ShowDialog();
                                            usuarios.FormClosing += (sender, args) =>
                                            {
                                                if (MessageBox.Show("Ok Tudo Configurado!... Pretendes Tentar entrar Já no Sistema?", "Entrada Automática", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                                                    Entrar_Login();
                                            };
                                        }
                                    }
                                    finally
                                    {
                                        Cursor = Cursors.Default;
                                    }
                                }
                                break;
                            case 1:
                                XtraMessageBox.Show("Erro de Login\nPor favor remeta as suas Credências\nErro Referênte a [(Usuário ou senha incorrecta)]\n(-_-)", "Erro de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPassword.SelectAll();
                                txtPassword.Focus();
                                break;
                            case 2:
                                XtraMessageBox.Show("Usuário Desativado pelo Usuário Principal\nResolução: Por favor contacte o seu Usuário principal para voltar a activar(Abilitar) o seu estado!...", "Estado Desativado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.SelectAll();
                                txtPassword.Focus();
                                break;
                            default:
                                Aplicar_Permissoes(instancia.IDGrupos, txtUsuários.Text);
                                break;
                        }
                    }
                    catch (Exception exe)
                    {
                        //await Erros(this.Text, exe.ToString(), "Entrar em Login");
                        XtraMessageBox.Show(exe.ToString(),
                                           "(Erro do Banco)!...",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                    }
                }
                finally
                {
                    btnEntrar.Enabled = true;
                    btnCancelar.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }
        private async void Aplicar_Permissoes(int iDGrupos, string userName)
        {
            #region Colocar e se lembrar de um usuário Especifico
            if (toggleSwitch1.IsOn)
            {
                ObjectoLogin.Default.Nome = txtUsuários.Text;
                ObjectoLogin.Default.Senha = txtPassword.Text;
                ObjectoLogin.Default.Estado = true;
            }
            else
            {
                ObjectoLogin.Default.Nome = string.Empty;
                ObjectoLogin.Default.Senha = string.Empty;
                ObjectoLogin.Default.Estado = false;
            }
            #endregion

            ObjectoLogin.Default.Save();

            Program.GrupoID = iDGrupos;
            Program.UserName = userName;
            var T = (await PermissoesPermissaoControllers.GetInstacia().GetList(iDGrupos));

            if (T != null)
            {
                this.Hide();
                var modulos = new frmMenu(T);
                modulos.Show();
                modulos.FormClosing += (sender, e) => { this.Visible = true;};
            }
            else
            {
                XtraMessageBox.Show("Lamentamos mais não existem permissões associados a este Usuário por favor tente coloca-lo agora\nContacte o Adminstrador do Sistema!...", "Permissões Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var f = new frmInicialWizardForm())
                {
                    f.ShowDialog();
                }
            }
        }
    }
}
