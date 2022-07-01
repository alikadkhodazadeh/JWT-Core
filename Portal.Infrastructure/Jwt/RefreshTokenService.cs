namespace Portal.Infrastructure.Jwt;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IJwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, IJwtSettings jwtSettings) =>
        (_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

    public string Generate(User user) => 
        _tokenGenerator.Generate(_jwtSettings.RefreshTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience, _jwtSettings.RefreshTokenExpirationMinutes);
}
