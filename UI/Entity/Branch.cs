using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Branch:BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
