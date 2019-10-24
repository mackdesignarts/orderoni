using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using orderoni.Models;
using orderoni.Services;

namespace orderoni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorefrontController : ControllerBase
    {
        private readonly StorefrontService _storefrontService;

        public StorefrontController(StorefrontService storefrontService)
        {
            _storefrontService = storefrontService;
        }

        // GET: api/Storefront
        [HttpGet]
        public ActionResult<List<Storefront>> Get()
        {
            return _storefrontService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetStorefront")]
        public ActionResult<Storefront> Get(string id)
        {
            var storefront = _storefrontService.Get(id);

            if (storefront == null)
            {
                return NotFound();
            }

            return storefront;
        }

        [HttpPost]
        public ActionResult<Storefront> Create(Storefront storefront)
        {
            _storefrontService.Create(storefront);

            return CreatedAtRoute("GetStorefront", new { id = storefront.Id.ToString() }, storefront);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Storefront portIn)
        {
            var storefront = _storefrontService.Get(id);

            if (storefront == null)
            {
                return NotFound();
            }

            _storefrontService.Update(id, portIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var storefront = _storefrontService.Get(id);

            if (storefront == null)
            {
                return NotFound();
            }

            _storefrontService.Remove(storefront.Id);

            return NoContent();
        }
    }
}
