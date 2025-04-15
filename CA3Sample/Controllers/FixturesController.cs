using CA3Sample.Models;
using CA3Sample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CA3Sample.Controllers
{
    public class FixturesController : Controller
    {
        public IActionResult Index()
        {
            var fixtures = FixtureService.GetAll();
            return View(fixtures);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                fixture.DateTime = DateTime.Now;
                FixtureService.Add(fixture);
                return RedirectToAction("Index");
            }

            return View(fixture);
        }

        public IActionResult Edit(int id)
        {
            var fixture = FixtureService.GetById(id);
            if (fixture == null)
                return NotFound();

            return View(fixture);
        }

        [HttpPost]
        public IActionResult Edit(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                FixtureService.Update(fixture);
                return RedirectToAction("Index");
            }

            return View(fixture);
        }

        public IActionResult Stats()
        {
            var fixtures = FixtureService.GetAll().Where(f => f.GoalsFor.HasValue && f.GoalsAgainst.HasValue);
            var now = DateTime.Now;

            var played = fixtures.Count(f => f.DateTime <= now);
            var won = fixtures.Count(f => f.GoalsFor > f.GoalsAgainst);
            var drawn = fixtures.Count(f => f.GoalsFor == f.GoalsAgainst);
            var lost = fixtures.Count(f => f.GoalsFor < f.GoalsAgainst);
            var goalDiff = fixtures.Sum(f => f.GoalsFor - f.GoalsAgainst);
            var points = fixtures.Sum(f =>
                f.GoalsFor > f.GoalsAgainst ? 3 :
                f.GoalsFor == f.GoalsAgainst ? 1 : 0);

            ViewBag.Played = played;
            ViewBag.Won = won;
            ViewBag.Drawn = drawn;
            ViewBag.Lost = lost;
            ViewBag.GoalDifference = goalDiff;
            ViewBag.Points = points;

            return View();
        }
    }

}
