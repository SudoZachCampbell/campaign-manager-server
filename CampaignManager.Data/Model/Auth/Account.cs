

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
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
        private const string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string passwordRegex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public bool ValidateCreateDetails(out string error)
        {
            if (string.IsNullOrEmpty(Username))
            {
                error = "Username is required";
                return false;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                error = "Email is required";
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                error = "Password is required";
                return false;
            }
            else if (!ValidEmail())
            {
                error = "Must be a valid email";
                return false;
            }
            else if (!ValidPassword())
            {
                error = "Password must be 8 characters, contain 1 uppercase and lowercase character, a number, and a special character";
                return false;
            }
            error = "";
            return true;
        }

        private bool ValidEmail() => Regex.IsMatch(Email ?? "", emailRegex);
        private bool ValidPassword() => Regex.IsMatch(Password ?? "", passwordRegex);
    }
}
