using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;

namespace ПР5_автокад_
{
    public partial class VSquare : Form
    {
        public Point2d Point1 { get; private set; }
        public Point2d Point2 { get; private set; }
        public Point2d Point3 { get; private set; }
        public Point2d Point4 { get; private set; }
        public double Storona { get; private set; }

        public VSquare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y) && double.TryParse(W.Text, out double storona))
            {
                Storona = storona;
                Point1 = new Point2d(x,y);
                Point2 = new Point2d(x, y+storona);
                Point3 = new Point2d(x-storona, y+storona);
                Point4 = new Point2d(x-storona, y);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Данные не подходят для постройки квадрата.");
            }
        }
    }
}
