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
    public class GruposVistaModelo : INotifyPropertyChanged
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
                GetGruposCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Grupo> Grupos { get; set; }

        public GruposVistaModelo(int idCarrera, int idTurno, int idCuatri)
        {
            Grupos = new ObservableCollection<Grupo>();

            GetGruposCommand = new Command(
                async () => await GetGrupos(idCarrera, idTurno, idCuatri),
                () => !IsBusy
                );
        }

        async Task GetGrupos(int idCarrera, int idTurno, int idCuatri)
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetGrupos(idCarrera, idTurno, idCuatri);
                    Grupos.Clear();
                    foreach (var grupo in Items)
                    {
                        Grupos.Add(grupo);
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

        public Command GetGruposCommand { get; set; }
    }
}
