

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace DDCatalogue.Model.Auth
{
    [Table("accounts")]
    public class Account : Base, IAccount
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        private byte[] _salt;
        public byte[] Salt { get => _salt; set => _salt = value; }
        private string _password;

        [Required]
        public string Password { get => _password; set => _password = HashPassword(value, out _salt); }
        public string Role { get; set; }

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

    }


    public class LoginAttempt
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
