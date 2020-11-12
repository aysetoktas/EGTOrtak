using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Student:BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
