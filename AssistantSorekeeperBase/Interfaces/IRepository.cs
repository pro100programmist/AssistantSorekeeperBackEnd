using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AssistantSorekeeperBase.Interfaces
{
    /// <summary>
    /// Интерфейс хранилища данных определенного типа модели
    /// </summary>
    /// <typeparam name="TEntity">Тип модели</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора модели (ID)</typeparam>
    public interface IRepository<TEntity, TKey> where TEntity : class
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Автоматическое применение изменений
        /// </summary>
        bool AutoSaveChanges { get; set; }

        /// <summary>
        /// Добавляет модель
        /// </summary>
        /// <param name="entity">Объект модели</param>
        TKey Add(TEntity entity);

        /// <summary>
        /// Добавляет сущности
        /// </summary>
        /// <param name="entity">Объект модели</param>
        IEnumerable<TKey> Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновляет модель
        /// </summary>
        /// <param name="entity">Объект модели</param>
        void Update(TEntity entity);

        /// <summary>
        /// Добавляет сущности
        /// </summary>
        /// <param name="entity">Объект модели</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Помечает модель как удаленную
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        void Delete(TKey id);

        /// <summary>
        /// Помечает модель как удаленную
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        void Delete(IEnumerable<TKey> ids);

        /// <summary>
        /// Удаляет модель
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        void Remove(TKey id);

        /// <summary>
        /// Возвращает объект модели по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        TEntity GetByID(TKey id);

        /// <summary>
        /// Найти первый обьект модели по условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetFirstOrDefault(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Найти единственный обьект модели по условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetSingleOrDefault(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        TEntity GetByID(TKey id, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Возвращает объект модели по идентификаторам
        /// </summary>
        /// <param name="id">Идентификатор</param>
        IEnumerable<TEntity> GetByIDs(List<TKey> ids);

        /// <summary>
        /// Возвращает объект модели по идентификаторам
        /// </summary>
        /// <param name="id">Идентификатор</param>
        IEnumerable<TEntity> GetByIDs(List<TKey> ids, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Возвращает список всех объектов модели
        /// </summary>
        /// <param name="includeProperties">Навигационные свойства</param>
        /// <returns>Список объектов</returns>
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Возвращает список объектов модели удовлетворяющих условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties">Навигационные свойства</param>
        /// <returns>Список объектов</returns>
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Проверить наличия сущностей удовлетворяющим условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        bool Any(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties);

        /// <summary>
        /// Фиксация изменений.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
