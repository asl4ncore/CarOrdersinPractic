using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Models
{
    interface IUserService
    {
        Task<OperationDetails> Create(User userDto);
        ClaimsIdentity Authenticate(User userDto);
        Task SetInitialData(User adminDto, List<string> roles);
    }
}
