using System.Text;

namespace Apache.Shiro.Authc
{
    public class UsernamePasswordToken : IHostAuthenticationToken, IRememberMeAuthenticationToken
    {
        public UsernamePasswordToken()
        {

        }

        public UsernamePasswordToken(string username, string password, bool rememberMe = false, string host = null)
            : this(username, password == null ? null : password.ToCharArray(), rememberMe, host)
        {

        }

        public UsernamePasswordToken(string username, char[] password, bool rememberMe = false, string host = null)
        {
            Username = username;
            Password = password;
            RememberMe = rememberMe;
            Host = host;
        }

        public object Credentials
        {
            get
            {
                return Password;
            }
        }

        public string Host { get; set; }

        public char[] Password { get; set; }

        public object Principal
        {
            get
            {
                return Username;
            }
        }

        public bool RememberMe { get; set; }

        public string Username { get; set; }

        public void Clear()
        {
            Username = null;
            Host = null;
            RememberMe = false;

            if (Password != null)
            {
                for (var i = 0; i < Password.Length; ++i)
                {
                    Password[i] = '\0';
                }
                Password = null;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(GetType().Name)
                .Append(" - ")
                .Append(Username)
                .Append(", RememberMe=").Append(RememberMe);
            if (Host != null)
            {
                builder.Append(" (").Append(Host).Append(")");
            }

            return builder.ToString();
        }
    }
}