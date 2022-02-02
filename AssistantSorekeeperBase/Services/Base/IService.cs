using AssistantSorekeeperBase.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistantSorekeeperBase.Services
{
    public interface IService
    {
        /// <summary>
        /// Автоматическое применение изменений
        /// </summary>
        bool AutoSaveChanges { get; set; }

        /// <summary>
        /// Тип ошибки возникшей при обработке запроса
        /// </summary>
        ApiErrorEnum Error { get; set; }

        /// <summary>
        /// Применение изменений
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
