namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using DataEntityFrameWork.Models;
    using DataEntityFrameWork.ViewModels;
    using Desktop.Hels;
    using Desktop.Hels.Settings;
    using DevExpress.XtraEditors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmProfessorDisciplinaAdd : XtraForm
    {
        #region Variaveis Globais
        private bool mover;
        private int cX, cY;
        bool tela;
        #endregion

        #region Construtores
        public frmProfessorDisciplinaAdd(string Titulo, ProfessorViewModelsAdapter models)
        {
            InitializeComponent();
            LimparCampos();
            ImplementacoaInicial();

            #region Aplicar
            this.txtTitulo.Text = $"Página: {Titulo}";
            #endregion

            #region AcoplarDados
            if (models != null)
            {
                txtCodigo.EditValue = models.ProfessorDisciplinaID;
                txtTurmas.EditValue = models.Descricao;

                // Professor
                listView2.Items.Add(
                    new ListViewItem(new string[] 
                    { models.Professor.ProfessorID.ToString(), models.Professor.Nome }));

                foreach (var item in models.Disciplina)
                {
                    listView1.Items.Add(
                     new ListViewItem(new string[]
                     { item.DisciplinaID.ToString(), item.Designacao }));
                }
                txtTurmas.Focus();
            }
            #endregion
        }
        public frmProfessorDisciplinaAdd(string Titulo)
        {
            InitializeComponent();
            ImplementacoaInicial();

            #region Aplicar
            this.txtTitulo.Text = $"Página: {Titulo}";
            #endregion
        }
        private void ImplementacoaInicial()
        {
            #region Valores internos
            this.FormClosing += FrmMessage_FormClosing;
            this.Load += FrmMessage_Load;
            #endregion

            #region Chamadas
            btnNovo.Click += BtnNovo_Click;
            btnGuardar.Click += BtnGuardar_Click;

            panel1.MouseDown += panel_MouseDown;
            panel1.MouseMove += panel_MouseMove;
            panel1.MouseUp += panel_MouseUp;

            panel2.MouseDown += panel_MouseDown;
            panel2.MouseMove += panel_MouseMove;
            panel2.MouseUp += panel_MouseUp;
            panel1.MouseDoubleClick += delegate (object sender, MouseEventArgs args) { Tela(); };
            #endregion

            btnProfessor.Click += BtnBuscar_Click;
            btnDisciplina.Click += BtnBuscar1_Click;
            btnSelecioneProfessor.Click += BtnSelecioneProfessor_Click;
            btnDisciplinaAdicionar.Click += BtnDisciplinaAdicionar_Click;
            btnRemover.Click += BtnRemover_Click;
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;

            // 

            txtCodigo.TextChanged += TxtCodigo_TextChanged;
            ListGeral();

            // ListBox
            listBoxControl1.SelectedIndexChanged += delegate
            {
                if (listBoxControl1.SelectedItems.Count > 0)
                    btnSelecioneProfessor.Enabled = true;
                else
                    btnSelecioneProfessor.Enabled = false;
            };
            listBoxControl2.SelectedIndexChanged += delegate
            {
                if (listBoxControl2.SelectedItems.Count > 0)
                    btnDisciplinaAdicionar.Enabled = true;
                else
                    btnDisciplinaAdicionar.Enabled = false;
            };

        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            var selectitems = listView1.FocusedItem.Selected;
            if (selectitems)
                listView1.FocusedItem.Remove();
        }
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                btnRemover.Enabled = true;
            else
                btnRemover.Enabled = false;
        }

        private void BtnDisciplinaAdicionar_Click(object sender, EventArgs e)
        {
            var disci = disciplinaViewModelsBindingSource.Current as Disciplina;
            var exist = listView1.Items;

            if (disci != null)
            {
                if (exist.Count > 0)
                {
                    var test = false;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        var result = item.SubItems[0].Text.ToString().Equals(disci.DisciplinaID.ToString());
                        if (result)
                        {
                            XtraMessageBox.Show("Desculpe mais esta disciplina já esta Adicionada à Lista",
                                                "Redundância", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            test = true;
                        }                           
                    }
                    if (!test)
                    {
                        ListViewItem listViewItem = new ListViewItem
                            (new string[] { disci.DisciplinaID.ToString(), disci.Designacao });
                        listView1.Items.Add(listViewItem);
                    }               
                }
                else
                {
                    ListViewItem listViewItem = new ListViewItem
                             (new string[] { disci.DisciplinaID.ToString(), disci.Designacao });
                    listView1.Items.Add(listViewItem);
                }                 
            }       
        }

        private void BtnSelecioneProfessor_Click(object sender, EventArgs e)
        {
            var exist = listView2.Items;
            var result = professorViewModelsBindingSource.Current as Professor;
            if (exist.Count > 0)
            {
                foreach (ListViewItem items in exist)
                {
                    if (items.SubItems[0].Text.ToString().Equals(result.ProfessorID.ToString()))
                    {
                        XtraMessageBox.Show("Desculpe mais este Professor já esta Adicionado à Lista", "Redundância", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                listView2.Items.Clear();
                ListViewItem item = new ListViewItem(new string[] { result.ProfessorID.ToString(), result.Nome });
                listView2.Items.Add(item);
            }
            else
            {
                ListViewItem items = new ListViewItem(new string[] { result.ProfessorID.ToString(), result.Nome });
                listView2.Items.Add(items);
            }
        }

        private async void ListGeral()
        {
            var result = await ProfessorControllers.GetInstacia().GetList();
            professorViewModelsBindingSource.DataSource = result.ToList();

            var result1 = await DisciplinaControllers.GetInstacia().GetList();
            disciplinaViewModelsBindingSource.DataSource = result1.ToList();
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Atualizar";
                btnNovo.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
                btnNovo.Enabled = true;
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            using (var forms = new frmProfessorAdd("(Professor) Adicionar"))
            {
                if (forms.ShowDialog() == DialogResult.OK)
                    ListGeral();
            }
        }
        private void BtnBuscar1_Click(object sender, EventArgs e)
        {
            using (var forms = new frmDisciplinaAdd("(Disciplina) Adicionar"))
            {
                if (forms.ShowDialog() == DialogResult.OK)
                    ListGeral();
            }
        }
        #endregion

        #region Metodos
        private void FrmMessage_Load(object sender, EventArgs e)
        {
            var color = FormsColor.Default;

            #region Leitura Cores
            this.panel1.BackColor = color.PainelTopBooton;
            this.panel2.BackColor = color.PainelTopBooton;
            this.panel3.BackColor = color.PainelFundo;

            this.btnNovo.BackColor = color.PainelTopBooton;
            this.btnGuardar.BackColor = color.PainelTopBooton;

            this.btnNovo.ForeColor = color.ForeColorAll;
            this.btnGuardar.ForeColor = color.ForeColorAll;
            txtTitulo.ForeColor = color.ForeColorAll;
            #endregion

            #region LoaderLayer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    var file = f.Loader(this.Name + Program.ProgramName);

                    if (!string.IsNullOrWhiteSpace(file))
                        layoutControl1.RestoreLayoutFromXml(file);
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }
        private void FrmMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Leitura do Layer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    layoutControl1.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName));            
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
                Atualizar();
            else
                Guardar();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private async void BtnApagar_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Apagar uma informação implica perda de informação!\nPretendes mesmo continuar?!...", "Apagar Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    var resultDelete = await TurmasControllers.GetInstacia().Delete((int) txtCodigo.EditValue);

                    if (resultDelete.IsSucess)
                    {
                        XtraMessageBox.Show("Informação selecionada Pagada com Exito!...", "Apagar Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListGeral();
                    }                   
                    else
                        XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Exception exe)
                {
                    XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...\n Verifique o as informações Adicionais: Talvez seja o facto de haver informções que dependem desta que estas a tentar apagar, e apagar este informação implica perder toda a informção delecionada comprimetendo assim a estabilidade do sistema {" + exe.Message + "}", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LimparCampos()
        {
            txtCodigo.EditValue = string.Empty;
            txtTurmas.EditValue = string.Empty;
            txtTurmas.Focus();
        }
        private async void Guardar()
        {
            try
            {
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;

                    // Professor
                    var profCod = new Professor();
                    foreach (ListViewItem item in listView2.Items)
                    {
                        profCod.ProfessorID = int.Parse(item.SubItems[0].Text);
                        profCod.Nome = item.SubItems[1].Text;
                    }
                    // Disciplina
                    var DisciplinaCod = new List<DisciplinaViewModels>();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        var dis = new DisciplinaViewModels
                        {
                            DisciplinaID = int.Parse(item.SubItems[0].Text),
                            Designacao = item.SubItems[1].Text,
                        };
                        DisciplinaCod.Add(dis);
                    }
                    // Disciplina Antigas
                    var disciAntigas = await ProfessorDisciplinaControllers.GetInstacia().GetList(profCod.ProfessorID);

                    var curs = new ProfessorViewModelsAdapter
                    {
                        Descricao = txtTurmas.Text,
                        ProfessorID = profCod.ProfessorID,
                        Disciplina = DisciplinaCod,
                    };



                    // Apagar Dados
                    ApagarDados(DisciplinaCod, disciAntigas);

                    if ((await ProfessorDisciplinaControllers.GetInstacia().Insert(curs, disciAntigas)).IsSucess)
                    {
                        XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        ListGeral();
                    }
                    else
                        XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void ApagarDados(List<DisciplinaViewModels> disciplinaActual, ProfessorViewModelsAdapter disciAntigas)
        {
            foreach (var item in disciAntigas.Disciplina)
            {

            }
        }

        private async void Atualizar()
        {
            try
            {
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;
                    //if (!(await ExistingData((int)txtProfessor.EditValue, (int) txtDisciplina.EditValue) > 1))
                    //{
                    //    if (XtraMessageBox.Show("Atualizar uma informação implica Alteração de informação!\nPretendes mesmo continuar?!...", "Atualizar Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    //    {
                    //        var curs = new Professor_Disciplina
                    //        {
                    //            ProfessorDisciplinaID = Convert.ToInt32(txtCodigo.Text),
                    //            Descricao = txtTurmas.Text,
                    //            DisciplinaID = (int)txtProfessor.EditValue,
                    //            ProfessorID = (int)txtDisciplina.EditValue,
                    //        };
                    //        if ((await ProfessorDisciplinaControllers.GetInstacia().Update(curs)).IsSucess)
                    //        {
                    //            XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //            LimparCampos();
                    //            ListGeral();
                    //        }
                    //        else
                    //            XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Lamentamos mais já existe este login no Sistema\n Não pode existir PIN ou login com o mesmo acesso", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
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
        private bool Validar1()
        {
            if (txtTurmas.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Digite o Nome completo por favor!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTurmas.Focus();
                return false;
            }
            if (listView1.Items.Count <= 0)
            {
                XtraMessageBox.Show("Por favor coloque algumas disciplinas pertencentes ao professor preencha por favor!", 
                    string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                listView1.Focus();
                return false;
            }
            if (listView2.Items.Count <= 0)
            {
                XtraMessageBox.Show("Por favor selecione um professor especifico!... preencha por favor!", 
                    string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                listView2.Focus();
                return false;
            }
            else
                return true;
        }

        private bool Validar()
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                return true;
            else
                return false;
        }

        #region Metodos
        protected override void OnLoad(EventArgs e)
        {
            // Novo Botão
            ArredondarFormas.BordasCurvas(btnNovo);
            ArredondarFormas.BordasCurvas(btnGuardar);
            base.OnLoad(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //ArredondarFormas.BordasCirculos(onject);
            base.OnPaint(e);
        }

        #region Combinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                BtnNovo_Click(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if ((keyData == Keys.F2) || (keyData == Keys.Enter))
            {
                BtnGuardar_Click(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F3)
            {
                BtnApagar_Click(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion

        #region Mover Paines
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - panel1.Left);
                this.Top += e.Y - (cY - panel1.Top);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }
        private void panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Tela();
        }
        public void Tela()
        {
            if (tela == false)
            {
                this.WindowState = FormWindowState.Maximized;
                tela = true;
            }
            else if (tela == true)
            {
                this.WindowState = FormWindowState.Normal;
                tela = false;
            }
        }

        private void txtTurmas_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #endregion

        #region (Existing Data)
        async Task<int> ExistingData(int professor, int Disciplina)
        {
            var result = await ProfessorDisciplinaControllers.GetInstacia().GetCount(professor, Disciplina);
            return result > 0 ? 1 : 0;
        }
        #endregion
    }
}
