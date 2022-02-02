using System;

namespace AssistantSorekeeperBase.Data
{
    /// <summary>
    /// Фабрика для создания контекста базы данных
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private AssistantSorekeeperContext dataContext;

        /// <summary>
        /// Возвращает контекст базы данных
        /// </summary>
        public AssistantSorekeeperContext Get()
        {
            return dataContext ?? (dataContext = new AssistantSorekeeperContext());
        }

        /// <summary>
        /// Освободить ресурсы, занятые контекстом
        /// </summary>
        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }

    /// <summary>
    /// Интерфейс фабрики для создания контекста базы данных
    /// </summary>
    public interface IDatabaseFactory
    {
        /// <summary>
        /// Возвращает контекст базы данных
        /// </summary>
        AssistantSorekeeperContext Get();
    }
}