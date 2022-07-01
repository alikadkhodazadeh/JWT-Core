public class User
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    public User(string firstName, string lastName, string email, string password) : this()
    {
        firstName.ThorwIfNull();
        lastName.ThorwIfNull();
        email.ThorwIfNull();
        password.ThorwIfNull();

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = SecurityHelper.GetSha256Hash(password);
        Role = Role.User;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; }
}

public enum Role : byte
{
    Admin = 0,
    User = 1,
}
