using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rushtell_Bunk
{
    class Loger
    {
        public Loger(SystemPayments W)
        {
            using (FileStream st = new FileStream(@"logs.txt", FileMode.OpenOrCreate)) { }
            W.DepositChanged += W_DepositChanged;
        }

        private void W_DepositChanged(Clients.IClient client, double sum)
        {
            string log = $"Счёт клиента с ID: {client.Id} был пополнен на сумму {sum}";
            using(StreamWriter st = new StreamWriter(@"logs.txt", true))
            {
                st.WriteLine(log);
            }
        }
    }
}
