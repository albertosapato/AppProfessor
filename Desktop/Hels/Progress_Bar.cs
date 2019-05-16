namespace Desktop.Hels
{
    using DevExpress.XtraBars.ToastNotifications;
    using DevExpress.XtraEditors;
    using DevExpress.XtraSplashScreen;
    using System;
    using System.Windows.Forms;
    public class Progress_Bar: IDisposable
    {
        public Form form { get; set; }
        public void Dispose()
        {
            form?.Dispose();
            Mostrar_Close();
        }
        public Progress_Bar(Form Form)
        {
            this.form = Form;
        }
        public Progress_Bar()
        {

        }
        public void Mostrar(Form C)
        {
            SplashScreenManager.ShowForm(C, typeof(WaitForm1), true, true, true);
            SplashScreenManager.Default.SetWaitFormCaption("A processar seu pedido so mais um instante!...");
            SplashScreenManager.Default.SetWaitFormDescription("Aguarde por favor");
        }
        public void Mostrar(string Captione, string Descricao)
        {
            SplashScreenManager.ShowForm(form, typeof(WaitForm1), true, true, true);
            SplashScreenManager.Default.SetWaitFormCaption(Captione);
            SplashScreenManager.Default.SetWaitFormDescription(Descricao);
        }
        public void Mostrar(XtraForm C)
        {
            try
            {
                SplashScreenManager.ShowForm(C, typeof(WaitForm1), true, true, true);
            }
            catch (Exception)
            {
                return;
            }
            finally
            {

            }
        }
        public void Mostrar(Form C, string Caption, string Descricao)
        {
            try
            {
                SplashScreenManager.ShowForm(C, typeof(WaitForm1), true, true, true);
                SplashScreenManager.Default.SetWaitFormCaption(Caption);
                SplashScreenManager.Default.SetWaitFormDescription(Descricao);
            }
            catch (Exception)
            {
                return;
            }
            finally
            {

            }
        }
        public void Mostrar_Close()
        {
            try
            {
                SplashScreenManager.CloseForm(true);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void Mostrar_Close(Form C)
        {
            try
            {
                SplashScreenManager.CloseForm(true);
            }
            catch (Exception)
            {
                return;
            }
        }
        public void ToastSave(Form F, string Messagem)
        {
            using (ToastNotification notification = new ToastNotification("FFFFF",
                null,
                "N:",
                "Notificação",
                Messagem, ToastNotificationTemplate.Generic))
            {

            }
        }
        public void ToastSave(Form F, string Messagem, System.Drawing.Image image)
        {
            ToastNotification r = new ToastNotification
            ("FFFFF",
                true ? image : null,
                "N:",
                "Notificação",
                Messagem, ToastNotificationTemplate.Generic);
        }
        public void Mostrar_Splash()
        {
            try
            {
                SplashScreenManager.ShowForm(this.form, typeof(frmSplah), true, true, true);
            }
            catch { return; }
        }
        public void Mostrar_Aguardando()
        {
            try
            {
                SplashScreenManager.ShowForm(this.form, typeof(frmSplah), true, true, true);
            }
            catch { return; }
        }
    }
}
