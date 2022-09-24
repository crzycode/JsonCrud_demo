using JsonCrud_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json;
using System.IO;

namespace JsonCrud_demo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]


    public class HomeController : ControllerBase
    {
        private int i;
        private string Filename = @"D:\Json\Data.json";

        Func_method fun = new Func_method();
        

        [HttpPost]
        public dynamic  PostData(User u){
            i++;

            string lineContents = fun.ReadSpecificLine(2);
            JObject json = JObject.FromObject(u);
            var jsonString = JsonConvert.SerializeObject(u, Formatting.Indented);
             int iInsertAtLineNumber = 1+1;
            object strTextToInsert = ","+jsonString;
            ArrayList lines = new ArrayList();
            StreamReader rdr = new StreamReader(Filename);
            string line;
            while ((line = rdr.ReadLine()) != null)
                lines.Add(line);
            rdr.Close();
            if (lines.Count > iInsertAtLineNumber)
                lines.Insert(iInsertAtLineNumber,
                   strTextToInsert);
            else
                lines.Add(strTextToInsert);
            StreamWriter wrtr = new StreamWriter(Filename);
            foreach (object strNewLine in lines)
                wrtr.WriteLine(strNewLine);
            
            wrtr.Close(); 

            return "successs";
        }
      

        [HttpGet]
        public dynamic getdata()
        {
            string lineContents = fun.ReadSpecificLine(1);
            dynamic data = System.IO.File.ReadAllText(Filename);

            var json = JsonConvert.DeserializeObject<List<User>>(data);
           
            if(json != null)
            {
                for (int i = 0; i < json.Count; i++)
                {
                    User u = json[i];
                    
                }
                
            }

            
           
            return json;

        }
       
    }
}
