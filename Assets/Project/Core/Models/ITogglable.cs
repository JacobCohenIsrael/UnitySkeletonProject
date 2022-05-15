using RSG;

namespace JCI.Core.Models
{
    public interface ITogglable
    {
        IPromise Toggle(bool toggle);
    }
}
