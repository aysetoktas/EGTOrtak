using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer:BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}
