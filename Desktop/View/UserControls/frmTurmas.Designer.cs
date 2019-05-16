namespace Desktop
{
    partial class frmTurmas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurmas));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contAtualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contApagar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.ContBaseDeDados = new System.Windows.Forms.ToolStripMenuItem();
            this.turmasViewModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTurmasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurmasNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSala = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdadeInicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdadeFim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClasses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCursosID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCursos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtPesquisar = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnNovos = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.turmasViewModelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridControl1.DataSource = this.turmasViewModelsBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.gridControl1.Location = new System.Drawing.Point(8, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(542, 320);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.contAtualizar,
            this.toolStripSeparator3,
            this.contApagar,
            this.toolStripSeparator2,
            this.contRelatorios,
            this.ContBaseDeDados});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 174);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // contAtualizar
            // 
            this.contAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("contAtualizar.Image")));
            this.contAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contAtualizar.Name = "contAtualizar";
            this.contAtualizar.Size = new System.Drawing.Size(229, 38);
            this.contAtualizar.Text = "Editar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(226, 6);
            // 
            // contApagar
            // 
            this.contApagar.Image = ((System.Drawing.Image)(resources.GetObject("contApagar.Image")));
            this.contApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contApagar.Name = "contApagar";
            this.contApagar.Size = new System.Drawing.Size(229, 38);
            this.contApagar.Text = "Apagar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // contRelatorios
            // 
            this.contRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("contRelatorios.Image")));
            this.contRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contRelatorios.Name = "contRelatorios";
            this.contRelatorios.Size = new System.Drawing.Size(229, 38);
            this.contRelatorios.Text = "Relatórios";
            // 
            // ContBaseDeDados
            // 
            this.ContBaseDeDados.Image = ((System.Drawing.Image)(resources.GetObject("ContBaseDeDados.Image")));
            this.ContBaseDeDados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ContBaseDeDados.Name = "ContBaseDeDados";
            this.ContBaseDeDados.Size = new System.Drawing.Size(229, 38);
            this.ContBaseDeDados.Text = "Relatórios (Base de Dados)";
            // 
            // turmasViewModelsBindingSource
            // 
            this.turmasViewModelsBindingSource.DataSource = typeof(DataEntityFrameWork.ViewModels.TurmasViewModels);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTurmasID,
            this.colTurmasNome,
            this.colDescricao,
            this.colSala,
            this.colQuantidade,
            this.colIdadeInicio,
            this.colIdadeFim,
            this.colClassesID,
            this.colClasses,
            this.colCursosID,
            this.colCursos,
            this.colPeriodoID,
            this.colPeriodo});
            this.gridView1.DetailHeight = 239;
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colTurmasID
            // 
            this.colTurmasID.Caption = "Código";
            this.colTurmasID.FieldName = "TurmasID";
            this.colTurmasID.MinWidth = 13;
            this.colTurmasID.Name = "colTurmasID";
            this.colTurmasID.Visible = true;
            this.colTurmasID.VisibleIndex = 0;
            this.colTurmasID.Width = 56;
            // 
            // colTurmasNome
            // 
            this.colTurmasNome.Caption = "Turma";
            this.colTurmasNome.FieldName = "TurmasNome";
            this.colTurmasNome.MinWidth = 13;
            this.colTurmasNome.Name = "colTurmasNome";
            this.colTurmasNome.Visible = true;
            this.colTurmasNome.VisibleIndex = 1;
            // 
            // colDescricao
            // 
            this.colDescricao.Caption = "Descrição";
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.MinWidth = 13;
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 2;
            this.colDescricao.Width = 78;
            // 
            // colSala
            // 
            this.colSala.Caption = "Sala";
            this.colSala.FieldName = "Sala";
            this.colSala.MinWidth = 13;
            this.colSala.Name = "colSala";
            this.colSala.Visible = true;
            this.colSala.VisibleIndex = 3;
            this.colSala.Width = 41;
            // 
            // colQuantidade
            // 
            this.colQuantidade.Caption = "Qtd";
            this.colQuantidade.FieldName = "Quantidade";
            this.colQuantidade.MinWidth = 13;
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.Visible = true;
            this.colQuantidade.VisibleIndex = 4;
            this.colQuantidade.Width = 31;
            // 
            // colIdadeInicio
            // 
            this.colIdadeInicio.Caption = "I. Inicial";
            this.colIdadeInicio.FieldName = "IdadeInicio";
            this.colIdadeInicio.MinWidth = 13;
            this.colIdadeInicio.Name = "colIdadeInicio";
            this.colIdadeInicio.Visible = true;
            this.colIdadeInicio.VisibleIndex = 5;
            this.colIdadeInicio.Width = 60;
            // 
            // colIdadeFim
            // 
            this.colIdadeFim.Caption = "I. Finial";
            this.colIdadeFim.FieldName = "IdadeFim";
            this.colIdadeFim.MinWidth = 13;
            this.colIdadeFim.Name = "colIdadeFim";
            this.colIdadeFim.Visible = true;
            this.colIdadeFim.VisibleIndex = 6;
            this.colIdadeFim.Width = 53;
            // 
            // colClassesID
            // 
            this.colClassesID.Caption = "Classe";
            this.colClassesID.FieldName = "Classes.ClassesNome";
            this.colClassesID.MinWidth = 13;
            this.colClassesID.Name = "colClassesID";
            this.colClassesID.Visible = true;
            this.colClassesID.VisibleIndex = 7;
            this.colClassesID.Width = 47;
            // 
            // colClasses
            // 
            this.colClasses.FieldName = "Classes";
            this.colClasses.MinWidth = 13;
            this.colClasses.Name = "colClasses";
            this.colClasses.Width = 23;
            // 
            // colCursosID
            // 
            this.colCursosID.Caption = "Cursos";
            this.colCursosID.FieldName = "Cursos.CursosNome";
            this.colCursosID.MinWidth = 13;
            this.colCursosID.Name = "colCursosID";
            this.colCursosID.Visible = true;
            this.colCursosID.VisibleIndex = 8;
            this.colCursosID.Width = 40;
            // 
            // colCursos
            // 
            this.colCursos.FieldName = "Cursos";
            this.colCursos.MinWidth = 13;
            this.colCursos.Name = "colCursos";
            this.colCursos.Width = 23;
            // 
            // colPeriodoID
            // 
            this.colPeriodoID.Caption = "Períodos";
            this.colPeriodoID.FieldName = "Periodo.PeriodoNome";
            this.colPeriodoID.MinWidth = 13;
            this.colPeriodoID.Name = "colPeriodoID";
            this.colPeriodoID.Visible = true;
            this.colPeriodoID.VisibleIndex = 9;
            this.colPeriodoID.Width = 45;
            // 
            // colPeriodo
            // 
            this.colPeriodo.FieldName = "Periodo";
            this.colPeriodo.MinWidth = 13;
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.Width = 47;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(574, 376);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnNovos);
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.txtPesquisar);
            this.dataLayoutControl1.Location = new System.Drawing.Point(8, 8);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(558, 360);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(68, 8);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPesquisar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPesquisar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPesquisar.Properties.NullValuePrompt = "Digite aqui um texto para pesquisar!...";
            this.txtPesquisar.Properties.ShowNullValuePromptWhenFocused = true;
            this.txtPesquisar.Size = new System.Drawing.Size(416, 20);
            this.txtPesquisar.StyleController = this.dataLayoutControl1;
            this.txtPesquisar.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(558, 360);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPesquisar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(478, 24);
            this.layoutControlItem2.Text = "Pesquisar...";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(544, 322);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(574, 376);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(560, 362);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnNovos
            // 
            this.btnNovos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNovos.ImageOptions.Image")));
            this.btnNovos.Location = new System.Drawing.Point(486, 8);
            this.btnNovos.Name = "btnNovos";
            this.btnNovos.Size = new System.Drawing.Size(64, 22);
            this.btnNovos.StyleController = this.dataLayoutControl1;
            this.btnNovos.TabIndex = 10;
            this.btnNovos.Text = "Novo";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnNovos;
            this.layoutControlItem3.Location = new System.Drawing.Point(478, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(66, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmTurmas";
            this.Size = new System.Drawing.Size(574, 376);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.turmasViewModelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit txtPesquisar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem contAtualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contApagar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contRelatorios;
        private System.Windows.Forms.ToolStripMenuItem ContBaseDeDados;
        private System.Windows.Forms.BindingSource turmasViewModelsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTurmasID;
        private DevExpress.XtraGrid.Columns.GridColumn colTurmasNome;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colSala;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidade;
        private DevExpress.XtraGrid.Columns.GridColumn colIdadeInicio;
        private DevExpress.XtraGrid.Columns.GridColumn colIdadeFim;
        private DevExpress.XtraGrid.Columns.GridColumn colClassesID;
        private DevExpress.XtraGrid.Columns.GridColumn colClasses;
        private DevExpress.XtraGrid.Columns.GridColumn colCursosID;
        private DevExpress.XtraGrid.Columns.GridColumn colCursos;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodoID;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodo;
        private DevExpress.XtraEditors.SimpleButton btnNovos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
