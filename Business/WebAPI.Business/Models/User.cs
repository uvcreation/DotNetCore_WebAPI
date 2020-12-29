namespace WebAPI.Business.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
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
        /// User Password
        /// </summary>
        public string Password { get; set; }
    }
}
