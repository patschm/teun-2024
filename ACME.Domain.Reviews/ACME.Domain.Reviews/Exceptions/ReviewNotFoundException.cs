namespace ACME.Domain.Reviews.Exceptions;

public class ReviewNotFoundException : Exception
{
    public ReviewNotFoundException(long id) : base($"Review with Id {id} does not exist")
    {
        
    }
}
