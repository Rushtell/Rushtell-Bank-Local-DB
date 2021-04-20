using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    class EntityDB
    {
        static EDMdbRushBank db;

        /// <summary>
        /// Инициализируем базу при помощи EntityFramework и заполняем локальную базу из удаленной для более быстрой работы
        /// </summary>
        public EntityDB()
        {
            db = new EDMdbRushBank();
            var dbWorkers = db.Workers;
            var dbVIPworkers = db.VIPworkers;
            var dbOrganizations = db.Organizations;

            if (!db.Workers.Any() && !db.VIPworkers.Any() && !db.Organizations.Any()) AddTestWorkers();

            int maxid = 0;
            foreach (var item in dbWorkers)
            {
                if (item.Id > maxid) maxid = item.Id;
            }
            foreach (var item in dbVIPworkers)
            {
                if (item.Id > maxid) maxid = item.Id;
            }
            foreach (var item in dbOrganizations)
            {
                if (item.Id > maxid) maxid = item.Id;
            }

            for (int i = 0; i <= maxid; i++)
            {
                bool check = false;
                foreach (var item in dbWorkers)
                {
                    if (item.Id == i)
                    {
                        if (item.type != "DELETED")
                        {
                            Repository.db.Add(new Worker(item.firstname,
                    item.lastname, item.age, item.salary,
                    item.methodPayments, item.mounthCreateStandartPaymentMeth,
                    item.deposit, item.depositType, item.Id, item.type));
                            check = true;
                        }
                        else
                        {
                            Repository.db.Add(default);
                            check = true;
                        }
                    }
                }
                if (check) continue;
                foreach (var item in dbVIPworkers)
                {
                    if (item.Id == i)
                    {
                        if (item.type != "DELETED")
                        {
                            Repository.db.Add(new VIPworker(item.firstname,
                    item.lastname, item.age, item.salary,
                    item.methodPayments, item.mounthCreateStandartPaymentMeth,
                    item.deposit, item.depositType, item.Id, item.type));
                            check = true;
                        }
                        else
                        {
                            Repository.db.Add(default);
                            check = true;
                        }
                    }
                }
                if (check) continue;
                foreach (var item in dbOrganizations)
                {
                    if (item.Id == i)
                    {
                        if (item.type != "DELETED")
                        {
                            Repository.db.Add(new Organization(item.name, item.salary,
                    item.methodPayments, item.mounthCreateStandartPaymentMeth,
                    item.deposit, item.depositType, item.Id, item.type));
                        }
                        else
                        {
                            Repository.db.Add(default);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод изменяющий депозит клинта в базе данных
        /// </summary>
        /// <param name="client"></param>
        public static void Change(IClient client)
        {
            if (client.type == "Worker")
            {
                var clientInDBW = db.Workers.Where(e => e.Id == client.Id);
                foreach (var item in clientInDBW)
                {
                    item.deposit = ((Worker)client).deposit;
                }
            }
            else if (client.type == "VIPworker")
            {
                var clientInDBVIP = db.VIPworkers.Where(e => e.Id == client.Id);
                foreach (var item in clientInDBVIP)
                {
                    item.deposit = ((VIPworker)client).deposit;
                }
            }
            else if (client.type == "Organization")
            {
                var clientInDBO = db.Organizations.Where(e => e.Id == client.Id);
                foreach (var item in clientInDBO)
                {
                    item.deposit = ((Organization)client).deposit;
                }
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Метод полностью стирающий клиента из базы данных
        /// </summary>
        /// <param name="Id"></param>
        public static void Delete(int Id)
        {
            var clientInDBW = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBW)
            {
                db.Workers.Remove(item);
            }
            var clientInDBVIP = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBVIP)
            {
                db.Workers.Remove(item);
            }
            var clientInDBO = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBO)
            {
                db.Workers.Remove(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Метод изменяющий тип клиента на "DELETED" в базе данных
        /// </summary>
        /// <param name="Id"></param>
        public static void LowDelete(int Id)
        {
            var clientInDBW = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBW)
            {
                item.type = "DELETED";
            }
            var clientInDBVIP = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBVIP)
            {
                item.type = "DELETED";
            }
            var clientInDBO = db.Workers.Where(e => e.Id == Id);
            foreach (var item in clientInDBO)
            {
                item.type = "DELETED";
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Метод добавления клиента в базу данных
        /// </summary>
        /// <param name="client"></param>
        public static void Add(IClient client)
        {
            if (client.type == "Worker")
            {
                db.Workers.Add(new Workers()
                {
                    Id = ((Worker)client).Id,
                    firstname = ((Worker)client).firstname,
                    lastname = ((Worker)client).lastname,
                    age = ((Worker)client).age,
                    salary = ((Worker)client).salary,
                    deposit = ((Worker)client).deposit,
                    methodPayments = ((Worker)client).methodPayments,
                    mounthCreateStandartPaymentMeth = ((Worker)client).mounthCreateStandartPaymentMeth,
                    depositType = ((Worker)client).depositType,
                    type = ((Worker)client).type
                });
            }
            else if (client.type == "VIPworker")
            {
                db.VIPworkers.Add(new VIPworkers()
                {
                    Id = ((VIPworker)client).Id,
                    firstname = ((VIPworker)client).firstname,
                    lastname = ((VIPworker)client).lastname,
                    age = ((VIPworker)client).age,
                    salary = ((VIPworker)client).salary,
                    deposit = ((VIPworker)client).deposit,
                    methodPayments = ((VIPworker)client).methodPayments,
                    mounthCreateStandartPaymentMeth = ((VIPworker)client).mounthCreateStandartPaymentMeth,
                    depositType = ((VIPworker)client).depositType,
                    type = ((VIPworker)client).type
                });
            }
            else if (client.type == "Organization")
            {
                db.Organizations.Add(new Organizations()
                {
                    Id = ((Organization)client).Id,
                    name = ((Organization)client).name,
                    salary = ((Organization)client).salary,
                    deposit = ((Organization)client).deposit,
                    methodPayments = ((Organization)client).methodPayments,
                    mounthCreateStandartPaymentMeth = ((Organization)client).mounthCreateStandartPaymentMeth,
                    depositType = ((Organization)client).depositType,
                    type = ((Organization)client).type
                });
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Метод чтобы добавть тестовые данные
        /// </summary>
        private static void AddTestWorkers()
        {
            Worker testWorker = new Worker("Ваня", "НеТупой", 20, 1000, 2, Repository.correntMonth, 0);
            testWorker.deposit = 1000;
            Add(testWorker);
            testWorker = new Worker("Саня", "НеТупой", 20, 1000, 2, Repository.correntMonth, 1);
            testWorker.deposit = 2000;
            Add(testWorker);
            testWorker = new Worker("Миша", "НеТупой", 20, 1000, 2, Repository.correntMonth, 2);
            testWorker.deposit = 3000;
            Add(testWorker);
            testWorker = new Worker("Ваня", "НеТупой", 20, 1000, 2, Repository.correntMonth, 3);
            testWorker.deposit = 1000;
            Add(testWorker);
            testWorker = new Worker("Миша", "НеТупой", 20, 1000, 2, Repository.correntMonth, 4);
            testWorker.deposit = 2000;
            Add(testWorker);
            testWorker = new Worker("Саня", "НеТупой", 20, 1000, 2, Repository.correntMonth, 5);
            testWorker.deposit = 3000;
            Add(testWorker);
            Organization testOrg = new Organization("ООО", 1000000, 2, Repository.correntMonth, 6);
            testWorker.deposit = 1000000;
            Add(testOrg);
        }
    }
}
