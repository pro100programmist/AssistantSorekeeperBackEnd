using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.Model
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Удалён
        /// </summary>
        public bool Remove { get; set; }
        /// <summary>
        /// Кто удалил
        /// </summary>
        public int? RemoveLUId { get; set; }
        /// <summary>
        /// Дата последнего входа в систему
        /// </summary>
        public DateTime? LastLoginDateTime { get; set; }
    }
}
