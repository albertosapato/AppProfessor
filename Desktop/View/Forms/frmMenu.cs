namespace Desktop
{
    using DataEntityFrameWork.Models;
    using Desktop.Hels;
    using Desktop.View;
    using Desktop.View.Forms;
    using Desktop.View.Helps;
    using System;
    using System.Windows.Forms;

    public partial class frmMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region Variaveis Globais
        private readonly Permissoes t;
        #endregion

        #region Construtores da Classe
        public frmMenu(Permissoes t)
        {
            InitializeComponent();
            this.t = t;
            PlicarPermissoes(t);

            // Chamadas
            this.Load += FrmMenu_Load;
            this.FormClosed += FrmMenu_FormClosed; ;

            btnAlunos.Click += BtnAlunos_Click;
            btnTurma.Click += BtnTurma_Click;
            btnClasse.Click += BtnClasse_Click;
            btnCursos.Click += BtnCursos_Click;
            btnPeriodos.Click += BtnPeriodos_Click;
            btnSobre.Click += BtnSobre_Click;
            btnProgramador.Click += BtnProgramador_Click;
            btnDefinições.Click += BtnDefinições_Click;
            btnEscola.Click += BtnEscola_Click;
            btnTrimestres.Click += BtnTrimestres_Click;

            //Usuarios
            btnUsuarios.Click += BtnUsuarios_Click;
            btnPermissoes.Click += BtnPermissoes_Click;
            btnGrupos.Click += BtnGrupos_Click;

            btnDisciplina.Click += BtnDisciplina_Click;
            btnProfessor.Click += BtnProfessor_Click;
            btnProfessorDisciplina.Click += BtnProfessorDisciplina_Click;


            // Ferramentas
            btnMacs.Click += BtnMacs_Click;
        }
        private void BtnProfessorDisciplina_Click(object sender, EventArgs e)
        {
            OpenForms(frmProfessorDisciplina.Instacia);
        }
        private void BtnProfessor_Click(object sender, EventArgs e)
        {
            OpenForms(frmProfessores.Instacia);
        }
        private void BtnDisciplina_Click(object sender, EventArgs e)
        {
            OpenForms(frmDisciplina.Instacia);
        }

        private void BtnTrimestres_Click(object sender, EventArgs e)
        {
            OpenForms(frmTrimestres.Instacia);
        }

        private void BtnMacs_Click(object sender, EventArgs e)
        {
            OpenForms(frmMacs.Instacia);
        }
        private void BtnGrupos_Click(object sender, EventArgs e)
        {
            OpenForms(frmUsuariosGrupos.Instacia);
        }

        private void BtnPermissoes_Click(object sender, EventArgs e)
        {
            OpenForms(frmUsuariosPermissoes.Instacia);
        }
        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            OpenForms(frmUsuarios.Instacia);

        }
        private void BtnEscola_Click(object sender, EventArgs e)
        {
            OpenForms(frmEscolas.Instacia);
        }

        #region Métodos
        private void BtnPeriodos_Click(object sender, EventArgs e)
        {
            OpenForms(frmPeriodos.Instacia);
        }

        private void BtnCursos_Click(object sender, EventArgs e)
        {
            OpenForms(frmCursos.Instacia);
        }

        private void BtnClasse_Click(object sender, EventArgs e)
        {
            OpenForms(frmClasse.Instacia);
        }
        private void BtnTurma_Click(object sender, EventArgs e)
        {
            OpenForms(frmTurmas.Instacia);
        }
        private void BtnDefinições_Click(object sender, EventArgs e)
        {
            OpenForms(new frmDefinicoes());
        }
        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            #region Leitura do Layer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    accordionControl1.SaveLayoutToXml(f.fileName(this.Name + Program.ProgramName));
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            #region LoaderLayer
            try
            {
                using (SaveLayoutXML f = new SaveLayoutXML())
                {
                    var file = f.Loader(this.Name + Program.ProgramName);

                    if (!string.IsNullOrWhiteSpace(file))
                        accordionControl1.RestoreLayoutFromXml(file);
                }
            }
            catch (System.Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            #endregion
        }
        private void BtnProgramador_Click(object sender, EventArgs e)
        {
            OpenForms(new frmProgramdor());
        }

        private void BtnSobre_Click(object sender, EventArgs e)
        {
            OpenForms(new AppsAbout());
        }
        #endregion

        #region Conbinações de Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == (Keys.Control | Keys.V))
            {
                OpenForms(frmAlunos.Instacia);
                return true;
            }          
            return false;
        }
        #endregion

        private void PlicarPermissoes(Permissoes t)
        {
            // Aplicar permissões de utilizadores
            btnPeriodos.Enabled = t.Periodos;
            btnCursos.Enabled = t.Cursos;
            btnClasse.Enabled = t.Classe;
            btnAlunos.Enabled = t.Alunos;
            btnTurma.Enabled = t.Turma;
        }
        #endregion

        #region Metodos de Aberturas
        private void BtnAlunos_Click(object sender, EventArgs e)
        {
            OpenForms(frmAlunos.Instacia);
        }
        #endregion

        #region Singliton
        private void OpenForms(Control control)
        {
            if (control == null)
                control = new Control();

            if (!fluentDesignFormContainer1.Controls.Contains(control))
            {
                fluentDesignFormContainer1.Controls.Add(control);
                control.Dock = DockStyle.Fill;
                control.BringToFront();
            }
            control.BringToFront();
        }
        private void OpenForms(Form control)
        {           
            if (control == null)
                control = new Form();
            control.ShowDialog();
            control.BringToFront();
            fluentDesignFormControl1.Text = control.Text;
        }
        #endregion

        private void SetText()
        {
            fluentDesignFormControl1.Text = "App Professor";
        }
    }
}
