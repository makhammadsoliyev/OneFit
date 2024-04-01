using OneFit.Domain.Commons;

namespace OneFit.Domain.Entities;

public class Enrollment : Auditable
{
    public long UserId { get; set; }
    public long StudioId { get; set; }
}
