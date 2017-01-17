namespace Abp.Domain.Specifications
{
    using System;
    using System.Linq.Expressions;

    public class AndNotSpecification<T> : CompositeSpecification<T>
    {
        #region Ctor
        /// <summary>
        /// Constructs a new instance of <c>AndNotSpecification&lt;T&gt;</c> class.
        /// </summary>
        /// <param name="left">The first specification.</param>
        /// <param name="right">The second specification.</param>
        public AndNotSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the LINQ expression which represents the current specification.
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        public override Expression<Func<T, bool>> GetExpression()
        {
            var bodyNot = Expression.Not(this.Right.GetExpression().Body);
            var bodyNotExpression = Expression.Lambda<Func<T, bool>>(bodyNot, this.Right.GetExpression().Parameters);

            return this.Left.GetExpression().And(bodyNotExpression);
        }
        #endregion
    }
}
