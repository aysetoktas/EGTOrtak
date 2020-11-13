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


        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string Content { get; set; }
        public string Logo { get; set; }
        public string Path { get; set; }
        public string ProjectLink { get; set; }
        public string DocumentLink { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Syllabu> Syllabus { get; set; }
        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}
