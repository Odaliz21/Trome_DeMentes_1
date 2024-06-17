using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class frmServicio : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from S in trome.Servicio
                           select S;
            gvServicio.DataSource = consulta;
            gvServicio.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tarifaBase;
                if (!decimal.TryParse(txtTarifaBase.Text, out tarifaBase))
                {
                    lblMensaje.Text = "Error: TarifaBase debe ser un número decimal válido.";
                    return;
                }

                Servicio nuevoServicio = new Servicio
                {
                    Descripcion = txtdescripcion.Text,
                    TarifaBase = tarifaBase,
                };

                trome.Servicio.InsertOnSubmit(nuevoServicio);
                trome.SubmitChanges();
                Listar();
                lblMensaje.Text = "Servicio agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar servicio: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                string descripcion = txtdescripcion.Text;
                var servicio = trome.Servicio.SingleOrDefault(s => s.Descripcion == descripcion);

                if (servicio != null)
                {
                    trome.Servicio.DeleteOnSubmit(servicio);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Servicio eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Servicio no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar servicio: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtdescripcion.Text.ToLower();
                var servicio = trome.Servicio.SingleOrDefault(s => s.Descripcion.ToLower() == descripcion);

                if (servicio != null)
                {
                    if (decimal.TryParse(txtTarifaBase.Text, out decimal tarifaBase))
                    {
                        servicio.Descripcion = txtdescripcion.Text;
                        servicio.TarifaBase = tarifaBase;

                        trome.SubmitChanges();
                        Listar();
                        lblMensaje.Text = "Servicio actualizado correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "Error: TarifaBase debe ser un número decimal válido.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Servicio no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar servicio: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtBuscar.Text;
                var consulta = from S in trome.Servicio
                               where S.Descripcion == descripcion
                               select S;

                gvServicio.DataSource = consulta.ToList();
                gvServicio.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Cliente no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar cliente: " + ex.Message;
            }
        }




        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }


        protected void gvServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvServicio.SelectedRow;
            txtdescripcion.Text = row.Cells[2].Text;
            txtTarifaBase.Text = row.Cells[3].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}