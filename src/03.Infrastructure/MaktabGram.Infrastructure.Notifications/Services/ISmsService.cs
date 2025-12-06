namespace MaktabGram.Infrastructure.Notifications.Services
{
    public interface ISmsService
    {
        Task Send(string number, string message);
        Task<int> SendOTP(string number);
    }
}
