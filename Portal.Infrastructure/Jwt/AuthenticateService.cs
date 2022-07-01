namespace Portal.Infrastructure.Jwt;

public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IContext _db;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IContext db)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _db = db;
    }

    public async Task<AuthenticateResponse> Authenticate(User user, CancellationToken cancellationToken)
    {
        var refreshToken = _refreshTokenService.Generate(user);
        var result = await _db.RefreshTokens
            .SingleOrDefaultAsync(t=>t.UserId.Equals(user.Id), cancellationToken);

        if (string.IsNullOrEmpty(result.Token))
            await _db.RefreshTokens.AddAsync(new RefreshToken(user.Id, refreshToken), cancellationToken);
        else
            result.Token = refreshToken;

        await _db.SaveAsync(cancellationToken);
        var res = new AuthenticateResponse(_accessTokenService.Generate(user), refreshToken);
        return res;
    }
}