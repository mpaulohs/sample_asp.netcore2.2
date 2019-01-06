using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleOneDDD.Application.Interfaces;
using SampleOneDDD.Application.ViewModels;
using SampleOneDDD.Domain.Core.Notifications;

namespace SampleOneDDD.UI.Site.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogAppService _blogAppService;

        public BlogController(IBlogAppService blogAppService,
                              INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _blogAppService = blogAppService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _blogAppService.GetAllAsync();
            return View(model);
        }

        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogViewModel m)
        {
            var nf = GetNotifications();
            if (IsValidOperation()) return View();

            _blogAppService.Register(m);
            return RedirectToAction("Index", "Blog");
        }
    }
}