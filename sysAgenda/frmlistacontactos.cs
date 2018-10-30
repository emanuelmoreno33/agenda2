using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sysAgenda
{
    public partial class frmlistacontactos : Form
    {
        public frmlistacontactos()
        {
            InitializeComponent();
        }

        private void frmlistacontactos_Load(object sender, EventArgs e)
        {
            contacto persona = new contacto();
            rpListaContactos rpt = new rpListaContactos();
            rpt.SetDataSource(persona.ListarContacto());
            this.crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

    }
}
