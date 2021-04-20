using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Rushtell_Bunk.Clients
{
    class Organization : IClient, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string nameF { get; private set; }
        public int salaryF { get; private set; }
        public double depositF { get; set; }
        public int methodPaymentsF { get; set; }
        public int mounthCreateStandartPaymentMethF { get; set; }
        public string depositTypeF { get; set; }
        public int IdF { get; protected set; }
        public string type { get; protected set; }

        public string name
        {
            get => nameF;
            private set
            {
                nameF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
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

        public Organization(string name, int salary, int methodPayments, int correntMonth, int Id)
        {
            deposit = 0;
            this.name = name;
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
            type = "Organization";
        }

        public Organization(string name, int salary, int methodPayments,
            int mounthCreateStandartPaymentMeth, double deposit,
            string depositType, int Id, string type)
        {
            this.deposit = deposit;
            this.name = name;
            this.salary = salary;
            this.methodPayments = methodPayments;
            this.depositType = depositType;
            this.Id = Id;
            this.type = type;
            this.mounthCreateStandartPaymentMeth = mounthCreateStandartPaymentMeth;
        }

        public void SalaryChange(int salaryUp)
        {
            salary += salaryUp;
        }

        public string getName()
        {
            return name;
        }

        public int getSalary()
        {
            return salary;
        }
    }
}
