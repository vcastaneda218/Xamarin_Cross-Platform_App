using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using System.Collections.ObjectModel;
using Ubicapp.Modelo;
using Ubicapp.Servicio;
using Ubicapp.VistaModelo;

namespace Ubicapp.Paginas
{
    public partial class CarrerasPage : ContentPage
    {
        public CarrerasVistaModelo cvm;

        public CarrerasPage()
        {
            InitializeComponent();

            Title = "Carreras";

            cvm = new CarrerasVistaModelo();

            BindingContext = cvm;

            cvm.GetCarrerasCommand.Execute(this);

            var BtnSincronizar = new ToolbarItem
            {
                Icon = "icono_actualizar.png",
                Text = "Actualizar"
            };

            BtnSincronizar.Clicked += ActualizarClicked;

            ToolbarItems.Add(BtnSincronizar);

            ListViewCarreras.ItemSelected += ListViewCarreras_ItemSelected;
        }

        private void ListViewCarreras_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Carrera selectedCarrera = (Carrera)e.SelectedItem;
            System.Diagnostics.Debug.WriteLine("Abriendo SeleccionarGrupoPage -> " + selectedCarrera.Nombre);
            ((NavigationPage)this.Parent).PushAsync(new SeleccionarGrupoPage(selectedCarrera)); //Abrir la siguiente pagina
        }

        void ActualizarClicked(object sender, EventArgs e)
        {
            cvm = new CarrerasVistaModelo();
            BindingContext = cvm;
            cvm.GetCarrerasCommand.Execute(this);
        }
    }
}
