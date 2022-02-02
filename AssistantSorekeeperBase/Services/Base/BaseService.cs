using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using AssistantSorekeeperBase.Interfaces;

namespace AssistantSorekeeperBase.Services
{
    /// <summary>
    /// Интерфейс базового сервиса
    /// </summary>
    /// <typeparam name="TModel">Модель сущности (БД)</typeparam>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TRepository">Репозиторий</typeparam>
    public interface IBaseService<TModel, TEntity, TRepository> : IService
        where TEntity : class
        where TModel : class
        where TRepository : IRepository<TModel, int>
    {
        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        /// <returns></returns>
        TEntity GetByID(int id);

        /// <summary>
        /// Получить сущности по идентификаторам
        /// </summary>
        /// <param name="ids">идентификаторы сущностей</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByIDs(List<int> ids);

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(TEntity entity);

        /// <summary>
        /// Добавить сущности
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<int> Add(IEnumerable<TEntity> entities);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Обновить сущности
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        void Delete(int id);

        /// <summary>
        /// Удалить сущности
        /// </summary>
        /// <param name="ids"></param>
        void Delete(IEnumerable<int> ids);

    }

    public enum BaseServiceMethodEnum
    {
        /// <summary>
        /// Includes, Error
        /// </summary>
        GetById,
        /// <summary>
        /// Includes, Error
        /// </summary>
        GetByIds,
        /// <summary>
        /// Error
        /// </summary>
        Add,
        /// <summary>
        /// Error
        /// </summary>
        Delete,
        /// <summary>
        /// Error
        /// </summary>
        Update,
        /// <summary>
        /// Error
        /// </summary>
        AddRange,
        /// <summary>
        /// Error
        /// </summary>
        DeleteRange,
        /// <summary>
        /// Error
        /// </summary>
        UpdateRange,
    }

    /// <summary>
    /// Абстрактный класс базового класса
    /// </summary>
    /// <typeparam name="TModel">Модель сущности (БД)</typeparam>
    /// <typeparam name="TEntity">Сущность (вход и выход)</typeparam>
    /// <typeparam name="TRepository">Репозиторий</typeparam>
    public abstract class BaseService<TModel,TEntity,TRepository> : IBaseService<TModel, TEntity, TRepository> 
        where TEntity : class
        where TModel : class
        where TRepository : IRepository<TModel, int>
    {

        protected Dictionary<BaseServiceMethodEnum, List<Expression<Func<TModel, object>>>> Includes { get; set; }
        protected Dictionary<BaseServiceMethodEnum, ApiErrorEnum> Errors { get; set; }

        public BaseService(TRepository repo)
        {
            this.Includes = new Dictionary<BaseServiceMethodEnum, List<Expression<Func<TModel, object>>>>();
            this.Errors = new Dictionary<BaseServiceMethodEnum, ApiErrorEnum>();
            this.repo = repo;
            this.Error = ApiErrorEnum.NoErrors;
        }

        protected readonly TRepository repo;
        public bool AutoSaveChanges { get => repo.AutoSaveChanges; set => repo.AutoSaveChanges = value; }
        public ApiErrorEnum Error { get; set; }

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        /// <returns></returns>
        public virtual TEntity GetByID(int id)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.GetById;
            try
            {
                TModel item = null;
                if (Includes.ContainsKey(mothodEnum))
                    item = repo.GetByID(id, Includes[mothodEnum].ToArray());
                else
                    item = repo.GetByID(id);

                TEntity result = Mapper.Map<TEntity>(item);
                return result;
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Получить сущности по идентификаторам
        /// </summary>
        /// <param name="ids">идентификаторы сущностей</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetByIDs(List<int> ids)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.GetByIds;
            try
            {
                IEnumerable<TModel> items = null;
                if (Includes.ContainsKey(BaseServiceMethodEnum.GetById))
                    items = repo.GetByIDs(ids, Includes[BaseServiceMethodEnum.GetByIds].ToArray());
                else
                    items = repo.GetByIDs(ids);

                IEnumerable<TEntity> result = Mapper.Map<IEnumerable<TEntity>>(items);
                return result;
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(TEntity entity)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.Add;
            try
            {
                TModel item = Mapper.Map<TModel>(entity);
                return repo.Add(item);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Добавить сущности
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual IEnumerable<int> Add(IEnumerable<TEntity> entities)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.AddRange;
            try
            {
                var items = Mapper.Map<IEnumerable<TModel>>(entities);
                return repo.Add(items);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.Update;
            try
            {
                var item = Mapper.Map<TModel>(entity);
                repo.Update(item);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError; this.Error = ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Обновить сущности
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.UpdateRange;
            try
            {
                var items = Mapper.Map<IEnumerable<TModel>>(entities);
                repo.Update(items);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        public virtual void Delete(int id)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.Delete;
            try
            {
                this.Error = ApiErrorEnum.UnknownError;
                repo.Delete(id);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }


        /// <summary>
        /// Удалить сущности
        /// </summary>
        /// <param name="ids">идентификаторы сущностей</param>
        public virtual void Delete(IEnumerable<int> ids)
        {
            BaseServiceMethodEnum mothodEnum = BaseServiceMethodEnum.DeleteRange;
            try
            {
                repo.Delete(ids);
            }
            catch (Exception ex)
            {
                this.Error = Errors.ContainsKey(mothodEnum) ? Errors[mothodEnum] : ApiErrorEnum.UnknownError;
                throw ex;
            }
        }

        /// <summary>
        /// Применение изменений
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            try
            {
                return this.repo.SaveChanges();
            }
            catch (Exception ex)
            {
                Error = ApiErrorEnum.UnableToSaveChange;
                throw ex;
            }
        }
    }

    /// <summary>
    /// Абстрактный класс базового класса
    /// </summary>
    /// <typeparam name="TModel">Модель сущности (БД)</typeparam>
    /// <typeparam name="TEntity">Сущность (вход и выход)</typeparam>
    public abstract class BaseService<TModel,TEntity> : BaseService<TModel, TEntity, IRepository<TModel, int>>
        where TEntity : class
        where TModel : class
    {
        public BaseService(IRepository<TModel, int> repo) : base(repo) { }
    }
}
