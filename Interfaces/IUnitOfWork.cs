namespace Evaluation.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
