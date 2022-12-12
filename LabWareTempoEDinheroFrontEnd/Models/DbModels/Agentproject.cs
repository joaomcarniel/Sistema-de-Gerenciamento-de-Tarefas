using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class Agentproject
    {
        public Agentproject()
        {
            Tasks = new HashSet<TaskModel>();
        }

        public int IdAgentProject { get; set; }
        public int IdProject { get; set; }
        public int IdAgent { get; set; }
        public DateTime StartAction { get; set; }
        public DateTime? EndAction { get; set; }

        public virtual Agent IdAgentNavigation { get; set; }
        public virtual Project IdProjectNavigation { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}
