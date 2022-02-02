using AssistantSorekeeperBase.Services;
using AssistantSorekeeperBase.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantSorekeeperBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    public class WorkController : ControllerBase
    {
        IWorkService workservice;
        public WorkController(IWorkService workservice)
        {
            this.workservice = workservice;
        }

        /// <summary>
        /// Получить Id пользователя по токену
        /// </summary>
        string UID()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").ToString().Substring(4);
        }

        #region Склады
        [Route("/warehouses")]
        [HttpGet]
        public string Warehouses()
        {
            return JsonConvert.SerializeObject(workservice.Warehouses(), Formatting.None);
        }
        [Route("/addwarehouses")]
        [HttpPost]
        public void AddWarehouses(WarehousesView warehousesView)
        {
            workservice.AddWarehouses(warehousesView);
        }
        [Route("/editwarehouses")]
        [HttpPut]
        public void EditWarehouses(WarehousesView warehousesView)
        {
            workservice.EditWarehouses(warehousesView);
        }
        [Route("/removewarehouses")]
        [HttpDelete]
        public void RemoveWarehouses(WarehousesView warehousesView)
        {
            workservice.RemoveWarehouses(warehousesView);
        }
        #endregion

        #region Номенклатуры
        [Route("/nomenclature")]
        [HttpGet]
        public string Nomenclature()
        {
            return JsonConvert.SerializeObject(workservice.Nomenclature(), Formatting.None);
        }
        [Route("/addnomenclature")]
        [HttpPost]
        public void AddNomenclature(NomenclatureView nomenclatureView)
        {
            workservice.AddNomenclature(nomenclatureView);
        }
        [Route("/editnomenclature")]
        [HttpPut]
        public void EditNomenclature(NomenclatureView nomenclatureView)
        {
            workservice.EditNomenclature(nomenclatureView);
        }
        [Route("/removenomenclature")]
        [HttpDelete]
        public void RemoveNomenclature(NomenclatureView nomenclatureView)
        {
            workservice.RemoveNomenclature(nomenclatureView);
        }
        #endregion

        #region Остатки/Перемещения
        [Route("/remains")]
        [HttpPost]
        public string Remains(RemainsView remainsView)
        {
            remainsView.Items = new List<RemainsItemsView>();
            remainsView.Id = UID();
            return JsonConvert.SerializeObject(workservice.Remains(remainsView), Formatting.None);
        }
        [Route("/movementsoptions")]
        [HttpGet]
        public string MovementsOpitons()
        {
            return JsonConvert.SerializeObject(workservice.MovementOption(), Formatting.None);
        }        
        [Route("/movements")]
        [HttpGet]
        public string Movements()
        {
            return JsonConvert.SerializeObject(workservice.Movements(), Formatting.None);
        }
        [Route("/addmovement")]
        [HttpPost]
        public string AddMovement(CreateMovementView createMovementView)
        {
            createMovementView.Id = UID();
            return JsonConvert.SerializeObject(workservice.AddMovements(createMovementView), Formatting.None);
        }
        #endregion
    }
}
