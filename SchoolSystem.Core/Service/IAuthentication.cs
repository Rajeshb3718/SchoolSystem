namespace LearnAPI.Service
{
    public interface IAuthentication
    {
        string Authenticate(string username, string password);
    }
}
