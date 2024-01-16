using Ordering.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Contrats.Infrastructure
{
    internal interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
