namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction(bool autoDetectChange = true);

        void Commit();

        void Rollback();
    }
}
