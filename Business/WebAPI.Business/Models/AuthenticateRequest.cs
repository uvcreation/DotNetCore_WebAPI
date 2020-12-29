using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Business.Models
{
    /// <summary>
    /// Authenticate Request
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string Username { get; set; }
        
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
