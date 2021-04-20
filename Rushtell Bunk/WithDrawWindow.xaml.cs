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
        public WithDrawWindow(MainWindow W)
        {
            InitializeComponent();
            this.W = W;
            ID.Text = W.idtext.Text;
            Deposit.Text = W.textDeposit.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(sum.Text) < 0) throw new MoneyException("Sum can be only positive number");
                if (Convert.ToDouble(sum.Text) > Convert.ToDouble(Deposit.Text)) throw new MoneyException("You havent so much money");
                Repository.db[Convert.ToInt32(ID.Text)].deposit -= Convert.ToDouble(sum.Text);
                EntityDB.Change(Repository.db[Convert.ToInt32(ID.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(ID.Text)]);
                string log = $"-->Со счёта клиента с ID: {ID.Text} была снята сумма {sum.Text}";
                using (StreamWriter st = new StreamWriter(@"logs.txt", true))
                {
                    st.WriteLine(log);
                }
                this.DialogResult = true;
            }
            catch (MoneyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Wrong sum");
            }
        }
    }
}
