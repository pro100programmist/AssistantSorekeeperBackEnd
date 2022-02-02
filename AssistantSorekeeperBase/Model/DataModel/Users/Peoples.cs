using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.Model
{
    [Table("Peoples", Schema = "Users")]
    public class Peoples
    {
        [Key]
        public int Id { get; set; }        
        public string FullName { get; set; }
    }
}
