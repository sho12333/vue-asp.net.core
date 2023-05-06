using Microsoft.AspNetCore.Mvc;
using Project.Server.Models;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var items = new List<Item>()
            {
                new Item() { Id = "1", Name = "Item 1" },
                new Item() { Id = "2", Name = "Item 2" },
                new Item() { Id = "3", Name = "Item 3" }
            };

            return items;
        }
    }
}
