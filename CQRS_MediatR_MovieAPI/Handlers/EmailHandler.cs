using CQRS_MediatR_MovieAPI.Data;
using CQRS_MediatR_MovieAPI.Notifications;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Handlers
{
    public class EmailHandler : INotificationHandler<MovieAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(MovieAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Movie, "Email sent");
            await Task.CompletedTask;
        }
    }
}
