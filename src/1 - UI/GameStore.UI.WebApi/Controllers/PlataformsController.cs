using GameStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using System.Collections.Generic;
using GameStore.UI.WebApi.Filters;
using GameStore.Application.DTOS.Plataforms;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlataformsController : Controller
    {
        private IPlataformServices _services;
        public PlataformsController(IPlataformServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<PlataformViewModel>> Get()
        {
            return await _services.GetAllPlataforms();
        }

        [HttpGet("{id}")]
        public async Task<PlataformViewModel> Get(Guid id)
        {
            return await _services.GetPlataformById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody]AddOrUpdatePlataformDTO plataform)
        {
            _services.InsertPlataform(plataform);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void Update([FromBody]AddOrUpdatePlataformDTO plataform)
        {
            _services.UpdatePlataform(plataform);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _services.DeletePlataform(id);
        }
    }
}