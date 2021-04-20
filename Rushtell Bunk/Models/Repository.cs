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
    /// Все базы данных клиентов хранятся здесь
    /// </summary>
    static class Repository
    {
        public static ConstructorRepositClients<IClient> db = new ConstructorRepositClients<IClient>();

        public static ObservableCollection<Organization> dbOrganizations = new ObservableCollection<Organization>();

        public static ObservableCollection<VIPworker> dbVIPworkers = new ObservableCollection<VIPworker>();

        public static ObservableCollection<Worker> dbWorkers = new ObservableCollection<Worker>();

        /// <summary>
        /// Счетчик месяца в приложении для установки выплат клиентам непосредственно в те месяцы когда создан их счет
        /// </summary>
        public static int correntMonth = 0;

        /// <summary>
        /// Метод обновления коллекций
        /// </summary>
        public static void Refresh()
        {
            dbWorkers.Clear();
            dbOrganizations.Clear();
            dbVIPworkers.Clear();
            for (int i = 0; i < db.Count; i++)
            {
                if (db[i] == null) continue;
                if (db[i].GetType() == Type.GetType("Rushtell_Bunk.Clients.Worker"))
                {
                    dbWorkers.Add((Worker)db[i]);
                }
                else if (db[i].GetType() == Type.GetType("Rushtell_Bunk.Clients.VIPworker"))
                {
                    dbVIPworkers.Add((VIPworker)db[i]);
                }
                else if (db[i].GetType() == Type.GetType("Rushtell_Bunk.Clients.Organization"))
                {
                    dbOrganizations.Add((Organization)db[i]);
                }
            }
        }
    }
}
