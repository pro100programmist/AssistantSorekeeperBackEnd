using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantSorekeeperBase.ViewModel
{
    public class AuthView
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class AuthViewResponse
    {
        public string Token { get; set; }
        public bool RememberMe { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
