namespace Desktop
{
    partial class frmLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label6 = new System.Windows.Forms.Label();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtModos = new System.Windows.Forms.Label();
            this.btnMudar_Password = new System.Windows.Forms.LinkLabel();
            this.painel_login_Password = new System.Windows.Forms.GroupBox();
            this.txtPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.txtUsuários = new DevExpress.XtraEditors.TextEdit();
            this.PhotoPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.painel_login_Password.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuários.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 465);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Lembre-me deste Usuário";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSwitch1.Location = new System.Drawing.Point(431, 19);
            this.toggleSwitch1.Margin = new System.Windows.Forms.Padding(4);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Ñ guardar";
            this.toggleSwitch1.Properties.OnText = "Guardar";
            this.toggleSwitch1.Size = new System.Drawing.Size(169, 26);
            this.toggleSwitch1.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(564, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 41);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtModos
            // 
            this.txtModos.AutoSize = true;
            this.txtModos.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModos.Location = new System.Drawing.Point(20, 15);
            this.txtModos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtModos.Name = "txtModos";
            this.txtModos.Size = new System.Drawing.Size(72, 19);
            this.txtModos.TabIndex = 0;
            this.txtModos.Text = "iSoft 2019";
            // 
            // btnMudar_Password
            // 
            this.btnMudar_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMudar_Password.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMudar_Password.Image = ((System.Drawing.Image)(resources.GetObject("btnMudar_Password.Image")));
            this.btnMudar_Password.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMudar_Password.Location = new System.Drawing.Point(8, 21);
            this.btnMudar_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnMudar_Password.Name = "btnMudar_Password";
            this.btnMudar_Password.Size = new System.Drawing.Size(234, 35);
            this.btnMudar_Password.TabIndex = 3;
            this.btnMudar_Password.TabStop = true;
            this.btnMudar_Password.Text = "Mudar Password (F1)";
            this.btnMudar_Password.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // painel_login_Password
            // 
            this.painel_login_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.painel_login_Password.Controls.Add(this.txtPassword);
            this.painel_login_Password.Controls.Add(this.txtUsuários);
            this.painel_login_Password.Controls.Add(this.PhotoPictureEdit);
            this.painel_login_Password.Controls.Add(this.btnCancelar);
            this.painel_login_Password.Controls.Add(this.btnEntrar);
            this.painel_login_Password.Location = new System.Drawing.Point(96, 74);
            this.painel_login_Password.Margin = new System.Windows.Forms.Padding(4);
            this.painel_login_Password.Name = "painel_login_Password";
            this.painel_login_Password.Padding = new System.Windows.Forms.Padding(4);
            this.painel_login_Password.Size = new System.Drawing.Size(453, 387);
            this.painel_login_Password.TabIndex = 1;
            this.painel_login_Password.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(46, 240);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPassword.Properties.NullValuePrompt = "Senha/Pin";
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(376, 24);
            this.txtPassword.TabIndex = 24;
            // 
            // txtUsuários
            // 
            this.txtUsuários.Location = new System.Drawing.Point(46, 183);
            this.txtUsuários.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuários.Name = "txtUsuários";
            this.txtUsuários.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUsuários.Properties.Appearance.Options.UseFont = true;
            this.txtUsuários.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUsuários.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtUsuários.Properties.NullValuePrompt = "Email/Login";
            this.txtUsuários.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtUsuários.Size = new System.Drawing.Size(376, 24);
            this.txtUsuários.TabIndex = 23;
            // 
            // PhotoPictureEdit
            // 
            this.PhotoPictureEdit.EditValue = ((object)(resources.GetObject("PhotoPictureEdit.EditValue")));
            this.PhotoPictureEdit.Location = new System.Drawing.Point(164, 28);
            this.PhotoPictureEdit.Margin = new System.Windows.Forms.Padding(4);
            this.PhotoPictureEdit.Name = "PhotoPictureEdit";
            this.PhotoPictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PhotoPictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.PhotoPictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PhotoPictureEdit.Properties.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle;
            this.PhotoPictureEdit.Properties.OptionsMask.Offset = new System.Drawing.Point(0, -20);
            this.PhotoPictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.PhotoPictureEdit.Size = new System.Drawing.Size(163, 141);
            this.PhotoPictureEdit.TabIndex = 22;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(261, 301);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(162, 57);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrar.Image")));
            this.btnEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntrar.Location = new System.Drawing.Point(46, 301);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(148, 57);
            this.btnEntrar.TabIndex = 2;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Informação Geral";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Controls.Add(this.txtModos);
            this.panelControl1.Controls.Add(this.painel_login_Password);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(639, 558);
            this.panelControl1.TabIndex = 11;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panelControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panelControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toggleSwitch1);
            this.groupBox1.Controls.Add(this.btnMudar_Password);
            this.groupBox1.Location = new System.Drawing.Point(10, 482);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(618, 66);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 558);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.painel_login_Password.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuários.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox painel_login_Password;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label txtModos;
        private System.Windows.Forms.LinkLabel btnMudar_Password;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit PhotoPictureEdit;
        private DevExpress.XtraEditors.ButtonEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsuários;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}