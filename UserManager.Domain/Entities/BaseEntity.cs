using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; internal set; }
        public DateTime? UpdatedAt { get; internal set; }
    }
}
