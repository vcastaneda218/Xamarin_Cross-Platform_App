using System;
using Xamarin.Forms;
using Ubicapp.Modelo;
using Ubicapp.VistaModelo;


namespace Ubicapp.Paginas
{
    public partial class ProfesoresPage : ContentPage
    {
        public ProfesoresVistaModelo pvm;
        //public BuscarProfesoresVistaModelo pvmbuscar;
      

        public ProfesoresPage()
        {
            InitializeComponent();

            Title = "Profesores";
           


            pvm = new ProfesoresVistaModelo();

            BindingContext = pvm;

            pvm.GetProfesoresCommand.Execute(this);

            /*
             * https://es.icons8.com/web-app/new-icons/androidL
             * https://material.io/guidelines/style/icons.html#icons-app-shortcut-icons
             * https://forums.xamarin.com/discussion/17339/navigationpage-and-toolbaritems
             * http://stackoverflow.com/questions/29478018/button-in-action-bar-for-xamarin-forms-application
             * https://github.com/xamarin/xamarin-forms-book-preview-2/blob/master/Chapter01/PlatformVisuals/PlatformVisuals/PlatformVisuals/PlatformVisualsPage.xaml
             */
            var BtnSincronizar = new ToolbarItem
            {
                Icon = "icono_actualizar.png",
                Text = "Actualizar"/*,
                Command = pvm.GetProfesoresCommand*/
            };

            BtnSincronizar.Clicked += ActualizarClicked;

            ToolbarItems.Add(BtnSincronizar);

            sbBuscar.SearchCommand = new Command(() => BuscarCommand());
            sbBuscar.TextChanged += SbBuscar_TextChanged;
            //sbBuscar.SearchButtonPressed += BuscarFunction;

            ListViewProfesores.ItemSelected += ListViewProfesores_ItemSelected;
           
         
          
            /*ObservableCollection<Profesor> _lista_Profesores = new ObservableCollection<Profesor>(new ServicioProfesor().ConsultarProfesor());

            listaProfesores.ItemsSource = _lista_Profesores;

            imgPrueba.Source = new UriImageSource
            {
                Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(5, 0, 0, 0)
            };*/
        }

        private void ListViewProfesores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Profesor selectedProfe = (Profesor)e.SelectedItem;
            /*DisplayAlert(
                "IDProfesor: " + selectedProfe.IDProfesor.ToString() ,
                "Nombre: " + selectedProfe.Nombre + "\nApellido: " + selectedProfe.Apellido, 
                "OK"
                );*/
            ((NavigationPage)this.Parent).PushAsync(new HorarioProfesorPage(selectedProfe)); //Abrir la siguiente pagina
        }

        private void SbBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(sbBuscar.Text == "")
            {
                pvm = new ProfesoresVistaModelo();
                BindingContext = pvm;
                pvm.GetProfesoresCommand.Execute(this);
            }
            /*pvm = new ProfesoresVistaModelo();
            BindingContext = pvm;
            pvm.buscar = sbBuscar.Text;
            pvm.GetBuscarProfesoresCommand.Execute(this);*/
        }

        void BuscarCommand()
        {
            if (sbBuscar.Text != null)
            {
                pvm = new ProfesoresVistaModelo();
                BindingContext = pvm;
                pvm.buscar = sbBuscar.Text;
                pvm.GetBuscarProfesoresCommand.Execute(this);
            }
            else
            {
                pvm = new ProfesoresVistaModelo();
                BindingContext = pvm;
                pvm.GetProfesoresCommand.Execute(this);
            }
        }

        /*void BuscarFunction(object sender, EventArgs e)
        {
            if (sbBuscar.Text != null)
            {
                pvm = new ProfesoresVistaModelo();
                BindingContext = pvm;
                pvm.buscar = sbBuscar.Text;
                pvm.GetBuscarProfesoresCommand.Execute(this);
            }
            else
            {
                pvm = new ProfesoresVistaModelo();
                BindingContext = pvm;
                pvm.GetProfesoresCommand.Execute(this);
            }
        }*/

        //https://github.com/xamarin/xamarin-forms-samples/tree/master/WebServices/TodoAWSAuth/TodoAWS
        /*void BtnBuscarClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Buscar", "Buscando: " + txtBuscar.Text, "OK");

            if(txtBuscar.Text != null)
            {
                //pvmbuscar = new BuscarProfesoresVistaModelo(txtBuscar.Text);

                //BindingContext = pvmbuscar;

                //pvmbuscar.GetBuscarProfesoresCommand.Execute(this);
                pvm = new ProfesoresVistaModelo();

                BindingContext = pvm;

                pvm.buscar = txtBuscar.Text;

                pvm.GetBuscarProfesoresCommand.Execute(this);
            }
            else
            {
                pvm = new ProfesoresVistaModelo();

                BindingContext = pvm;

                pvm.GetProfesoresCommand.Execute(this);
            }
        }*/

        void ActualizarClicked(object sender, EventArgs e)
        {
            pvm = new ProfesoresVistaModelo();
            BindingContext = pvm;
            pvm.GetProfesoresCommand.Execute(this);
            //txtBuscar.Text = "";
            sbBuscar.Text = "";
        }

        async void GuardarClicked(object sender, EventArgs e)
        {
            var respuesta = await DisplayAlert("Guardar", "¿Desea guardar los datos?", "Aceptar", "Cancelar");

            if(respuesta == true)
            {
                //pvm.GetProfesoresCommand.Execute(this);
                await DisplayAlert("Completado", "Datos guardados correctamente", "OK");
            }
        }

        void OtrasOpcionesClicked(object sender, EventArgs e)
        {
            //https://developer.xamarin.com/guides/xamarin-forms/user-interface/navigation/pop-ups/
            DisplayAlert("Otras opciones", "Mensaje de prueba :)", "OK");
        }
    }
}
