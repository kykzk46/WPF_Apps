using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerBrower.ViewModel
{
    class Employer_VM : ObservableObject
    {
        DataModel.Employer_DM f = new DataModel.Employer_DM();

        public uint Id
        {
            get { return f.Id; }
            set
            {
                if(value != f.Id)
                {
                    f.Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string FirstName
        {
            get { return f.FirstName; }
            set
            {
                if(value !=f.FirstName)
                {
                    f.FirstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return f.LastName; }
            set
            {
                if (value != f.LastName)
                {
                    f.LastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return f.DateOfBirth; }
            set
            {
                if(value !=f.DateOfBirth)
                {
                    f.DateOfBirth = value;
                    RaisePropertyChanged("DateOfBirth");
                }
            }
        }

        public DataModel.Gender Sex
        {
            get { return f.Sex; }
            set
            {
                if(value != f.Sex)
                {
                    f.Sex = value;
                    RaisePropertyChanged("Sex");
                }
            }
        }

        public DataModel.EmploymentTypes EmploymentType
        {
            get { return f.EmploymentType; }
            set
            {
                if(value !=f.EmploymentType)
                {
                    f.EmploymentType = value;
                    RaisePropertyChanged("EmploymentType");
                }
            }
        }

    }
}
