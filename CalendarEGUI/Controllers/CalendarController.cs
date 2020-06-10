using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calendar.Models;
using Newtonsoft.Json;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;

        public CalendarController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? year, int? month)
        {
            string json = System.IO.File.ReadAllText(@"events.json");
            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);

            if (!year.HasValue || !month.HasValue)
            {
                year = DateTime.Today.Year;
                month = DateTime.Today.Month;
            }
            DateTime Today = new DateTime(year.Value, month.Value, 1);
            ViewData["Date"] = Today;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Day(int year, int month, int day)
        {
            string json = System.IO.File.ReadAllText(@"events.json");
            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);

            DateTime thisDate = new DateTime(year, month, day);
            Event basicEvent = new Event()
            {
                eventDescription = "Type your description here...",
                eventDate = thisDate,
                eventTime1 = "12:30",
                eventTime2 = "12:30"
            };

            ViewData["Event"] = basicEvent;

            ViewData["Year"] = year;
            ViewData["Month"] = month;
            ViewData["Day"] = day;
            return View();
        }

        public IActionResult Event(int year, int month, int day)
        {
            DateTime thisDate = new DateTime(year, month, day);
            Event basicEvent = new Event()
            {
                eventDescription = "Type your description here...",
                eventDate = thisDate,
                eventTime1 = "12:30",
                eventTime2 = "12:30"
            };

            ViewData["Event"] = basicEvent;

            ViewData["Year"] = year;
            ViewData["Month"] = month;
            ViewData["Day"] = day;
            return View();
        }

        public IActionResult saveEvent(int year, int month, int day, string time1, string time2, string description)
        {
            DateTime newDate = new DateTime(year, month, day);
            Event newEvent = new Event()
            {
                eventDescription = description,
                eventDate = newDate,
                eventTime1 = time1,
                eventTime2 = time2
            };


            //saving to json
            string json = System.IO.File.ReadAllText(@"events.json");
            List<Event> list = JsonConvert.DeserializeObject<List<Event>>(json);

            if (list == null)
            {
                list = new List<Event>();
            }

            list.Add(newEvent);

            string result = JsonConvert.SerializeObject(list);
            System.IO.File.WriteAllText(@"events.json", result);

            ViewData["Year"] = year;
            ViewData["Month"] = month;
            ViewData["Day"] = day;

            json = System.IO.File.ReadAllText(@"events.json");
            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);
            return View("Day");
        }

        public IActionResult deleteEvent(int year, int month, int day, string description, string time1, string time2)
        {
            DateTime date = new DateTime(year, month, day);//????????????????????????
            string json = System.IO.File.ReadAllText(@"events.json");
            List<Event> list = JsonConvert.DeserializeObject<List<Event>>(json);
            foreach (Event element in list)
            {
                if (element.eventDate == date
                    && element.eventTime1 == time1 && element.eventTime2 == time2
                    && element.eventDescription == description)
                {
                    list.Remove(element);

                    string listResult = JsonConvert.SerializeObject(list);
                    System.IO.File.WriteAllText(@"events.json", listResult);
                    json = System.IO.File.ReadAllText(@"events.json");
                    ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);
                    ViewData["Year"] = date.Year;
                    ViewData["Month"] = date.Month;
                    ViewData["Day"] = date.Day;
                    return View("Day");
                }
            }
            string result = JsonConvert.SerializeObject(list);
            System.IO.File.WriteAllText(@"events.json", result);
            json = System.IO.File.ReadAllText(@"events.json");
            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);

            ViewData["Year"] = date.Year;
            ViewData["Month"] = date.Month;
            ViewData["Day"] = date.Day;
            return View("Day");
        }

        public IActionResult EditEvent(int year, int month, int day, string description, string time1, string time2)
        {
            DateTime date = new DateTime(year, month, day);//????????????????????????
            Event newEvent = new Event()
            {
                eventDescription = description,
                eventDate = date,
                eventTime1 = time1,
                eventTime2 = time2
            };
            ViewData["Event"] = newEvent;
            string json = System.IO.File.ReadAllText(@"events.json");

            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);

            ViewData["Year"] = date.Year;
            ViewData["Month"] = date.Month;
            ViewData["Day"] = date.Day;
            return View();
        }
        public IActionResult DeleteEditEvent(int year, int month, int day, string description, string time1, string time2, string oldDescription, string oldTime1, string oldTime2)
        {
            DateTime date = new DateTime(year, month, day);//????????????????????????
            Event newEvent = new Event()
            {
                eventDescription = description,
                eventDate = date,
                eventTime1 = time1,
                eventTime2 = time2
            };
            ViewData["Event"] = newEvent;
            string json = System.IO.File.ReadAllText(@"events.json");
            List<Event> list = JsonConvert.DeserializeObject<List<Event>>(json);
            list.Add(newEvent);
            foreach (Event element in list)
            {
                if (element.eventTime1 == oldTime1 && element.eventTime2 == oldTime2
                    && element.eventDescription == oldDescription)
                {
                    list.Remove(element);

                    string listResult = JsonConvert.SerializeObject(list);
                    System.IO.File.WriteAllText(@"events.json", listResult);
                    json = System.IO.File.ReadAllText(@"events.json");
                    ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);
                    ViewData["Year"] = date.Year;
                    ViewData["Month"] = date.Month;
                    ViewData["Day"] = date.Day;
                    return View("Day");
                }
            }
            //saving to json
            json = System.IO.File.ReadAllText(@"events.json");
            list = JsonConvert.DeserializeObject<List<Event>>(json);

            if (list == null)
            {
                list = new List<Event>();
            }

            list.Add(newEvent);

            string result = JsonConvert.SerializeObject(list);
            System.IO.File.WriteAllText(@"events.json", result);

            ViewData["Year"] = year;
            ViewData["Month"] = month;
            ViewData["Day"] = day;

            json = System.IO.File.ReadAllText(@"events.json");
            ViewData["Events"] = JsonConvert.DeserializeObject<List<Event>>(json);
            return View("Day");
        }



    }
}
