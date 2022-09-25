using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
namespace JsonCrud_demo.Models.CrudClass

{
    public class JsonData
    {
       public string DBStore = @"D:\json\DBStore.json";
       public string Jkey = @"D:\json\Jkey.json";
        string counterval = "0";
        public JsonData()
        {
            if (!System.IO.File.Exists(DBStore))
            {
                System.IO.File.Create(DBStore);
            }
            if (!System.IO.File.Exists(Jkey))
            {
                System.IO.File.Create(Jkey);
            }
            var linesList = File.ReadAllLines(DBStore).ToList();
            if(linesList.Count <= 0)
            {
                System.IO.File.WriteAllText(DBStore,"[\n]");
            }
        }
        public dynamic JPost(object u)
        {
            string lineContents = ReadSpecificLine(2);
            JObject json = JObject.FromObject(u);
            var jsonString = JsonConvert.SerializeObject(u, Formatting.Indented);
            int iInsertAtLineNumber = 1 ;
            object strTextToInsert = "," + jsonString;
            ArrayList lines = new ArrayList();
            StreamReader rdr = new StreamReader(DBStore);
            string line;
            while ((line = rdr.ReadLine()) != null)
                lines.Add(line);
            rdr.Close();
            if (lines.Count > iInsertAtLineNumber)
                lines.Insert(iInsertAtLineNumber,
                   strTextToInsert);
            else
                lines.Add(strTextToInsert);
            StreamWriter wrtr = new StreamWriter(DBStore);
            foreach (object strNewLine in lines)
                wrtr.WriteLine(strNewLine);
            wrtr.Close();
            return "successs";
        }

        public dynamic JGet()
        {
            string lineContents = ReadSpecificLine(1);
            dynamic data = System.IO.File.ReadAllText(DBStore);
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
       public dynamic JKey()
        {
            var linesList = File.ReadAllLines(Jkey).ToList();
            if (linesList.Count <= 0)
            {
                System.IO.File.WriteAllText(Jkey, counterval);
            }
            var Inc = File.ReadAllLines(Jkey).ToList();
            var value = int.Parse(Inc[0]);
            var data = value + 1;
            System.IO.File.WriteAllText(Jkey, data.ToString());
            return data;
        }
        public dynamic ReadSpecificLine(int count)
        {
            if (count == 2)
            {
                var linesList = File.ReadAllLines(DBStore).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, ",{");
                    File.WriteAllLines(DBStore, linesList.ToArray());
                }
            }
            else
            {
                var linesList = File.ReadAllLines(DBStore).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, "{");
                    File.WriteAllLines(DBStore, linesList.ToArray());
                }
            }
            return "success";
        }
    }
}
