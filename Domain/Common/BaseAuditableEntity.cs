namespace Sat.Recruitment.Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public string? CreateBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
