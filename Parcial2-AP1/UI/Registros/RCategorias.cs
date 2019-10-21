using Parcial2_AP1.BLL;
using Parcial2_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_AP1.UI.Registros
{
    public partial class RCategorias : Form
    {
        public RCategorias()
        {
            InitializeComponent();
        }


        private void Limpiar()
        {
            CategoriaIdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            MyerrorProvider.Clear();
            
        }

        private Categorias LlenaClase()
        {
            Categorias categorias = new Categorias();

            categorias.CategoriaId = (int)CategoriaIdnumericUpDown.Value;
            categorias.Descripcion = DescripciontextBox.Text;

            return categorias;
        }

        private void LlenaCampos(Categorias categorias)
        {
            CategoriaIdnumericUpDown.Value =categorias.CategoriaId;
            DescripciontextBox.Text = categorias.Descripcion;
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyerrorProvider.SetError(DescripciontextBox, "El campo Nombre no puede estar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();
            Categorias categorias = repositorio.Buscar((int)CategoriaIdnumericUpDown.Value);
            return (categorias != null);
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Categorias categorias;
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();

            if (!Validar())
                return;

            categorias = LlenaClase();

            if (CategoriaIdnumericUpDown.Value == 0)
                paso = repositorio.Guardar(categorias);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un registro que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = repositorio.Modificar(categorias);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("¡No fue posible guardar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();
            int id;
            int.TryParse(Convert.ToString(CategoriaIdnumericUpDown.Value), out id);
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();

            Limpiar();

            if (repositorio.Eliminar(id))
                MessageBox.Show("¡Registro eliminado exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyerrorProvider.SetError(CategoriaIdnumericUpDown, "No se pudo eliminar el registro");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Categorias categorias = new Categorias();
            int.TryParse(Convert.ToString(CategoriaIdnumericUpDown.Value), out id);
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>();

            Limpiar();

            categorias = repositorio.Buscar(id);
             
            if (categorias != null)
                LlenaCampos(categorias);
            else
                MessageBox.Show("¡Registro no encontrado!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
