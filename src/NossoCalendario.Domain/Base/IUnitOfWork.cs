using System.Threading.Tasks;

namespace NossoCalendario.Domain.Base
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
