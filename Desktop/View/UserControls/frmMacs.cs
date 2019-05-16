namespace Desktop.View
{
    using DataEntityFrameWork.Controllers;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.ViewModels;
    using Desktop.Hels;
    using DevExpress.XtraEditors;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmMacs : XtraUserControl
    {
        #region Singliton
        private static frmMacs _Instacia;
        public static frmMacs Instacia
        {
            get
            {
                if (_Instacia == null)
                    return new frmMacs();
                return _Instacia;
            }
        }
        #endregion

        #region Instancias
        public List<MacsViewModels> InstaciaList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                InstaciaList = new List<MacsViewModels>();

                InstaciaList = await ClientesFiltersAsync();
                macsViewModelsBindingSource.DataSource = InstaciaList.ToList();              
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
        private async void ListGeralRelacionado()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                trimestresViewModelsBindingSource.DataSource = await Clientes1FiltersAsync();
                turmasViewModelsBindingSource.DataSource = await Clientes2FiltersAsync();
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
        private async Task<List<MacsViewModels>> ClientesFiltersAsync()
        {
            var turma = cbTurmas.Text.Equals("[Selecione sua turma por favor]") ? null : turmasViewModelsBindingSource.Current as Turmas;
            var trimestre = cbTurmas.Text.Equals("[Selecione o triméstre por favor]") ? null : trimestresViewModelsBindingSource.Current as Trimestres;

            return
                await MacsControllers.GetInstacia()
                .GetList(trimestre == null ? 0 : (int)trimestre.TrimestreID,
                         turma == null ? null : (int?) turma.TurmasID);
        }
        private async Task<List<Trimestres>> Clientes1FiltersAsync()
        {
            return
                await TrimestresControllers.GetInstacia()
                .GetList();
        }
        private async Task<List<Turmas>> Clientes2FiltersAsync()
        {
            return
                await TurmasControllers.GetInstacia()
                .GetList();
        }
        #endregion
        public frmMacs()
        {
            InitializeComponent();
            ListGeralRelacionado();
            //ListGeral();

            // GridView Metodos
            this.gridView1.DoubleClick += GridView1_DoubleClick;
            this.gridControl1.DefaultViewChanged += GridControl1_DefaultViewChanged;
            this.Load += FrmAlunos_Load;
            cbTrimestre.EditValueChanging += GridLookUpEdit2_EditValueChanging;
            cbTurmas.EditValueChanging += CbTurmas_EditValueChanging;

            btnTrimestre.Click += BtnTrimestre_Click;
            btnTumas.Click += BtnTumas_Click;

            // Menu de Contexto
            #region Menu Populat
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            contApagar.Click += ContApagar_Click;
            contUpdate.Click += ContUpdate_Click; ;
            ContBaseDeDados.Click += ContBaseDeDados_Click;
            #endregion
            gridControl1.Enabled = false;
        }

        private void CbTurmas_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            var turmas = turmasViewModelsBindingSource.Current as Turmas;

            if (turmas == null)
                gridControl1.Enabled = false;
            else
            {
                gridControl1.Enabled = true;
                ListGeral();
            }
            var t = cbTurmas.EditValue;
        }

        private void GridLookUpEdit2_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            var trimestre = trimestresViewModelsBindingSource.Current as Trimestres;

            if (trimestre == null)
                gridControl1.Enabled = false;
            else
            {
                gridControl1.Enabled = true;
                ListGeral();
            }           
        }

        private void ContUpdate_Click(object sender, System.EventArgs e)
        {
            Guardar();
        }

        private async void Guardar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var trimestreResult = macsViewModelsBindingSource.DataSource as List<MacsViewModels>;
                List<Macs> MacsAdapter = new List<Macs>();

                if (trimestreResult.Count > 0)
                {
                    trimestreResult.ForEach(x =>
                    {
                        var models = new Macs
                        { 
                            MacsID = x.MacsID,
                            nota1 = x.nota1,
                            nota2 = x.nota2,
                            nota3 = x.nota3,
                            nota4 = x.nota4,
                            nota5 = x.nota5,
                            nota6 = x.nota6,
                            nota7 = x.nota7,
                            nota8 = x.nota8, 
                            AlunosID = x.AlunosID,
                            TrimestreID = x.TrimestreID,                         
                        };
                        MacsAdapter.Add(models);
                    });
                }     
                if ((await MacsControllers.GetInstacia().InsertAll(MacsAdapter)).IsSucess)
                {
                    XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListGeral();
                }
                else
                    XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BtnTumas_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmTurmasAdd("Turma: (Adicionar)"))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                    ListGeral();
            }
        }

        private void BtnTrimestre_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmTrimestreAdd("Trimestre: (Adicionar)"))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                    ListGeral();
            }
        }

        private void FrmAlunos_Load(object sender, System.EventArgs e)
        {
            #region LoaderLayer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    var file = f.Loader(this.Name + Program.ProgramName);
                    if (!string.IsNullOrWhiteSpace(file))
                        gridView1.RestoreLayoutFromXml(file);
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        private void GridControl1_DefaultViewChanged(object sender, System.EventArgs e)
        {
            #region Leitura do Layer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    gridView1.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName));
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        #region Contexto Menu
        private void ContBaseDeDados_Click(object sender, System.EventArgs e)
        {
            //var user = alunosBindingSource.DataSource as List<Alunos>;
            //if (user != null)
            //    clsReport.GetReport(new rptProdutos(user), false);
        }

        private void ContAtualizar_Click(object sender, System.EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                GridView1_DoubleClick(null, null);
            else
                MessageBox.Show("Por favor selecione alguma informação na tela!...");
        }

        private async void ContApagar_Click(object sender, System.EventArgs e)
        {
            //if (gridView1.FocusedRowHandle >= 0)
            //{
            //    if (XtraMessageBox.Show("Apagar uma informação implica perda de informação!\nPretendes mesmo continuar?!...", "Apagar Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //    {
            //        var result = turmasViewModelsBindingSource.Current as Turmas;
            //        try
            //        {
            //            if (result != null)
            //            {
            //                var resultDelete = await TurmasControllers.GetInstacia().Delete(result);
            //                if (resultDelete.IsSucess)
            //                {
            //                    XtraMessageBox.Show("Informação selecionada Pagada com Exito!...", "Apagar Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    ListGeral();
            //                }
            //                else
            //                    XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        catch (System.Exception exe)
            //        {
            //            XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...\n Verifique o as informações Adicionais: Talvez seja o facto de haver informções que dependem desta que estas a tentar apagar, e apagar este informação implica perder toda a informção delecionada comprimetendo assim a estabilidade do sistema {" + exe.Message + "}", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //    XtraMessageBox.Show("Por favor selecione alguma informação na tela!...");
        }
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((gridView1.SelectedRowsCount > 0) || (gridView1.FocusedRowHandle > 0))
            {
                contApagar.Enabled = true;
                contUpdate.Enabled = true;
                ContBaseDeDados.Enabled = true;
            }
            else
            {
                contApagar.Enabled = false;
                contUpdate.Enabled = false;
                ContBaseDeDados.Enabled = false;
            }
        }
        #endregion
        private void GridView1_DoubleClick(object sender, System.EventArgs e)
        {
            //if (gridView1.SelectedRowsCount > 0)
            //{
            //    var result = turmasViewModelsBindingSource.Current as Turmas;

            //    using (var forms = new frmTurmasAdd("(Turma) Adicionar", result ?? null))
            //    {
            //        if (forms.ShowDialog() == DialogResult.OK)
            //            ListGeral();
            //    }
            //}
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ListGeralRelacionado();
                ListGeral();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        private void gridControl1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
