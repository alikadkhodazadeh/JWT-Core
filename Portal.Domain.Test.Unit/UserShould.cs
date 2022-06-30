public class UserShould
{
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _email;
    private readonly string _password;

    public UserShould()
    {
        _firstName = "Jack";
        _lastName = "Ma";
        _email = "jackma@example.com";
        _password = "jack123";
    }

    [Fact]
    public void Construct_User_Domain()
    {
        User user = new(_firstName, _lastName, _email, _password);

        user.FirstName.ShouldBe(_firstName);
        user.LastName.ShouldBe(_lastName);
        user.Email.ShouldBe(_email);
        user.PasswordHash.ShouldNotBe(_password);
    }

    [Fact]
    public void Return_The_Hashed_Value()
    {
        string value = "pass1234";

        string hash = SecurityHelper.GetSha256Hash(value);

        hash.ShouldNotBe(value);
    }

    [Fact]
    public void Throw_ArgumentNullException_When_FirstName_Is_Empty_In_Construct_User_Domain()
    {
        var actual = () => new User(" ", _lastName, _email, _password);

        actual.ShouldThrow<ArgumentNullException>();
    }
}
