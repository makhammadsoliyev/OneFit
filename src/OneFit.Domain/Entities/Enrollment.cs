using OneFit.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFit.Domain.Entities
{
    public class Enrollment : Auditable
    {
        public long UserId { get; set; }
        public long StudioId { get; set; }
    }
}
