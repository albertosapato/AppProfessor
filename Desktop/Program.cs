using DataEntityFrameWork.Controllers;
using Desktop.Hels;
using Desktop.Hels.Settings;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Desktop
{
    static class Program
    {
        #region Variaveis Globais
        public static int GrupoID { get; internal set; }
        public static string ProgramName { get { return "AppProfessor"; } }
        public static string UserName { get; set; }
        #endregion

        [STAThread]
        static void Main()
        {
            try
            {
                #region Interno
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!Get45PlusFromRegistry())
                    Application.Exit();

                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");

                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle(
                    ObjectoUserSetings.Default.DefaultAppSkin,
                    ObjectoUserSetings.Default.DefaultPalette);

                WindowsFormsSettings.TouchUIMode = ObjectoUserSetings.Default.TouchUI == true ? TouchUIMode.True : TouchUIMode.False;
                WindowsFormsSettings.DefaultFont = ObjectoUserSetings.Default.DefaultAppFont;
                WindowsFormsSettings.DefaultPrintFont = ObjectoUserSetings.Default.DefaultAppFont;
                #endregion


                
                

                Mutex mt = new Mutex(true, name: "{26070B7C-21EC-4998-AB16-FE2BA4E25E10}");
                try
                {
                    if (mt.WaitOne(TimeSpan.Zero, true))
                    {
                        // Leitura do Splash
                        using (var f = new Progress_Bar())
                        {
                            f.Mostrar_Splash();
                            {
                                //#region Executar como Adminstrador
                                //// Executar como adminstrador
                                //if (!GetAdminstrador())
                                //{
                                //    XtraMessageBox.Show("Você precisa executar a aplicação usando a opção 'run as administrator'", "É preciso ser uma administrador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    Application.Exit();
                                //}
                                //#endregion

                                #region Validar Conexao do Sistema;
                                try
                                {
                                    ValidarConexao();
                                }
                                catch (Exception exException)
                                {
                                    f.Dispose();
                                    XtraMessageBox.Show("Lamentamos mais verifique o seu Servidor: O SQLSERVER não esta Indisponivel ou não foi instalado neste computador\n " + exException.Message + "\n\nDetalhes: \n" + exException.Message, "Erro do Servidor SQLServer 2014 ou 2016!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                #endregion                   
                            }
                        }
                        Application.Run(frmLogin.GetInstancia());
                    }
                    else
                        XtraMessageBox.Show("Desculpe mais a sua Aplicação Já esta em Execução\nTente fecha-la e volte a abrir novamente", "Aplicação já em Execução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mt.ReleaseMutex();
                }
            }
            catch
            {
                return;
            }
        }

        private static bool ValidarConexao()
        {
            try
            {
                var result = ConectionsControllers.GetInstacia().GetListFirstOrDefault();
                result.Wait();
                return result.Result == null ? true : false;
            }
            catch (System.Exception exe)
            {
                XtraMessageBox.Show("Sem conexão a internete\n" +
                                    "Ou sem ligação ao Servidor\n" +
                                    "Tente Reiniciar o computador para corrigir este erro de conexao\n" +
                                    "Feche sua aplicação e tente novamente depois de Reiniciares o computador!..."
                                     + exe.Message, "Conexão requerida",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                return false;
            }
        }

        #region Detectar Netframworks
        private static bool Get45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    if (((int)ndpKey.GetValue("Release")) >= 393295)
                        return true;
                    else
                        return false;
                }
                else
                {
                    MessageBox.Show("Lamentamos mais falta o .NET Framework Instalado no PC\nOu estas a executar uma versão abaixo do Requerido " + ".NET Framework Version: " + CheckFor45PlusVersion((int)ndpKey.GetValue("Release")) +
                                    "Click em Ok para abrir a pagina de instalação destas ferramentas:",
                                   ".NET Framework em Falta",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Process.Start("https://dotnet.microsoft.com/download/dotnet-framework-runtime");
                }
                return false;
            }
        }
        // Checking the version using >= will enable forward compatibility.
        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 461808)
                return "4.7.2 or later";
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
        #endregion
    }
}