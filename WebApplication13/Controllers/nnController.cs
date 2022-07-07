using learn.core1.Data;
using learn.core1.Repoisitory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nnController : ControllerBase
    {
        private readonly Icategoreyrepoisitory icategoreyrepoisitory;
        public nnController(Icategoreyrepoisitory icategoreyrepoisitory)
        {
            this.icategoreyrepoisitory = icategoreyrepoisitory;
        }


        [HttpPost]
        public string CAT(categorey_api cc)
        {
            icategoreyrepoisitory.insertcat(cc);
            return "valid";
        }
    }
}
