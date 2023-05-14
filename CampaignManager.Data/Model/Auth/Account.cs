

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using CampaignManager.Data.Model.Creatures;

namespace CampaignManager.Data.Model.Auth
{
    [Table("accounts")]
    public class Account : Base, IAccount
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        private byte[]? _salt;
        [JsonIgnore]
        public byte[]? Salt { get => _salt; set => _salt = value; }
        private string? _password;
        public string? Password { get => _password; set => _password = HashPassword(value, out _salt); }
        public string? Role { get; set; }

        #region Foreign Keys

        public List<Monster>? Monsters { get; set; }

        #endregion

        public bool CheckPassword(string inputPassword)
            => HashPassword(inputPassword, out var salt) == Password;

        public string HashPassword(string password, out byte[] salt)
        {
            salt = Salt ?? RandomNumberGenerator.GetBytes(64);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                350000,
                HashAlgorithmName.SHA512,
                64);
            return Convert.ToHexString(hash);
        }

        public static Account FromCreate(CreateAttempt createAttempt)
        {
            return new Account()
            {
                Username = createAttempt.Username,
                Password = createAttempt.Password,
                Email = createAttempt.Email
            };
        }

    }


    public class LoginAttempt
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool ValidateLoginDetails()
            => !(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Email)) && !string.IsNullOrEmpty(Password);
    }

    public class CreateAttempt
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool ValidateCreateDetails()
            => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
    }
}
