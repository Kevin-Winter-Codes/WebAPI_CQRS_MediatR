using CQRS_MediatR_MovieAPI.Data;
using CQRS_MediatR_MovieAPI.Data.Entities;
using CQRS_MediatR_MovieAPI.Queries;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMovieByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken) =>
            await _fakeDataStore.GetMovieById(request.Id);

        
    }
}
