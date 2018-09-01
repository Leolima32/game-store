using System.Collections.Generic;
using System.Security.Claims;

namespace GameStore.UI.WebApi.Models
{
    public class AccountModel {
        public string UserName { get; set; }
        public IEnumerable<string> Roles {get;set;}
    }   
}