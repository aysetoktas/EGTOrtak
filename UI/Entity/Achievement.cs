using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Achievement:BaseEntity
    {
        public string Name { get; set; }
        public int Date { get; set; }
        public int? LessonID { get; set; }
        public virtual Lesson Lesson { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
