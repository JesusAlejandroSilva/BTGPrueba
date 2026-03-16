using BTGFunds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTGFunds.Application.Interfaces
{
    public interface INotificationService
    {
        Task Notify(User user, string message);
    }
}
