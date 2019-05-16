namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using DataEntityFrameWork.Controllers.Helps;
    using DataEntityFrameWork.Models;
    using Desktop.Hels;
    using DevExpress.XtraEditors;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmUsuariosAdd : XtraForm
    {       
        #region Instancias
        public DateTime GetData { get { return DateTime.Now; } }
        #endregion

        #region Instancias
        private List<Usuarios> UsuariosInstaciaList { get; set; }
        private List<Grupos> GruposInstaciasList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                UsuariosInstaciaList = new List<Usuarios>();
                GruposInstaciasList = new List<Grupos>();

                UsuariosInstaciaList = (await FiltersAsync());

                GruposInstaciasList = (await Filters2Async());
                // Assinar Valores para o Binding
                gruposBindingSource.DataSource = GruposInstaciasList;
                Autocomplete(txtNomeCompleto, UsuariosInstaciaList.Select(x => x.UsuarioNomeCompleto).ToList());
            }
            catch (Exception exe)
            {
                      XtraMessageBox.Show("Sem conexão a internete\nOu sem ligação ao Servidor\n"
                      + exe.Message, "Conexão requerida",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }        
        }
        private async Task<List<Usuarios>> FiltersAsync()
        {
            return await UsuariosControllers.GetInstacia().GetList();
        }
        private async Task<List<Grupos>> Filters2Async()
        {
            return await GruposControllers.GetInstacia().GetList();
        }
        #endregion

        private Progress_Bar prog;
        private Usuarios item;

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPIN { get; set; }
        public bool isNew { get; private set; }

        public frmUsuariosAdd(string Titulim, int Select)
        {
            InitializeComponent();
            Inicializar(Titulim);
        }
        private void Inicializar(string Titulim)
        {
            Text = Titulim;
            txtNomeCompleto.TextChanged += TxtNomeCompleto_TextChanged;

            // Instacias Inicias
            prog = new Progress_Bar();
            this.FormClosing += new FormClosingEventHandler(FrmModelos_FormClosing);

            // Chamadas dos Botões
            btnNovo.Click += new EventHandler(BtnNovo_TextChangedAsync);
            btnGuardadr.Click += new EventHandler(BtnGuardadr_TextChanged);
            btnApagar.Click += new EventHandler(BtnApagar_Click);

            txtCodigo.TextChanged += new EventHandler(TxtCodigo_TextChanged);

            this.Load += frmModern__LoadAsync;

            brnRefresk.Click += delegate { Listar_Tudo(); };

            txtCodigo.ButtonClick += delegate
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    dataGridView1.Rows.Clear();

                    foreach (var item in UsuariosInstaciaList)
                        dataGridView1.Rows.Add(item.UsuariosId, item.UsuarioNomeCompleto);

                    flyoutPanel1.ShowBeakForm();
                    txtPesquisa_Flag.Focus();
                }
                catch (System.Exception exception)
                {
                    MessageBox.Show("Erro " + exception, "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };
            dataGridView1.MouseDoubleClick += delegate {
                if (dataGridView1.Rows.Count > 0)
                { txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); flyoutPanel1.HidePopup(); Edit(Convert.ToInt32(txtCodigo.Text), ""); };
            };
            txtPesquisa_Flag.TextChanged += TxtPesquisa_Flag_TextChanged;

            #region Validações Rapidas dos Campos
            txtGrupos.TextChanged += delegate { if (!txtGrupos.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtGrupos, "Atenção Este campo tem que ter valores"); };
            txtNomeCompleto.TextChanged += delegate { if (!txtNomeCompleto.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtNomeCompleto, "Atenção Este campo tem que ter valores"); };
            txtApelido.TextChanged += delegate { if (!txtApelido.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtApelido, "Atenção Este campo tem que ter valores"); };
            txtLogin.TextChanged += delegate { if (!txtLogin.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtLogin, "Atenção Este campo tem que ter valores"); };
            txtSenha.TextChanged += delegate { if (!txtSenha.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtSenha, "Atenção Este campo tem que ter valores"); };
            txtRepetir_Senha.TextChanged += delegate { if (!txtRepetir_Senha.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtRepetir_Senha, "Atenção Este campo tem que ter valores"); };
            txtPIN.TextChanged += delegate { if (!txtPIN.Text.Equals(string.Empty)) { errorProvider1.Clear(); } else errorProvider1.SetError(txtPIN, "Atenção Este campo tem que ter valores"); };
            #endregion

            //txtSenha.Validating += delegate {
            //    OnValidatePassword(new object(),
            //                       new ValidatePasswordEventArgs("", txtSenha.Text, true));
            //};
            txtEmail.Validating += TxtEmail_Validating;


            // Validações dos Valores da PAssword 1
            txtSenha.GotFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword)) isNew = true;
                else txtSenha.Text = string.Empty;
            };

            txtSenha.LostFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword)) return;
                else if (!string.IsNullOrWhiteSpace(UserPassword) && string.IsNullOrWhiteSpace(txtSenha.Text)) { txtSenha.Text = UserPassword; isNew = false; }
                else
                    isNew = true;
            };

            // Validações dos Valores da PAssword 2
            txtRepetir_Senha.GotFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword)) isNew = true;
                else txtRepetir_Senha.Text = string.Empty;
            };

            txtRepetir_Senha.LostFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword)) return;
                else if (!string.IsNullOrWhiteSpace(UserPassword) && string.IsNullOrWhiteSpace(txtRepetir_Senha.Text))
                { txtRepetir_Senha.Text = UserPassword; isNew = false; }
                else
                    isNew = true;
            };

            // Validações dos Valores da PIN
            txtPIN.GotFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword)) isNew = true;
                else txtPIN.Text = string.Empty;
            };

            txtPIN.LostFocus += delegate {
                if (string.IsNullOrWhiteSpace(UserPassword))
                    return;
                else if (!string.IsNullOrWhiteSpace(UserPassword) && string.IsNullOrWhiteSpace(txtPIN.Text))
                { txtPIN.Text = UserPassword; isNew = false; }
                else
                    isNew = true;
            };
            txtPIN.TextChanged += delegate
            {
                #region Validar
                //string actualdata = string.Empty;
                //char[] entereddata = txtPIN.Text.ToCharArray();

                //foreach (char aChar in entereddata.AsEnumerable())
                //{
                //    if (Char.IsDigit(aChar))
                //    {
                //        actualdata = actualdata + aChar;
                //        // MessageBox.Show(aChar.ToString());
                //    }
                //    else
                //    {
                //        MessageBox.Show(aChar + " is not numeric");
                //        actualdata.Replace(aChar, ' ');
                //        actualdata.Trim();
                //    }
                //}
                //txtPIN.Text = actualdata; 
                #endregion
            };
            txtPIN.KeyPress += (sender, e) =>
            {
                #region Validar
                // Text
                string text = ((Control)sender).Text;

                // Is Negative Number?
                if (e.KeyChar == '-' && text.Length == 0)
                {
                    e.Handled = false;
                    return;
                }
                // Is Float Number?
                if (e.KeyChar == '.' && text.Length > 0 && !text.Contains("."))
                {
                    e.Handled = false;
                    return;
                }
                // Is Digit?
                e.Handled = (!char.IsDigit(e.KeyChar));
                #endregion
            };

            txtPIN.Validating += (sender, e) =>
            {
                var t = Encriptar.GetMD5Hash(txtEmail.Text);
                var result = UsuariosInstaciaList.Where(x => x.Pin == t && x.GrupoId == (int)txtGrupos.EditValue)
                                                 .FirstOrDefault();
                if (result != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtCodigo.Text) || !txtCodigo.Text.Equals("0"))
                    {
                        if (result.UsuariosId != int.Parse(txtCodigo.Text))
                        {
                            XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "PIN Indisponivel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "PIN Indisponivel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEmail.Focus();
                    }
                }
            };
            txtNomeCompleto.KeyDown += TxtNomeCompleto_KeyDown1;
            ListGeral();
        }

        public frmUsuariosAdd(Usuarios item)
        {
            InitializeComponent();
            Inicializar("Pagina: Usuários");
            this.item = item;

            if (item != null)
            {
                txtCodigo.Text = item.UsuariosId.ToString();
                txtNomeCompleto.Text = item.UsuarioNomeCompleto.ToString();
                txtApelido.Text = item.Apelido.ToString();
                txtSenha.Text = item.Senha.ToString();
                txtRepetir_Senha.Text = item.Senha.ToString();
                txtPIN.Text = item.Pin.ToString();
                txtEmail.Text = item.Email.ToString();
                checkEdit1.Checked = item.Estado;
                dateEdit1.DateTime = item.DataNascimento.Date;

                txtGrupos.EditValue = item.GrupoId;
                txtLogin.Text = item.Login;

                if (item.Perfil != null)
                    ImagemPictureEdit.Image = (Image) ImagemTratamento.byteArrayToImage(item.Perfil);
            }
        }

        private void TxtNomeCompleto_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoaderUsuarios(txtNomeCompleto.Text.ToLower());
        }
        private void LoaderUsuarios(string v1)
        {
            Edit(0,txtNomeCompleto.Text);
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                if (!EmailValidade.GetIstance().IsValidEmail(txtEmail.Text.Trim()))
                {
                    XtraMessageBox.Show("Email Inválido coloque um email válido", "Email Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
                else
                {
                    var result = UsuariosInstaciaList.Where(x => x.Email.ToLower() == txtEmail.Text.ToLower()).FirstOrDefault();
                    if (result != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtCodigo.Text) || txtCodigo.Text.Equals(0))
                        {
                            XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "E-Mail Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                        }
                        else
                        {
                            if (result.UsuariosId != int.Parse(txtCodigo.Text))
                            {
                                XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "E-Mail Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void TxtNomeCompleto_TextChanged(object sender, EventArgs e)
        {
            string fullName = txtNomeCompleto.Text;
            string[] names = fullName.Split(' ');
            txtApelido.Text = names.Last();
            txtLogin.Text = names.First();
        }
        //public void OnValidatePassword(object sender,
        //                      ValidatePasswordEventArgs args)
        //{
        //    System.Text.RegularExpressions.Regex r =
        //      new System.Text.RegularExpressions.Regex(@"(?=.{4,})(?=(.*\d){1,})(?=(.*\W){1,})");

        //    if (!r.IsMatch(args.Password))
        //    {
        //        args.FailureInformation =
        //          new System.Exception("Levamos a sua segurança muito a sério \nA senha tem que ter pelo menos 4 Caracteres!..." +
        //                               "Para a sua Segurança tens que colocar uma senha que tenha mais ou menos letras Maiusculas e Minusculas\n" +
        //                               "E Associado a um Número.");
        //        args.Cancel = true;
        //    }
        //}
        private void TxtPesquisa_Flag_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPesquisa_Flag.Enabled = false;
                procura(sender);
            }
            finally
            {
                txtPesquisa_Flag.Enabled = true;
                txtPesquisa_Flag.Focus();
            }
        }

        private void FrmModelos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!txtNomeCompleto.Text.Trim().Equals(string.Empty) || !txtLogin.Text.Trim().Equals(string.Empty))
            {
                if (XtraMessageBox.Show("Tens a certeza de que pretendes sair do formulário?", "Sair do formulário", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    e.Cancel = true;
                else
                    this.DialogResult = DialogResult.OK;
            }
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                if (btnNovo.Enabled == true)
                {
                    Novo_Registro_Async();
                }
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }

            if (keyData == Keys.F2)
            {
                if (btnGuardadr.Enabled == true)
                {
                    BtnGuardadr_TextChanged(new object(), new EventArgs());
                }
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;

            }

            if (keyData == Keys.F3)
            {
                if (btnApagar.Enabled == true)
                {
                    Apagar_Registro();
                }
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F5)
            {
                Listar_Tudo();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        void Listar_Tudo()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ListGeral();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString(), "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void frmModern__LoadAsync(object sender, EventArgs e)
        {
            Listar_Tudo();
        }
   
        private void BtnApagar_Click(object sender, EventArgs e)
        {
            Apagar_Registro();
        }
        private void BtnGuardadr_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
                Guardar_Registro();
            else
                Atualizar_RegistroAsync();
        }
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            Activar();
        }

        #region Activar e Desativar()
        void Activar()
        {
            if (txtCodigo.Text.Trim().Equals(string.Empty))
            {
                this.btnNovo.Enabled = true;
                this.btnGuardadr.Enabled = true;
                btnGuardadr.Text = "Guardar";
                this.btnApagar.Enabled = false;
            }
            else
            {
                this.btnNovo.Enabled = true;
                this.btnGuardadr.Enabled = true;
                btnGuardadr.Text = "Atualizar";
                this.btnApagar.Enabled = true;
            }
        }

        #endregion

        bool Validar1(int Metodo1ou2)
        {
            if (txtGrupos.Text.Equals("[Por Favor selecione o seu grupo por favor!...]"))
            {
                XtraMessageBox.Show("Selecione o grupo  aque vai pertencer este Usuário!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtGrupos, "Grupo invalido");
                txtGrupos.ShowPopup();
                txtGrupos.Focus();
                return false;
            }
            if (txtNomeCompleto.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Digite o nome do Usuário por favor!... \npreencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtNomeCompleto, "Usuário invalido");
                txtNomeCompleto.Focus();
                return false;
            }
            else if (txtSenha.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Digite a senha do usuário por favor!... \npreencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSenha, "Password inválido");
                txtSenha.Focus();
                return false;
            }
            else if (txtRepetir_Senha.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Pepita a senha por favor!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtRepetir_Senha, "Senha invalido");
                txtRepetir_Senha.Focus();
                return false;
            }
            else if (txtPIN.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Digite o pin Por favor!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtPIN, "PIN invalido");
                txtPIN.Focus();
                return false;
            }
            else if (txtSenha.Text.Trim().Length <= 4)
            {
                XtraMessageBox.Show("Desculpe não é permitido palavra passe com menos de 6 Caracter\n tente colocar uma com mais caracter!...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSenha, "Senha invalido");
                errorProvider1.SetError(txtRepetir_Senha, "Senha invalido");
                txtRepetir_Senha.SelectAll();
                txtSenha.SelectAll();
                txtSenha.Focus();
                return false;
            }
            else if (txtPIN.Text.Length < 0)
            {
                XtraMessageBox.Show("Desculpe mais não permitimos pin com menos de 2 Caracter", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtPIN, "PIN invalido");
                txtPIN.SelectAll();
                txtPIN.Focus();
                return false;
            }
            else if (!txtSenha.Text.Trim().Equals(txtRepetir_Senha.Text))
            {
                XtraMessageBox.Show("Desculpe mais os 2 Campos da senha não Conscidem \n tente colocar senhas iguas para os 2 Campos!...", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtSenha, "Senha invalido");
                errorProvider1.SetError(txtRepetir_Senha, "Senha invalido");
                txtRepetir_Senha.SelectAll();
                txtSenha.SelectAll();
                txtSenha.Focus();
                return false;
            }
            #region Validação 2
            // Validar Email
            var result = UsuariosInstaciaList.ToList();

            if (!EmailValidade.GetIstance().IsValidEmail(txtEmail.Text.Trim()))
            {
                XtraMessageBox.Show("Email Inválido coloque um email válido", "Erro de Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.SelectAll();
                txtEmail.Focus();
                return false;
            }
            else
            {
                if (Metodo1ou2 == 1)
                {
                    var result12 = result.Where(x => x.Email == txtEmail.Text).FirstOrDefault();

                    if (result12 != null)
                    {
                        if (!string.IsNullOrWhiteSpace(txtCodigo.Text) || !txtCodigo.Text.Equals("0"))
                        {
                            if (result12.UsuariosId != int.Parse(txtCodigo.Text))
                            {
                                XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "Erro de Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Lamentamos mais este E-Mail já Existe no Sistema", "Erro de Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                            return false;
                        }
                    }
                    // Pin
                    var t = Encriptar.GetMD5Hash(txtPIN.Text.Trim());
                    var result1 = result.Where(x => x.Pin == t && x.GrupoId == (int)(txtGrupos.EditValue as Grupos).GrupoId).FirstOrDefault();
                    if (result1 != null)
                    {
                        if (!string.IsNullOrWhiteSpace(txtCodigo.Text) || !txtCodigo.Text.Equals("0"))
                        {
                            if (result1.UsuariosId != int.Parse(txtCodigo.Text))
                            {
                                XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "Erro de PIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "Erro de PIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                            return false;
                        }
                    }
                }
                else
                {
                    // Pin
                    var t = Encriptar.GetMD5Hash(txtPIN.Text);
                    var result1 = result.Where(x => x.Pin == t && x.GrupoId == (int)(txtGrupos.EditValue as Grupos).GrupoId).FirstOrDefault();

                    if (result.Where(x => x.Pin == t && x.GrupoId == (int)(txtGrupos.EditValue as Grupos).GrupoId).Count() > 1)
                    {
                        if (!string.IsNullOrWhiteSpace(txtCodigo.Text) || !txtCodigo.Text.Equals("0"))
                        {
                            if (result1.UsuariosId != int.Parse(txtCodigo.Text))
                            {
                                XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "Erro de PIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Lamentamos mais este PIN Esta Indisponivel!...", "Erro de PIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEmail.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
            #endregion
        }

        #region Limpar Campos
        private void BtnNovo_TextChangedAsync(object sender, EventArgs e)
        {
            Novo_Registro_Async();
        }
        #region Novo Campo
        private void Novo_Registro_Async()
        {
            limpar_Campos();
        }

        #region Limpar Alguns Campos
        private void limpar_Campos()
        {
            txtCodigo.Text = string.Empty;
            txtNomeCompleto.Text = string.Empty;
            txtApelido.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtPIN.Text = string.Empty;
            dateEdit1.EditValue = DateTime.Now;
            txtEmail.Text = string.Empty;
            txtRepetir_Senha.Text = string.Empty;

            isNew = true;
            UserPassword = string.Empty;
            UserPIN = string.Empty;

            ImagemPictureEdit.Image = null;

            errorProvider1.Clear();
            txtNomeCompleto.Focus();
        }
        #endregion

        #endregion

        #endregion

        private async void Guardar_Registro()
        {
            try
            {
                if (Validar1(1))
                {
                    Cursor = Cursors.WaitCursor;

                    if (!(GetExistingData() > 0))
                    {
                        var curs = new Usuarios
                        {
                            //CursosTypoNome = txtNome.Text == null ? "" : "",
                            UsuarioNomeCompleto = txtNomeCompleto.Text,
                            Apelido = txtApelido.Text,
                            Login = txtLogin.Text,
                            Senha = Encriptar.GetMD5Hash(txtSenha.Text),
                            DataNascimento = Convert.ToDateTime(dateEdit1.EditValue),
                            Email = txtEmail.Text.Trim(),
                            Pin = Encriptar.GetMD5Hash(txtPIN.Text),
                            Estado = (bool)checkEdit1.EditValue,
                            GrupoId = Convert.ToInt32(txtGrupos.EditValue),
                            Perfil = (byte[])ImagemTratamento.ImageToByteArray(ImagemPictureEdit.Image)
                        };
                        if ((await UsuariosControllers.GetInstacia().Insert(curs)).IsSucess)
                        {
                            XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListGeral();
                            limpar_Campos();
                        }
                        else
                        {
                            XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lamentamos mais já existe este login no Sistema\n Não pode existir PIN ou login com o mesmo acesso", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception exception)
            {
                MessageBox.Show("Erro " + exception, "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private async void Atualizar_RegistroAsync()
        {
            try
            {
                if (Validar1(2))
                {
                    Cursor = Cursors.WaitCursor;

                    if (!(GetExistingData() > 1))
                    {
                        if (MessageBox.Show("Estas preste a alterar o valor do (" + txtNomeCompleto.Text + ")! pretendes continuar?", "Alteração de dados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            string Pass1;
                            string Pass2;

                            if (isNew)
                            {
                                Pass1 = Encriptar.GetMD5Hash(txtSenha.Text);
                                Pass2 = Encriptar.GetMD5Hash(txtPIN.Text);
                            }
                            else
                            {
                                Pass1 = txtSenha.Text;
                                Pass2 = txtPIN.Text;
                            }

                            var cursos = new Usuarios
                            {
                                UsuariosId = Convert.ToInt32(txtCodigo.Text),
                                UsuarioNomeCompleto = txtNomeCompleto.Text,
                                Apelido = txtApelido.Text,
                                Login = txtLogin.Text,
                                Senha = Pass1,
                                DataNascimento = Convert.ToDateTime(dateEdit1.EditValue),
                                Email = txtEmail.Text,
                                Pin = Pass2,
                                Estado = (bool)checkEdit1.EditValue,
                                GrupoId = Convert.ToInt32(txtGrupos.EditValue),
                                Perfil = (byte[])ImagemTratamento.ImageToByteArray(ImagemPictureEdit.Image)
                            };
                            if ((await UsuariosControllers.GetInstacia().Update(cursos)).IsSucess)
                            {
                                XtraMessageBox.Show("Serviço Atualizado com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ListGeral();
                                limpar_Campos();
                            }
                            else
                                XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Lamentamos mais já existe este login no Sistema\n Não pode existir PIN ou login com o mesmo acesso", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception exe)
            {
                XtraMessageBox.Show(exe.Message, "Arro de Actualização", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private async void Apagar_Registro()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (!txtCodigo.Text.Equals(string.Empty))
                {
                    if (XtraMessageBox.Show("Estas preste a apagar o (" + txtNomeCompleto.Text + ")! pretendes continuar?", "Alteração de dados", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        var cursos = new Usuarios
                        {
                            UsuariosId = Convert.ToInt32(txtCodigo.Text),
                            UsuarioNomeCompleto = txtNomeCompleto.Text,
                            Apelido = txtApelido.Text,
                            Login = txtLogin.Text,
                            Senha = txtSenha.Text,
                            DataNascimento = Convert.ToDateTime(dateEdit1.EditValue),
                            Email = txtEmail.Text,
                            Pin = txtPIN.Text,
                            Estado = (bool)checkEdit1.EditValue,
                            GrupoId = Convert.ToInt32(txtGrupos.EditValue)
                        };

                        if ((await UsuariosControllers.GetInstacia().Delete(cursos)).IsSucess)
                        {
                            XtraMessageBox.Show("Serviço Apagado com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListGeral();
                            limpar_Campos();
                        }
                        else
                            XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message, "Erro de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void Edit(int I, string user)
        {
            try
            {
                prog.Mostrar(this, "Aguarde!...", "Aguarde");

                var item = UsuariosInstaciaList.Where(x => x.UsuariosId == I ||
                                                           x.UsuarioNomeCompleto.ToLower() == user.ToLower()).FirstOrDefault();

                if (item != null)
                {
                    txtCodigo.Text = item.UsuariosId.ToString();
                    txtNomeCompleto.Text = item.UsuarioNomeCompleto;
                    txtApelido.Text = item.Apelido;
                    txtLogin.Text = item.Login;
                    txtSenha.Text = item.Senha;
                    txtRepetir_Senha.Text = item.Senha;
                    dateEdit1.EditValue = item.DataNascimento;
                    txtEmail.Text = item.Email;
                    txtPIN.Text = item.Pin;
                    checkEdit1.EditValue = item.Estado;
                    txtGrupos.EditValue = item.GrupoId;

                    UserPassword = item.Senha;
                    UserPIN = item.Pin;

                    var ImagemProd = item.Perfil;
                    if (ImagemProd != null)
                    {
                        ImagemPictureEdit.Image = (Image)ImagemTratamento.byteArrayToImage(item.Perfil);
                        ImagemProd = null;
                    }
                    else
                        ImagemPictureEdit.Image = null;
                }
                txtNomeCompleto.Focus();
            }
            catch (System.Exception exe)
            {
                MessageBox.Show("Erro ao passar Dados" + exe.Message, "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                prog.Mostrar_Close(this);
                txtNomeCompleto.Focus();
            }
        }
        public void procura(object sender)
        {
            var termo = (sender as TextEdit).Text.ToLowerInvariant();
            bool SemTernmo = string.IsNullOrWhiteSpace(termo);

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((item.Cells[Column2.Index].Value as string).ToLowerInvariant().Contains(txtPesquisa_Flag.Text) || SemTernmo)
                    item.Visible = true;
                else
                    item.Visible = false;
            }
        }

        void Autocomplete(TextEdit edit, List<string> listF)
        {
            if (listF.Count == 0)
                return;
            else
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                foreach (var item in listF)
                {
                    collection.Add(item);
                }
                edit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                edit.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                edit.MaskBox.AutoCompleteCustomSource = collection;
            }
        }
        private int GetExistingData()
        {
            return UsuariosInstaciaList.Where(x => (x.Login == txtLogin.Text && x.Senha == txtSenha.Text) || x.Pin == txtPIN.Text).Count();
        }
    }
}
