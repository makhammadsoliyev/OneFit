using OneFit.Domain.Commons;

namespace OneFit.Domain.Entities;

public class StudioFacility:Auditable
{
    public long StudioId { get; set; }
    public long FacilityId { get; set; }
}