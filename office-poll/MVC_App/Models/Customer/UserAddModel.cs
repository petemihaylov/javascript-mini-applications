using MVC_App.Administrator;
using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Customer
{
    public class UserAddModel
    {
        public UserAddModel() {
            Answer = new AnswerModel();
            Question = new QuestionModel();
            Characteristic = new CharacteristicModel();
            AnswerChar = new AnswerToCharacteristicModel();
        }
        public QuestionModel Question { get; set; }
        public AnswerModel Answer { get; set; }
        public CharacteristicModel Characteristic { get; set; }
        public AnswerToCharacteristicModel AnswerChar { get; set; }

        
    }
}