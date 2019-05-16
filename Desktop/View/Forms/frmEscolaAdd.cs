namespace Desktop
{
    using DataEntityFrameWork.Controllers;
    using DataEntityFrameWork.Models;
    using Desktop.Hels;
    using Desktop.Hels.Settings;
    using DevExpress.XtraEditors;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class frmEscolaAdd : XtraForm
    {
        #region Variaveis Globais
        private bool mover;
        private int cX, cY;
        bool tela;
        #endregion

        #region Construtores
        public frmEscolaAdd(string Titulo, Escola models)
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
                txtCodigo.EditValue = models.EscolaID;
                txtNome.EditValue = models.Nome;
                txttxtRepublica.EditValue = models.republica;
                txtMinisterio.EditValue = models.Ministerio;              
                txtOutros.EditValue = models.Outros;
                txtRodape.EditValue = models.Rodape;
                txtNome.Focus();
            }
            #endregion
        }
        public frmEscolaAdd(string Titulo)
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
            btnApagar.Click += BtnApagar_Click;

            panel1.MouseDown += panel_MouseDown;
            panel1.MouseMove += panel_MouseMove;
            panel1.MouseUp += panel_MouseUp;

            panel2.MouseDown += panel_MouseDown;
            panel2.MouseMove += panel_MouseMove;
            panel2.MouseUp += panel_MouseUp;
            panel1.MouseDoubleClick += delegate (object sender, MouseEventArgs args) { Tela(); };
            #endregion

            txtCodigo.TextChanged += TxtCodigo_TextChanged;
            ListGeral();
        }

        private async void ListGeral()
        {
            var result = await ClasseControllers.GetInstacia().GetList();
            classesViewModelsBindingSource.DataSource = result.ToList();

            var result1 = await PeriodosControllers.GetInstacia().GetList();
            periodoViewModelsBindingSource.DataSource = result1.ToList();

            var result2 = await CursosControllers.GetInstacia().GetList();
            cursosViewModelsBindingSource.DataSource = result2.ToList();
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                btnApagar.Enabled = true;
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Atualizar";
                btnNovo.Enabled = true;
            }
            else
            {
                btnApagar.Enabled = false;
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
                btnNovo.Enabled = true;
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            using (var forms = new frmClasseAdd("(Classes) Adicionar"))
            {
                if (forms.ShowDialog() == DialogResult.OK)
                    ListGeral();
            }
        }
        private void BtnBuscar1_Click(object sender, EventArgs e)
        {
            using (var forms = new frmPeriodoAdd("(Períodos) Adicionar"))
            {
                if (forms.ShowDialog() == DialogResult.OK)
                    ListGeral();
            }
        }
        private void BtnBuscar2_Click(object sender, EventArgs e)
        {
            using (var forms = new frmCursosAdd("(Turmas) Adicionar"))
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
            this.btnApagar.BackColor = color.PainelTopBooton;

            this.btnNovo.ForeColor = color.ForeColorAll;
            this.btnGuardar.ForeColor = color.ForeColorAll;
            this.btnApagar.ForeColor = color.ForeColorAll;
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
            txtNome.EditValue = string.Empty;
            txttxtRepublica.EditValue = string.Empty;
            txtRodape.EditValue = string.Empty;
            txtOutros.EditValue = string.Empty;
            txtMinisterio.EditValue = string.Empty;
            txtNome.Focus();
        }
        private async void Guardar()
        {
            try
            {
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;
                    if (!(await ExistingData(
                        (string) txtNome.Text, 
                        (string)txttxtRepublica.EditValue, (string)txtMinisterio.EditValue) > 0))
                    {
                        var curs = new Escola
                        {
                            Nome = txttxtRepublica.Text,
                            Rodape = (string) txtRodape.EditValue,
                            Ministerio = (string)txtMinisterio.EditValue,
                            Outros = (string)txtOutros.EditValue,
                            republica = txtNome.Text,
                        };
                        if ((await EscolaControllers.GetInstacia().Insert(curs)).IsSucess)
                        {
                            XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                            ListGeral();
                        }
                        else
                            XtraMessageBox.Show("Este Valor já existe tente novamente", "Má conclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async void Atualizar()
        {
            try
            {
                if (Validar1())
                {
                    Cursor = Cursors.WaitCursor;
                    if (!(await ExistingData(
                        (string)txtNome.EditValue, 
                        (string) txttxtRepublica.EditValue, 
                        (string)txtMinisterio.EditValue) > 1))
                    {
                        if (XtraMessageBox.Show("Atualizar uma informação implica Alteração de informação!\nPretendes mesmo continuar?!...", "Atualizar Informação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            var curs = new Escola
                            {
                                EscolaID = Convert.ToInt32(txtCodigo.Text),
                                Nome = txttxtRepublica.Text,
                                Rodape = (string)txtRodape.EditValue,
                                Ministerio = (string)txtMinisterio.EditValue,
                                Outros = (string)txtOutros.EditValue,
                                republica = txtNome.Text,
                            };
                            if ((await EscolaControllers.GetInstacia().Update(curs)).IsSucess)
                            {
                                XtraMessageBox.Show("Serviço Inserido com Sucesso!...", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos();
                                ListGeral();
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
            if (txtNome.Text.Trim().Equals(string.Empty))
            {
                XtraMessageBox.Show("Digite o Nome completo por favor!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace((string)txttxtRepublica.EditValue))
            {
                XtraMessageBox.Show("Digite a Republica!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttxtRepublica.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace((string)txtMinisterio.EditValue))
            {
                XtraMessageBox.Show("Digite o seu Ministéio!... preencha por favor!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMinisterio.Focus();
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
            ArredondarFormas.BordasCurvas(btnApagar);
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

        private void txtRodape_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #endregion

        #region (Existing Data)
        async Task<int> ExistingData(string nome, string republica, string Ministerio)
        {
            var result = await EscolaControllers
                                               .GetInstacia()
                                               .GetCount(nome, republica, Ministerio);
            return result > 0 ? 1 : 0;
        }
        #endregion
    }
}
