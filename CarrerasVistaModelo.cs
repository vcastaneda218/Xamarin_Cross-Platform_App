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
    public class CarrerasVistaModelo : INotifyPropertyChanged
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
                GetCarrerasCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Carrera> Carreras { get; set; }

        public CarrerasVistaModelo()
        {
            Carreras = new ObservableCollection<Carrera>();

            GetCarrerasCommand = new Command(
                async () => await GetCarreras(),
                () => !IsBusy
                );
        }

        async Task GetCarreras()
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetCarreras();
                    Carreras.Clear();
                    foreach (var carrera in Items)
                    {
                        Carreras.Add(carrera);
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

        public Command GetCarrerasCommand { get; set; }
    }
}
