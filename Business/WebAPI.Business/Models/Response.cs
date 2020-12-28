namespace WebAPI.Business.Models
{
    /// <summary>
    /// Response Model
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Response message
        /// </summary>
        public string  Message { get; set; }

        /// <summary>
        /// Response description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Response code
        /// </summary>
        public int Code { get; set; }
    }
}
