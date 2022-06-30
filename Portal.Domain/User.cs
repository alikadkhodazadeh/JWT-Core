public class User
{
    private User()
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

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Role Role { get; private set; }
}

public enum Role : byte
{
    Admin = 0,
    User = 1,
}
