using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.ViewModel
{
    public class RemainsView
    {          
        public string Id { get; set; }
        public string WarehouseName { get; set; }
        public int IdWarehouses { get; set; }
        public string DateTimeStart { get; set; }
        public string DateTimeEnd { get; set; }
        public List<RemainsItemsView> Items { get; set; }
    }
}
