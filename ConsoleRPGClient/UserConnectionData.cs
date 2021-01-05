namespace ConsoleRPGClient
{
    public class UserConnectionData
    {
        private string _login;
        private string _password;
        private bool _isAuthenticated;

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

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set => _isAuthenticated = value;
        }

        public UserConnectionData(string login, string password, bool isAuthenticated)
        {
            _login = login;
            _password = password;
            _isAuthenticated = isAuthenticated;
        }
    }
}