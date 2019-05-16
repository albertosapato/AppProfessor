using Desktop.Hels.Settings;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Desktop.View.Helps
{
    public partial class frmDefinicoes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Timer Time_;
        public frmDefinicoes()
        {
            InitializeComponent();
            this.Load += FrmDefinicoes_Load;
            this.FormClosing += FrmDefinicoes_FormClosing;

            Time_ = new Timer();
            Time_.Enabled = true;
            Time_.Start();
            Time_.Tick += T_Tick;

            txtUsuarios.Caption = $"USUÁRIO: {Program.UserName}" ;
            btnTatil.EditValueChanged += delegate { ribbonControl1.OptionsTouch.TouchUI = (bool) btnTatil.EditValue == true ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False; };
            btnFonte.EditValueChanged += delegate 
            {
                WindowsFormsSettings.DefaultFont = (Font) btnFonte.EditValue;
            };
        }

        private void T_Tick(object sender, EventArgs e)
        {
            txtDateTime.EditValue = String.Format("{0:F}", DateTime.Now);
        }
        private void FrmDefinicoes_Load(object sender, System.EventArgs e)
        {
            LeituraSkins();
        }
        private void FrmDefinicoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            FecharSkins();
        }
        private void FecharSkins()
        {
            try
            {
                var objectoUserSetings = ObjectoUserSetings.Default;
                //defaultLookAndFeel1.LookAndFeel.SetSkinStyle(objectoUserSetings.DefaultAppSkin, objectoUserSetings.DefaultPalette);
                objectoUserSetings.DefaultAppSkin = defaultLookAndFeel1.LookAndFeel.SkinName;
                objectoUserSetings.DefaultPalette = skinPaletteRibbonGalleryBarItem1.Caption;
                objectoUserSetings.TouchUI = (bool)btnTatil.EditValue;
                objectoUserSetings.DefaultAppFont = (Font) btnFonte.EditValue;
                objectoUserSetings.Save();

                // Propriedades de Fundo
                var formsColor = FormsColor.Default;
                formsColor.ForeColorAll = (Color)btnForeColorAll.EditValue;
                formsColor.PainelFundo = (Color) btnPainelFundo.EditValue;
                formsColor.PainelTopBooton = (Color)btnPainelTop.EditValue;
                formsColor.Save();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }       
        }
        private void LeituraSkins()
        {
            try
            {
                // Propriedades de Aparencias
                var objectoUserSetings = ObjectoUserSetings.Default;
                defaultLookAndFeel1.LookAndFeel.SetSkinStyle(objectoUserSetings.DefaultAppSkin, objectoUserSetings.DefaultPalette);
                btnTatil.EditValue = (bool)objectoUserSetings.TouchUI;
                btnFonte.EditValue = objectoUserSetings.DefaultAppFont;

                // Propriedades de Fundo
                var formsColor = FormsColor.Default;
                btnForeColorAll.EditValue = formsColor.ForeColorAll;
                btnPainelFundo.EditValue = formsColor.PainelFundo;
                btnPainelTop.EditValue = formsColor.PainelTopBooton;

                // WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode..
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fontDialog1.Font = (Font)btnFonte.EditValue;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                btnFonte.EditValue = fontDialog1.Font;
            };
        }
    }
}