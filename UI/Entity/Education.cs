using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Education:BaseEntity
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string ImagePath { get; set; }
        public int Hour { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string Certificate { get; set; }
        

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        //public virtual ICollection<Unit> Units { get; set; }







    }
}
