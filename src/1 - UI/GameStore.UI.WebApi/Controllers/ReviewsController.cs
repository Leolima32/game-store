using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.Commands;
using GameStore.Application.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;
using GameStore.Application.DTOS.Reviews;
using GameStore.Application.ViewModels;
using System.Collections.Generic;
using GameStore.Domain.Entities;

namespace GameStore.UI.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReviewsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IReviewServices _services;
        public ReviewsController(IReviewServices services, UserManager<IdentityUser> userManager)
        {
            _services = services;
            _userManager = userManager;
        }

        [Route("product/{id}")]
        public IEnumerable<Review> GetByProductId(Guid id) {
            return _services.GetReviewByProductId(id);
        }

        [Route("user/{id}")]
        public IEnumerable<Review> GetByUserId(Guid id) {
            return _services.GetReviewByUserId(id);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Post([FromBody]AddOrUpdateReviewDTO review)
        {
            var id = _services.Save(review);
            if(id != null) {
                return new OkObjectResult(new ResultViewModel(id,200,"Success!"));
            } else {
                return new BadRequestObjectResult(new ResultViewModel(500, "Something went wrong! Try again later."));
            }
        }
    }
}