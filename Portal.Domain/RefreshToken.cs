
public class RefreshToken
{
    public RefreshToken(Guid id, string refreshToken)
    {
        Id = id;
        Value = refreshToken;
    }

    public Guid Id { get; set; }
    public string Value { get; set; }
}