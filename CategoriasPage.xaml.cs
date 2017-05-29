using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ubicapp.Paginas
{
    public partial class CategoriasPage : ContentPage
    {
        public CategoriasPage()
        {
            InitializeComponent();

            Title = "Categorias";

            btnProfesores.Clicked += BtnProfesores_Clicked;

            btnCarrerasProfesionales.Clicked += BtnCarrerasProfesionales_Clicked;
        }

        private void BtnProfesores_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ProfesoresPage()); //Abrir la siguiente pagina
        }

        private void BtnCarrerasProfesionales_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
