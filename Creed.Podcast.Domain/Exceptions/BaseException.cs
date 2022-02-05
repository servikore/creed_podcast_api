using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creed.Podcast.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public BaseException(string message): base(message)
        {            
        }        
    }
}
