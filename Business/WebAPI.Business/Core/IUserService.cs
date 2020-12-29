using WebAPI.Business.Models;

namespace WebAPI.Business.Core
{
    /// <summary>
    /// User Authentication Service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticate the request with users and generate JwtToken
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);
    }
}
