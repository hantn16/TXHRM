namespace TXHRM.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}