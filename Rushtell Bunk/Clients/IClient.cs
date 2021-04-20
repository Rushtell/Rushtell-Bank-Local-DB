using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushtell_Bunk.Clients
{
    interface IClient
    {
        string getName();
        int getSalary();
        double deposit { get; set; }
        int methodPayments { get; set; }
        int mounthCreateStandartPaymentMeth { get; set; }
        string depositType { get; set; }
        int Id { get; }
        string type { get; }
    }
}
