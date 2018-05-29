using GameStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;
using System.Collections.Generic;
using GameStore.UI.WebApi.Filters;
using GameStore.Application.DTOS.Games;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace GameStore.UI.WebApi.Controllers
{
    [ValidateModel]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private IGameServices _services;
        public GamesController(IGameServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IEnumerable<GameViewModel>> Get()
        {
            return await _services.GetAllGames();
        }

        [HttpGet("{id}")]
        public async Task<GameViewModel> Get(Guid id)
        {
            return await _services.GetGameById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Post([FromBody]AddOrUpdateGameDTO game)
        {
            _services.InsertGame(game);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public void Update([FromBody]AddOrUpdateGameDTO game)
        {
            _services.UpdateGame(game);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _services.DeleteGame(id);
        }
    }
}