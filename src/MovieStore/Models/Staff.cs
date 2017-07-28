using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Staff
    {
        public string StaffID { get; set; }
        public string Name { get; set; }

        public Staff(string staffid, string name)
        {
            StaffID = staffid;
            Name = name;
        }
    }
}
