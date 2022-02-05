using Creed.Podcast.Domain.Common;

namespace Creed.Podcast.Domain.Interfaces
{
    public interface ISecurityService
    {
        AccessToken AuthenticateUser(string username, string password);
    }
}
