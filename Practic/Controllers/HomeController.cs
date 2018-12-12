using AutoMapper;
using Practic.Infrastructure.Data;
using Practic.Models;
using Practic.ViewModel;
using Practic.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practic.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unit;
        public HomeController()
        {
            unit = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var routeType = unit.RouteTypeRepo.Get();
            return View(routeType);
        }
        public ActionResult Get()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<RouteTypeViewModels, RouteType>().ReverseMap());


            var routeType =
                Mapper.Map<IQueryable<RouteType>, List<RouteTypeViewModels>>(unit.RouteTypeRepo.Get());
            return View(routeType);
        }
    }
}
