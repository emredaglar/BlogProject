using Microsoft.AspNetCore.Identity;

namespace BlogProject.PresentationLayer.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola en az bir özel karakter içermelidir (örneğin: @, #, !, $, vb.)."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresDigit",
                Description = "Parola en az bir rakam içermelidir (0-9 arası)."
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresLower",
                Description = "Parola en az bir küçük harf içermelidir (a-z)."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = "Parola en az bir büyük harf içermelidir (A-Z)."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "DuplicateEmail",
                Description = $"'{email}' adresi zaten kullanılmaktadır."
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = "InvalidEmail",
                Description = $"'{email}' geçersiz bir e-posta adresidir."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = "DuplicateUserName",
                Description = $"'{userName}' kullanıcı adı zaten kullanılmaktadır."
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = "InvalidUserName",
                Description = $"'{userName}' geçersiz bir kullanıcı adıdır."
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = "UserAlreadyHasPassword",
                Description = "Kullanıcının zaten bir parolası var."
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = "UserLockoutNotEnabled",
                Description = "Kullanıcı kilitleme etkinleştirilmemiş."
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = "UserAlreadyInRole",
                Description = $"Kullanıcı zaten '{role}' rolünde."
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = "UserNotInRole",
                Description = $"Kullanıcı '{role}' rolünde değil."
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = "PasswordMismatch",
                Description = "Parola uyuşmuyor."
            };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = "InvalidToken",
                Description = "Geçersiz bir token."
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Code = "RecoveryCodeRedemptionFailed",
                Description = "Kurtarma kodu geçersiz veya kullanılmış."
            };
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = "DefaultError",
                Description = "Bilinmeyen bir hata oluştu."
            };
        }
    }
}
