namespace ConsoleRPG.Player
{
    public class AuthenticationData
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public AuthenticationData(string login, string password)
        {
            _login = login;
            _password = password;
        }
    }
}