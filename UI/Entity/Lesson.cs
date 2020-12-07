using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Lesson:BaseEntity
    {
        public string Name { get; set; }

        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int EducationID { get; set; }
        public virtual Education Education { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int? UnitID { get; set; }
        public virtual Unit Unit { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Content { get; set; }
        public string Logo { get; set; }
        public string Path { get; set; }
        public bool? IsLive { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Document> Documents { get; set; }



    }
}
