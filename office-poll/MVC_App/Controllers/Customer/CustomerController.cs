using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_App.Models;
using MVC_App.Models.Administrator;
using MVC_App.Data;
using MVC_App.Administrator;
using MVC_App.Models.Customer;

public class CustomerController : Controller
{



    public CustomerController()
    {
    }
    // GET: AnswerQuestion
    public ViewResult AnswerQuestion()
    {
        QuestionContext qt = new QuestionContext();
        ParentModel question = new ParentModel(false);
        try
        {
            question = qt.GetQuestionOfTheDay();
            Session.Add("QuestionId", question.Question.id);
        }
        catch (MissingMemberException)
        {
            question.Question.Question = "There isn't question of the day ...";
        }
        catch (Exception)
        {
            throw new Exception();
        }

        return View(question);
    }

    // POST: AnswerQuestion
    [HttpPost]
    public ActionResult AnswerQuestion(FormCollection form)
    {

        int answeredQuestionId = Int32.Parse(form["AnswersCollection"]);

        Session.Add("AnswerdQuestionId", answeredQuestionId);
        return RedirectToAction("AnswerCharacteristics");
    }

    // GET: AnswerCharacteristics
    public ViewResult AnswerCharacteristics()
    {
        QuestionContext qt = new QuestionContext();
        ParentModel parent = new ParentModel();
        parent = qt.GetQuestionOfTheDay();
        CharacteristicsContext ch = new CharacteristicsContext();
        parent.Characteristic = ch.GetAllCharacteristicAnswers();

        return View(parent);
    }

    // POST: AnswerCharacteristics
    [HttpPost]
    public ActionResult AnswerCharacteristics(FormCollection form)
    {
        int characteristiId = Int32.Parse(form["Characteristic.answers_to_characteristic"]);
        CustomerAnswersContext ct = new CustomerAnswersContext();

        ct.AnswerTheQuetion((int)Session["QuestionId"], (int)Session["AnswerdQuestionId"], characteristiId);
        return RedirectToAction("Index");
    }

    public RedirectToRouteResult Index()
    {
        return RedirectToAction("AnswerQuestion", "Customer");
    }

    // GET: Finish
    public ViewResult Finish()
    {
        return View();
    }
}
