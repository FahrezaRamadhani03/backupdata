using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garuda.Modules.Common.Dtos.Requests
{
    public class RefreshTokenRequests
    {
        /// <summary>
        /// Gets or sets token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets user refresh token.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
