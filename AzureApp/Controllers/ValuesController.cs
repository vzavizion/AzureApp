using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureApp.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<int> _values;

        static ValuesController()
        {
            Init();
        }

        private static void Init()
        {
            _values = new List<int>();

            _values.Add(2);
            _values.Add(4);
            _values.Add(6);
        }

        [HttpGet, ActionName("GetAll")]
        public IEnumerable<int> GetAll()
        {
            return _values;
        }

        [HttpGet("{id}"), ActionName("GetById")]
        public int GetById([FromRoute] int id)
        {
            return _values[id];
        }

        [HttpGet, ActionName("GetByIdQ")]
        public int GetByIdQ([FromQuery] int id)
        {
            return _values[id];
        }

        [HttpPost, ActionName("Add")]
        public IActionResult Add(Item item)
        {
            _values.Add(item.value);
            _values.Add(item.value + 2);

            return Ok(_values);
        }

        [HttpPost, ActionName("Clear")]
        public IActionResult Clear()
        {
            Init();

            return Ok(_values);
        }

        //#region AutoCreate

        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<int> Get()
        //{
        //    return _values;
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public int Get(int id)
        //{
        //    return _values[id];
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public IActionResult Post([FromBody] int value)
        //{
        //    _values.Add(value);

        //    return Ok("OK");
        //}

        //#endregion
    }
}
