using BLL;
using Entidades;
using Sugerencias.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sugerencias.Registros
{
    public partial class rSugerencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToFormatDate();
            }
        }
        private void Limpiar()
        {
            SugerenciasIdTextBox.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString();
            DescripcionTextBox.Text = string.Empty;
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private Sugerencia LlenaClase()
        {
            return new Sugerencia()
            {
                SugerenciasId = SugerenciasIdTextBox.Text.ToInt(),
                Fecha = FechaTextBox.Text.ToDatetime(),
                Descripcion = DescripcionTextBox.Text
            };
        }
        private void LlenaCampo(Sugerencia sugerencia)
        {
            SugerenciasIdTextBox.Text = sugerencia.SugerenciasId.ToString();
            FechaTextBox.Text = sugerencia.Fecha.ToString();
            DescripcionTextBox.Text = sugerencia.Descripcion;
        }
        private bool Validar()
        {
            bool paso = true;
            if (SugerenciasIdTextBox.Text.EsNulo() || string.IsNullOrWhiteSpace(SugerenciasIdTextBox.Text))
                paso = false;
            if (string.IsNullOrWhiteSpace(FechaTextBox.Text))
                paso = false;
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                paso = false;
            return paso;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Sugerencia> repositorio = new RepositorioBase<Sugerencia>();
            Sugerencia sugerencias = repositorio.Buscar(DescripcionTextBox.Text.ToInt());
            return sugerencias.EsNulo();
        }
        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            RepositorioBase<Sugerencia> repositorio = new RepositorioBase<Sugerencia>();
            Sugerencia sugerencias = LlenaClase();
            TipoTitulo tipoTitulo = TipoTitulo.OperacionFallida;
            TiposMensajes tiposMensajes = TiposMensajes.RegistroNoGuardado;
            IconType iconType = IconType.error;
            bool paso = false;

            if (sugerencias.SugerenciasId == 0)
                paso = repositorio.Guardar(sugerencias);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utils.ToastSweet(this, IconType.info, TiposMensajes.RegistroNoEncontrado);
                    return;
                }
                paso = repositorio.Modificar(sugerencias);
            }
            if (paso)
            {
                Limpiar();
                tipoTitulo = TipoTitulo.OperacionExitosa;
                tiposMensajes = TiposMensajes.RegistroGuardado;
                iconType = IconType.success;
            }
            Utils.Alerta(this, tipoTitulo, tiposMensajes, iconType);
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Sugerencia> repositorio = new RepositorioBase<Sugerencia>();
            int id = SugerenciasIdTextBox.Text.ToInt();
            if (!ExisteEnLaBaseDeDatos())
            {
                Utils.Alerta(this, TipoTitulo.OperacionFallida, TiposMensajes.RegistroInexistente, IconType.error);
                return;
            }
            else
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.Alerta(this, TipoTitulo.OperacionExitosa, TiposMensajes.RegistroEliminado, IconType.success);
                    Limpiar();
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Sugerencia> repositorio = new RepositorioBase<Sugerencia>();
            Sugerencia Sugerencias = repositorio.Buscar(SugerenciasIdTextBox.Text.ToInt());
            if (!Sugerencias.EsNulo())
            {
                Limpiar();
                LlenaCampo(Sugerencias);
            }
            else
                Utils.ToastSweet(this, IconType.info, TiposMensajes.RegistroNoEncontrado);
        }
    }
}