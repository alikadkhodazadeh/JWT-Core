
public class RefreshToken
{
    public RefreshToken()
    {

    }
    public RefreshToken(Guid userId, string refreshToken)
    {
        UserId = userId;
        Token = refreshToken;
    }

    public Guid UserId { get; set; }
    public string Token { get; set; }

    public User User { get; set; }
}