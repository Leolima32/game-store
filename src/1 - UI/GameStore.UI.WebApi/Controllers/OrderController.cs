using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.Commands;
using GameStore.Application.Interfaces;

namespace GameStore.UI.WebApi.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices _services;
        public OrderController(IOrderServices services)
        {
            _services = services;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public void FinishOrder(FinishCreditCardOrderCommand order)
        {
            //todo create handler
            _services.FinishCreditCardOrder(order);
        }
    }
}