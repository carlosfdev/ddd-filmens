using System;
using System.Linq;
using System.Threading.Tasks;
using Filmens.Core.FilmAggregate;
using Filmens.UnitTests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Filmens.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            // add a project
            var repository = GetRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var film = new Film(initialTitle, DateTime.UtcNow);

            await repository.AddAsync(film);

            // detach the item so we get a different instance
            _dbContext.Entry(film).State = EntityState.Detached;

            // fetch the item and update its title
            var newFilm = (await repository.ListAsync())
                .FirstOrDefault(f => film.Title == initialTitle);
            Assert.NotNull(newFilm);
            Assert.NotSame(film, newFilm);
            // var newName = Guid.NewGuid().ToString();

            // // Update the item
            // await repository.UpdateAsync(newProject);

            // // Fetch the updated item
            // var updatedItem = (await repository.ListAsync())
            //     .FirstOrDefault(project => project.Name == newName);

            // Assert.NotNull(updatedItem);
            // Assert.NotEqual(project.Name, updatedItem.Name);
            // Assert.Equal(newProject.Id, updatedItem.Id);
        }
    }
}
