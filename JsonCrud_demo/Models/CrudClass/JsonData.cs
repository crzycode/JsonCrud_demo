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
                System.IO.File.Create(DBStore).Dispose();   
            }
            if (!System.IO.File.Exists(Jkey))
            {
                System.IO.File.Create(Jkey).Dispose();
            }
            var line = File.ReadAllLines(Jkey).ToList();
            if (line.Count <= 0)
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
            var line = File.ReadAllLines(Jkey).ToList();
            if (line.Count <= 0)
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
        public dynamic JFindById(string id)
        {
            dynamic data = System.IO.File.ReadAllText(DBStore);
            ReadSpecificLine(1);
            var json = JsonConvert.DeserializeObject<List<User>>(data);
            int numericValue;
            bool isNumber = int.TryParse(id, out numericValue);
            if (isNumber == true)
            {
                if (json != null)
                {
                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].U_id == numericValue)
                        {
                            return json[i];
                            break;
                        }
                    }
                }
            }
            else
            {
                if (json != null)
                {
                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].U_Name == id)
                        {

                            return json[i];


                        }

                    }
                }
            }
            return "Id Does not Exist";
        }
        public dynamic JUpdate(User u, string id)
        {
            dynamic data = System.IO.File.ReadAllText(DBStore);
            ReadSpecificLine(1);
            var json = JsonConvert.DeserializeObject<List<User>>(data);


            int numericValue;
            bool isNumber = int.TryParse(id, out numericValue);
            if (isNumber == true)
            {
                if (json != null)
                {
                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].U_id == numericValue)
                        {
                            json[i].U_Name = u.U_Name;
                            json[i].U_Email = u.U_Email;
                            json[i].U_Age = u.U_Age;
                            json[i].U_Salary = u.U_Salary;
                            json[i].U_Disignation = u.U_Disignation;
                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                            File.WriteAllText(DBStore, output);
                            return json[i];
                        }
                    }
                }
            }
            else
            {
                if (json != null)
                {
                    for (int i = 0; i < json.Count; i++)
                    {
                        if (json[i].U_Name == id)
                        {
                            json[i].U_Name = u.U_Name;
                            json[i].U_Email = u.U_Email;
                            json[i].U_Age = u.U_Age;
                            json[i].U_Salary = u.U_Salary;
                            json[i].U_Disignation = u.U_Disignation;
                            string output = Newtonsoft.Json.JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                            File.WriteAllText(DBStore, output);
                            return json[i];
                        }

                    }
                }
            }
            return "hey";
        }
    }
}
