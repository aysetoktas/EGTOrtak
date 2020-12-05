using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public virtual ICollection<Lesson> Lessons{ get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
    }
}
