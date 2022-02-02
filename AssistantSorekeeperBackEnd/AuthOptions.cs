using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TokenApp
{
    public static class AuthenticationOptions
    {
        /// <summary>
        /// Ключ шифрования
        /// </summary>
        private const string KEY = "fbff495e-3bca-493f-9492-02bfbc719779";

        /// <summary>
        /// Издатель токена
        /// </summary>
        public const string ISSUER = "AssistantSorekeeperBackEnd.Server";

        /// <summary>
        /// Клиентское приложение
        /// </summary>
        public const string AUDIENCE = "AssistantSorekeeperBackEnd.API";

        /// <summary>
        /// Время жизни токена в днях
        /// </summary>
        public const int LIFE_TIME = 7;

        /// <summary>
        /// Возвращает
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
