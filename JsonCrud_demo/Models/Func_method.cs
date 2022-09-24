using System.Collections;
using System.Collections.Generic;

namespace JsonCrud_demo.Models
{
    public class Func_method
    {
        private string filePath = @"D:\Json\Data.json";

        public dynamic ReadSpecificLine(int count)
        {
            if (count == 2)
            {
                var linesList = File.ReadAllLines(filePath).ToList();
                linesList.RemoveAt(2);
                linesList.Insert(2, ",{");
                File.WriteAllLines(filePath, linesList.ToArray());
            }
            else
            {
                var linesList = File.ReadAllLines(filePath).ToList();
                linesList.RemoveAt(2);
                linesList.Insert(2, "{");
                File.WriteAllLines(filePath, linesList.ToArray());

            }
           
            
          

            return "success";

        }

    }
}
