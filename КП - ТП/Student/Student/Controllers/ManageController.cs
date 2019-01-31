using Student.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.Controllers
{
    public class ManageController : Controller
    {
        UserContext userContext = new UserContext();
        LectureContext lectureContext = new LectureContext();
        TestContext testContext = new TestContext();
         // GET: Manage
        public ActionResult Index()
        {
            return View(userContext.GetUser(User.Identity.Name));
        }
        public ActionResult LectureList()
        {
            return View(lectureContext.Lecture);
        }


        public ActionResult CreateLecture()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateLecture(Lecture lecture)
        {
            lecture.date = DateTime.Now;
            lectureContext.Lecture.Add(lecture);
            lectureContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLecture(int id) 
        {
            Lecture lecture = lectureContext.Lecture.Find(id);
            return View("DeleteLecture", lecture);
        }

        [HttpPost]
        public ActionResult DeleteLecture(int id, FormCollection collection)
        {
            Lecture lecture = lectureContext.Lecture.Find(id);
            lectureContext.Lecture.Remove(lecture);
            lectureContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditLecture(int id)
        {
            Lecture lecture = lectureContext.Lecture.Find(id);
            return View("EditLecture", lecture);
        }

        [HttpPost]
        public ActionResult EditLecture(Lecture lecture)
        {
            lecture.date = DateTime.Now;
            lectureContext.Entry(lecture).State = EntityState.Modified;
            lectureContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TestList()
        {
            return View(testContext.Test);
        }

        public ActionResult CreateTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            testContext.Test.Add(test);
            testContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GoTest(int id)
        {
            Test test = testContext.Test.Find(id);
            return View(test);
        }

        [HttpPost]
        public ActionResult GoTest(Test test, string names)
        {
            if (test.response == names)
            {
                int userId = userContext.GetUser(User.Identity.Name).Id;
                Mark mark = new Mark();
                mark.mark = 5;
                mark.Testid = test.id;
                mark.Userid = userId;
                testContext.Mark.Add(mark);
                testContext.SaveChanges();
            }
            else
            {
                int userId = userContext.GetUser(User.Identity.Name).Id;
                Mark mark = new Mark();
                mark.mark = 2;
                mark.Testid = test.id;
                mark.Userid = userId;
                testContext.Mark.Add(mark);
                testContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult MarkList()
        {
            return View(testContext.Mark.Include(e => e.user));
        }

        public ActionResult DeleteTest(int id)
        {
            Test test = testContext.Test.Find(id);
            return View("DeleteTest", test);
        }

        [HttpPost]
        public ActionResult DeleteTest(int id, FormCollection collection)
        {
            Test test = testContext.Test.Find(id);
            testContext.Test.Remove(test);
            testContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UserList()
        {
            return View(userContext.User);
        }

        public ActionResult DeleteUser(int id)
        {
            User user = userContext.User.Find(id);
            return View("DeleteUser", user);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            User user = userContext.User.Find(id);
            foreach (Mark m in testContext.Mark)
            {
                if (id == m.Userid)
                    testContext.Mark.Remove(m);
            }
            testContext.SaveChanges();
            userContext.User.Remove(user);
            userContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}