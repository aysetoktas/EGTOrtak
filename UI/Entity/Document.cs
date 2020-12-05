using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Document:BaseEntity
    {
        public int LessonID { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
