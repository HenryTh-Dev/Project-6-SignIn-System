using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IUserServices
    {
        bool AlreadyRegistredEmail(string email);
    }
}
