using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_App.Models;
using MVC_App.Administrator;
using MVC_App.Models.Customer;

namespace MVC_App.Models.Administrator
{
    public class ParentModel
    {
        public ParentModel() { }
        public ParentModel(bool initializeQuestions = true)
        {
            AnswersCollection = new List<AnswerModel>();
            Question = new QuestionModel();
            if (initializeQuestions)
            {
                for (int i = 0; i < 5; i++)
                {
                    AnswersCollection.Add(new AnswerModel());
                }
            }
        }


        public List<AnswerModel> AnswersCollection { get; set; }
        public CharacteristicModel Characteristic { get; set; }
        public QuestionModel Question { get; set; }
        
    }
}