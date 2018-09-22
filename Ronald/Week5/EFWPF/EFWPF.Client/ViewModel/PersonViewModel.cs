using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EFWPF.Client.Helpers;
using EFWPF.Client.Messaging;
using EFWPF.Data;
using EFWPF.Repository.Abstract;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace EFWPF.Client.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;

        public PersonViewModel(IPersonRepository personRepository) // Constructor injectie (DirectInjection / IoC)
        {
            this.personRepository = personRepository;
            // Properties vullen / initieren
            PersonInfo = new Person();

            People = new ObservableCollection<Person>();
            GetPeopleCommand = new RelayCommand(GetPeople);
            SaveCommand = new RelayCommand<Person>(AddPerson);
            NewCommand = new RelayCommand(NewPerson);
            SearchCommand = new RelayCommand(SearchPerson);
            SendPersonCommand = new RelayCommand<Person>(SendPersonInfo);

            GenderTypes = new ObservableCollection<GenderType>
            {
                // Enum is een nettere oplossing
                new GenderType{ Name = "Vrouw", Value = 0},
                new GenderType{ Name = "Man", Value = 1}
            };
            // Enable Messages
            ReceivePersonInfo();
        }

        #region ViewModel Eigenschappen

        ObservableCollection<Person> _people;
        /// <summary>
        /// Observable Collection gebruikt in een DataGrid
        /// </summary>
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                RaisePropertyChanged("People");
            }
        }

        string _personName;

        /// <summary>
        /// Zoeken van een persoon via een voor of achternaam
        /// </summary>
        public string PersonName
        {
            get { return _personName; }
            set
            {
                _personName = value;
                RaisePropertyChanged("PersonName");
            }
        }

        Person _personInfo;

        /// <summary>
        /// Persoon object. Deze wordt gebruikt in de Save actie en bij de messenger
        /// </summary>
        public Person PersonInfo
        {
            get { return _personInfo; }
            set
            {
                _personInfo = value;
                RaisePropertyChanged(() => PersonInfo); // propertyExpression
            }
        }

        private ObservableCollection<GenderType> _genderTypes;
        public ObservableCollection<GenderType> GenderTypes
        {
            get { return _genderTypes; }
            set
            {
                _genderTypes = value;
                RaisePropertyChanged("GenderTypes");
            }
        }

        #endregion

        #region Commands
        public RelayCommand GetPeopleCommand { get; set; }
        public RelayCommand<Person> SaveCommand { get; set; }
        public RelayCommand NewCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand<Person> SendPersonCommand { get; set; }
        #endregion

        #region Actions
        private void GetPeople()
        {
            People.Clear();
            var people = personRepository.GetPeople();
            foreach (var item in people)
            {
                People.Add(item);
            }
        }

        private void AddPerson(Person person)
        {          
            if (person.Id > 0)
            {
                return;
            }

            // todo: Opslaan kan fout gaan implementeer altijd een foutafhandeling en toon een bericht aan de gebruiker!
            PersonInfo.Id = personRepository.CreatePerson(person);
            if (PersonInfo.Id > 0)
            {
                People.Add(PersonInfo);
                RaisePropertyChanged(()=>PersonInfo);
            }
        }

        private void NewPerson()
        {
            PersonInfo = new Person();
            RaisePropertyChanged(() => PersonInfo);
        }

        /// <summary>
        /// Deze methode stuurt de geselecteerde persoon van de DataGrid naar de SavePersonView
        /// </summary>
        /// <param name="person"></param>
        private void SendPersonInfo(Person person)
        {
            if (person != null)
            {
                Messenger.Default.Send(new MessageSender()
                {
                    Person = person
                });
            }
        }


        /// <summary>
        /// Deze methode ontvangt de data van de DataGrid en assigned het 
        /// aan de PersonInfo property. Omdat het een observable is wordt de 
        /// SavePersonView bijgewerkt.
        /// </summary>
        void ReceivePersonInfo()
        {
            if (PersonInfo != null)
            {
                Messenger.Default.Register<MessageSender>(this, (p) => {
                    this.PersonInfo = p.Person;
                });
            }
        }

        private void SearchPerson()
        {
            People.Clear();
            // Deze query kan beter! Hoe?
            var people = from p in personRepository.GetPeople() 
                         where p.Firstname.ToLower().Contains(PersonName.ToLower()) || p.Lastname.ToLower().Contains(PersonName.ToLower())
                         select p;
            foreach (var p in people)
            {
                People.Add(p);
            }
        }
        #endregion
    }
}
