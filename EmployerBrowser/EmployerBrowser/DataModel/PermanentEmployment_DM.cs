using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerBrower.DataModel
{
    class PermanentEmployment_DM
    {
        public uint EmployerId;
        public DateTime OnDutyTime;
        public DateTime OffDutyTime;
        public bool MondayOnDuty;
        public bool TuesdayOnDuty;
        public bool WednesdayOnDuty;
        public bool ThursdayOnDuty;
        public bool FridayOnDuty;
        public bool SaturdayOnDuty;
        public bool SundayOnDuty;
    }
}
