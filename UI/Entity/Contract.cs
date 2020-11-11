using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contract:BaseEntity
    {
        public string EduPrice { get; set; }

        public int? EducationID { get; set; }
        public virtual Education Education { get; set; }

        public string PricePerMonth { get; set; }
        public int EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
