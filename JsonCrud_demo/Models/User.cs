using RestSharp;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft;
using System.ComponentModel.DataAnnotations;

namespace JsonCrud_demo.Models
{
    public class User
    {
        

        [Key]
        public int U_id { get; set; }
        public string U_Name { get; set;}
        public string U_Email { get; set; }
        public int U_Age { get; set; }
        
        public int U_Salary { get; set; }
        public string U_Disignation { get; set; }






    }

 }

