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
    public class BuscarProfesoresVistaModelo : INotifyPropertyChanged
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
                GetBuscarProfesoresCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Profesor> Profesores { get; set; }

        public BuscarProfesoresVistaModelo(string buscar)
        {
            Profesores = new ObservableCollection<Profesor>();

            GetBuscarProfesoresCommand = new Command(
                async () => await GetBuscarProfesores(buscar),
                () => !IsBusy
                );
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
                    foreach (var profe in Items)
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
                if (error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
                }
            }
            return;
        }

        public Command GetBuscarProfesoresCommand { get; set; }
    }
}
