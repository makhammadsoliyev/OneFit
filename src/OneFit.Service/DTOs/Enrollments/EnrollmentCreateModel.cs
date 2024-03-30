using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFit.Service.DTOs.Enrollments
{
    public class EnrolmentCreateModel
    {
        public long UserId { get; set; }
        public long StudioId { get; set; }
    }
}
