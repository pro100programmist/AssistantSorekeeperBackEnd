using System;

namespace AssistantSorekeeperBase.Interfaces
{
    /// <summary>
    /// Интерфейс Unit Of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Автоматическое применение изменений
        /// </summary>
        bool AutoSavecChanges { get; set; }

        /// <summary>
        /// Фиксация изменений в базе данных
        /// </summary>
        void Commit();

        /// <summary>
        /// Откат всех внесенных изменений
        /// </summary>
        void Rollback();
    }
}