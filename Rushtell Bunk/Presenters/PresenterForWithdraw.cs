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
    class PresenterForWithdraw
    {
        WithDrawWindow W;

        public PresenterForWithdraw(WithDrawWindow W)
        {
            this.W = W;
        }

        /// <summary>
        /// Снятие денег со счета клиента
        /// </summary>
        public void WithdrawMoney()
        {
            try
            {
                if (Convert.ToDouble(W.sum.Text) < 0) throw new MoneyException("Sum can be only positive number");
                if (Convert.ToDouble(W.sum.Text) > Convert.ToDouble(W.Deposit.Text)) throw new MoneyException("You havent so much money");
                Repository.db[Convert.ToInt32(W.ID.Text)].deposit -= Convert.ToDouble(W.sum.Text);
                EntityDB.Change(Repository.db[Convert.ToInt32(W.ID.Text)]);
                //BaseSQL.Change(SystemPayments.db[Convert.ToInt32(ID.Text)]);
                string log = $"-->Со счёта клиента с ID: {W.ID.Text} была снята сумма {W.sum.Text}";
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
