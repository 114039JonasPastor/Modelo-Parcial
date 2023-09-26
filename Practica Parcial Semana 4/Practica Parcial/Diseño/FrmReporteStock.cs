using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Parcial.Diseño
{
    public partial class FrmReporteStock : Form
    {
        public FrmReporteStock()
        {
            InitializeComponent();
        }

        private void FrmReporteStock_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetStock.SP_REPORTE_STOCK' Puede moverla o quitarla según sea necesario.
            this.sP_REPORTE_STOCKTableAdapter.Fill(this.dataSetStock.SP_REPORTE_STOCK);

            this.reportViewer1.RefreshReport();
        }
    }
}
