using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class Project
    {
        public Project()
        {
            Agentprojects = new HashSet<Agentproject>();
        }

        public int IdProject { get; set; }
        public int IdCustomer { get; set; }
        public string StatusProject { get; set; }
        public string NameProject { get; set; }
        public int LeaderProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DescriptionProject { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<Agentproject> Agentprojects { get; set; }
    }
}
