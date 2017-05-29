using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Ubicapp.Modelo;
using Ubicapp.VistaModelo;

namespace Ubicapp.Paginas
{
    public partial class HorarioProfesorPage : ContentPage
    {
        private Profesor ElProfe;
        private int DiaActivo = 1;

        public HorarioVistaModelo hvm;

        public HorarioProfesorPage(Profesor profe)
        {
            InitializeComponent();

            ElProfe = profe;

            lblProfesor.Text = ElProfe.NombreCompleto;

            btnLunes.Clicked += BtnLunes_Clicked;
            btnMartes.Clicked += BtnMartes_Clicked;
            btnMiercoles.Clicked += BtnMiercoles_Clicked;
            btnJueves.Clicked += BtnJueves_Clicked;
            btnViernes.Clicked += BtnViernes_Clicked;

            MostrarHorario(DiaActivo);

            DevExpress.Mobile.DataGrid.Theme.ThemeManager.ThemeName = DevExpress.Mobile.DataGrid.Theme.Themes.Light;
            DevExpress.Mobile.DataGrid.Theme.ThemeManager.Theme.HeaderCustomizer.BackgroundColor = Color.FromHex("#0e8c80");
            DevExpress.Mobile.DataGrid.Theme.ThemeManager.Theme.HeaderCustomizer.Font = new DevExpress.Mobile.DataGrid.ThemeFontAttributes("Verdana", DevExpress.Mobile.DataGrid.ThemeFontAttributes.FontSizeFromNamedSize(NamedSize.Medium), FontAttributes.Bold, Color.White);
            DevExpress.Mobile.DataGrid.Theme.ThemeManager.RefreshTheme();

            gridHorarioProfesor.SwipeButtonClick += OnSwipeButtonClick;
        }

        private void BtnLunes_Clicked(object sender, EventArgs e)
        {
            if(DiaActivo != 1)
            {
                RestablecerColorBotones();
                DiaActivo = 1;
                MostrarHorario(DiaActivo);
            }
        }
        private void BtnMartes_Clicked(object sender, EventArgs e)
        {
            if (DiaActivo != 2)
            {
                RestablecerColorBotones();
                DiaActivo = 2;
                MostrarHorario(DiaActivo);
            }
        }
        private void BtnMiercoles_Clicked(object sender, EventArgs e)
        {
            if (DiaActivo != 3)
            {
                RestablecerColorBotones();
                DiaActivo = 3;
                MostrarHorario(DiaActivo);
            }
        }
        private void BtnJueves_Clicked(object sender, EventArgs e)
        {
            if (DiaActivo != 4)
            {
                RestablecerColorBotones();
                DiaActivo = 4;
                MostrarHorario(DiaActivo);
            }
        }
        private void BtnViernes_Clicked(object sender, EventArgs e)
        {
            if (DiaActivo != 5)
            {
                RestablecerColorBotones();
                DiaActivo = 5;
                MostrarHorario(DiaActivo);
            }
        }
        private void RestablecerColorBotones()
        {
            btnLunes.BackgroundColor = Color.FromHex("#0e8c80");
            btnMartes.BackgroundColor = Color.FromHex("#0e8c80");
            btnMiercoles.BackgroundColor = Color.FromHex("#0e8c80");
            btnJueves.BackgroundColor = Color.FromHex("#0e8c80");
            btnViernes.BackgroundColor = Color.FromHex("#0e8c80");
        }
        private void MostrarHorario(int dia)
        {
            switch(dia)
            {
                case 1:
                    //DisplayAlert("Lunes", "Mostrando horario del dia lunes", "OK");
                    btnLunes.BackgroundColor = Color.FromHex("#ff0000");
                    CargarHorario(dia);
                break;
                case 2:
                    //DisplayAlert("Martes", "Mostrando horario del dia martes", "OK");
                    btnMartes.BackgroundColor = Color.FromHex("#ff0000");
                    CargarHorario(dia);
                break;
                case 3:
                    //DisplayAlert("Miercoles", "Mostrando horario del dia miercoles", "OK");
                    btnMiercoles.BackgroundColor = Color.FromHex("#ff0000");
                    CargarHorario(dia);
                break;
                case 4:
                    //DisplayAlert("Jueves", "Mostrando horario del dia jueves", "OK");
                    btnJueves.BackgroundColor = Color.FromHex("#ff0000");
                    CargarHorario(dia);
                break;
                case 5:
                    //DisplayAlert("Viernes", "Mostrando horario del dia viernes", "OK");
                    btnViernes.BackgroundColor = Color.FromHex("#ff0000");
                    CargarHorario(dia);
                break;
            }
        }
        private void CargarHorario(int dia)
        {
            hvm = new HorarioVistaModelo(int.Parse(ElProfe.IDProfesor), dia);
            BindingContext = hvm;
            hvm.GetHorarioCommand.Execute(this);
        }

        void OnSwipeButtonClick(object sender, DevExpress.Mobile.DataGrid.SwipeButtonEventArgs e)
        {
            if (e.ButtonInfo.ButtonName.Equals("btnSwMostrarUbicacion"))
            {
                string NombreSalon = (string)gridHorarioProfesor.GetCellValue(e.RowHandle, "Salon");
                System.Diagnostics.Debug.WriteLine("Algo en RightButton OnSwipeButtonClick: " + NombreSalon);
                //DisplayAlert("Alert from " + e.ButtonInfo.ButtonName, "Salón: " + NombreSalon, "OK");
                DisplayAlert("Mostrar ubicación", "Salón: " + NombreSalon, "OK");
            }
        }
    }
}
