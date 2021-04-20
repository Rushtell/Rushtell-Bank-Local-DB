using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows;
using System.IO;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    /// <summary>
    /// Логика начисления денег на счет клиентов в зависимости от их параметров
    /// </summary>
    class SystemPayments : INotifyPropertyChanged
    {
        int timercount = 0;
        DispatcherTimer timer;

        public event Action<IClient, double> DepositChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public SystemPayments()
        {
            Loger loger = new Loger(this);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();

            //AddTestWorkers();
            
            Repository.Refresh();
        }

        /// <summary>
        /// Таймер который будет отсчитывать месяцы
        /// </summary>
        public int Timer
        {
            get { return timercount; }
            set
            {
                timercount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timer)));
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Логика после срабатывания таймера
            Timer++;
            Repository.correntMonth++;
            if (Repository.correntMonth == 13)
            {
                Repository.correntMonth = 1;
            }
            Payment();
        }

        /// <summary>
        /// Метод начисления выплат
        /// </summary>
        public void Payment()
        {
            for (int i = 0; i < Repository.db.Count; i++)
            {
                if (Repository.db[i] == null) continue;
                if (Repository.db[i].methodPayments == 1 && Repository.db[i].mounthCreateStandartPaymentMeth == Repository.correntMonth)
                {
                    MethodPaymentsStandart(i);
                }
                else if (Repository.db[i].methodPayments == 2)
                {
                    MethodPaymentsCapitalizated(i);
                }
            }
        }

        /// <summary>
        /// Метод для стандартной выплаты
        /// </summary>
        public void MethodPaymentsStandart(int Id)
        {
            if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.Worker"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.24 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.24;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }
            else if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.VIPworker"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.36 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.36;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }
            else if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.Organization"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.12 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.12;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }

        }

        /// <summary>
        /// Метод для выплаты каждый месяц
        /// </summary>
        public void MethodPaymentsCapitalizated(int Id)
        {
            if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.Worker"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.02 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.02;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }
            else if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.VIPworker"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.03 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.03;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }
            else if (Repository.db[Id].GetType() == Type.GetType("Rushtell_Bunk.Clients.Organization"))
            {
                DepositChanged?.Invoke(Repository.db[Id], Math.Round(Repository.db[Id].deposit * 1.01 - Repository.db[Id].deposit, 2));
                Repository.db[Id].deposit = Repository.db[Id].deposit * 1.01;
                Repository.db[Id].deposit = Math.Round(Repository.db[Id].deposit, 2);
                EntityDB.Change(Repository.db[Id]);
                //BaseSQL.Change(db[Id]);
            }
        }
    }
}
