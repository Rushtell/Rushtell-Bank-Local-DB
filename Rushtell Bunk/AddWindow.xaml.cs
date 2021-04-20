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
using System.Windows.Shapes;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        PresenterForAdd presenter;

        public AddWindow()
        {
            InitializeComponent();
            presenter = new PresenterForAdd(this);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.MenuChange();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddClient();
        }
    }
}
