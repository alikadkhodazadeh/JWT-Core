internal class JwtSettings : IJwtSettings
{
    public JwtSettings(string accessTokenSecret, string refreshTokenSecret,
        double accessTokenExpirationMinutes, double refreshTokenExpirationMinutes, string issuer, string audience)
    {
        AccessTokenSecret = accessTokenSecret;
        RefreshTokenSecret = refreshTokenSecret;
        AccessTokenExpirationMinutes = accessTokenExpirationMinutes;
        RefreshTokenExpirationMinutes = refreshTokenExpirationMinutes;
        Issuer = issuer;
        Audience = audience;
    }

    public string AccessTokenSecret { get; }
    public string RefreshTokenSecret { get; }
    public double AccessTokenExpirationMinutes { get; }
    public double RefreshTokenExpirationMinutes { get; }
    public string Issuer { get; }
    public string Audience { get; }
}