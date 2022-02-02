using System;
using System.Collections.Generic;
using System.Text;

namespace AssistantSorekeeperBase.ViewModel
{
    public class CreateMovementView
    {
        public string Id { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public List<CreateMovementItemsView> items { get; set; }
    }
    public class CreateMovementItemsView
    { 
        public int nomenclatureId { get; set; }
        public string nomenclature { get; set; }
        public int count { get; set; }
    }
}
