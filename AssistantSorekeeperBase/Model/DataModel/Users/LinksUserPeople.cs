using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.Model
{
    [Table("LinksUserPeople", Schema = "Users")]
    public class LinksUserPeople
    {
        [Key]
        public int Id { get; set; }      
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int PeoplesId { get; set; }
        [ForeignKey("PeoplesId")]
        public Peoples Peoples { get; set; }        
    }
}
