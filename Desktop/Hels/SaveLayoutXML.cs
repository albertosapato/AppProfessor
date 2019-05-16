namespace Desktop.Hels
{
    using System;
    using System.IO;
    public class SaveLayoutXML : IDisposable
    {
        private string Directo;
        public string Loader(string Ficheiro)
        {
            Directo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directo = System.IO.Path.Combine(Directo, "DesignerLayoutAppProfessor");

            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);

            string Filename = string.Format("{0}/{1}.xml", Directo, Ficheiro);

            if (File.Exists(Filename))
                return Filename;
            else
                return string.Empty;
        }
        public string Restore(string Ficheiro)
        {
            Directo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directo = System.IO.Path.Combine(Directo, "DesignerLayoutAppProfessor");

            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);

            string Filename = string.Format("{0}/{1}.xml", Directo, Ficheiro);

            if (!File.Exists(Filename))
                return Filename;
            else
                return string.Empty;
        }
        public string fileName(string Ficheiro)
        {
            Directo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directo = System.IO.Path.Combine(Directo, "DesignerLayoutAppProfessor");

            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);

            return string.Format("{0}/{1}.xml", Directo, Ficheiro);
        }
        public void Dispose()
        {
            Directo = null;
        }
    }
}
