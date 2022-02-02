using AssistantSorekeeperBase.Data;
using AssistantSorekeeperBase.Model;
using AssistantSorekeeperBase.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBackEnd.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        AssistantSorekeeperContext asc;

        public AccountController(UserManager<User> userManager, AssistantSorekeeperContext asc)
        {
            _userManager = userManager;
            this.asc = asc;
        }

        /// <summary>
        /// Получение токена при авторизации 
        /// </summary>
        [Route("/token")]
        [HttpPost]
        public async Task<string> Token([FromBody] AuthView authView)
        {
            var user = asc.User.FirstOrDefault(x => x.NormalizedUserName == authView.Login.ToUpper());
            if (user == null)
            {
                Response.StatusCode = 404;
                return JsonConvert.SerializeObject(new { error = "Пользователя с данным логином не существует в системе !" }, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            if (await _userManager.CheckPasswordAsync(user, authView.Password))
            {
                var dateNow = DateTime.UtcNow;

                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

                var jwt = new JwtSecurityToken(
                        issuer: "AssistantSorekeeperBackEnd.Server",
                        audience: "AssistantSorekeeperBackEnd.API",
                        notBefore: dateNow,
                        claims: claims,
                        expires: dateNow.Add(TimeSpan.FromDays(7)),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fbff495e-3bca-493f-9492-02bfbc719779")), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt).ToString();
            }
            else
            {
                Response.StatusCode = 404;
                return JsonConvert.SerializeObject(new { error = "Ошибка авторизации !", }, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
        }

        [Route("/LUPAuth")]
        [HttpGet]
        public string LUPAuth()
        {
            string userid = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").ToString().Substring(4);
            LinksUserPeople lup = asc.LinksUserPeople.Include(x => x.Peoples).FirstOrDefault(x => x.UserId == userid);
            if (lup != null)
                return JsonConvert.SerializeObject(lup, new JsonSerializerSettings { Formatting = Formatting.None });
            return "";
        }
    }
}
