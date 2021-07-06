using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Filmens.Core.FilmAggregate;
using Filmens.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Filmens.Web.Endpoints.FilmEndpoints
{
    public class CreateFilmEndpoint : BaseAsyncEndpoint
        .WithRequest<CreateFilmRequest>
        .WithResponse<CreateFilmResponse>
    {
        private readonly IRepository<Film> _repository;

        public CreateFilmEndpoint(IRepository<Film> repository)
        {
            _repository = repository;
        }

        [HttpPost("/films")]
        [SwaggerOperation(
            Summary = "Creates a new Film",
            Description = "Creates a new Film",
            OperationId = "Film.Create",
            Tags = new[] { "FilmEndpoints" })
        ]
        public override async Task<ActionResult<CreateFilmResponse>> HandleAsync(CreateFilmRequest request,
            CancellationToken cancellationToken)
        {
            var newFilm = new Film(request.Title, request.ReleaseDate);

            var createdItem = await _repository.AddAsync(newFilm, cancellationToken);

            var response = new CreateFilmResponse
            {
                Id = createdItem.Id,
                Title = createdItem.Title,
                ReleaseDate = createdItem.ReleaseDate,
                CreationDate = createdItem.CreationDate
            };

            return Ok(response);
        }
    }
}
