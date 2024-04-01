using OneFit.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace OneFit.Domain.Entities;

public class Studio : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    [EnumDataType(typeof(Enums.Type))]
    public Enums.Type Type { get; set; }
    public long CategoryId { get; set; }
}