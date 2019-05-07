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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;

namespace GameStore.UI.WebApi.Controllers
{
    [ValidateModel]
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private IGameServices _services;
        private IHostingEnvironment _hostingEnvironment;
        public GamesController(IGameServices services, IHostingEnvironment hostingEnvironment)
        {
            _services = services;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IEnumerable<GameListViewModel>> Get()
        {
            return await _services.GetAllGames();
        }

        [HttpGet("listbygenre/{genreId}")]
        public async Task<IEnumerable<GameListViewModel>> GetListByGenre(Guid genreId)
        {
            return await _services.GetGamesByGenre(genreId);
        }

        [HttpGet("{id}")]
        public async Task<GameViewModel> Get(Guid id)
        {
            return await _services.GetGameById(id);
        }

        [HttpGet("bestrated")]
        public async Task<IEnumerable<GameListViewModel>> GetBestRatedGames()
        {
            return await _services.GetBestRatedGames();
        }

        [HttpGet("bestsellers")]
        public async Task<IEnumerable<GameListViewModel>> GetBestSellerGames()
        {
            return await _services.GetBestSellerGames();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Post([FromBody]AddOrUpdateGameDTO game)
        {
            var id = _services.InsertGame(game);
            if (id != null)
            {
                return new OkObjectResult(new ResultViewModel(id, 200, "Success!"));
            }
            else
            {
                return new BadRequestObjectResult(new ResultViewModel(500, "Something went wrong! Try again later."));
            }
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/uploadthumbimage")]
        public async Task<ActionResult> UploadThumbImage(Guid id)
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "images/games/" + id + "/thumb";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    await _services.UpdateThumbImage(id, "/" + folderName + "/" + fileName);
                }
                return Json("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
    }
}