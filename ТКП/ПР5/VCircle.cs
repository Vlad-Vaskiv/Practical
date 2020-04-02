using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;

namespace ПР5_автокад_
{
    public partial class VCircle : Form
    {
        public Point3d Center { get; private set; }

        public double Radius { get; private set; }

        public VCircle()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y) && double.TryParse(Radiuskoor.Text, out double radius))
            {
                Center = new Point3d(x,y,0);
                Radius = radius;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Данные не подходят для постройки круга.");
            }
        }

        private void Xkoor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
