﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Rushtell_Bunk.Clients;
using SaveAndLoadLibrary;

namespace Rushtell_Bunk
{
    class PresenterForMain
    {
        MainWindow W;
        ModelStandart model;

        public PresenterForMain(MainWindow W)
        {
            this.W = W;
            model = new ModelStandart();
        }

        public void LoadData()
        {
            W.DataContext = model.buisnessLogic;

            var load = Task.Factory.StartNew(() =>
            {
                model.ConnectToDB();
            });
            load.ContinueWith((a) =>
            {
                W.Dispatcher.Invoke(() => Repository.Refresh());
            });
            W.lsW.ItemsSource = model.viewWorkers;
            W.lsVIPW.ItemsSource = model.viewVIPworkers;
            W.lsOrg.ItemsSource = model.viewOrganizations;
        }

        public void SetVIPWorker()
        {
            if (W.tabLists.SelectedIndex == 0)
            {
                if (W.lsW.SelectedIndex != -1)
                {
                    int Id = Repository.db.GetId((Worker)W.lsW.SelectedItem);
                    VIPworker newvip = new VIPworker((Worker)Repository.db[Id]);
                    Repository.db.ReWrite(newvip, Id);
                    EntityDB.Delete(newvip.Id);
                    EntityDB.Add(newvip);
                    Repository.Refresh();
                }
                else MessageBox.Show("Select client");
            }
            else MessageBox.Show("VIP can be seted only standart clients!");
        }

        public void ViewConcretData()
        {
            W.idtext.Text = "";
            W.textDeposit.Text = "";
            if (W.tabLists.SelectedIndex == 0)
            {
                if (W.lsW.SelectedIndex != -1)
                {
                    W.idtext.Text = $"{((Worker)W.lsW.SelectedItem).Id.ToString()}";
                    W.textDeposit.Text = $"{((Worker)W.lsW.SelectedItem).deposit.ToString()}";
                }
            }
            else if (W.tabLists.SelectedIndex == 1)
            {
                if (W.lsVIPW.SelectedIndex != -1)
                {
                    W.idtext.Text = $"{((VIPworker)W.lsVIPW.SelectedItem).Id.ToString()}";
                    W.textDeposit.Text = $"{((VIPworker)W.lsVIPW.SelectedItem).deposit.ToString()}";

                }
            }
            else if (W.tabLists.SelectedIndex == 2)
            {
                if (W.lsOrg.SelectedIndex != -1)
                {
                    W.idtext.Text = $"{((Organization)W.lsOrg.SelectedItem).Id.ToString()}";
                    W.textDeposit.Text = $"{((Organization)W.lsOrg.SelectedItem).deposit.ToString()}";
                }
            }
        }

        public void Delete()
        {
            if (W.tabLists.SelectedIndex == 0)
            {
                if (W.lsW.SelectedIndex != -1)
                {
                    EntityDB.LowDelete(((Worker)W.lsW.SelectedItem).Id);
                    Repository.db.Delete(((Worker)W.lsW.SelectedItem).Id);
                }
            }
            else if (W.tabLists.SelectedIndex == 1)
            {
                if (W.lsVIPW.SelectedIndex != -1)
                {
                    EntityDB.LowDelete(((VIPworker)W.lsVIPW.SelectedItem).Id);
                    Repository.db.Delete(((VIPworker)W.lsVIPW.SelectedItem).Id);
                }
            }
            else if (W.tabLists.SelectedIndex == 2)
            {
                if (W.lsOrg.SelectedIndex != -1)
                {
                    EntityDB.LowDelete(((Organization)W.lsOrg.SelectedItem).Id);
                    Repository.db.Delete(((Organization)W.lsOrg.SelectedItem).Id);
                }
            }
            Repository.Refresh();
        }

        public void Save()
        {
            var save = Task.Factory.StartNew(() => new Save(Repository.db));
            save.Wait();
        }

        public void CreateAddWindow()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        public void CreateDepositWindow()
        {
            if (W.idtext.Text != "")
            {
                DepositWindow W = new DepositWindow(this.W);
                if (W.ShowDialog() == true)
                {
                    Repository.Refresh();
                    MessageBox.Show("The money has been successfully deposited!");
                }
            }
        }

        public void CreateWithdrawWindow()
        {
            if (W.idtext.Text != "")
            {
                WithDrawWindow W = new WithDrawWindow(this.W);
                if (W.ShowDialog() == true)
                {
                    Repository.Refresh();
                    MessageBox.Show("The money has been successfully withdraw!");
                }
            }
        }

        public void CreateTransferWindow()
        {
            if (W.idtext.Text != "")
            {
                TransferWindow W = new TransferWindow(this.W);
                if (W.ShowDialog() == true)
                {
                    Repository.Refresh();
                    MessageBox.Show("The money has been successfully transfered!");
                }
            }
        }
    }
}
