namespace Blocks.Domain;

public interface IAuditableAction
{
    int CreatedById { get; set; }
    DateTime CreatedOn { get; }
}
