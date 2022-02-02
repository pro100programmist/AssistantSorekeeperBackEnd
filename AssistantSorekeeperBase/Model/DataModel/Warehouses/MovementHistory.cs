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
    /// История перемещений
    /// </summary>
    [Table("MovementHistory", Schema = "Warehouses")]
    public class MovementHistory : StandartUserChangeFields, Interfaces.IBaseEntity<int>
    {
        /// <summary>
        /// Получатель
        /// </summary>
        public int WarehousesRecipientId { get; set; }
        [ForeignKey("WarehousesRecipientId")]
        public Warehouses WarehousesRecipient { get; set; }
        /// <summary>
        /// Отправитель?
        /// </summary>
        public int? WarehousesSenderId { get; set; }
        [ForeignKey("WarehousesSenderId")]
        public Warehouses WarehousesSender { get; set; }
    }
}
