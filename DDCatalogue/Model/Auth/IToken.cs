namespace DDCatalogue.Model.Auth
{
    public interface IToken
    {
        static abstract string BuildToken(string key, string issuer, string audience, Account user);
        static abstract bool ValidateToken(string key, string issuer, string audience, string token);
    }
}