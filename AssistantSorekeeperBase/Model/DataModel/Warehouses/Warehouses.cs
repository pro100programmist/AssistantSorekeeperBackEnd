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
    /// Склады
    /// </summary>
    [Table("Warehouses", Schema = "Warehouses")]
    public class Warehouses : StandartUserChangeFields, Interfaces.IBaseEntity<int>
    {          
        public string Name { get; set; }
    }
}
