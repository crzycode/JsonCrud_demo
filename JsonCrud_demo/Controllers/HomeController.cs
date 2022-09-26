using JsonCrud_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json;
using System.IO;
using JsonCrud_demo.Models.CrudClass;


namespace JsonCrud_demo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class HomeController : ControllerBase
    {
        JsonData js = new JsonData();
        

        [HttpPost]
        public dynamic  Adduser(User u){
             u.U_id = js.JKey();
            var data = js.JPost(u);
            return data;
        
        }
      

        [HttpGet]
        public dynamic getdata()
        {
            var data = js.JGet();
            return data;

        }
        [HttpGet("{id}")]
        public dynamic finddata(string id)
        {
            var data = js.JFindById(id);
            return data;
        }
        [HttpPut("{id}")]
        public dynamic updatedata(User u,string id)
        {

            var data = js.JUpdate(u,id);
            return data;
        }
       
    }
}
