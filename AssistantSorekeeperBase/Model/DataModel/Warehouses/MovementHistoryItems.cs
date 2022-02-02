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
    /// История перемещений детально
    /// </summary>
    [Table("MovementHistoryItems", Schema = "Warehouses")]
    public class MovementHistoryItems : StandartUserChangeFields, Interfaces.IBaseEntity<int>
    {
        public int MovementHistoryId { get; set; }
        [ForeignKey("MovementHistoryId")]
        public MovementHistory MovementHistory { get; set; }
        public int Count { get; set; }
        public int NomenclatureId { get; set; }
        [ForeignKey("NomenclatureId")]
        public Nomenclature Nomenclature { get; set; }
    }
}
