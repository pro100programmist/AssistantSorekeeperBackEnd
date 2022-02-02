using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AssistantSorekeeperBase.Model;

namespace AssistantSorekeeperBase.Data
{
    public partial class AssistantSorekeeperContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public AssistantSorekeeperContext(DbContextOptions<AssistantSorekeeperContext> options) : base(options) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        public AssistantSorekeeperContext() : base() { }

        #region Users
        /// <summary>
        /// Связь людей и пользователей
        /// </summary>
        public DbSet<LinksUserPeople> LinksUserPeople { get; set; }
        /// <summary>
        /// Люди
        /// </summary>
        public DbSet<Peoples> Peoples { get; set; }
        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> User { get; set; }
        #endregion

        #region Warehouses

        /// <summary>
        /// Связь склада и номенклатуры
        /// </summary>
        public DbSet<LinkWarehousesNomenclature> LinkWarehousesNomenclature { get; set; }
        /// <summary>
        /// История перемещений
        /// </summary>
        public DbSet<MovementHistory> MovementHistory { get; set; }
        /// <summary>
        /// История перемещений детально
        /// </summary>
        public DbSet<MovementHistoryItems> MovementHistoryItems { get; set; }
        /// <summary>
        /// Номенклатура
        /// </summary>
        public DbSet<Nomenclature> Nomenclature { get; set; }
        /// <summary>
        /// Склады
        /// </summary>
        public DbSet<Warehouses> Warehouses { get; set; }

        #endregion
    }
}
