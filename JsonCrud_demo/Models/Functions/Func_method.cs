using System.Collections;
using System.Collections.Generic;


namespace JsonCrud_demo.Models.Functions
{
    public class Func_method
    {
        private string filePath = @"D:\Json\Data.json";

        public dynamic ReadSpecificLine(int count)
        {
            
            if (count == 2)
            {

                var linesList = File.ReadAllLines(filePath).ToList();
               
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, ",{");
                    File.WriteAllLines(filePath, linesList.ToArray());
                }

            }
            else
            {
                var linesList = File.ReadAllLines(filePath).ToList();
                if (linesList.Count > 6)
                {
                    linesList.RemoveAt(1);
                    linesList.Insert(1, "{");
                    File.WriteAllLines(filePath, linesList.ToArray());

                }



            }




            return "success";

        }

    }
}
