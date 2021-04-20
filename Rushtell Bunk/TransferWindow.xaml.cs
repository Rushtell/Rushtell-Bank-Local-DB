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
    /// Логика взаимодействия для TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        MainWindow W;
        public TransferWindow(MainWindow W)
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
                if (Repository.db[Convert.ToInt32(idAddressee.Text)] == null) throw new IDException("Wrong ID addressee");
                if (Repository.db[Convert.ToInt32(ID.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Organization") &&
                                Repository.db[Convert.ToInt32(idAddressee.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Worker")) throw new ClassTypeException("Juristical clints can transfer money only juristical client");
                if (Repository.db[Convert.ToInt32(ID.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Organization") &&
                                Repository.db[Convert.ToInt32(idAddressee.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.VIPworker")) throw new ClassTypeException("Juristical clints can transfer money only juristical client");

                Repository.db[Convert.ToInt32(ID.Text)].deposit -= Convert.ToDouble(sum.Text);
                Repository.db[Convert.ToInt32(idAddressee.Text)].deposit += Convert.ToDouble(sum.Text);
                EntityDB.Change(Repository.db[Convert.ToInt32(ID.Text)]);
                EntityDB.Change(Repository.db[Convert.ToInt32(idAddressee.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(ID.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(idAddressee.Text)]);
                string log = $"-->Со счёта клиента с ID: {ID.Text} была переведена сумма {sum.Text}, клиенту {idAddressee.Text}";
                using (StreamWriter st = new StreamWriter(@"logs.txt", true))
                {
                    st.WriteLine(log);
                }
                this.DialogResult = true;

            }
            catch (IDException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (MoneyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ClassTypeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong sum or ID addressee");
            }
        }
    }
}
