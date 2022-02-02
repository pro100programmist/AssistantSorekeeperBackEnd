using System;
using System.Collections.Generic;
using System.Text;

namespace AssistantSorekeeperBase.ViewModel
{
    public class MovementView
    {
        public string WhoMovement { get; set; }
        public string WarehouseStart { get; set; }
        public string WarehouseEnd { get; set; }
        public string DateTime { get; set; }
        public List<MovementItemView> Items { get; set; }
    }
}
