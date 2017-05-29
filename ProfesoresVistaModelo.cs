using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using Ubicapp.Modelo;
using Xamarin.Forms;

namespace Ubicapp.VistaModelo
{
    public class ProfesoresVistaModelo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = null) =>
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));

        private bool Busy;

        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetProfesoresCommand.ChangeCanExecute();
                GetBuscarProfesoresCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Profesor> Profesores { get; set; }

        public ProfesoresVistaModelo()
        {
            Profesores = new ObservableCollection<Profesor>();

            GetProfesoresCommand = new Command(
                async () => await GetProfesores(),
                () => !IsBusy
                );

            GetBuscarProfesoresCommand = new Command(
                async () => await GetBuscarProfesores(buscar),
                () => !IsBusy
                );
        }

        async Task GetProfesores()
        {
            if(!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetProgesores();
                    Profesores.Clear();
                    foreach(var profe in Items)
                    {
                        Profesores.Add(profe);
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
                if(error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
                }
            }
            return;
        }

        async Task GetBuscarProfesores(string buscar)
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetBuscarProfesores(buscar);
                    Profesores.Clear();
                    if(Items.Count > 0)
                    {
                        foreach(var profe in Items)
                        {
                            Profesores.Add(profe);
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Busqueda profesores", "No se encontraron datos.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
                if (error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
                }
            }
            return;
        }

        public Command GetProfesoresCommand { get; set; }

        public Command GetBuscarProfesoresCommand { get; set; }

        public string buscar { get; set; }
        
    }
}
