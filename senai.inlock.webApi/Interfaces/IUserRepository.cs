using senai.inlock.webApi.DataTransfer;
using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUserRepository
    {
        UserDomain login(UserTransfer findedUser);
    }
}
