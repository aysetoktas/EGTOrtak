using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Chat : BaseEntity
    {
        public string chatSubject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
        public bool ownerIsStudent { get; set; }
        public DateTime lastMessageTime { get; set; }

    }
}
