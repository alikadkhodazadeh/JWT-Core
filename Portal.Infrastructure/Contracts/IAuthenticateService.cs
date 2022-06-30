public interface IAuthenticateService
{
    Task<AuthenticateResponse> Authenticate(User user, CancellationToken cancellationToken);
}
