using JsonCrud_demo.Models.Functions;
using Newtonsoft.Json;

namespace JsonCrud_demo.Models.CrudClass

{
    public class GetClass
    {
        Func_method fun = new Func_method();
        public dynamic get(string Filename)
        {
            string lineContents = fun.ReadSpecificLine(1);
            dynamic data = System.IO.File.ReadAllText(Filename);

            var json = JsonConvert.DeserializeObject<List<User>>(data);

            if (json != null)
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
