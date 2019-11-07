using System.Collections.Generic;

namespace SwaggerSolution.Services.Models
{
    /// <summary>
    /// Thr result model of articles
    /// </summary>
    public class ArticleResultModel
    {
        /// <summary>
        /// List of articles
        /// </summary>
        public IList<ArticleModel> Data { get; set; }
        /// <summary>
        /// List of errors if we are not able to get the errors
        /// </summary>
        public IList<string> Errors { get; set; }
    }
}