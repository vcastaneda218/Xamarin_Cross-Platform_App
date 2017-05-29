using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ubicapp.Paginas
{
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
            Title = "Ubicapp";

            listaEdificios.ItemsSource = DatosEdificios.GetDatosEdificios();

            listaEdificios.ItemSelected += ListaEdificios_ItemSelected; //agregar evento selected al item

            btnBusqueda.Clicked += BtnBusqueda_Clicked; //agregar el evento click al boton
        }

        private void ListaEdificios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Edificio selectedEdificio = (Edificio)e.SelectedItem;
            //DisplayAlert("Edificio", "El edificio seleccionado es: " + selected_item, "Aceptar");
            //visualizacionEdificio.Text = "Edificio: " + selectedEdificio.Nombre;
            imgMapa.Source = selectedEdificio.ImgNombre;
        }

        private void BtnBusqueda_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new CategoriasPage()); //Abrir la siguiente pagina
        }
    }

    public class Edificio
    {
        public int IdEdificio { get; set; }
        public string Nombre { get; set; }
        public string NomLista
        {
            get
            {
                return IdEdificio + ".- " + Nombre;
            }
        }
        public string ImgNombre { get; set; } //390 * 680
    }

    public class DatosEdificios
    {
        public static List<Edificio> GetDatosEdificios()
        {
            List<Edificio> edificios = new List<Edificio>();

            edificios.Add(new Edificio { IdEdificio = 1, Nombre = "Rectoria", ImgNombre = "mapa_rectoria" });
            edificios.Add(new Edificio { IdEdificio = 2, Nombre = "Vinculacion", ImgNombre = "mapa_vinculacion" });
            edificios.Add(new Edificio { IdEdificio = 3, Nombre = "Docencia I", ImgNombre = "mapa_docencia_1" });
            edificios.Add(new Edificio { IdEdificio = 4, Nombre = "Docencia II", ImgNombre = "mapa_docencia_2" });
            edificios.Add(new Edificio { IdEdificio = 5, Nombre = "Pesado I", ImgNombre = "mapa_pesado_1" });
            edificios.Add(new Edificio { IdEdificio = 6, Nombre = "Pesado II", ImgNombre = "mapa_pesado_2" });
            edificios.Add(new Edificio { IdEdificio = 7, Nombre = "Pesado III", ImgNombre = "mapa_pesado_3" });
            edificios.Add(new Edificio { IdEdificio = 8, Nombre = "Mediateca", ImgNombre = "mapa_mediateca" });
            edificios.Add(new Edificio { IdEdificio = 9, Nombre = "Otros salones", ImgNombre = "mapa_salones" });
            edificios.Add(new Edificio { IdEdificio = 10, Nombre = "Cafeteria", ImgNombre = "mapa_cafeteria" });
            edificios.Add(new Edificio { IdEdificio = 11, Nombre = "Canchas", ImgNombre = "mapa_canchas" });

            return edificios;
        }
    }
}
