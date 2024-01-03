using CarBook.Domain.Entities;

namespace TestProject1
{
    public interface IDbContext
    {
        public IList<Author> Authors { get; }

    }

}