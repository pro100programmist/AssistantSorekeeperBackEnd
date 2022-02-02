using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Repositories
{
    public interface IWarehousesRepository : AssistantSorekeeperBase.Interfaces.IRepository<Warehouses, int> { }
    public class WarehousesRepository : Repository<Warehouses, int>, IWarehousesRepository
    {
        public WarehousesRepository(UnitOfWork context) : base(context) { }
    }
}
