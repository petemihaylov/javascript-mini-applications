using MVC_App.Data;
using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_App.Models;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVC_App.Administrator;
using System.Web.Helpers;
using MVC_App.Models.Customer;

namespace MVC_App.Controllers.Administrator
{
    public class QuestionController : Controller
    {
        public QuestionController() { }
        // GET: Question
        public ViewResult Index()
        {
            return View(new QuestionContext().SelectAllQuestions());
        }

        // GET: Question/Details/5
        public ViewResult Details(int id)
        {

            ParentModel p = new ParentModel();
            p.Question =  new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);
            

            return View(p);
        }

        // GET: Question/Create
        public ViewResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(ParentModel p)
        {
            try
            {

                // TODO: Add insert logic here
                AnswerToQuestionContext ans = new AnswerToQuestionContext();
                QuestionContext qt = new QuestionContext();

               
                int qId = ans.GetMaxId() + 1;
                DateTime date = DateTime.ParseExact(p.Question.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                qt.CreateQuestion(qId, p.Question.Question, date);


                foreach (var item in p.AnswersCollection)
                {
                    if (!String.IsNullOrEmpty(item.Text))
                    {
                        ans.CreateAnswerToTheQuestions(qId, item.Text);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Question/Edit/1
        public ViewResult Edit(int id)
        {
            ParentModel p = new ParentModel();
           
            p.Question =  new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);


            return View(p);
        }


        // POST: Question/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, ParentModel p)
        {

            try
            {
                AnswerToQuestionContext ans = new AnswerToQuestionContext();
                QuestionContext qt = new QuestionContext();
                qt.UpdateQuestion(id, p.Question.Question, p.Question.Date);
                ans.UpdateAnswerToTheQuestions(id, p.AnswersCollection);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            ParentModel p = new ParentModel();
            p.Question = new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);
            
            return View(p);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(QuestionModel q)
        {
            try
            {

                QuestionContext qt = new QuestionContext();
                qt.DeleteQuestion(q.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void ExportContentToCSV(int id)
        {
            CustomerAnswersContext qt = new CustomerAnswersContext();
            StatisticModel statistics = new StatisticModel();
            statistics = qt.GetStatisticOfTheDay(id);
            StringWriter strw = new StringWriter();

            strw.WriteLine("Question;Answers count;years working in Nemetschek Bulgaria;;;;");
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                string.Format("attachment;filename = File.csv"));
            Response.ContentType = "text/csv";

            strw.Write("{0};Total", statistics.Question);

            foreach (var characteristic in statistics.Characteristics)
            {
                strw.Write(";{0}", characteristic.characteristicName);
            }


            var item = statistics.Characteristics.ElementAt(0);
            //var answersCount = new List<int>();
            foreach (var answ in item.AnswersList)
            {
                strw.WriteLine();
                strw.Write("{0}", answ.answerName);
                int totalSum = 0;
                var answersCount = new List<int>();
                foreach (var characteristic in statistics.Characteristics)
                {

                    foreach (var currentAnsw in characteristic.AnswersList)
                    {
                        if (currentAnsw.answerName.Equals(answ.answerName))
                        {
                            answersCount.Add(currentAnsw.ansersCount);
                            totalSum += currentAnsw.ansersCount;
                            break;
                        }
                    }
                }
                strw.Write(";{0}", totalSum);
                foreach (var count in answersCount)
                {
                    strw.Write(";{0}", count);
                }
            }


            Response.Write(strw.ToString());
            Response.End();
        }


        public void CreateChart(int id)
        {
            CustomerAnswersContext qt = new CustomerAnswersContext();
            StatisticModel statistics = new StatisticModel();
            statistics = qt.GetStatisticOfTheDay(id);


            Chart myChart = new Chart(width: 800, height: 600)
                .AddTitle(statistics.Question);
            var xVals = new List<String>();
            xVals.Add("Total");
            foreach (var statCharact in statistics.Characteristics)
            {
                xVals.Add(statCharact.characteristicName);
            }
            //........................ready


            var item = statistics.Characteristics.ElementAt(0);

            foreach (var answ in item.AnswersList)
            {
                int totalCount = 0;
                var yVals = new List<int>();

                foreach (var characteristic in statistics.Characteristics)
                {
                    foreach (var currentAnsw in characteristic.AnswersList)
                    {
                        if (currentAnsw.answerName.Equals(answ.answerName))
                        {

                            yVals.Add(currentAnsw.ansersCount);
                            totalCount += currentAnsw.ansersCount;
                            break;
                        }
                    }

                }
                yVals.Insert(0, totalCount);
                myChart.AddSeries(
                   name: answ.answerName,
                   //xValue - static
                   xValue: xVals,
                   //yValue - from the DB Coun (*)
                   yValues: yVals)
                       .AddLegend();

            }

            myChart.Write("png");
        }


    }
}