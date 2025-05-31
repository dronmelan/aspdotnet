using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservation.Client.Client.shared.Models;
using Reservation.Client.Shared.Models;

namespace Reservation.Client.Shared.Services
{
    public interface IAuthService
    {
        Task<JwtTokenResponse> Login(LoginDto loginDto);

        Task Logout();
        Task Register(RegisterDto registerDto);
    }
}

