using System;
using System.Collections.Generic;

#nullable disable

namespace LabWareTempoEDinheroFrontEnd.Models.Authorization
{
    public partial class User
    {
        public int IdUsers { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
    }
}
