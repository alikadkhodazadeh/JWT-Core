public interface IJwtSettings
{
    double AccessTokenExpirationMinutes { get; }
    string AccessTokenSecret { get; }
    string Audience { get; }
    string Issuer { get; }
    double RefreshTokenExpirationMinutes { get; }
    string RefreshTokenSecret { get; }
}