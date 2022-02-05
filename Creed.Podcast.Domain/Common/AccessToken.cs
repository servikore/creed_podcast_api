using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creed.Podcast.Domain.Common
{
    public class AccessToken
    {
        public AccessToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; }
        public DateTime Expiration { get; }
    }
}
