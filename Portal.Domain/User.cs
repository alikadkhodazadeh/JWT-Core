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
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
