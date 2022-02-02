using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.Model
{
    /// <summary>
    /// Связь склада и номенклатуры
    /// </summary>
    [Table("LinkWarehousesNomenclature", Schema = "Warehouses")]
    public class LinkWarehousesNomenclature : StandartUserChangeFields, Interfaces.IBaseEntity<int>
    {
        public int Count { get; set; }
        public bool Past { get; set; }
        public int WarehousesId { get; set; }
        [ForeignKey("WarehousesId")]
        public Warehouses Warehouses { get; set; }
        public int NomenclatureId { get; set; }
        [ForeignKey("NomenclatureId")]
        public Nomenclature Nomenclature { get; set; }
    }
}
