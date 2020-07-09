using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerBrower.DataModel
{
    enum Gender { Male, Female, }
    enum EmploymentTypes { Permanent, ShortContract, }

    class Employer_DM
    {
        public uint Id;
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public Gender Sex;
        public EmploymentTypes EmploymentType;
    }
}
