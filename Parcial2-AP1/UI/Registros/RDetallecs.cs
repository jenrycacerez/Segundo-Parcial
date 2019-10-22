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
    public partial class RDetallecs : Form
    {
        public List<ServicioDetalles> Detalle { get; set; }
        public RDetallecs()
        {
            InitializeComponent();
            
            this.Detalle = new List<ServicioDetalles>();
            LLenaComboboxCategoria();
        }

        public void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            EstudiantetextBox.Text = string.Empty;
            CategoriacomboBox.ResetText();
            CantidadnumericUpDown.Value = 0;
            PreciotextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;
            TotaltextBox.Text = "0.00";
            ErrorProvider.Clear();
            this.Detalle = new List<ServicioDetalles>();
            CargarGrid();
            ErrorProvider.Clear();


        }

        private void LLenaComboboxCategoria()
        {
           
            RepositorioBase<Categorias> oCategorias = new RepositorioBase<Categorias>();
            CategoriacomboBox.DataSource = null;
            CategoriacomboBox.DataSource = oCategorias.GetList(p => true);
            CategoriacomboBox.ValueMember = "CategoriaId";
            CategoriacomboBox.DisplayMember = "Descripcion";
        }

        private Factura LlenaClase()
        {
            Factura ofactura = new Factura();

            ofactura.FacturaID = (int)IdnumericUpDown.Value;
            ofactura.Fecha = FechadateTimePicker.Value;
            ofactura.Estudiante = EstudiantetextBox.Text;
            ofactura.Total = Convert.ToDecimal(TotaltextBox.Text);
            ofactura.Detalles = this.Detalle;

            return ofactura;
        }
        private Factura LlenaCampo(Factura factura)
        {

            IdnumericUpDown.Value = factura.FacturaID;
            FechadateTimePicker.Value = factura.Fecha;
            EstudiantetextBox.Text = factura.Estudiante;
            TotaltextBox.Text = Convert.ToString(factura.Total);
            this.Detalle = factura.Detalles;
            CargarGrid();

            

              return factura;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            ServicioRepositorio AP = new ServicioRepositorio();
            Factura factura = AP.Buscar((int)IdnumericUpDown.Value);
            return (factura != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(EstudiantetextBox.Text))
            {
                ErrorProvider.SetError(EstudiantetextBox, "El campo Estudiante no puede estar vacio");
                EstudiantetextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ValidarCamposDetalle()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(CategoriacomboBox.Text))
            {
                ErrorProvider.SetError(CategoriacomboBox, "El campo Categoria no puede estar vacio");
                CategoriacomboBox.Focus();
                paso = false;
            }

            if (CantidadnumericUpDown.Value == 0)
            {
                ErrorProvider.SetError(CantidadnumericUpDown, "El campo Cantidad no puede ser cero");
                CantidadnumericUpDown.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(PreciotextBox.Text))
            {
                ErrorProvider.SetError(PreciotextBox, "El campo Precio no puede estar vacio");
                PreciotextBox.Focus();
                paso = false;
            }
            if (Convert.ToDecimal(PreciotextBox.Text)<=0)
            {
                ErrorProvider.SetError(PreciotextBox, "El campo Precio no puede estar menor igual 0");
                PreciotextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ImportetextBox.Text))
            {
                ErrorProvider.SetError(ImportetextBox, "El campo Importe no puede ser cero");
                ImportetextBox.Focus();
                paso = false;
            }

            return paso;
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            DetallesdataGridView.AutoGenerateColumns = false;
            int id;
            Factura factura = new Factura();
            int.TryParse(Convert.ToString(IdnumericUpDown.Value), out id);
            ServicioRepositorio AR = new ServicioRepositorio();

            Limpiar();

            factura = AR.Buscar(id);

            if (factura != null)
                LlenaCampo(factura);
            else
                MessageBox.Show("¡Registro no encontrado!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            int id;
            int.TryParse(Convert.ToString(IdnumericUpDown.Value), out id);
           ServicioRepositorio AR = new ServicioRepositorio();

            Limpiar();

            if (AR.Eliminar(id))
                MessageBox.Show("¡Registro eliminado exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                ErrorProvider.SetError(IdnumericUpDown, "No se pudo eliminar el registro");
        }
        private void CargarGrid()
        {
            DetallesdataGridView.DataSource = null;
            DetallesdataGridView.DataSource = this.Detalle;
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetallesdataGridView.Rows.Count > 0 && DetallesdataGridView.CurrentRow != null)
            {
               TotaltextBox.Text = (Convert.ToDecimal(TotaltextBox.Text) - Convert.ToDecimal(DetallesdataGridView.SelectedRows[0].Cells["Importe"].Value)).ToString("N2");
                this.Detalle.RemoveAt(DetallesdataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

 


        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            DetallesdataGridView.AutoGenerateColumns = false;
            if (DetallesdataGridView.DataSource != null)
                this.Detalle = (List<ServicioDetalles>)DetallesdataGridView.DataSource;

            if (!ValidarCamposDetalle())
                return;

            this.Detalle.Add(new ServicioDetalles
                            (DetalleId: 0,
                             EstudianteId: 0,
                             NombreCategoria: CategoriacomboBox.Text,
                             FacturaId:(int)IdnumericUpDown.Value,
                             Cantidad: Convert.ToInt32(CantidadnumericUpDown.Value),
                             Precio: Convert.ToInt32(PreciotextBox.Text),
                             Importe: Convert.ToDecimal(ImportetextBox.Text)

                            ));

            CargarGrid();
            TotaltextBox.Text = Convert.ToString(Convert.ToDecimal(TotaltextBox.Text) + Convert.ToDecimal(ImportetextBox.Text));
            CategoriacomboBox.Focus();
            CategoriacomboBox.Text = string.Empty;
            CantidadnumericUpDown.Value = 0;
            PreciotextBox.Text = string.Empty;
            ImportetextBox.Text = string.Empty;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Factura ofactura;
            ServicioRepositorio AR = new ServicioRepositorio();

            if (!Validar())
                return;

            ofactura = LlenaClase();

            if (IdnumericUpDown.Value == 0)
                paso = AR.Guardar(ofactura);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un registro que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                paso = AR.Modificar(ofactura);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("¡Guardado exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("¡No fue posible guardar!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void ImportetextBox_TextChanged(object sender, EventArgs e)
        {
           
               // if (CantidadnumericUpDown.Value != 0 && PrecionumericUpDown.Value != 0)
                //    ImportetextBox.Text = Convert.ToString(CantidadnumericUpDown.Value * PrecionumericUpDown.Value);
            
        }

        private void PreciotextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (CantidadnumericUpDown.Value != 0 && Convert.ToDecimal(PreciotextBox.Text) != 0)
                { 
                    ImportetextBox.Text = Convert.ToString(CantidadnumericUpDown.Value * Convert.ToDecimal( PreciotextBox.Text));
                }
            }
            catch {
                MessageBox.Show("¡No fue posible Calcular importe!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
