using OneFit.Domain.Entities;

namespace OneFit.Service.DTOs.StudioFacilities;

public class StudioFacilityViewModel
{
    public long Id { get; set; }
    public Studio Studio { get; set; }
    public Facility Facility { get; set; }
}