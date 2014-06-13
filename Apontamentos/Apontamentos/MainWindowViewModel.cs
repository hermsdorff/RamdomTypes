namespace Apontamentos
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Input;

    using Apontamento.Dominio;

    class MainWindowViewModel: INotifyPropertyChanged
    {
        private static DateTime _termino;

        private Thread threadCronometro;

        public DateTime Inicio { get; private set; }

        public DateTime Termino { get
        {
            return _termino;
        }
            private set
            {
                _termino = value;
                OnPropertyChanged("Termino");
                OnPropertyChanged("Cronometro");
            }
        }
        public String Cronometro
        {
            get
            {
                return _termino.Subtract(Inicio).ToString("hh':'mm':'ss");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private readonly ObservableCollection<Demanda> _demandas = new ObservableCollection<Demanda>();

        public ObservableCollection<Demanda> Demandas
        {
            get
            {
                return _demandas;
            }
        }

        public ICommand PlayPauseButtonPressed
        {
            get
            {
                return new Comando(this.IniciaCronometro);
            }
        }

        public ICommand StopButtonPressed
        {
            get
            {
                return new Comando(this.ParaCronometro);
            }
        }

        private void IniciaCronometro()
        {
            threadCronometro = new Thread(ThCronometro);
            threadCronometro.Start(this);
        }

        public void ParaCronometro()
        {
            if (threadCronometro != null)
            {
                threadCronometro.Abort();
                threadCronometro.Join();
            }
        }

        private static void ThCronometro(object viewmodel)
        {
            var viewModel = (MainWindowViewModel)viewmodel;
            viewModel.Inicio = DateTime.Now;
            while (true)
            {
                Thread.Sleep(1000);
                viewModel.Termino = DateTime.Now;
            }
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class Comando: ICommand
    {
        private readonly Action _acao;

        public Comando(Action action)
        {
            _acao = action;
        }

        #region Implementation of ICommand

        public void Execute(object parameter)
        {
            _acao();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
