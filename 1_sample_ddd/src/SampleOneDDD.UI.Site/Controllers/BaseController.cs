using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleOneDDD.Domain.Core.Notifications;

namespace SampleOneDDD.UI.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        public List<DomainNotification> GetNotifications()
        {
            var nf = _notifications.GetNotifications();
            return nf;
        }
    }
}