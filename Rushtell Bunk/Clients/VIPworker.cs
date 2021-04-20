using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rushtell_Bunk.Clients
{
    class VIPworker : Worker
    {
        public VIPworker (Worker worker) : base (worker.firstname, worker.lastname,
            worker.age, worker.salary, worker.methodPayments, worker.mounthCreateStandartPaymentMeth,
            worker.deposit, worker.depositType, worker.Id, "VIPworker") { }

        public VIPworker (string firstname, string lastname, int age, int salary,
            int methodPayments, int mounthCreateStandartPaymentMeth, double deposit,
            string depositType, int Id, string type) : base(firstname, lastname, age,
                salary, methodPayments, mounthCreateStandartPaymentMeth, deposit, depositType, Id, type) { }
    }
}
