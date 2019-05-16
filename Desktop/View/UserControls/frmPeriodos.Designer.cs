namespace Desktop
{
    partial class frmPeriodos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeriodos));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contAtualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contApagar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.ContBaseDeDados = new System.Windows.Forms.ToolStripMenuItem();
            this.periodoViewModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPeriodoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodoNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.periodoViewModelsBindingSource)).BeginInit();
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
            this.gridControl1.DataSource = this.periodoViewModelsBindingSource;
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
            // periodoViewModelsBindingSource
            // 
            this.periodoViewModelsBindingSource.DataSource = typeof(DataEntityFrameWork.ViewModels.PeriodoViewModels);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPeriodoID,
            this.colPeriodoNome,
            this.colDescricao});
            this.gridView1.DetailHeight = 239;
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPeriodoID
            // 
            this.colPeriodoID.Caption = "Código";
            this.colPeriodoID.FieldName = "PeriodoID";
            this.colPeriodoID.MinWidth = 13;
            this.colPeriodoID.Name = "colPeriodoID";
            this.colPeriodoID.Visible = true;
            this.colPeriodoID.VisibleIndex = 0;
            this.colPeriodoID.Width = 109;
            // 
            // colPeriodoNome
            // 
            this.colPeriodoNome.Caption = "Periodos";
            this.colPeriodoNome.FieldName = "PeriodoNome";
            this.colPeriodoNome.MinWidth = 13;
            this.colPeriodoNome.Name = "colPeriodoNome";
            this.colPeriodoNome.Visible = true;
            this.colPeriodoNome.VisibleIndex = 1;
            this.colPeriodoNome.Width = 206;
            // 
            // colDescricao
            // 
            this.colDescricao.Caption = "Descrição";
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.MinWidth = 13;
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 2;
            this.colDescricao.Width = 210;
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
            this.txtPesquisar.Size = new System.Drawing.Size(407, 20);
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
            this.layoutControlItem2.Size = new System.Drawing.Size(469, 24);
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
            this.btnNovos.Location = new System.Drawing.Point(477, 8);
            this.btnNovos.Name = "btnNovos";
            this.btnNovos.Size = new System.Drawing.Size(73, 22);
            this.btnNovos.StyleController = this.dataLayoutControl1;
            this.btnNovos.TabIndex = 8;
            this.btnNovos.Text = "Novo";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnNovos;
            this.layoutControlItem3.Location = new System.Drawing.Point(469, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(75, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPeriodos";
            this.Size = new System.Drawing.Size(574, 376);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.periodoViewModelsBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource periodoViewModelsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodoID;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodoNome;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraEditors.SimpleButton btnNovos;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
