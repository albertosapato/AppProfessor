namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using DataEntityFrameWork.Models;
    using Desktop.Hels;
    using DevExpress.XtraEditors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmUsuariosPermissoes : XtraForm
    {
        #region Instancias
        public List<Permissoes> InstaciaList { get; set; }
        public List<Grupos> GruposInstaciaList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                InstaciaList = new List<Permissoes>();
                GruposInstaciaList = new List<Grupos>();
                InstaciaList = (await ClientesFiltersAsync())
                                                         .ToList();

                GruposInstaciaList = (await Clientes2FiltersAsync())
                                                         .ToList();

                gruposViewModelsBindingSource.DataSource = GruposInstaciaList.ToList();
                permissoesViewModelsBindingSource.DataSource = InstaciaList.ToList();
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
        private async Task<List<Permissoes>> ClientesFiltersAsync()
        {
            return await PermissoesPermissaoControllers.GetInstacia().GetList();
        }
        private async Task<List<Grupos>> Clientes2FiltersAsync()
        {
            return await GruposControllers.GetInstacia().GetList();
        }
        #endregion

        #region Instancias
        public DateTime GetData { get { return DateTime.Now; } }

        #region Singliton
        private static frmUsuariosPermissoes _Instacia;
        public static frmUsuariosPermissoes Instacia
        {
            get
            {
                if (_Instacia == null)
                    return new frmUsuariosPermissoes();
                return _Instacia;
            }
        }
        #endregion

        #endregion

        public bool t = true;
        private Progress_Bar prog;

        public frmUsuariosPermissoes()
        {
            InitializeComponent();

            // Instacias Inicias
            prog = new Progress_Bar();

            // Chamadas dos Botões
            btnNovo.Click += new EventHandler(BtnNovo_TextChangedAsync);
            btnGuardadr.Click += new EventHandler(BtnGuardadr_TextChanged);
            btnApagar.Click += new EventHandler(BtnApagar_Click);

            PermissoesIdTextEdit.TextChanged += new EventHandler(TxtCodigo_TextChanged);
            brnRefresk.Click += delegate { ListGeral(); };

            #region Validações Rapidas dos Campos
            PermissoesIdTextEdit.TextChanged += delegate { if (!PermissoesIdTextEdit.Text.Equals("Selecione o Grupo de Administrador a que pertence!...")) { errorProvider1.Clear();  } else errorProvider1.SetError(PermissoesIdTextEdit, "Atenção Este campo tem que ter valores"); };
            #endregion

            ListGeral();
            dataLayoutControl1.Changed += DataLayoutControl1_Changed;
            btnNovos.Click += BtnNovos_Click;
        }
        private void BtnNovos_Click(object sender, System.EventArgs e)
        {
            permissoesViewModelsBindingSource.AddNew();
        }
        private void DataLayoutControl1_Changed(object sender, EventArgs e)
        {
            #region Leitura do Layer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    dataLayoutControl1.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName));
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        private void FrmUsuariosPermissoes_Load(object sender, EventArgs e)
        {
            #region LoaderLayer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    var file = f.Loader(this.Name + Program.ProgramName);
                    if (!string.IsNullOrWhiteSpace(file))
                        dataLayoutControl1.RestoreLayoutFromXml(file);
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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
                ListGeral();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            Apagar_Registro();
        }
        private void BtnGuardadr_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PermissoesIdTextEdit.Text) || PermissoesIdTextEdit.Text.Equals("0"))
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
            if ((PermissoesIdTextEdit.Text.Trim().Equals(string.Empty)) || (PermissoesIdTextEdit.Text.Trim().Equals("0")))
            {
                this.btnNovo.Enabled = true;
                this.btnGuardadr.Enabled = true;
                btnGuardadr.Text = "Guardar";
                this.btnApagar.Enabled = false;
                this.btnReport.Enabled = false;
                GrupoIdLookUpEdit.Enabled = true;
            }
            else
            {
                this.btnNovo.Enabled = true;
                this.btnGuardadr.Enabled = true;
                btnGuardadr.Text = "Atualizar";
                this.btnApagar.Enabled = true;
                this.btnReport.Enabled = true;
                GrupoIdLookUpEdit.Enabled = false;
            }
        }
        #endregion

        bool Validar1()
        {       

            if (GrupoIdLookUpEdit.EditValue == null)
            {
                XtraMessageBox.Show("Este campo encontra-se vazio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(GrupoIdLookUpEdit, "Grupo invalido");
                GrupoIdLookUpEdit.ShowPopup();
                GrupoIdLookUpEdit.Focus();

                return false;
            }

            else
                return true;
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
            this.PermissoesIdTextEdit.Text = string.Empty;
            permissoesViewModelsBindingSource.AddNew();
            PermissoesIdTextEdit.Focus();
        }
        #endregion
        #endregion
        #endregion

        private async void Guardar_Registro()
        {
            try
            {
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;

                    if (!(ExistingData(Convert.ToInt32(GrupoIdLookUpEdit.EditValue)) > 0))
                    {
                        var curs = new Permissoes
                        {
                            Adicionar = (bool)AdicionarCheckEdit.EditValue,
                            Guardar = (bool)GuardarCheckEdit.EditValue,
                            Atualizar = (bool)AtualizarCheckEdit.EditValue,
                            Apagar = (bool)ApagarCheckEdit.EditValue,
                            Descontos = (bool)DescontosCheckEdit.EditValue,
                            Dividas = (bool)DividasCheckEdit.EditValue,
                            Relatorios = (bool)RelatoriosCheckEdit.EditValue,
                            Definicoes = (bool)DefinicoesCheckEdit.EditValue,                   
                            Backup = (bool)BackupCheckEdit.EditValue,               
                            Graficos = (bool)GraficosCheckEdit.EditValue,
                            Grupos = (bool)GruposCheckEdit.EditValue,
                            GruposAdicionar = (bool)GruposAdicionarCheckEdit.EditValue,
                            GruposConsultar = (bool)GruposConsultarCheckEdit.EditValue,

                            // Usuarios
                            Usuarios = (bool)UsuariosCheckEdit.EditValue,
                            UsuariosAdicionar = (bool)UsuariosAdicionarCheckEdit.EditValue,
                            UsuariosConsultar = (bool)UsuariosConsultarCheckEdit.EditValue,

                            // Sistemas
                            ErrosLogs = (bool)ErrosLogsCheckEdit.EditValue,
                            ErrosLogsReport = (bool)ErrosLogsReportCheckEdit.EditValue,

                            GrupoId = (int)GrupoIdLookUpEdit.EditValue,
                            Consultas = (bool)ConsultasCheckEdit.EditValue,
                            Promocoes = (bool)PromocoesCheckEdit.EditValue,

                            // Modulos
                            ModuloGeral = (bool)ModuloGeralCheckEdit.EditValue,
                            
                        };
                        if ((await PermissoesPermissaoControllers.GetInstacia().Insert(curs)).IsSucess)
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
                        XtraMessageBox.Show("Lamentamos mais já foi registado um uma permissão com este GRUPO tente alterar o grupo por favor", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;

                    if (!(ExistingData(Convert.ToInt32(GrupoIdLookUpEdit.EditValue)) > 1))
                    {
                        if (XtraMessageBox.Show("Estas preste a alterar o valor do (" + GrupoIdLookUpEdit.Text + ")! pretendes continuar?", "Alteração de dados", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            var curs = new Permissoes
                            {
                                PermissoesId = (int)PermissoesIdTextEdit.EditValue,
                                Adicionar = (bool)AdicionarCheckEdit.EditValue,
                                Guardar = (bool)GuardarCheckEdit.EditValue,
                                Atualizar = (bool)AtualizarCheckEdit.EditValue,
                                Apagar = (bool)ApagarCheckEdit.EditValue,
                                Descontos = (bool)DescontosCheckEdit.EditValue,
                                Dividas = (bool)DividasCheckEdit.EditValue,
                                Relatorios = (bool)RelatoriosCheckEdit.EditValue,
                                Definicoes = (bool)DefinicoesCheckEdit.EditValue,
                                Backup = (bool)BackupCheckEdit.EditValue,
                                Graficos = (bool)GraficosCheckEdit.EditValue,
                                Grupos = (bool)GruposCheckEdit.EditValue,
                                GruposAdicionar = (bool)GruposAdicionarCheckEdit.EditValue,
                                GruposConsultar = (bool)GruposConsultarCheckEdit.EditValue,

                                // Usuarios
                                Usuarios = (bool)UsuariosCheckEdit.EditValue,
                                UsuariosAdicionar = (bool)UsuariosAdicionarCheckEdit.EditValue,
                                UsuariosConsultar = (bool)UsuariosConsultarCheckEdit.EditValue,

                                // Sistemas
                                ErrosLogs = (bool)ErrosLogsCheckEdit.EditValue,
                                ErrosLogsReport = (bool)ErrosLogsReportCheckEdit.EditValue,

                                GrupoId = (int)GrupoIdLookUpEdit.EditValue,
                                Consultas = (bool)ConsultasCheckEdit.EditValue,
                                Promocoes = (bool)PromocoesCheckEdit.EditValue,

                                // Modulos
                                ModuloGeral = (bool)ModuloGeralCheckEdit.EditValue,

                            };

                            if ((await PermissoesPermissaoControllers.GetInstacia().Update(curs)).IsSucess)
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
                        XtraMessageBox.Show("Lamentamos mais já foi registado um uma permissão com este GRUPO tente alterar o grupo por favor", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!PermissoesIdTextEdit.Text.Equals(string.Empty))
                {
                    if (MessageBox.Show("Estas preste a apagar o (" + GrupoIdLookUpEdit.Text + ")! pretendes continuar?", "Alteração de dados", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        var curs = new Permissoes
                        {
                            PermissoesId = (int)PermissoesIdTextEdit.EditValue,
                        };

                        if ((await PermissoesPermissaoControllers.GetInstacia().Delete(curs)).IsSucess)
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
    
        #region (Existing Data)
        int ExistingData(int id)
        {
            //if (!(ExistingData((int)searchLookUpEdit1.EditValue) > 1))
            return InstaciaList
                          .Where(x => x.GrupoId == id)
                          .Count();
        }
        #endregion
    }
}
