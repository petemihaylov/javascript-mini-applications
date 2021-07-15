using MVC_App.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Data
{
    public class CustomerAnswersContext
    {
        private OfficePoll2Entities entities = new OfficePoll2Entities();
        public void CreateAnswer(int Question_id, int Question_answer_id, int Characteristic_id, int Characteristics_answers_id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                entities.Answering_the_Question.Add(
                    new Answering_the_Question()
                    {
                        question_id = Question_id
                    ,
                        question_answer_id = Question_answer_id
                    ,
                        characteristic_id = Characteristic_id
                    ,
                        characteristic_answers_id = Characteristics_answers_id
                    });
                entities.SaveChanges();

            }
        }

        public void DeleteAnswer(int CustomerId)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                var Answer = entities.Answering_the_Question.Find(CustomerId);
                entities.Answering_the_Question.Remove(Answer);
                entities.SaveChanges();

            }
        }


        public void AnswerTheQuetion(int q_id, int q_ans_id, int char_ans_id, int char_id = 2)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                entities.Answering_the_Question.Add(new Answering_the_Question()
                {
                    question_id = q_id,
                    question_answer_id = q_ans_id,
                    characteristic_id = char_id,
                    characteristic_answer_id = char_ans_id

                });
                entities.SaveChanges();
            }

        }

        public StatisticModel GetStatisticOfTheDay(int questionId)
        {
            StatisticModel result = new StatisticModel();
            try
            {
                using (OfficePoll2Entities entities = new OfficePoll2Entities())
                {
                    var questionOfTheDay = entities.Questions.FirstOrDefault(q => q.id == questionId);
                    result.Question = questionOfTheDay.text;

                    var characteristics = entities.Answers_to_the_Characteristics.ToList();

                    var answered = entities.Answering_the_Question.Where(a => a.question_id == questionOfTheDay.id);

                    var posibleAnswers = entities.Answers_to_the_Questions.Where(a => a.question_id == questionOfTheDay.id);

                    foreach (var item in characteristics)
                    {
                        var characteristic = new Models.Customer.Characteristics()
                        {
                            characteristicName = item.text,
                            id = item.id
                        };
                        foreach (var ans in posibleAnswers)
                        {
                            var answ = new Answers() { answerName = ans.text };
                            answ.ansersCount = answered.Count(q => q.characteristic_answer_id == characteristic.id && q.question_answer_id == ans.id);
                            characteristic.AnswersList.Add(answ);

                        }
                        result.Characteristics.Add(characteristic);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        //public CustomerParentModel SelectAnswer(int CustomerId)
        //{
        //    CustomerParentModel answer = new CustomerParentModel();

        //    using (entities)
        //    {

        //        var answ = entities.Answering_the_Question.Find(CustomerId);
        //        answer.Question.id = answ.question_id;
        //        IQueryable<Answering_the_Question> answers = entities.Answering_the_Question.Where(item => item.id == CustomerId);
        //      //  answer.AnswerToQuestion.id = answers.First().question_answer_id; 
        //        answer.Characteristics.id = answ.question_id;
        //        answer.AnswerToCharacteristics = answ.question_id
        //        //q.answers = SelectAnswers(question.id);
        //    }
        //    return q;
        //}

    }
}