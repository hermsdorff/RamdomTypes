using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Apontamentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGrid1_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            PlayPauseButton.IsEnabled = true;
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            PlayPauseButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PlayPauseButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = (MainWindowViewModel)_teste.DataContext;
            viewModel.ParaCronometro();
        }
    }
}
