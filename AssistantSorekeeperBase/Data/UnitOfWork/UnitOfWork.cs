using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace AssistantSorekeeperBase.Data
{
    /// <summary>
    /// Реализация UnitOfWork
    /// </summary>
    public class UnitOfWork : Disposable, AssistantSorekeeperBase.Interfaces.IUnitOfWork
    {
        /// <summary>
        /// Автоматическое применение изменений
        /// </summary>
        public bool AutoSavecChanges { get; set; } = true;

        /// <summary>
        /// Транзакция
        /// </summary>
        IDbContextTransaction transaction;

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        public DbContext Context { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public UnitOfWork(AssistantSorekeeperContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Открывает транзакцию
        /// </summary>
        /// <param name="isolationLevel">Уровень изоляции транзакции</param>
        public void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            try
            {
                if (transaction == null)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    transaction = Context.Database.BeginTransaction();//.BeginTransaction(isolationLevel);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Фиксирует транзакцию
        /// </summary>
        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Откатывает транзакцию
        /// </summary>
        public void Rollback()
        {
            try
            {
                transaction.Rollback();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Применить изменения в контексте
        /// </summary>
        public void SaveChanges()
        {
            //DbContext.SaveChanges();
        }
    }
}