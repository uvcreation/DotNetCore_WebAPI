namespace WebAPI.Business.Models
{
    /// <summary>
    /// Authenticate Response
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Jwt Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Prepare the Authenticate response
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
