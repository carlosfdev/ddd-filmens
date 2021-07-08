using System.Linq;
using System;
using System.Threading.Tasks;
using Filmens.Core.FilmAggregate;
using Xunit;

namespace Filmens.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsProjectAndSetsId()
        {
            var testFilmTitle = "testFilm";
            var repository = GetRepository();
            var film = new Film(testFilmTitle, DateTime.UtcNow);

            await repository.AddAsync(film);

            var newFilm = (await repository.ListAsync())
                            .FirstOrDefault();

            Assert.Equal(testFilmTitle, film.Title);
            Assert.True(newFilm?.Id > 0);
        }
    }
}
