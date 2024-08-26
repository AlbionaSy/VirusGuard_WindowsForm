using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusGuard_Antivirus.Helpers;

namespace VirusGuard_Antivirus
{
    public partial class ThreatsFound : UserControl
    {
        public ThreatsFound()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in VirusHelper.Threats)
            {
                File.Delete(item);
            }
            VirusHelper.Threats.Clear();
            MessageBox.Show("Threats removed!");
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
