using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;

namespace ПР5_автокад_
{
    public partial class VLine : Form
    {
        public Point3d Point1 { get; private set; }
        public Point3d Point2 { get; private set; }

        public VLine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y) && double.TryParse(Zkoor.Text, out double z)
                && double.TryParse(X2koor.Text, out double x1) && double.TryParse(Y2koor.Text, out double y1) && double.TryParse(Z2koor.Text, out double z1))
            {
                Point1 = new Point3d(x, y, z);
                Point2 = new Point3d(x1, y1, z1);
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
