using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creed.Podcast.Domain.Exceptions
{
    public class DomainNotFoundException : BaseException
    {
        public DomainNotFoundException(string message):base(message)
        {

        }
    }
}
