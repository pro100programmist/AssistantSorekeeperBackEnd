using System;

namespace AssistantSorekeeperBase.Interfaces
{
    /// <summary>
    /// Интерфейс базовой модели
    /// </summary>
    public interface IBaseEntity<TKey>
    {
        /// <summary>
        /// Уникальный идентификатор модели
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime InsertedDate { get; set; }

        /// <summary>
        /// ID пользователя создавшего запись
        /// </summary>
        int InsertedLUPId { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// ID пользователя изменившего запись
        /// </summary>
        int? UpdatedLUPId { get; set; }

        /// <summary>
        /// Дата удаления записи (если значение не NULL, запись считается удаленной)
        /// </summary>
        DateTime? DeletedDate { get; set; }

        /// <summary>
        /// ID пользователя удалившего запись
        /// </summary>
        int? DeletedLUPId { get; set; }
    }
}
