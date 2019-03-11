using GameStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using System.Collections.Generic;
using GameStore.UI.WebApi.Filters;
using GameStore.Application.DTOS.Platforms;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.UI.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PlatformsController : Controller
    {
        private IPlatformServices _services;
        public PlatformsController(IPlatformServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<PlatformViewModel>> Get()
        {
            return await _services.GetAllPlatforms();
        }

        [HttpGet("{id}")]
        public async Task<PlatformViewModel> Get(Guid id)
        {
            return await _services.GetPlatformById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody]AddOrUpdatePlatformDTO platform)
        {
            _services.InsertPlatform(platform);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void Update([FromBody]AddOrUpdatePlatformDTO platform)
        {
            _services.UpdatePlatform(platform);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _services.DeletePlatform(id);
        }
    }
}