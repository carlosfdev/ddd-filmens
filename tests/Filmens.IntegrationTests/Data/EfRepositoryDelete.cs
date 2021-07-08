using System;
using System.Threading.Tasks;
using Filmens.Core.FilmAggregate;
using Xunit;

namespace Filmens.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            // add a project
            var repository = GetRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var film = new Film(initialTitle, DateTime.UtcNow);
            await repository.AddAsync(film);

            // delete the item
            await repository.DeleteAsync(film);

            // verify it's no longer there
            Assert.DoesNotContain(await repository.ListAsync(),
                project => film.Title == initialTitle);
        }
    }
}
