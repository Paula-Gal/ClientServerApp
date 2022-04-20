using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    [Serializable]
    public class Entity<TID>
    {
        public TID ID { get; set; }
    }
}
