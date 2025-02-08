namespace Sagittaras.Repository.Tests.Projection.AutoMapper.Environment
{
    public class User
    {
        private string _username = string.Empty;
        
        public int Id { get; set; }

        public string Username
        {
            get => _username;
            set
            {
                UsernameNormalized = _username.ToUpper();
                _username = value;
            }
        }

        public string UsernameNormalized { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}