using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerBrower.ViewModel
{
    class ShortContract_VM : ObservableObject, IPageViewModel
    {
        DataModel.ShortContract_DM dm = new DataModel.ShortContract_DM();

        public uint EmployerId
        {
            get { return dm.EmployerId; }
            set
            {
                if(value != dm.EmployerId)
                {
                    dm.EmployerId = value;
                    RaisePropertyChanged("EmployerId");
                }
            }
        }
        public DateTime StartDate
        {
            get { return dm.StartDate; }
            set
            {
                if(value != dm.StartDate)
                {
                    dm.StartDate = value;
                    RaisePropertyChanged("StartDate");
                }
            }
        }
        public DateTime EndDate
        {
            get { return dm.EndDate; }
            set
            {
                if(value != dm.EndDate)
                {
                    dm.EndDate = value;
                    RaisePropertyChanged("EndDate");
                }
            }
        }
        public uint WorkHourPerDay
        {
            get { return dm.WorkHourPerDay; }
            set
            {
                if(value != dm.WorkHourPerDay)
                {
                    dm.WorkHourPerDay = value;
                    RaisePropertyChanged("WorkHourPerDay");
                }
            }
        }

    }
}
