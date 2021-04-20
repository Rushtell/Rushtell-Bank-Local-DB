using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Rushtell_Bunk.Clients
{
    abstract class Human : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string firstnameF { get; set; }
        public string lastnameF { get; private set; }
        public int ageF { get; private set; }
        public string firstname
        {
            get => firstnameF;
            set
            {
                firstnameF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.firstname)));
            }
        }
        public string lastname
        {
            get => lastnameF; 
            private set
            {
                lastnameF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.lastname)));
            }
        }
        public int age
        {
            get => ageF;
            private set
            {
                ageF = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.age)));
            }
        }

        Random r = new Random();

        string[] randonFirstNames = new string[] { "Ваня", "Петя", "Саша", "Миша" };
        string[] randonLastNames = new string[] { "Иванов", "Петров", "Сидоров", "Букин" };

        public Human (string firstname, string lastname, int age)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }

        public Human()
        {
            firstname = randonFirstNames[r.Next(0, randonFirstNames.Length)];
            lastname = randonLastNames[r.Next(0, randonLastNames.Length)];
            age = r.Next(18, 71);
        }

        public void AgeUp()
        {
            age++;
        }
    }
}
