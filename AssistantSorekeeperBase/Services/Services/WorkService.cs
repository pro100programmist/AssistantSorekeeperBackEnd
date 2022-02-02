using AssistantSorekeeperBase.ViewModel;
using AssistantSorekeeperBase.Repositories;
using System.Collections.Generic;
using AssistantSorekeeperBase.Model;
using System.Linq;
using System;
using AssistantSorekeeperBase.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace AssistantSorekeeperBase.Services
{
    public interface IWorkService
    {
        #region Склады
        public List<WarehousesView> Warehouses();
        public void AddWarehouses(WarehousesView warehousesView);
        public void EditWarehouses(WarehousesView warehousesView);
        public void RemoveWarehouses(WarehousesView warehousesView);
        #endregion

        #region Номенклатуры
        public List<NomenclatureView> Nomenclature();
        public void AddNomenclature(NomenclatureView nomenclatureView);
        public void EditNomenclature(NomenclatureView nomenclatureView);
        public void RemoveNomenclature(NomenclatureView nomenclatureView);
        #endregion

        #region Остатки/Перемещения
        public RemainsView Remains(RemainsView remainsView);
        public MovementOptionView MovementOption();
        public List<MovementView> Movements();
        public MovementView AddMovements(CreateMovementView createMovementView);
        #endregion
    }
    public class WorkService : IWorkService
    {
        AssistantSorekeeperContext asc; ILinkWarehousesNomenclatureRepository linkWarehousesNomenclatureRepository; IMovementHistoryItemsRepository movementHistoryItemsRepository; IMovementHistoryRepository movementHistoryRepository; INomenclatureRepository nomenclatureRepository; IWarehousesRepository warehousesRepository;
        public WorkService(AssistantSorekeeperContext asc, ILinkWarehousesNomenclatureRepository linkWarehousesNomenclatureRepository, IMovementHistoryItemsRepository movementHistoryItemsRepository, IMovementHistoryRepository movementHistoryRepository, INomenclatureRepository nomenclatureRepository, IWarehousesRepository warehousesRepository)
        {
            this.asc = asc;
            this.linkWarehousesNomenclatureRepository = linkWarehousesNomenclatureRepository;
            this.movementHistoryItemsRepository = movementHistoryItemsRepository;
            this.movementHistoryRepository = movementHistoryRepository;
            this.nomenclatureRepository = nomenclatureRepository;
            this.warehousesRepository = warehousesRepository;
        }

        LinksUserPeople LUP(string Id)
        {
            LinksUserPeople linksUserPeople = asc.LinksUserPeople.Include(x => x.User).Include(x => x.Peoples).FirstOrDefault(x => x.UserId == Id);
            return linksUserPeople;
        }

        #region Склады
        public List<WarehousesView> Warehouses()
        {
            List<WarehousesView> warehousesViews = new List<WarehousesView>();
            foreach (Warehouses item in warehousesRepository.GetAll(x => x.DeletedDate == null).OrderBy(x => x.Id).ToList())
                warehousesViews.Add(new WarehousesView() { IdWarehouses = item.Id, Name = item.Name });
            return warehousesViews;
        }
        public void AddWarehouses(WarehousesView warehousesView)
        {
            LinksUserPeople linksUserPeople = LUP(warehousesView.Id);
            warehousesRepository.Add(new Model.Warehouses() { InsertedDate = DateTime.Now, InsertedLUPId = linksUserPeople.Id, Name = warehousesView.Name });
        }
        public void EditWarehouses(WarehousesView warehousesView)
        {
            LinksUserPeople linksUserPeople = LUP(warehousesView.Id);
            Warehouses warehouses = warehousesRepository.GetByID(warehousesView.IdWarehouses);
            warehouses.UpdatedDate = DateTime.Now;
            warehouses.UpdatedLUPId = linksUserPeople.Id;
            warehousesRepository.Update(warehouses);
        }
        public void RemoveWarehouses(WarehousesView warehousesView)
        {
            LinksUserPeople linksUserPeople = LUP(warehousesView.Id);
            Warehouses warehouses = warehousesRepository.GetByID(warehousesView.IdWarehouses);
            warehouses.DeletedDate = DateTime.Now;
            warehouses.DeletedLUPId = linksUserPeople.Id;
            warehousesRepository.Update(warehouses);
        }
        #endregion

        #region Номенклатуры
        public List<NomenclatureView> Nomenclature()
        {
            List<NomenclatureView> nomenclatureView = new List<NomenclatureView>();
            foreach (Nomenclature item in nomenclatureRepository.GetAll(x => x.DeletedDate == null).OrderBy(x => x.Id).ToList())
                nomenclatureView.Add(new NomenclatureView() { IdNomenclature = item.Id, Name = item.Name });
            return nomenclatureView;
        }
        public void AddNomenclature(NomenclatureView nomenclatureView)
        {
            LinksUserPeople linksUserPeople = LUP(nomenclatureView.Id);
            nomenclatureRepository.Add(new Model.Nomenclature() { InsertedDate = DateTime.Now, InsertedLUPId = linksUserPeople.Id, Name = nomenclatureView.Name });
        }
        public void EditNomenclature(NomenclatureView nomenclatureView)
        {
            LinksUserPeople linksUserPeople = LUP(nomenclatureView.Id);
            Nomenclature nomenclature = nomenclatureRepository.GetByID(nomenclatureView.IdNomenclature);
            nomenclature.UpdatedDate = DateTime.Now;
            nomenclature.UpdatedLUPId = linksUserPeople.Id;
            nomenclatureRepository.Update(nomenclature);
        }
        public void RemoveNomenclature(NomenclatureView nomenclatureView)
        {
            LinksUserPeople linksUserPeople = LUP(nomenclatureView.Id);
            Nomenclature nomenclature = nomenclatureRepository.GetByID(nomenclatureView.IdNomenclature);
            nomenclature.DeletedDate = DateTime.Now;
            nomenclature.DeletedLUPId = linksUserPeople.Id;
            nomenclatureRepository.Update(nomenclature);
        }
        #endregion

        #region Остатки/Перемещения 
        public RemainsView Remains(RemainsView remainsView)
        {
            if (remainsView.DateTimeStart != null && remainsView.DateTimeEnd != null)
            {
                List<LinkWarehousesNomenclature> items = linkWarehousesNomenclatureRepository.GetAll(x => x.DeletedDate == null && x.InsertedDate>=Convert.ToDateTime(remainsView.DateTimeStart) && x.InsertedDate<= Convert.ToDateTime(remainsView.DateTimeEnd) && x.WarehousesId == remainsView.IdWarehouses, x => x.Nomenclature).OrderByDescending(x => x.Id).ToList();
                foreach (LinkWarehousesNomenclature item in items)
                    if(remainsView.Items.FirstOrDefault(x=>x.IdNomenclature==item.NomenclatureId)==null)
                    remainsView.Items.Add(new RemainsItemsView() { IdNomenclature = item.NomenclatureId, Name = item.Nomenclature.Name, Count = item.Count });
                remainsView.Items = remainsView.Items.OrderBy(x => x.IdNomenclature).ToList();
            }
            else
            foreach (LinkWarehousesNomenclature item in linkWarehousesNomenclatureRepository.GetAll(x => x.DeletedDate == null && !x.Past && x.WarehousesId == remainsView.IdWarehouses, x => x.Nomenclature).OrderBy(x => x.NomenclatureId).ToList())
                remainsView.Items.Add(new RemainsItemsView() { IdNomenclature = item.NomenclatureId, Name = item.Nomenclature.Name, Count = item.Count });
            remainsView.WarehouseName = warehousesRepository.GetByID(remainsView.IdWarehouses).Name;
            return remainsView;
        }
        public MovementOptionView MovementOption()
        {
            return new MovementOptionView() { Nomenclature = nomenclatureRepository.GetAll(x => x.DeletedDate == null).OrderBy(x => x.Id).ToList(), Warehouses = warehousesRepository.GetAll(x => x.DeletedDate == null).OrderBy(x => x.Id).ToList() };
        }
        public List<MovementView> Movements()
        {
            List<MovementView> movementViews = new List<MovementView>();
            foreach (MovementHistory item in movementHistoryRepository.GetAll(x => x.DeletedDate == null, x => x.InsertedLUP.Peoples).OrderByDescending(x => x.Id))
            {
                MovementView movement = new MovementView() { DateTime = item.InsertedDate.ToString("yyyy.MM.dd HH:mm"), WhoMovement = item.InsertedLUP.Peoples.FullName, WarehouseEnd = warehousesRepository.GetByID(item.WarehousesRecipientId).Name, Items = new List<MovementItemView>() };
                if (item.WarehousesSenderId != null) movement.WarehouseStart = warehousesRepository.GetByID((int)item.WarehousesSenderId).Name;
                else movement.WarehouseStart = "Из вне";
                foreach (MovementHistoryItems mitem in movementHistoryItemsRepository.GetAll(x => x.DeletedDate == null && x.MovementHistoryId == item.Id, x => x.Nomenclature).OrderBy(x => x.Id))
                    movement.Items.Add(new MovementItemView() { Name = mitem.Nomenclature.Name, Count = mitem.Count });
                movementViews.Add(movement);
            }
            return movementViews;
        }
        public MovementView AddMovements(CreateMovementView createMovementView)
        {
            LinksUserPeople linksUserPeople = LUP(createMovementView.Id);
            DateTime dateTime = DateTime.Now;
            MovementView movementView = new MovementView() { WarehouseEnd = warehousesRepository.GetByID(createMovementView.end).Name, DateTime = dateTime.ToString("yyyy.MM.dd HH:mm"), WhoMovement = linksUserPeople.Peoples.FullName, Items = new List<MovementItemView>() };
            if (createMovementView.start != 0) movementView.WarehouseStart = warehousesRepository.GetByID(createMovementView.start).Name;
            else movementView.WarehouseStart = "Из вне";
            MovementHistory movementHistory = new MovementHistory() { InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, WarehousesRecipientId = createMovementView.end };
            if (createMovementView.start != 0) movementHistory.WarehousesSenderId = createMovementView.start;
            movementHistoryRepository.Add(movementHistory);
            foreach (CreateMovementItemsView item in createMovementView.items)
            {
                movementView.Items.Add(new MovementItemView() { Count = item.count, Name = item.nomenclature });
                movementHistoryItemsRepository.Add(new MovementHistoryItems() { InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, Count = item.count, MovementHistoryId = movementHistory.Id, NomenclatureId = item.nomenclatureId });
                if (createMovementView.start != 0)
                {
                    LinkWarehousesNomenclature linkWarehousesNomenclatureSenderOld = linkWarehousesNomenclatureRepository.GetFirstOrDefault(x => x.DeletedDate == null && !x.Past && x.NomenclatureId == item.nomenclatureId && x.WarehousesId == createMovementView.start);
                    LinkWarehousesNomenclature linkWarehousesNomenclatureSenderNew = new LinkWarehousesNomenclature() { InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, NomenclatureId = item.nomenclatureId, WarehousesId = createMovementView.start };
                    linkWarehousesNomenclatureSenderOld.UpdatedDate = dateTime;
                    linkWarehousesNomenclatureSenderOld.UpdatedLUPId = linksUserPeople.Id;
                    linkWarehousesNomenclatureSenderOld.Past = true;
                    linkWarehousesNomenclatureRepository.Update(linkWarehousesNomenclatureSenderOld);
                    linkWarehousesNomenclatureSenderNew.Count = linkWarehousesNomenclatureSenderOld.Count - item.count;
                    if (linkWarehousesNomenclatureSenderNew.Count != 0)
                        linkWarehousesNomenclatureRepository.Add(linkWarehousesNomenclatureSenderNew);
                }
                LinkWarehousesNomenclature linkWarehousesNomenclatureOld = linkWarehousesNomenclatureRepository.GetFirstOrDefault(x => x.DeletedDate == null && !x.Past && x.NomenclatureId == item.nomenclatureId && x.WarehousesId == createMovementView.end);
                LinkWarehousesNomenclature linkWarehousesNomenclatureNew = new LinkWarehousesNomenclature() { Count = item.count, InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, NomenclatureId = item.nomenclatureId, WarehousesId = createMovementView.end };
                if (linkWarehousesNomenclatureOld != null)
                {
                    linkWarehousesNomenclatureOld.UpdatedDate = dateTime;
                    linkWarehousesNomenclatureOld.UpdatedLUPId = linksUserPeople.Id;
                    linkWarehousesNomenclatureOld.Past = true;
                    linkWarehousesNomenclatureNew.Count = linkWarehousesNomenclatureNew.Count + linkWarehousesNomenclatureOld.Count;
                    linkWarehousesNomenclatureRepository.Update(linkWarehousesNomenclatureOld);
                }
                linkWarehousesNomenclatureRepository.Add(linkWarehousesNomenclatureNew);
            }
            return movementView;
        }
        #endregion
    }
}
