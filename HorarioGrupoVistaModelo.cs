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
    class HorarioGrupoVistaModelo : INotifyPropertyChanged
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
                GetHorarioCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Horario> ElHorario { get; set; }

        public HorarioGrupoVistaModelo(int idGrupo, int idDia)
        {
            ElHorario = new ObservableCollection<Horario>();

            GetHorarioCommand = new Command(
                async () => await GetHorario(idGrupo, idDia),
                () => !IsBusy
                );
        }

        async Task GetHorario(int idGrupo, int idDia)
        {
            if (!IsBusy)
            {
                Exception error = null;
                try
                {
                    IsBusy = true;
                    var Repository = new Repository();
                    var Items = await Repository.GetHorarioGrupo(idGrupo, idDia);
                    ElHorario.Clear();
                    foreach (var horario in Items)
                    {
                        ElHorario.Add(horario);
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

        public Command GetHorarioCommand { get; set; }
    }
}
