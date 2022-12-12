#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.DbModels
{
    public partial class Timecontroltask
    {
        public int IdTimeControlTask { get; set; }
        public int IdTask { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? StopTime { get; set; }

        public virtual TaskModel IdTaskNavigation { get; set; }
    }
}
