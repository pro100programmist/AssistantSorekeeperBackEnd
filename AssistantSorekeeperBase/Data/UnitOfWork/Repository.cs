using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AssistantSorekeeperBase.Data
{
    /// <summary>
    /// Абстрактный класс хранилища определенного типа модели
    /// </summary>
    /// <typeparam name="TEntity">Тип модели</typeparam>
    /// <typeparam name="TKey">Тип уникального идентификатора модели</typeparam>
    public abstract class Repository<TEntity, TKey> : Interfaces.IRepository<TEntity, TKey> //where TEntity : KeyedBaseModel<TEntity, TKey>
   //where TKey : IEquatable<TKey> //
        where TEntity : class, Interfaces.IBaseEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Автоматическое применение изменений
        /// </summary>
        public bool AutoSaveChanges { get => unitOfWork.AutoSavecChanges; set => unitOfWork.AutoSavecChanges = value; }

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly UnitOfWork unitOfWork;

        /// <summary>
        /// Загружает связанные данные
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> result = unitOfWork.Context.Set<TEntity>().AsNoTracking();
            return includeProperties.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public Repository(UnitOfWork context)
        {
            unitOfWork = context;
        }

        /// <summary>
        /// Добавляет модель
        /// </summary>
        /// <param name="entity">Объект модели</param>
        /// <returns>Уникальный идентификатор модели</returns>
        public virtual TKey Add(TEntity entity)
        {
            Include();
            unitOfWork.Context.Set<TEntity>().Add(entity);
            if (AutoSaveChanges)
                this.SaveChanges();
            return entity.Id;
        }

        /// <summary>
        /// Добавляет обьекты модели
        /// </summary>
        /// <param name="entity">Объекты модели</param>
        /// <returns>Уникальныу идентификаторы модели</returns>
        public virtual IEnumerable<TKey> Add(IEnumerable<TEntity> entities)
        {
            unitOfWork.Context.Set<TEntity>().AddRange(entities);
            if (AutoSaveChanges)
                this.SaveChanges();
            return entities.Select(o => o.Id);
        }

        /// <summary>
        /// Обновляет модель
        /// </summary>
        /// <param name="entity">Объект модели</param>
        public virtual void Update(TEntity entity)
        {
            if (entity != null)
            {
                TEntity updatableEntity = unitOfWork.Context.Set<TEntity>().Find(entity.Id);
                if (updatableEntity != null)
                {
                    unitOfWork.Context.Entry(updatableEntity).CurrentValues.SetValues(entity);
                    if (AutoSaveChanges)
                        this.SaveChanges();
                }

            }
        }

        /// <summary>
        /// Обновляет сушности модели
        /// </summary>
        /// <param name="entity">Объект модели</param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            unitOfWork.Context.Set<TEntity>().UpdateRange(entities); 
            //foreach (var entity in entities)
            //{
            //    if (entity != null)
            //    {
            //        TEntity updatableEntity = unitOfWork.Context.Set<TEntity>().Find(entity.Id);
            //        if (updatableEntity != null)
            //        {
            //            unitOfWork.Context.Entry(updatableEntity).CurrentValues.SetValues(entity);
            //        }
            //    }
            //}
            if (AutoSaveChanges)
                this.SaveChanges();
        }

        /// <summary>
        /// Помечает модель как удаленную
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        public virtual void Delete(TKey id)
        {
            TEntity deletableEntity = unitOfWork.Context.Set<TEntity>().Find(id);
            deletableEntity.DeletedDate = DateTime.Now;
            if (AutoSaveChanges)
                this.SaveChanges();
        }

        /// <summary>
        /// Помечает модель как удаленную
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        public virtual void Delete(IEnumerable<TKey> ids)
        {
            IQueryable<TEntity> deletableEntities = unitOfWork.Context.Set<TEntity>().Where(o => ids.Contains(o.Id));
            foreach (var deletableEintity in deletableEntities)
            {
                deletableEintity.DeletedDate = DateTime.Now;
            }
            if (AutoSaveChanges)
                this.SaveChanges();
        }

        /// <summary>
        /// Удаляет модель
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        public virtual void Remove(TKey id)
        {
            TEntity removableEntity = unitOfWork.Context.Set<TEntity>().Find(id);
            unitOfWork.Context.Set<TEntity>().Remove(removableEntity);
            if (AutoSaveChanges)
                this.SaveChanges();
        }

        /// <summary>
        /// Найти объект модели по идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор модели</param>
        public virtual TEntity GetByID (TKey id)
        {
            return unitOfWork.Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Найти первый обьект модели по условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual TEntity GetFirstOrDefault(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> result = unitOfWork.Context.Set<TEntity>();
            foreach(var inc in includeProperties)
            {
                result = result.Include(inc);
            }
            return result.FirstOrDefault(expression);
        }

        /// <summary>
        /// Найти единственный обьект модели по условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual TEntity GetSingleOrDefault(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> result = unitOfWork.Context.Set<TEntity>();
            foreach (var inc in includeProperties)
            {
                result = result.Include(inc);
            }
            return result.SingleOrDefault(expression);
        }

        public virtual TEntity GetByID (TKey id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> result = unitOfWork.Context.Set<TEntity>();
            foreach(var inc in includeProperties)
            {
                result = result.Include(inc);
            }
            return result.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Возвращает список всех объектов модели
        /// </summary>
        /// <param name="includeProperties">Навигационные свойства</param>
        /// <returns>Список объектов</returns>
        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties);
        }

        /// <summary>
        /// Возвращает список объектов модели удовлетворяющих условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties">Навигационные свойства</param>
        /// <returns>Список объектов</returns>
        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = Include(includeProperties);
            return result.Where(expression);
        }

        /// <summary>
        /// Возвращает список обьектов модели по их идентификаторам
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetByIDs(List<TKey> ids)
        {
            return unitOfWork.Context.Set<TEntity>().Where(o => ids.Contains(o.Id));
        }

        /// <summary>
        /// Возвращает список обьектов модели по их идентификаторам
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetByIDs(List<TKey> ids, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = Include(includeProperties);
            return result.Where(o => ids.Contains(o.Id));
        }

        /// <summary>
        /// Проверить наличия сущностей удовлетворяющим условию
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public bool Any(Func<TEntity, bool> expression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var result = Include(includeProperties);
            return result.Any(expression);
        }

        /// <summary>
        /// Фиксация изменений.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return unitOfWork.Context.SaveChanges();
        }
    }
}