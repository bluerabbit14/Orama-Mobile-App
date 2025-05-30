using Orama_API.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orama_API.Model.Domain
{
     public class UserVerifications
     {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }

        [EnumDataType(typeof(ContactType))]
        public string ContactType { get; set; } = null!;  // "Email" or "Phone"
        public string ContactValue { get; set; } = null!;
        public string VerificationCode { get; set; } = null!;

        [EnumDataType(typeof(CodeType))]
        public string CodeType { get; set; } = null!;     // "Token" or "OTP"
      
        [EnumDataType(typeof(PurposeType))]
        public string Purpose { get; set; } = null!;      // "AccountVerification" or "PasswordReset"

        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
     } 

       public enum ContactType
       {
         Email,
         Phone
       }
       public enum CodeType
       {
         Token,
         OTP
        }
       public enum PurposeType
       {
         AccountVerification,
         PasswordReset
       }
}
