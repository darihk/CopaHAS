using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SelecoesController : ControllerBase
    {
        private readonly DataContext _context; //using CopaHas.Data

        public SelecoesController(DataContext context)
        {
            _context = context;
        }

    }
}