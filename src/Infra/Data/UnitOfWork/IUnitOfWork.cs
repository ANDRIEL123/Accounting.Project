namespace Accounting.Project.src.Infra.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}