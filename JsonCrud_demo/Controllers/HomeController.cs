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
        JsonData data = new JsonData();
        

        [HttpPost]
        public dynamic  Adduser(User u){
            
            u.U_id = data.JKey();
            data.JPost(u);
            
            return "h";
        }
      

        [HttpGet]
        public dynamic getdata()
        {



            return data.JGet();

        }
       
    }
}
