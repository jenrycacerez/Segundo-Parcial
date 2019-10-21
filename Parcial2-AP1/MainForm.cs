using Parcial2_AP1.UI.Consultas;
using Parcial2_AP1.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_AP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas ca = new Consultas();
            ca.MdiParent = this;
            ca.Show();

        }

        private void RegistroCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RCategorias rc = new RCategorias();
            rc.MdiParent = this;
            rc.Show();
        }

        private void RegistroNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDetallecs rd = new RDetallecs();
            rd.MdiParent = this;
            rd.Show();
        }
    }
}
