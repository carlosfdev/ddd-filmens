using Ardalis.GuardClauses;
using Filmens.SharedKernel;
using Filmens.SharedKernel.Interfaces;
using System;

namespace Filmens.Core.FilmAggregate
{
    public class Film : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime CreationDate { get; protected set; } = DateTime.UtcNow;

        public Film(string title, DateTime releaseDate)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            ReleaseDate = releaseDate;
        }
    }
}
