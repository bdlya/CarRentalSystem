using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Policies;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Authorize(Policy = Policy.Customer)]
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        
    }
}
