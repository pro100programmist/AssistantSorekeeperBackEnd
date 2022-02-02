using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantSorekeeperBackEnd
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, AssistantSorekeeperContext asc)
        {
            LinksUserPeople linksUserPeople = new LinksUserPeople();
            DateTime dateTime = DateTime.Now;
            if (await userManager.FindByNameAsync("admin") == null)
            {
                User user = new User { UserName = "admin" };
                await userManager.CreateAsync(user, "123123");
                Peoples people = new Peoples() { FullName = "Администратор" };
                asc.Peoples.Add(people);
                asc.SaveChanges();
                linksUserPeople = new LinksUserPeople() { UserId = user.Id, PeoplesId = people.Id };
                asc.LinksUserPeople.Add(linksUserPeople);
                asc.SaveChanges();
            }
            if (asc.Warehouses.Count() == 0)
            {
                foreach (string item in new string[] { "Склад 1", "Склад 2", "Склад 3" })
                    asc.Warehouses.Add(new Warehouses() { InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, Name = item });

                foreach (string item in new string[] { "Шапка", "Шарф", "Куртка", "Штаны", "Перчатки", "Носки", "Ботинки" })
                    asc.Nomenclature.Add(new Nomenclature() { InsertedDate = dateTime, InsertedLUPId = linksUserPeople.Id, Name = item });

                asc.SaveChanges();
            }
        }

    }
}
