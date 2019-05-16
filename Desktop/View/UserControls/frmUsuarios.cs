namespace Desktop
{
    using DataEntityFrameWork.Controllers;
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

    public partial class frmUsuarios : XtraUserControl
    {
        #region Instancias
        public DateTime GetData { get { return DateTime.Now; } }
        #endregion

        #region Instancias
        public List<Usuarios> UsuariosInstaciaList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                UsuariosInstaciaList = new List<Usuarios>();
                UsuariosInstaciaList = (await FiltersAsync());
                usuariosBindingSource.DataSource = UsuariosInstaciaList.ToList();
            }
            catch (System.Exception exe)
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
        #endregion

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPIN { get; set; }
        public bool isNew { get; private set; }

        #region Singliton
        private static frmUsuarios _Instacia;
        public static frmUsuarios Instacia
        {
            get
            {
                if (_Instacia == null)
                    return new frmUsuarios();
                return _Instacia;
            }
        }
        #endregion

        public frmUsuarios()
        {
            InitializeComponent();

            // Instacias Inicias
            txtPesquizar.TextChanged += new EventHandler(TxtConsultas_TextChanged);

            gridControl1.MouseDoubleClick += delegate
            {
                if (gridView1.FocusedRowHandle >= 0)
                    Edit();
            };

            gridControl1.MouseClick += (argos, EventArgs) =>
            {
                if (gridView1.FocusedColumn.FieldName == "Email")
                {
                    EmailSender();
                }
                Detalhes();
            };

            #region Menu Populat
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;

            contApagar.Click += delegate { if (gridView1.FocusedRowHandle > 0) Edit(); };
            contAtualizar.Click += delegate { if (gridView1.FocusedRowHandle > 0) Edit(); };
            contRelatorios.Click += delegate {
                gridControl1.ShowRibbonPrintPreview();
            };
            emitirCartãoToolStripMenuItem.Click += delegate { Relatorios(); };
            #endregion

            ListGeral();

            this.Load += FrmUsuarios_Load;
            gridControl1.DefaultViewChanged += delegate { GuardarLayer(); };
            layoutControl2.Changed += delegate { GuardarLayer(); };
            btnNovos.Click += BtnNovos_Click;
        }
        private void BtnNovos_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmUsuariosAdd("Usuarios: (Adicionar)", 0))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                    ListGeral();
            }
        }

        private void GuardarLayer()
        {
            #region Leitura do Layer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    layoutControl2.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName));
                    gridView1.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName + "GridView"));
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            #region LoaderLayer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    var file = f.Loader(this.Name + Program.ProgramName);
                    var file1 = f.Loader(this.Name + Program.ProgramName + "GridView");
                    if (!string.IsNullOrWhiteSpace(file))
                        layoutControl2.RestoreLayoutFromXml(file);
                    if (!string.IsNullOrWhiteSpace(file1))
                        gridView1.RestoreLayoutFromXml(file);
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        private void EmailSender()
        {
            //var client = usuariosBindingSource.Current as Usuarios;
            //if (client != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(client.Email))
            //    {
            //        if (EmailValidade.GetIstance().IsValidEmail(client.Email))
            //        {
            //            using (frmEmailSender f = new frmEmailSender(
            //                    client.Email, 
            //                    client.UsuarioNomeCompleto))
            //            {
            //                f.ShowDialog();
            //            }
            //        }
            //    }
            //}
        }
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((gridView1.SelectedRowsCount > 0) || (gridView1.FocusedRowHandle > 0))
            {
                contVoltar.Enabled = true;
                contApagar.Enabled = true;
                contAtualizar.Enabled = true;
                contRelatorios.Enabled = true;
            }
            else
            {
                contVoltar.Enabled = false;
                contApagar.Enabled = false;
                contAtualizar.Enabled = false;
                contRelatorios.Enabled = false;
            }
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {        
            if (keyData == Keys.F5)
            {
                ListGeral();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        private void List_Async()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                txtPesquizar.Enabled = false;

                if (string.IsNullOrWhiteSpace(txtPesquizar.Text))
                    usuariosBindingSource.DataSource = UsuariosInstaciaList.ToList();
                else
                    usuariosBindingSource.DataSource = UsuariosInstaciaList
                                                       .Where(x => x.UsuarioNomeCompleto.ToUpper()
                                                                                        .Contains(txtPesquizar.Text.ToLower())
                                                                || x.Login.ToUpper()
                                                                                        .Contains(txtPesquizar.Text.ToUpper())).ToList();
            }
            finally
            {
                //prog.Mostrar_Close(this);
                Cursor = Cursors.Default;
                this.txtPesquizar.Enabled = true;
                this.txtPesquizar.Focus();
            }
        }
        private void TxtConsultas_TextChanged(object sender, EventArgs e)
        {
            List_Async();
        }
        private void Edit()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (gridView1.RowCount > 0)
                {
                    var item = usuariosBindingSource.Current as Usuarios;

                    if (item != null)
                    {
                        using (var detalhes = new frmUsuariosAdd(item))
                        {
                            detalhes.ShowDialog();
                        }
                    }                 
                }
                else
                    MessageBox.Show("Impossivel passar valores quando a tabela encontra-se vazia", "Erro Tabela Vazia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception exe)
            {
                MessageBox.Show("Erro ao passar Dados" + exe.Message, "Erro de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        public void Detalhes()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    if (gridView1.FocusedRowHandle >= 0)
                    {
                        listBoxControl1.Items.Clear();

                        var item = usuariosBindingSource.Current as Usuarios;
                        var ImagemProd = item.Perfil;

                        if (item != null)
                        {
                            if (ImagemProd != null)
                            {
                                pictureEdit1.Image = (Image) ImagemTratamento.byteArrayToImage(ImagemProd);
                                ImagemProd = null;
                            }
                            else
                                pictureEdit1.Image = null;

                            listBoxControl1.Items.AddRange(new object[] {"Código :    " + item.UsuariosId.ToString(),
                                                                         "Usuário:    " + item.UsuarioNomeCompleto,
                                                                         "Apelido:    " + item.Apelido,
                                                                         "E-Mail :    " + item.Email,
                                                                         "Estado :    " + string.Format("{0}",item.Estado == true ? "Activado" : "Desativado",
                                                                         "Aniversário:" + item.DataNascimento.ToShortDateString()),

                            });
                        }

                        try
                        {
                            LerLogs();
                        }
                        catch (Exception exe)
                        {
                            MessageBox.Show(exe.Message);
                        }
                    }
                }
            }
            finally
            {
              
                Cursor = Cursors.Default;
            }
        }
        private async void LerLogs()
        {
            try
            {
               var value = (await LogsControllers.GetInstacia()
                                .GetList((usuariosBindingSource.Current as Usuarios)
                                .UsuariosId));

                logsBindingSource.DataSource = value.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }        
        }
        public void Relatorios()
        {
            //if (Program.Relatorios)
            //{
            //    try
            //    {
            //        prog.Mostrar(this);

            //        var report = usuariosBindingSource.DataSource as List<Usuarios>;
            //        if (report != null)
            //            clsReport.GetReport(new rptUsuariosGeralNCartao(report), false);
            //    }
            //    finally
            //    {
            //        prog.Mostrar_Close(this);
            //    }
            //}
            //else
            //    XtraMessageBox.Show("Não tens permissão para executar esta Acção", "Peça permissão de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
