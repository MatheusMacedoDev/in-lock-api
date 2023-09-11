using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IStudioRepository
    {
        List<StudioDomain> ListAll();
        void Create(StudioDomain studio);
    }
}
