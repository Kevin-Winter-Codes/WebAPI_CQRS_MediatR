using CQRS_MediatR_MovieAPI.Data.Entities;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Queries
{
    public record GetMoviesQuery() : IRequest<IEnumerable<Movie>>;
}
