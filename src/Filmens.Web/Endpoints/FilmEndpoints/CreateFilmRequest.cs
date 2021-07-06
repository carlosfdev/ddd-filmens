using System.ComponentModel.DataAnnotations;
using System;

namespace Filmens.Web.Endpoints.FilmEndpoints
{
    public class CreateFilmRequest
    {
        public const string Route = "/films";

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}