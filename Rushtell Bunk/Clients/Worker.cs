using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;

namespace Rushtell_Bunk.Clients
{
    class Worker : Human, IClient, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public int salaryF { get; set; }
        public double depositF { get; set; }
        public int methodPaymentsF { get; set; }
        public int mounthCreateStandartPaymentMethF { get; set; }
        public string depositTypeF { get; set; }
        public int IdF { get; protected set; }
        public string type { get; protected set; }

        public int salary 
        {
            get => salaryF;
            set
            {
                salaryF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.salary)));
            }
        }
        public double deposit
        {
            get => depositF;
            set
            {
                depositF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.deposit)));
            }
        }
        public int methodPayments
        {
            get => methodPaymentsF;
            set
            {
                methodPaymentsF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.methodPayments)));
            }
        }
        public int mounthCreateStandartPaymentMeth
        {
            get => mounthCreateStandartPaymentMethF;
            set
            {
                mounthCreateStandartPaymentMethF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.mounthCreateStandartPaymentMeth)));
            }
        }
        public string depositType
        {
            get => depositTypeF;
            set
            {
                depositTypeF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.depositType)));
            }
        }
        public int Id 
        {
            get => IdF;
            protected set
            {
                IdF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id)));
            }
        }

        public Worker (string firstname, string lastname, int age, int salary, int methodPayments, int correntMonth, int Id) : base (firstname, lastname, age)
        {
            deposit = 0;
            this.salary = salary;
            this.methodPayments = methodPayments;
            if (methodPayments == 1)
            {
                if (correntMonth == 0) mounthCreateStandartPaymentMeth = 1;
                else mounthCreateStandartPaymentMeth = correntMonth;
            }
            switch (methodPayments)
            {
                case 0:
                    depositType = "Non payments";
                    break;
                case 1:
                    depositType = "Standart payments";
                    break;
                case 2:
                    depositType = "Payments every mounth";
                    break;
                default:
                    depositType = "N/A deposit type";
                    break;
            }
            this.Id = Id;
            type = "Worker";
        }

        public Worker(string firstname, string lastname, int age, int salary,
            int methodPayments, int mounthCreateStandartPaymentMeth,
            double deposit, string depositType, int Id, string type) : base(firstname, lastname, age)
        {
            this.deposit = deposit;
            this.salary = salary;
            this.methodPayments = methodPayments;
            this.depositType = depositType;
            this.Id = Id;
            this.type = type;
            this.mounthCreateStandartPaymentMeth = mounthCreateStandartPaymentMeth;
        }

        public string getName()
        {
            return $"{firstname} {lastname}";
        }

        public int getSalary()
        {
            return salary;
        }

        
    }
}
