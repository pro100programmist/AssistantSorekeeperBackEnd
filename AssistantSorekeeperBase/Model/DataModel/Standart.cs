using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantSorekeeperBase.Model
{
    /// <summary>
    /// 6 стандартных полей сущности
    /// </summary>
    public abstract class StandartUserChangeFields
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime InsertedDate { get; set; }
        /// <summary>
        /// Id пользователя создавшего запись
        /// </summary>
        public int InsertedLUPId { get; set; }
        [ForeignKey("InsertedLUPId")]
        public LinksUserPeople InsertedLUP { get; set; }
        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Id пользователя изменившего запись
        /// </summary>
        public int? UpdatedLUPId { get; set; }
        [ForeignKey("UpdatedLUPId")]
        public LinksUserPeople UpdatedLUP { get; set; }
        /// <summary>
        /// Дата удаления записи (если значение не NULL, запись считается удаленной)
        /// </summary>
        public DateTime? DeletedDate { get; set; }
        /// <summary>
        /// Id пользователя удалившего запись
        /// </summary>
        public int? DeletedLUPId { get; set; }
        [ForeignKey("DeletedLUPId")]
        public LinksUserPeople DeletedLUP { get; set; }
    }
}
