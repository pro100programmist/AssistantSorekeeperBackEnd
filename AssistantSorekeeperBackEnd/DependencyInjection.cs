using Microsoft.Extensions.DependencyInjection;
using AssistantSorekeeperBase.Repositories;
using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Services;

namespace AssistantSorekeeperBackEnd
{
    public static class DependencyInjection
    {
        public static void AddDepencyInjection(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            services.AddScoped<AssistantSorekeeperContext>();
            
            #region Репозитории
            services.AddScoped<ILinkWarehousesNomenclatureRepository, LinkWarehousesNomenclatureRepository>();
            services.AddScoped<IMovementHistoryItemsRepository, MovementHistoryItemsRepository>();
            services.AddScoped<IMovementHistoryRepository, MovementHistoryRepository>();
            services.AddScoped<INomenclatureRepository, NomenclatureRepository>();
            services.AddScoped<IWarehousesRepository, WarehousesRepository>();
            #endregion

            #region Сервисы
            services.AddScoped<IWorkService, WorkService>();
            #endregion
        }
    }
}
