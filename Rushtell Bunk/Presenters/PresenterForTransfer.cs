using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExceptionsLibrary;
using System.Windows;

namespace Rushtell_Bunk
{
    class PresenterForTransfer
    {
        TransferWindow W;

        public PresenterForTransfer(TransferWindow W)
        {
            this.W = W;
        }

        /// <summary>
        /// Перевод денег со счета на счет клинтов
        /// </summary>
        public void TransferMoney()
        {
            try
            {
                if (Convert.ToDouble(W.sum.Text) < 0) throw new MoneyException("Sum can be only positive number");
                if (Convert.ToDouble(W.sum.Text) > Convert.ToDouble(W.Deposit.Text)) throw new MoneyException("You havent so much money");
                if (Repository.db[Convert.ToInt32(W.idAddressee.Text)] == null) throw new IDException("Wrong ID addressee");
                if (Repository.db[Convert.ToInt32(W.ID.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Organization") &&
                                Repository.db[Convert.ToInt32(W.idAddressee.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Worker")) throw new ClassTypeException("Juristical clints can transfer money only juristical client");
                if (Repository.db[Convert.ToInt32(W.ID.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.Organization") &&
                                Repository.db[Convert.ToInt32(W.idAddressee.Text)].GetType() ==
                                Type.GetType("Rushtell_Bunk.Clients.VIPworker")) throw new ClassTypeException("Juristical clints can transfer money only juristical client");

                Repository.db[Convert.ToInt32(W.ID.Text)].deposit -= Convert.ToDouble(W.sum.Text);
                Repository.db[Convert.ToInt32(W.idAddressee.Text)].deposit += Convert.ToDouble(W.sum.Text);
                EntityDB.Change(Repository.db[Convert.ToInt32(W.ID.Text)]);
                EntityDB.Change(Repository.db[Convert.ToInt32(W.idAddressee.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(ID.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(idAddressee.Text)]);
                string log = $"-->Со счёта клиента с ID: {W.ID.Text} была переведена сумма {W.sum.Text}, клиенту {W.idAddressee.Text}";
                using (StreamWriter st = new StreamWriter(@"logs.txt", true))
                {
                    st.WriteLine(log);
                }
                W.DialogResult = true;

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
