using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;


namespace ПР5_автокад_
{
    public partial class Vpolyline : Form
    {
        public Point2d Point1 { get; private set; }
        public Point2d Point2 { get; private set; }
        public Point2d Point3 { get; private set; }

        public Vpolyline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y)
                && double.TryParse(X2koor.Text, out double x1) && double.TryParse(Y2koor.Text, out double y1)
                && double.TryParse(X2koor.Text, out double x3) && double.TryParse(Y2koor.Text, out double y3))
            {
                Point1 = new Point2d(x, y);
                Point2 = new Point2d(x1, y1);
                Point2 = new Point2d(x3, y3);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Данные не подходят для постройки точки.");
            }
        }
    }
}
