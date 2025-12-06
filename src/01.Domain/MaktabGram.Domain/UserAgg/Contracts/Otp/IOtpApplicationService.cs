using MaktabGram.Domain.Core.UserAgg.Enum;

namespace MaktabGram.Domain.Core.UserAgg.Contracts.Otp
{
    public interface IOtpApplicationService
    {
        public Task Create(string mobile, int code, OtpTypeEnum type, CancellationToken cancellationToken);
        public Task<bool> Verify(string mobile, int code, OtpTypeEnum otpType, CancellationToken cancellationToken);
    }
}
