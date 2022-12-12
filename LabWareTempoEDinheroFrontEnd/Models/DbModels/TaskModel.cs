using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class TaskModel
    {
        public TaskModel()
        {
            Timecontroltasks = new HashSet<Timecontroltask>();
        }

        public int IdTask { get; set; }
        public int IdAgentProject { get; set; }
        public string Objective { get; set; }
        public string StatusTask { get; set; }

        public virtual Agentproject IdAgentProjectNavigation { get; set; }
        public virtual ICollection<Timecontroltask> Timecontroltasks { get; set; }
    }
}
