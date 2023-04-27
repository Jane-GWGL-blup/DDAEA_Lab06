using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DemoADONET2023
{
    public partial class NuevoProducto : Form
    {
        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Insertar(new Entidad.Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    FechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text),
                    Estado = Convert.ToBoolean(txtEstado.Text),

                });
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);

            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            BProducto negocio = new BProducto();
            dgvProducto.DataSource = negocio.Listar(txtNombre.Text);

        }



        private void txtFechaCreacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProducto_DoubleClick(object sender, EventArgs e)
        {
            txtIdProducto.Text = dgvProducto.CurrentRow.Cells["IdProducto"].Value.ToString();
            txtNombre.Text = dgvProducto.CurrentRow.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = dgvProducto.CurrentRow.Cells["Precio"].Value.ToString();
            txtFechaCreacion.Text = dgvProducto.CurrentRow.Cells["FechaCreacion"].Value.ToString();
            txtEstado.Text = dgvProducto.CurrentRow.Cells["Estado"].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Actualizar(new Entidad.Producto
                {
                    IdProducto=int.Parse(txtIdProducto.Text),
                    Nombre = txtNombre.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    FechaCreacion = Convert.ToDateTime(txtFechaCreacion.Text),
                    Estado = Convert.ToBoolean(txtEstado.Text),

                });
                MessageBox.Show("Actualización exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Delete(new Entidad.Producto
                {
                    IdProducto = int.Parse(txtIdProducto.Text),

                });
                MessageBox.Show("Eliminación exitosa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }
    }
}
