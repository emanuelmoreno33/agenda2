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
    public partial class frmContacto : Form
    {
        //Variable para ID de Contacto
        string ID;
        //Variable que nos indicara
        //si pulsa Nuevo o Modificar
        private int temp = 0;
        //para obtener la fecha actual en una variable
        DateTime fechaActual = DateTime.Now;

        public frmContacto()
        {
            InitializeComponent();
        }

        private void frmContacto_Load(object sender, EventArgs e)
        {
            //Manejo de controles
            //Para su mejor comprension lo haremos de manera detallada
            txtNombres.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCelular.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboProfesion.Enabled = false;
            cboPais.Enabled = false;
            //Botones
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnListar.Enabled = true;
            btnSalir.Enabled = true;
            //Grid
            dtgDetalle.Enabled = true;
            //Mostrar el contenido del Grid
            MostrarGrid();
            MostrarPais();
            MostrarProfesion();

        }
        private void MostrarGrid()
        {
            contacto persona = new contacto();
            dtgDetalle.DataSource = persona.ListarContacto();
        }

        private void MostrarPais()
        {
            pais miPais = new pais();
            cboPais.DataSource = miPais.ListarPais();
            cboPais.DisplayMember = "NombrePais";
            cboPais.ValueMember = "CodigoPais";
        }

        private void MostrarProfesion()
        {
            profesion miProfesion = new profesion();
            cboProfesion.DataSource = miProfesion.ListarProfesion();
            cboProfesion.DisplayMember = "NombreProfesion";
            cboProfesion.ValueMember = "CodigoProfesion";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            temp = 0;
            // Valores en Blanco
            txtNombres.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            // Controles
            txtNombres.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCelular.ReadOnly = false;
            txtEmail.ReadOnly = false;
            cboProfesion.Enabled = true;
            cboPais.Enabled = true;
            //Botones
            btnNuevo.Enabled = false;
            btnGrabar.Enabled = true;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnListar.Enabled = false;
            btnSalir.Enabled = false;
            //Grid
            dtgDetalle.Enabled = false;
            //Foco
            txtNombres.Focus();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Trim().Length > 0)
            {
                contacto Persona = new contacto();
                if (temp == 0)
                {
                    Persona.AgregarContacto(txtNombres.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtEmail.Text, fechaActual, Convert.ToInt32(cboProfesion.SelectedValue.ToString()), Convert.ToInt32(cboPais.SelectedValue.ToString()));
                }
                else
                {
                    Persona.ModificarContacto(Convert.ToInt32(ID), txtNombres.Text,
                    txtDireccion.Text, txtTelefono.Text, txtCelular.Text, txtEmail.Text, fechaActual, Convert.ToInt32(cboProfesion.SelectedValue.ToString()),
                    Convert.ToInt32(cboPais.SelectedValue.ToString()));
                }
                // capa en los controles
                txtNombres.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtCelular.ReadOnly = true;
                txtEmail.ReadOnly = true;
                cboProfesion.Enabled = false;
                cboPais.Enabled = false;
                //Botones
                btnNuevo.Enabled = true;
                btnGrabar.Enabled = false;
                btnModificar.Enabled = false;
                btnCancelar.Enabled = false;
                btnEliminar.Enabled = false;
                btnListar.Enabled = true;
                btnSalir.Enabled = true;
                //Grid
                dtgDetalle.Enabled = true;
                dtgDetalle.Focus();
                MostrarGrid();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if ((dtgDetalle.Rows.Count > 0) &&
            (dtgDetalle.CurrentRow.Cells[0].Value != null))
            {
                temp = 1;
                ID = dtgDetalle.CurrentRow.Cells[0].Value.ToString();
                // capa en los controles
                txtNombres.ReadOnly = false;
                txtDireccion.ReadOnly = false;
                txtTelefono.ReadOnly = false;
                txtCelular.ReadOnly = false;
                txtEmail.ReadOnly = false;
                cboProfesion.Enabled = true;
                cboPais.Enabled = true;
                //Botones
                btnNuevo.Enabled = false;
                btnGrabar.Enabled = true;
                btnModificar.Enabled = false;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnListar.Enabled = false;
                btnSalir.Enabled = false;
                //Grid
                dtgDetalle.Enabled = false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombres.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCelular.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cboProfesion.Enabled = false;
            cboPais.Enabled = false;
            //Botones
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = false;
            btnListar.Enabled = true;
            btnSalir.Enabled = true;
            //Grid
            dtgDetalle.Enabled = true;
            dtgDetalle.Focus();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((dtgDetalle.Rows.Count > 0) &&
(dtgDetalle.CurrentRow.Cells[0].Value != null))
            {
                DialogResult resultado = MessageBox.Show("Esta Seguro que desea Eliminar ?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    ID = dtgDetalle.CurrentRow.Cells[0].Value.ToString();
                    contacto persona = new contacto();
                    persona.EliminarContacto(Convert.ToInt32(ID));
                    MostrarGrid();
                }
            }
            else
            {
                MessageBox.Show("No se selecciono datos.", "Eliminar",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dtgDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgDetalle.CurrentRow.Cells[0].Value.ToString();
            txtNombres.Text = dtgDetalle.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dtgDetalle.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dtgDetalle.CurrentRow.Cells[3].Value.ToString();
            txtCelular.Text = dtgDetalle.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dtgDetalle.CurrentRow.Cells[5].Value.ToString();
            cboProfesion.Text = dtgDetalle.CurrentRow.Cells[8].Value.ToString();
            cboPais.Text = dtgDetalle.CurrentRow.Cells[7].Value.ToString();
            // Podemos Modificar u Eliminar
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            frmlistacontactos frm = new frmlistacontactos();
            frm.Show();
        }


    }
}
