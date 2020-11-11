using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inspection:BaseEntity
    {
        public bool IsCome { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int AchievementID { get; set; }
        public virtual Achievement Achievement { get; set; }
    }
}
