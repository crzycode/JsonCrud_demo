using JsonCrud_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json;
using System.IO;
using JsonCrud_demo.Models.CrudClass;
using JsonCrud_demo.Models.Functions;

namespace JsonCrud_demo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class HomeController : ControllerBase
    {
        private int i;
        private string Filename = @"D:\Json\Data.json";

        Func_method fun = new Func_method();
        PostClass pos = new PostClass();
        GetClass get = new GetClass();
        

        [HttpPost]
        public dynamic  Adduser(User u){

            pos.Postdata(u,Filename);
            return "successs";
        }
      

        [HttpGet]
        public dynamic getdata()
        {


            return get.get(Filename);

        }
       
    }
}
