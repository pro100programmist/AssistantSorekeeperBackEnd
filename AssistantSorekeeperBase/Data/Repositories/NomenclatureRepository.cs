using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Repositories
{
    public interface INomenclatureRepository : AssistantSorekeeperBase.Interfaces.IRepository<Nomenclature, int> { }
    public class NomenclatureRepository : Repository<Nomenclature, int>, INomenclatureRepository
    {
        public NomenclatureRepository(UnitOfWork context) : base(context) { }
    }
}
