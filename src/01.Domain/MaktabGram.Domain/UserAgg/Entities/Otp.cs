using MaktabGram.Domain.Core.UserAgg.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabGram.Domain.Core.UserAgg.Entities
{
    public class Otp
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Mobile { get; set; }
        public OtpTypeEnum Type { get; set; }
        public DateTime SendAt { get; set; }
        public bool IsUsed { get; set; }
    }
}
