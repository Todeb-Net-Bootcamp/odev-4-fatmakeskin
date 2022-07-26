using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccess.UnitofWorks;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        
        [HttpGet(nameof(GetById) + "/{userId}")]
        public IActionResult GetById(int userId)
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.GetRepository<User>().GetById(x => x.Id.Equals(id));
                if (data != null) return Ok(data);
                else return NotFound("Veri bulunamadı."); 
            }
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.GetRepository<User>().GetById(x => x.Id.Equals(id));
                if (data != null) return Ok(data);
                else return NotFound("Veri bulunamadı.");
            }
        }
        [HttpPost(nameof(Add))]
        public IActionResult Add(User user)
        {
            using (var uow = new UnitofWork())
            {
                uow.GetRepository<User>().Add(user);
               if (uow.SaveChanges() > 0)
                    return Ok(user);
                else return StatusCode(500);
            }
        }
    }
}
