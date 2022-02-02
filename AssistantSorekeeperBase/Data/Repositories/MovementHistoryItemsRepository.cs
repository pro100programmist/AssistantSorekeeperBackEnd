using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Repositories
{
    public interface IMovementHistoryItemsRepository : AssistantSorekeeperBase.Interfaces.IRepository<MovementHistoryItems, int> { }
    public class MovementHistoryItemsRepository : Repository<MovementHistoryItems, int>, IMovementHistoryItemsRepository
    {
        public MovementHistoryItemsRepository(UnitOfWork context) : base(context) { }
    }
}
