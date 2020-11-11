using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Teacher:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Detail { get; set; }
        public string Note { get; set; }


        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}
