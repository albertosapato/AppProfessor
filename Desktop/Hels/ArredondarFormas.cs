namespace Desktop.Hels
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public static class ArredondarFormas
    {
        public static void BordasCurvas(Control btnNovo)
        {
            using (var ellipseRadius = new GraphicsPath())
            {
                ellipseRadius.StartFigure();
                ellipseRadius.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);

                ellipseRadius.AddLine(20, 0, btnNovo.Width - 20, 0);
                ellipseRadius.AddArc(new Rectangle(btnNovo.Width - 20, 0, 20, 20), -90, 90);
                ellipseRadius.AddLine(btnNovo.Width, 20, btnNovo.Width, btnNovo.Height - 20);
                ellipseRadius.AddArc(new Rectangle(btnNovo.Width - 20, btnNovo.Height - 20, 20, 20), 0, 90);
                ellipseRadius.AddLine(btnNovo.Width - 20, btnNovo.Height, 20, btnNovo.Height);
                ellipseRadius.AddArc(new Rectangle(0, btnNovo.Height - 20, 20, 20), 90, 90);
                ellipseRadius.CloseFigure();
                btnNovo.Region = new Region(ellipseRadius);
            }
        }
        public static void BordasCirculos(Control obj)
        {
            using (GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath())
            {
                gp.AddEllipse(0, 0, obj.Width - 3, obj.Height - 3);
                Region rg = new Region(gp);
                obj.Region = rg;
            }
        }
        public static void BordasCurvas(List<Control> btnNovo)
        {
            foreach (var item in btnNovo)
            {
                using (var ellipseRadius = new GraphicsPath())
                {
                    ellipseRadius.StartFigure();
                    ellipseRadius.AddArc(new Rectangle(0, 0, 20, 20), 180, 90);

                    ellipseRadius.AddLine(20, 0, item.Width - 20, 0);
                    ellipseRadius.AddArc(new Rectangle(item.Width - 20, 0, 20, 20), -90, 90);
                    ellipseRadius.AddLine(item.Width, 20, item.Width, item.Height - 20);
                    ellipseRadius.AddArc(new Rectangle(item.Width - 20, item.Height - 20, 20, 20), 0, 90);
                    ellipseRadius.AddLine(item.Width - 20, item.Height, 20, item.Height);
                    ellipseRadius.AddArc(new Rectangle(0, item.Height - 20, 20, 20), 90, 90);
                    ellipseRadius.CloseFigure();
                    item.Region = new Region(ellipseRadius);
                }
            }
        }
    }
}
