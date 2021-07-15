using MVC_App.Administrator;
using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Customer
{
    public class StatisticModel
    {
       public StatisticModel()
        {
            Characteristics = new List<Customer.Characteristics>();
        }

        public String Question { get; set; }
        public List<Characteristics> Characteristics { get; set; }


    }

    public class Characteristics {
        public Characteristics()
        {
            AnswersList = new List<Answers>();
        }
        public int id { get; set; }
        public string characteristicName { get; set; }
        public List<Answers> AnswersList { get; set;}

    }

    public class Answers
    {
        public string answerName { get; set; }
        public int ansersCount { get; set; }

    }

}