using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IGameRepository
    {
        List<GameDomain> FindAll();
        void Create(GameDomain game);
    }
}
