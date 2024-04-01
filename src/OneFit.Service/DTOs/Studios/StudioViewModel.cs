using OneFit.Domain.Enums;

namespace OneFit.Service.DTOs.Studios;

public class StudioViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public Domain.Enums.Type Type { get; set; }
    public long CategoryId { get; set; }
}
