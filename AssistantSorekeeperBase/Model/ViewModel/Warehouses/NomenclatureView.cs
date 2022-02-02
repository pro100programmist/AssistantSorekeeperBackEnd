using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.ViewModel
{
    public class NomenclatureView
    {          
        public string Id { get; set; }
        public int IdNomenclature { get; set; }
        public string Name { get; set; }
    }
}
