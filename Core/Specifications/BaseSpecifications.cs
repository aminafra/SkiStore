using System.Linq.Expressions;

namespace Core.Specifications;

public class BaseSpecifications<T> : ISpecification<T>
{
    protected BaseSpecifications()
    {
    }

    public BaseSpecifications(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    protected void AddIncludes(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

}