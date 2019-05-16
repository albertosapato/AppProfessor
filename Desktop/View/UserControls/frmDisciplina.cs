﻿using DataEntityFrameWork.Controllers;
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
    public partial class frmDisciplina : XtraUserControl
    {
        #region Singliton
        private static frmDisciplina _Instacia;
        public static frmDisciplina Instacia
        {
            get 
            {
                if (_Instacia == null)
                    return new frmDisciplina();
                return _Instacia;
            }
        }
        #endregion

        #region Instancias
        public List<Disciplina> InstaciaList { get; set; }
        public async void ListGeral()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                InstaciaList = new List<Disciplina>();
                InstaciaList = await ClientesFiltersAsync();
                disciplinaViewModelsBindingSource.DataSource = InstaciaList.ToList();
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
        private async Task<List<Disciplina>> ClientesFiltersAsync()
        {
            return
                await DisciplinaControllers
                .GetInstacia()
                .GetList();
        }
        #endregion
        public frmDisciplina()
        {
            InitializeComponent();
            ListGeral();

            txtPesquisar.TextChanged += TxtPesquisar_TextChanged;
            txtPesquisar.ButtonClick += TxtPesquisar_TextChanged;

            // GridView Metodos
            this.gridView1.DoubleClick += GridView1_DoubleClick;
            this.gridControl1.DefaultViewChanged += GridControl1_DefaultViewChanged;
            this.Load += FrmAlunos_Load;

            // Menu de Contexto
            #region Menu Populat
            contextMenuStrip1.Opening += ContextMenuStrip1_Opening;
            contApagar.Click += ContApagar_Click;
            contAtualizar.Click += ContAtualizar_Click;
            contRelatorios.Click += delegate { gridControl1.ShowRibbonPrintPreview();};
            ContBaseDeDados.Click += ContBaseDeDados_Click;
            btnNovos.Click += BtnNovos_Click;
            #endregion
        }
        private void BtnNovos_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmDisciplinaAdd("Disciplina: (Adicionar)"))
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
                    var result = disciplinaViewModelsBindingSource.Current as Disciplina;
                    try
                    {
                        if (result != null)
                        {
                            var resultDelete = await DisciplinaControllers.GetInstacia().Delete(result);
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
                var result = disciplinaViewModelsBindingSource.Current as Disciplina;

                using (var forms = new frmDisciplinaAdd("(Disciplina) Adicionar", result ?? null))
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
                disciplinaViewModelsBindingSource.DataSource = InstaciaList.ToList();
            else
                disciplinaViewModelsBindingSource.DataSource = InstaciaList
                                                   .Where(x => x.Designacao.ToUpper().Contains(txtPesquisar.Text.ToUpper()))
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