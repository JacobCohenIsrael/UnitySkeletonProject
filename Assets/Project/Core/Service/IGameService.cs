/// <summary>
/// Base interface for our service locator to work with. Services implementing
/// this interface will be retrievable using the locator.
/// </summary> 

namespace JCI.Core.Service
{
    public interface IGameService
    {

    }

    public interface IInitializable
    {
        void Init();
    }
}

