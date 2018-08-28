using System.Collections.Generic;
using System.Security.Claims;

namespace GameStore.UI.WebApi.Models
{
    public class AccountModel {
        public string UserName { get; set; }
        public IEnumerable<Claim> Roles {get;set;}
    }   
}