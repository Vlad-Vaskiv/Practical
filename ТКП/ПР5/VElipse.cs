using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;

namespace ПР5_автокад_
{
    public partial class VElipse : Form
    {
        public Point3d center { get; private set; }

        public double Radius { get; private set; }

        public Vector3d normal { get; private set; }

        public double MV { get; private set; }

        public VElipse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y) && double.TryParse(Zkoor.Text, out double z)
                && double.TryParse(Radiuskoor.Text, out double radius)&& double.TryParse(MajorVector.Text, out double mv))
            {
                center = new Point3d(x, y, z);
                Radius = radius;
                MV = mv;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Данные не подходят для постройки круга.");
            }
        }
    }
}
