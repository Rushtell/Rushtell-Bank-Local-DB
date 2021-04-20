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
using System.IO;
using ExceptionsLibrary;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Логика взаимодействия для WithDrawWindow.xaml
    /// </summary>
    public partial class WithDrawWindow : Window
    {
        MainWindow W;
        PresenterForWithdraw presenter;

        public WithDrawWindow(MainWindow W)
        {
            InitializeComponent();
            this.W = W;
            ID.Text = W.idtext.Text;
            Deposit.Text = W.textDeposit.Text;
            presenter = new PresenterForWithdraw(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            presenter.WithdrawMoney();
        }
    }
}
