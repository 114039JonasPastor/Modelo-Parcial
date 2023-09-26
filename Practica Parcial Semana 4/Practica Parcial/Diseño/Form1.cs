using Practica_Parcial.Datos;
using Practica_Parcial.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Parcial
{
    public partial class FrmRegistrarOrdenRetiro : Form
    {
        Helper gestor = null;
        private OrdenRetiro nuevo;
        public FrmRegistrarOrdenRetiro()
        {
            InitializeComponent();
            gestor = new Helper();
            nuevo = new OrdenRetiro();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtResponsable.Text == String.Empty)
            {
                MessageBox.Show("Debe de ingresar un responsable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(dgvOrden.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GuardarOrden();
        }

        private void GuardarOrden()
        {
            nuevo.Responsable = txtResponsable.Text;
            nuevo.Fecha = dtpFecha.Value;
            if (gestor.ConfimarOrden(nuevo))
            {
                MessageBox.Show("Se guardo la orden con exito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se pudo guardar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRegistrarOrdenRetiro_Load(object sender, EventArgs e)
        {
            CargarCombo();
            cmbMaterial.SelectedIndex = -1;
        }

        private void CargarCombo()
        {
            DataTable tabla = gestor.Consultar("SP_CONSULTAR_MATERIALES");
            cmbMaterial.DataSource = tabla;
            cmbMaterial.ValueMember = tabla.Columns[0].ColumnName;
            cmbMaterial.DisplayMember = tabla.Columns[1].ColumnName;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if(nudCantidad.Value <= 0)
            {
                MessageBox.Show("Ingrese un numero valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar al menos un material", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach(DataGridViewRow row in dgvOrden.Rows)
            {
                if (row.Cells["ColMaterial"].Value.ToString().Equals(cmbMaterial.Text))
                {
                    MessageBox.Show("El material: " + cmbMaterial.Text + " ya se encuentra como detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRowView item = (DataRowView)cmbMaterial.SelectedItem;

            int id = Convert.ToInt32(item.Row.ItemArray[0]);
            string material = item.Row.ItemArray[1].ToString();
            int stock = Convert.ToInt32(item.Row.ItemArray[2]);
            Material m = new Material(id, material, stock);

            int cantidad = (int)nudCantidad.Value;

            DetalleOrden detalle = new DetalleOrden(cantidad, m);
            nuevo.AgregarDetalle(detalle);

            dgvOrden.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], item.Row.ItemArray[2], nudCantidad.Value.ToString() });
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvOrden.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvOrden.CurrentRow.Index);
                dgvOrden.Rows.Remove(dgvOrden.CurrentRow);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
