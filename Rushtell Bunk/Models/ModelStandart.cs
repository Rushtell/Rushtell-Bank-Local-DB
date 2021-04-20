using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Rushtell_Bunk.Clients;

namespace Rushtell_Bunk
{
    class ModelStandart
    {
        public SystemPayments buisnessLogic;

        public ConstructorRepositClients<IClient> LocalDB;

        public ObservableCollection<Worker> viewWorkers;

        public ObservableCollection<VIPworker> viewVIPworkers;

        public ObservableCollection<Organization> viewOrganizations;

        public EntityDB entityDB;

        public ModelStandart()
        {
            buisnessLogic = new SystemPayments();
            viewWorkers = Repository.dbWorkers;
            viewVIPworkers = Repository.dbVIPworkers;
            viewOrganizations = Repository.dbOrganizations;
            LocalDB = Repository.db;
        }

        public void ConnectToDB()
        {
            entityDB = new EntityDB();
        }

        public void RefreshLocalDB()
        {
            Repository.Refresh();
        }
    }
}
