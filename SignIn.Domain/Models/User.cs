using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SignIn.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Snn { get; set; }
        public string Birthdate { get; set; }
        public string Password { get; set; }
        public bool ChangedPass { get; set; }

    }
}
