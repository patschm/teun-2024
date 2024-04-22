namespace ACME.Domain.Reviews.Entities;

// record. Immutable objecten
public sealed record Reviewer
{
    public Reviewer(long id, string? name)
    {
        Id = id; 
        Name = name;
    }
    public long Id { get; init; } // init ipv set maakt het property immutable
    public string? Name { get; init; }
}
