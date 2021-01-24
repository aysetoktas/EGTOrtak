using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Message : BaseEntity
    {
        public DateTime date { get; set; }
        public string message { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
        public bool fromStudent { get; set; }

        [DefaultValue(false)]
        public bool isRead { get; set; }
    }
}
