using JsonCrud_demo.Models.Functions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace JsonCrud_demo.Models.CrudClass
{
    public class PostClass
    {
       
        Func_method fun = new Func_method();
        public dynamic Postdata(object u, string Filename)
        {
            
            

            string lineContents = fun.ReadSpecificLine(2);
            JObject json = JObject.FromObject(u);
            var jsonString = JsonConvert.SerializeObject(u, Formatting.Indented);
            int iInsertAtLineNumber = 1;
            object strTextToInsert = "," + jsonString;
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
    }
}
