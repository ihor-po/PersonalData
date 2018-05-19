using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Collections.ObjectModel; //ObservableCollection

namespace PersonalData
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; }

        private Person selectedPerson;

        public ViewModel()
        {
            Persons = new ObservableCollection<Person>
            {
                new Person
                {
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    LastName = "Спиридонов",
                    Age = 45,
                    Inn = 1231231231,
                    Avatar = "user.ico"
                },
                new Person
                {
                    FirstName = "Андорин",
                    MiddleName = "Адоринов",
                    LastName = "Лапковский",
                    Age = 34,
                    Inn = 2342342342,
                    Avatar = "Person-purple.png"
                },
                new Person
                {
                    FirstName = "Ферана",
                    MiddleName = "Ферановна",
                    LastName = "Капушкина",
                    Age = 33,
                    Inn = 3453453453,
                    Avatar = "Person_blue.png"
                },
                new Person
                {
                    FirstName = "Кинурина",
                    MiddleName = "Адимовна",
                    LastName = "Вапирки",
                    Age = 189,
                    Inn = 4564564564,
                    Avatar = "Person.png"
                },
                new Person
                {
                    FirstName = "Петр",
                    MiddleName = "Петрович",
                    LastName = "Иванов",
                    Age = 33,
                    Inn = 5675675675,
                    Avatar = "Person-purple.png"
                },
                new Person
                {
                    FirstName = "Федер",
                    MiddleName = "Федерович",
                    LastName = "Петров",
                    Age = 21,
                    Inn = 6786786786,
                    Avatar = "Person_blue.png"
                },
                new Person
                {
                    FirstName = "Фаралакс",
                    MiddleName = "Фаралаксович",
                    LastName = "Фонарев",
                    Age = 1099,
                    Inn = 7897897897,
                    Avatar = "Person.png"
                }
            };
        }

        /// <summary>
        /// Выбранная персона
        /// </summary>
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
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
