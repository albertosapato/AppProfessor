using DataEntityFrameWork.Controllers;
using DataEntityFrameWork.Models;
using Desktop.Hels;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    public partial class frmClasse : XtraUserControl
    {
        #region Singliton
        private static frmClasse _Instacia;
        public static frmClasse Instacia
        {
            get 
            {
                if (_Instacia == null)
                    return new frmClasse();
                return _Instacia;
            }
        }
        #endregion

        #region Instancias
        public List<Classes> InstaciaList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                InstaciaList = new List<Classes>();
                InstaciaList = await ClientesFiltersAsync();
                classesViewModelsBindingSource.DataSource = InstaciaList.ToList();
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
        private async Task<List<Classes>> ClientesFiltersAsync()
        {
            return
                await ClasseControllers
                .GetInstacia()
                .GetList();
        }
        #endregion
        public frmClasse()
        {
            InitializeComponent();
            ListGeral();

            txtPesquisar.TextChanged += TxtPesquisar_TextChanged;
            txtPesquisar.ButtonClick += TxtPesquisar_TextChanged;

            // GridView Metodos
            this.gridView1.DoubleClick += GridView1_DoubleClick;
            this.gridControl1.DefaultViewChanged += GridControl1_DefaultViewChanged;
            this.Load += FrmAlunos_Load;
            btnNovos.Click += BtnNovos_Click;

            // Menu de Contexto
            #region Menu Populat
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            contApagar.Click += ContApagar_Click;
            contAtualizar.Click += ContAtualizar_Click;
            contRelatorios.Click += delegate { gridControl1.ShowRibbonPrintPreview();};
            ContBaseDeDados.Click += ContBaseDeDados_Click; 
            #endregion
        }
        private void BtnNovos_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmClasseAdd("Classe: (Adicionar)"))
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
            if (gridView1.FocusedRowHandle >= 0)
            {
                if (XtraMessageBox.Show("Apagar uma informação implica perda de informação!\nPretendes mesmo continuar?!...", "Apagar Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var result = classesViewModelsBindingSource.Current as Classes;
                    try
                    {
                        if (result != null)
                        {
                            var resultDelete = await ClasseControllers.GetInstacia().Delete(result);
                            if (resultDelete.IsSucess)
                            {
                                XtraMessageBox.Show("Informação selecionada Pagada com Exito!...", "Apagar Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ListGeral();
                            }                       
                            else
                                XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Exception exe)
                    {
                        XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...\n Verifique o as informações Adicionais: Talvez seja o facto de haver informções que dependem desta que estas a tentar apagar, e apagar este informação implica perder toda a informção delecionada comprimetendo assim a estabilidade do sistema {" + exe.Message + "}", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }              
            }
            else
                XtraMessageBox.Show("Por favor selecione alguma informação na tela!...");
        }
        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((gridView1.SelectedRowsCount > 0) || (gridView1.FocusedRowHandle > 0))
            {
                contApagar.Enabled = true;
                contAtualizar.Enabled = true;
                contRelatorios.Enabled = true;
                ContBaseDeDados.Enabled = true;
            }
            else
            {
                contApagar.Enabled = false;
                contAtualizar.Enabled = false;
                contRelatorios.Enabled = false;
                ContBaseDeDados.Enabled = false;
            }
        }
        #endregion
        private void GridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var result = classesViewModelsBindingSource.Current as Classes;

                using (var forms = new frmClasseAdd("(Classe) Adicionar", result ?? null))
                {
                    if (forms.ShowDialog() == DialogResult.OK)
                        ListGeral();
                }
            }
        }
        private void TxtPesquisar_TextChanged(object sender, System.EventArgs e)
        {
            #region Pesquisa
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
                classesViewModelsBindingSource.DataSource = InstaciaList.ToList();
            else
                classesViewModelsBindingSource.DataSource = InstaciaList
                                                   .Where(x => x.ClassesNome.ToUpper().Contains(txtPesquisar.Text.ToUpper()))
                                                   .ToList();
            #endregion
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
    }
}
