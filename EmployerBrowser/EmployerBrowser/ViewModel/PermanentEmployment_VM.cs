using MvvmFoundation.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerBrower.ViewModel
{
    class PermanentEmployment_VM : ObservableObject, IPageViewModel 
    {
        DataModel.PermanentEmployment_DM dm = new DataModel.PermanentEmployment_DM();

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
        public DateTime OnDutyTime
        {
            get { return dm.OnDutyTime; }
            set
            {
                if(value != dm.OnDutyTime)
                {
                    dm.OnDutyTime = value;
                    RaisePropertyChanged("OnDutyTime");
                }
            }
        }
        public DateTime OffDutyTime
        {
            get { return dm.OffDutyTime; }
            set
            {
                if(value != dm.OffDutyTime)
                {
                    dm.OffDutyTime = value;
                    RaisePropertyChanged("OffDutyTime");
                }
            }
        }
        public bool MondayOnDuty
        {
            get { return dm.MondayOnDuty; }
            set
            {
                if(value != dm.MondayOnDuty)
                {
                    dm.MondayOnDuty = value;
                    RaisePropertyChanged("MondayOnDuty");
                }
            }
        }
        public bool TuesdayOnDuty
        {
            get { return dm.TuesdayOnDuty; }
            set
            {
                if(value != dm.TuesdayOnDuty)
                {
                    dm.TuesdayOnDuty = value;
                    RaisePropertyChanged("TuesdayOnDuty");
                }
            }
        }
        public bool WednesdayOnDuty
        {
            get { return dm.WednesdayOnDuty; }
            set
            {
                if(value != dm.WednesdayOnDuty)
                {
                    dm.WednesdayOnDuty = value;
                    RaisePropertyChanged("WednesdayOnDuty");
                }
            }
        }
        public bool ThursdayOnDuty
        {
            get { return dm.ThursdayOnDuty; }
            set
            {
                if(value != dm.ThursdayOnDuty)
                {
                    dm.ThursdayOnDuty = value;
                    RaisePropertyChanged("ThursdayOnDuty");
                }
            }
        }
        public bool FridayOnDuty
        {
            get { return dm.FridayOnDuty; }
            set
            {
                if(value != dm.FridayOnDuty)
                {
                    dm.FridayOnDuty = value;
                    RaisePropertyChanged("FridayOnDuty");
                }
            }
        }
        public bool SaturdayOnDuty
        {
            get { return dm.SaturdayOnDuty; }
            set
            {
                if(value != dm.SaturdayOnDuty)
                {
                    dm.SaturdayOnDuty = value;
                    RaisePropertyChanged("SaturdayOnDuty");
                }
            }
        }
        public bool SundayOnDuty
        {
            get { return dm.SundayOnDuty; }
            set
            {
                if(value != dm.SundayOnDuty)
                {
                    dm.SundayOnDuty = value;
                    RaisePropertyChanged("SundayOnDuty");
                }
            }
        }
    }
}
