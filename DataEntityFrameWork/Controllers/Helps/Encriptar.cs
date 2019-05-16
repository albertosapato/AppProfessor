namespace DataEntityFrameWork.Controllers.Helps
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    public static class Encriptar
    {
        private static string Key = "iSoft2018";
        private static Rfc2898DeriveBytes pdb = null;
        private static MemoryStream ms = null;
        private static CryptoStream cs = null;
        public static string GetMD5Hash(string imput)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(imput);
                b = provider.ComputeHash(b);
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (var item in b)
                    sb.Append(item.ToString("x2"));
                return sb.ToString();
            }
        }

        public static string EncriptarSenha(string Entrada)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(Entrada);
                using (Aes encryptor = Aes.Create())
                {
                    pdb = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (ms = new MemoryStream())
                    {
                        using (cs = new CryptoStream(ms,
                                    encryptor.CreateEncryptor(),
                                    CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        Entrada = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                fechar();
            }
            return Entrada.ToString();
        }
        public static string DesencriptarSenha(string Saida)
        {
            try
            {
                Saida = Saida.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(Saida);
                using (Aes encryptor = Aes.Create())
                {
                    pdb = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (ms = new MemoryStream())
                    {
                        using (cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        Saida = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(" Contacte o adminstrador do systema " + exe.Message, "Erro");
            }
            finally
            {
                fechar();
            }
            return Saida;
        }
        public static void fechar()
        {
            if (pdb != null)
            {
                pdb.Dispose();
                pdb = null;
            }
            else if (ms != null)
            {
                ms.Close();
                ms.Dispose();
                ms = null;
            }
            else if (cs != null)
            {
                cs.Close();
                cs.Dispose();
                cs = null;
            }
        }
    }
}
