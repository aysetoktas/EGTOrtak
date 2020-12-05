using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }
        public int EducationID { get; set; }
        public virtual Education Education {get;set;}
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
