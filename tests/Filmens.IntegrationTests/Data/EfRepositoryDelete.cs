using System;
using System.Threading.Tasks;
using Filmens.Core.FilmAggregate;
using Xunit;

namespace Filmens.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesFilmfterAddingIt()
        {
            var repository = GetRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var film = new Film(initialTitle, DateTime.UtcNow);
            await repository.AddAsync(film);

            await repository.DeleteAsync(film);

            Assert.DoesNotContain(await repository.ListAsync(),
                f => film.Title == initialTitle);
        }
    }
}
