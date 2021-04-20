using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Rushtell_Bunk.Clients;
using SaveAndLoadLibrary;
using System.Data.Entity;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PresenterForMain presenter;

        public MainWindow()
        {
            InitializeComponent();

            presenter = new PresenterForMain(this);
            presenter.LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            presenter.CreateAddWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            presenter.SetVIPWorker();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.ViewConcretData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            presenter.CreateDepositWindow();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            presenter.CreateWithdrawWindow();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            presenter.CreateTransferWindow();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            presenter.Delete();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //presenter.Save();
        }


    }
}
