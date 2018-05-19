using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PersonalData
{
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string middleName;

        private int age;

        private long inn;

        private string avatar;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        /// <summary>
        /// ИНН
        /// </summary>
        public long Inn
        {
            get { return inn; }
            set
            {
                inn = value;
                OnPropertyChanged("Inn");
            }
        }

        /// <summary>
        /// Аватар
        /// </summary>
        public string Avatar
        {
            get { return avatar; }
            set
            {
                avatar = value;
                OnPropertyChanged("Avatar");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Событие изменения
        /// </summary>
        /// <param name="name"></param>
        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
