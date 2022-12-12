using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class Customer
    {
        public Customer()
        {
            Projects = new HashSet<Project>();
        }

        public int IdCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string CpfCustomer { get; set; }
        public string AddressCustomer { get; set; }
        public string TelephoneCustomer { get; set; }
        public int StatusCustomer { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
