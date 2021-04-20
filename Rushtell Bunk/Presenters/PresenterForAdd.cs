using Rushtell_Bunk.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Rushtell_Bunk
{
    class PresenterForAdd
    {
        AddWindow W;

        public PresenterForAdd(AddWindow W)
        {
            this.W = W;
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void AddClient() 
        {
            if (W.accType.SelectedIndex == 0)
            {
                if (W.nameOrg.Text != "" && W.salaryOrg.Text != "" && W.typePayOrg.SelectedIndex != -1)
                {
                    try
                    {
                        Organization newOrg = new Organization(W.nameOrg.Text, Convert.ToInt32(W.salaryOrg.Text),
                            W.typePayOrg.SelectedIndex, Repository.correntMonth, Repository.db.Count);
                        Repository.db.Add(newOrg);
                        Repository.Refresh();
                        EntityDB.Add(newOrg);
                        //BaseSQL.Add(newOrg);
                        W.DialogResult = true;
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }
                }
                else MessageBox.Show("All string must be fulled!");
            }
            else if (W.accType.SelectedIndex == 1)
            {
                if (W.firstnameW.Text != "" && W.lastnameW.Text != "" && W.ageW.Text != "" && W.salaryW.Text != "" && W.typePayW.SelectedIndex != -1)
                {
                    try
                    {
                        Worker newW = new Worker(W.firstnameW.Text, W.lastnameW.Text, Convert.ToInt32(W.ageW.Text),
                        Convert.ToInt32(W.salaryW.Text), W.typePayW.SelectedIndex,
                        Repository.correntMonth, Repository.db.Count);
                        Repository.db.Add(newW);
                        Repository.Refresh();
                        EntityDB.Add(newW);
                        //BaseSQL.Add(newW);
                        W.DialogResult = true;
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }
                }
                else MessageBox.Show("All string must be fulled!");
            }
            else return;
        }

        /// <summary>
        /// Изменение меню
        /// </summary>
        public void MenuChange()
        {
            if (W.accType.SelectedIndex == 0)
            {
                W.gridW.Visibility = Visibility.Hidden;
                W.gridOrg.Visibility = Visibility.Visible;
            }
            else if (W.accType.SelectedIndex == 1)
            {
                W.gridOrg.Visibility = Visibility.Hidden;
                W.gridW.Visibility = Visibility.Visible;
            }
            else
            {
                W.gridOrg.Visibility = Visibility.Hidden;
                W.gridW.Visibility = Visibility.Hidden;
            }
        }
    }
}
