using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Hels
{
    public class ImagemTratamento
    {
        public static Image redimensionarImagem(Image imagem, Size tamanho)
        {
            int larguraOrigem = imagem.Width;
            int alturaOrigem = imagem.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)tamanho.Width / (float)larguraOrigem);
            nPercentH = ((float)tamanho.Height / (float)alturaOrigem);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int larguraDestino = (int)(larguraOrigem * nPercent);
            int alturaDestino = (int)(alturaOrigem * nPercent);

            Bitmap b = new Bitmap(larguraDestino, alturaDestino);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imagem, 0, 0, larguraDestino, alturaDestino);
            g.Dispose();

            return (Image)b;
        }
        #region Métodos de Imagem
        public static object byteArrayToImage(object byteArrayIn)
        {
            if ((byteArrayIn == DBNull.Value))
            {
                return null;
            }
            else
            {
                using (MemoryStream mStream = new MemoryStream((byte[])byteArrayIn))
                {
                    return Image.FromStream(mStream);
                }
            }
        }
        public static object ImageToByteArray(object img)
        {
            if ((img == null) || (img == DBNull.Value))
            {
                return null;
            }
            else
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    Bitmap bmpImage = new Bitmap(ImagemTratamento.redimensionarImagem((Image)img,
                                      new Size(800, 590)));
                    bmpImage.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] data = mStream.GetBuffer();
                    return data;
                }
            }
        }
        #endregion
        public static object ImagemBuscar()
        {
            var openFileDialog1 = new OpenFileDialog();
            var _with1 = openFileDialog1;

            _with1.Filter = ("Arquivos de Imagem |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
            _with1.FilterIndex = 4;
            //Reset the file name
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                return Image.FromFile(openFileDialog1.FileName);
            else
                return null;
        }
        public static void ImagemCirculoAplica(DataGridView dataGridView1, int position)
        {
            try
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    byte[] bits = new byte[0];
                    bits = (byte[])r.Cells[position].Value;
                    MemoryStream ms = new MemoryStream(bits);
                    System.Drawing.Image imgSave = System.Drawing.Image.FromStream(ms);
                    r.Cells[position].Value = MakeCircleImage(imgSave);
                }

            }
            catch (Exception)
            {
                return;
            }
        }
        public static Image MakeCircleImage(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gpImg = new GraphicsPath())
            {

                gpImg.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.Clear(Color.White);
                    grp.SetClip(gpImg);
                    grp.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }
    }
}
