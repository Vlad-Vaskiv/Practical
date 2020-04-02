using Autodesk.AutoCAD.Geometry;
using System;
using System.Windows.Forms;

namespace ПР5_автокад_
{
    public partial class VPoint : Form
    {
        public Point3d Tochka { get; private set; }

        public VPoint()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(Xkoor.Text, out double x) && double.TryParse(Ykoor.Text, out double y) && double.TryParse(Zkoor.Text, out double z))
            {
                Tochka = new Point3d(x, y, z);
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
