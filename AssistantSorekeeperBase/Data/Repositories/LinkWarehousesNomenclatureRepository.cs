using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Repositories
{
    public interface ILinkWarehousesNomenclatureRepository : AssistantSorekeeperBase.Interfaces.IRepository<LinkWarehousesNomenclature, int> { }
    public class LinkWarehousesNomenclatureRepository : Repository<LinkWarehousesNomenclature, int>, ILinkWarehousesNomenclatureRepository
    {
        public LinkWarehousesNomenclatureRepository(UnitOfWork context) : base(context) { }
    }
}
