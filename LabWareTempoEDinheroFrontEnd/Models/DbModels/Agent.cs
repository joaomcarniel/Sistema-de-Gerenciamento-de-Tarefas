using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class Agent
    {
        public Agent()
        {
            Agentprojects = new HashSet<Agentproject>();
        }

        public int IdAgent { get; set; }
        public string NameAgent { get; set; }
        public string StatusAgent { get; set; }

        public virtual ICollection<Agentproject> Agentprojects { get; set; }
    }
}
