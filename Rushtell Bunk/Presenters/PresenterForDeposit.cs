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
    class PresenterForDeposit
    {
        DepositWindow W;

        public PresenterForDeposit(DepositWindow W)
        {
            this.W = W;
        }

        /// <summary>
        /// Внесение денег на счет клиента
        /// </summary>
        public void DepositMoney()
        {
            try
            {
                if (Convert.ToDouble(W.sum.Text) < 0) throw new MoneyException("Sum can be only positive number");
                Repository.db[Convert.ToInt32(W.ID.Text)].deposit += Convert.ToDouble(W.sum.Text);
                EntityDB.Change(Repository.db[Convert.ToInt32(W.ID.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(ID.Text)]);
                string log = $"-->Счёт клиента с ID: {W.ID.Text} был пополнен на сумму {W.sum.Text}";
                using (StreamWriter st = new StreamWriter(@"logs.txt", true))
                {
                    st.WriteLine(log);
                }
                W.DialogResult = true;
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
