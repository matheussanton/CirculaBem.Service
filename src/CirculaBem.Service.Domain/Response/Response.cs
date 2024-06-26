using System.Net;
using CirculaBem.Service.Domain.Responses.Enums;
using Flunt.Notifications;

namespace CirculaBem.Service.Domain.Responses
{
    public class Response
    {
        public ResponseStatus Status { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public IReadOnlyCollection<Notification>? Notifications { get; private set; }

        public void Send(ResponseStatus status, HttpStatusCode statusCode, IReadOnlyCollection<Notification> notifications = null)
        {
            Status = status;
            StatusCode = statusCode;
            Notifications = notifications;
        }
    }
    public class Response<T>
    {
        public T? Value { get; private set; }
        public ResponseStatus Status { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public IReadOnlyCollection<Notification>? Notifications { get; private set; }

        public void Send(ResponseStatus status, T? value, HttpStatusCode statusCode, IReadOnlyCollection<Notification>? notifications = null)
        {
            Value = value;
            Status = status;
            StatusCode = statusCode;
            Notifications = notifications;
        }
    }
}
