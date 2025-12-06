using MaktabGram.Domain.Core.UserAgg.Contracts.Otp;
using MaktabGram.Domain.Core.UserAgg.Entities;
using MaktabGram.Domain.Core.UserAgg.Enum;
using MaktabGram.Infrastructure.EfCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MaktabGram.Infrastructure.EfCore.Repositories.UserAgg
{
    public class OtpRepository (AppDbContext dbContext) : IOtpRepository
    {
        public async Task Create(string mobile, int code, OtpTypeEnum type,CancellationToken cancellationToken)
        {
            var entity = new Otp
            {
                Mobile = mobile,
                Code = code,
                Type = type,
                SendAt = DateTime.Now,
                IsUsed = false
            };

            await dbContext.Otps.AddAsync(entity);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> Verify(string mobile, int code, OtpTypeEnum otpType,CancellationToken cancellationToken)
        {
            return dbContext.Otps.AnyAsync(o => o.IsUsed == false 
            && o.Code == code 
            && o.Mobile == mobile 
            && o.Type == otpType 
            && DateTime.Now < o.SendAt.AddMinutes(2), cancellationToken);
        }
    }
}
