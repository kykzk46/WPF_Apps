using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmFoundation.Wpf;
using System.Windows.Input;

namespace EmployerBrower.ViewModel
{
    class Main_VM : ObservableObject
    {
        #region Fields

        List<IPageViewModel> employmentInfo_VMs = new List<IPageViewModel>();

        #endregion


        #region Data Binding Properties

        ObservableCollection<Employer_VM> _Employers = new ObservableCollection<Employer_VM>();
        public ObservableCollection<Employer_VM> Employers
        {
            get { return _Employers; }
            set
            {
                if(_Employers != value)
                {
                    _Employers = value;
                    RaisePropertyChanged("Employers");
                }
            }
        }

        ObservableCollection<ShortContract_VM> _ShortContracts = new ObservableCollection<ShortContract_VM>();
        public ObservableCollection<ShortContract_VM> ShortContracts
        {
            get { return _ShortContracts; }
            set
            {
                if (_ShortContracts != value)
                {
                    _ShortContracts = value;
                    RaisePropertyChanged("ShortContracts");
                }
            }
        }

        ObservableCollection<PermanentEmployment_VM> _PermanentEmployments = new ObservableCollection<PermanentEmployment_VM>();
        public ObservableCollection<PermanentEmployment_VM> PermanentEmployments
        {
            get { return _PermanentEmployments; }
            set
            {
                if (_PermanentEmployments != value)
                {
                    _PermanentEmployments = value;
                    RaisePropertyChanged("PermanentEmployments");
                }
            }
        }

        IPageViewModel _CurrentDisplayPage;
        public IPageViewModel CurrentDisplayPage
        {
            get { return _CurrentDisplayPage; }
            set
            {
                if(value != _CurrentDisplayPage)
                {
                    _CurrentDisplayPage = value;
                    RaisePropertyChanged("CurrentDisplayPage");
                }
            }
        }

        Employer_VM _SelectedEmployer = new Employer_VM();
        public Employer_VM SelectedEmployer
        {
            get { return _SelectedEmployer; }
            set
            {
                if(_SelectedEmployer != value)
                {
                    _SelectedEmployer = value;
                    RaisePropertyChanged("SelectedEmployer");

                    OnSelectedEmployerChange(_SelectedEmployer);
                }
            }
        }

        #endregion

        #region Command

        RelayCommand<object> _ChangePageCommand = null;
        public ICommand ChangePageCommand
        {
            get
            {
                if (_ChangePageCommand == null)
                {
                    _ChangePageCommand = new RelayCommand<object>(p => OnChangePageViewModelCommand(p), (p) => CanChangePageViewModelCommand(p));
                }

                return _ChangePageCommand;
            }
        }
        bool CanChangePageViewModelCommand(object param)
        {
            return true;
        }

        private void OnChangePageViewModelCommand(object param)
        {

        }

        #endregion


        public Main_VM()
        {
            InsertFakeData();

            CurrentDisplayPage = PermanentEmployments.FirstOrDefault();
        }

        void InsertFakeData()
        {
            var empr1 = new Employer_VM()
            {
                Id = 1,
                FirstName = "Joe",
                LastName = "Potter",
                DateOfBirth = new DateTime(1970, 12, 30),
                EmploymentType = DataModel.EmploymentTypes.Permanent,
                Sex = DataModel.Gender.Male,
            };
            Employers.Add(empr1);

            var empr2 = new Employer_VM()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Stone",
                DateOfBirth = new DateTime(1937, 7, 7),
                EmploymentType = DataModel.EmploymentTypes.ShortContract,
                Sex = DataModel.Gender.Female,
            };
            Employers.Add(empr2);

            var empr3 = new Employer_VM()
            {
                Id = 3,
                FirstName = "Amy",
                LastName = "Gaga",
                DateOfBirth = new DateTime(1977, 4, 9),
                EmploymentType = DataModel.EmploymentTypes.ShortContract,
                Sex = DataModel.Gender.Female,
            };

            Employers.Add(empr3);
            var empr4 = new Employer_VM()
            {
                Id = 4,
                FirstName = "Petter",
                LastName = "Stark",
                DateOfBirth = new DateTime(1967, 12, 31),
                EmploymentType = DataModel.EmploymentTypes.Permanent,
                Sex = DataModel.Gender.Male,
            };
            Employers.Add(empr4);

            var sc1 = new ShortContract_VM()
            {
                EmployerId = 2,
                StartDate = new DateTime(2020, 1, 1),
                EndDate = new DateTime(2020, 2, 1),
                WorkHourPerDay = 9,
            };
            ShortContracts.Add(sc1);

            var sc2 = new ShortContract_VM()
            {
                EmployerId = 3,
                StartDate = new DateTime(2020, 1, 10),
                EndDate = new DateTime(2020, 3, 10),
                WorkHourPerDay = 9,
            };
            ShortContracts.Add(sc2);

            var pe1 = new PermanentEmployment_VM()
            {
                EmployerId = 1,
                OnDutyTime = new DateTime(1, 1, 1, 09, 30, 0),
                OffDutyTime = new DateTime(1, 1, 1, 18, 30, 0),
                MondayOnDuty = true,
                TuesdayOnDuty = true,
                WednesdayOnDuty = false,
                ThursdayOnDuty = true,
                FridayOnDuty = true,
                SaturdayOnDuty = true,
                SundayOnDuty = false,
            };
            PermanentEmployments.Add(pe1);

            var pe2 = new PermanentEmployment_VM()
            {
                EmployerId = 4,
                OnDutyTime = new DateTime(1, 1, 1, 17, 30, 0),
                OffDutyTime = new DateTime(1, 1, 1, 01, 30, 0),
                MondayOnDuty = true,
                TuesdayOnDuty = true,
                WednesdayOnDuty = true,
                ThursdayOnDuty = true,
                FridayOnDuty = true,
                SaturdayOnDuty = false,
                SundayOnDuty = false,
            };
            PermanentEmployments.Add(pe2);
        }


        void OnSelectedEmployerChange(Employer_VM selectedEmployer)
        {
            if (selectedEmployer.EmploymentType == DataModel.EmploymentTypes.Permanent)
            {
                var rst = from pe in PermanentEmployments
                          where pe.EmployerId == selectedEmployer.Id
                          select pe;

                CurrentDisplayPage = rst.FirstOrDefault();
            }
            else if (selectedEmployer.EmploymentType == DataModel.EmploymentTypes.ShortContract)
            {
                var rst = from pe in ShortContracts 
                          where pe.EmployerId == selectedEmployer.Id
                          select pe;

                CurrentDisplayPage = rst.FirstOrDefault();
            }
        }


    }




}
