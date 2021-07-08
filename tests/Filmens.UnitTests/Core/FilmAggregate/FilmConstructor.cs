using Filmens.Core.FilmAggregate;
using Xunit;
using System;

namespace Filmens.UnitTests.Core.FilmAggregate
{
    public class FilmConstructor
    {
        private string _testTitle = "test title";
        private DateTime _testReleaseDate = DateTime.UtcNow;
        private Film _testFilm = null;

        private Film CreateFilm()
        {
            return new Film(_testTitle, _testReleaseDate);
        }

        [Fact]
        public void InitializesTitle()
        {
            _testFilm = CreateFilm();

            Assert.Equal(_testTitle, _testFilm.Title);
        }

        [Fact]
        public void InitializesReleaseDate()
        {
            _testFilm = CreateFilm();

            Assert.Equal(_testReleaseDate, _testFilm.ReleaseDate);
        }

    }
}
