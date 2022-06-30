namespace Portal.Infrastructure.Jwt;

public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IContext _context;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IContext context)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _context = context;
    }

    public async Task<AuthenticateResponse> Authenticate(User user, CancellationToken cancellationToken)
    {
        var refreshToken = _refreshTokenService.Generate(user);
        await _context.RefreshTokens.AddAsync(new RefreshToken(user.Id, refreshToken), cancellationToken);
        await _context.SaveAsync(cancellationToken);
        return new AuthenticateResponse(_accessTokenService.Generate(user), refreshToken);
    }
}