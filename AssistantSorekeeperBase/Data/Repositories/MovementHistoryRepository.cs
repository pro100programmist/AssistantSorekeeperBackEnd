using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Repositories
{
    public interface IMovementHistoryRepository : AssistantSorekeeperBase.Interfaces.IRepository<MovementHistory, int> { }
    public class MovementHistoryRepository : Repository<MovementHistory, int>, IMovementHistoryRepository
    {
        public MovementHistoryRepository(UnitOfWork context) : base(context) { }
    }
}
