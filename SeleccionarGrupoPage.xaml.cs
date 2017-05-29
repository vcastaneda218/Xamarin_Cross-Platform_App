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
    public partial class SeleccionarGrupoPage : ContentPage
    {
        private Carrera LaCarrera;
        private List<Turno> LosTurnos = new List<Turno>();
        private List<Cuatrimestre> LosCuatrimestres = new List<Cuatrimestre>();

        private GruposVistaModelo gvm;

        private int IDTurno = 0;
        private int IDCuatrimestre = 0;

        public SeleccionarGrupoPage(Carrera carrera)
        {
            InitializeComponent();

            LaCarrera = carrera;

            Title = LaCarrera.Nombre;

            LosTurnos = DatosLista.GetDatosTurno();
            listaTurnos.ItemsSource = LosTurnos;

            listaTurnos.ItemSelected += ListaTurnos_ItemSelected;

            LosCuatrimestres = DatosLista.GetDatosCuatrimestre();
            listaCuatrimestre.ItemsSource = LosCuatrimestres;

            listaCuatrimestre.ItemSelected += ListaCuatrimestre_ItemSelected;

            ListViewGrupos.ItemSelected += ListViewGrupos_ItemSelected;
        }

        private void ListaTurnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Turno selectedTurno = (Turno)e.SelectedItem;
            //DisplayAlert("Turno", "El turno seleccionado es: " + selectedTurno.Nombre, "Aceptar");
            IDTurno = selectedTurno.IDTurno;
            if(IDCuatrimestre != 0)
            {
                System.Diagnostics.Debug.WriteLine("Abrir HorarioGrupoPage(IDCarrera = "+LaCarrera.IDCarrera+", IDTurno = "+IDTurno+", IDCuatrimestre = "+IDCuatrimestre+")");
                gvm = new GruposVistaModelo(int.Parse(LaCarrera.IDCarrera), IDTurno, IDCuatrimestre);
                BindingContext = gvm;
                gvm.GetGruposCommand.Execute(this);
            }
        }

        private void ListaCuatrimestre_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cuatrimestre selectedCuatri = (Cuatrimestre)e.SelectedItem;
            //DisplayAlert("Cuatrimestre", "El cuatri seleccionado es: " + selectedCuatri.Nombre, "Aceptar");
            IDCuatrimestre = selectedCuatri.IDCuatrimestre;
            if (IDTurno != 0)
            {
                System.Diagnostics.Debug.WriteLine("Abrir HorarioGrupoPage(IDCarrera = " + LaCarrera.IDCarrera + ", IDTurno = " + IDTurno + ", IDCuatrimestre = " + IDCuatrimestre + ")");
                gvm = new GruposVistaModelo(int.Parse(LaCarrera.IDCarrera), IDTurno, IDCuatrimestre);
                BindingContext = gvm;
                gvm.GetGruposCommand.Execute(this);
            }
        }

        private void ListViewGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Grupo selectedGrupo = (Grupo)e.SelectedItem;
            //DisplayAlert("HorarioGrupoPage", "Mostrar el horario del grupo: " + selectedGrupo.Nombre, "OK");
            System.Diagnostics.Debug.WriteLine("Abrir HorarioGrupoPage(Grupo = " + selectedGrupo.Nombre + ")");
            ((NavigationPage)this.Parent).PushAsync(new HorarioGrupoPage(selectedGrupo)); //Abrir la siguiente pagina
        }
    }
}
