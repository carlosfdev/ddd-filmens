using System;

namespace Filmens.Web.Endpoints.FilmEndpoints
{
    public class CreateFilmResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}