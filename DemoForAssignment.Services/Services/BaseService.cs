using AutoMapper;
using DemoForAssignment.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForAssignment.Services.Services
{
    public class BaseService
    {
        protected AppDbContext _context { get; set; }
        protected IMapper _mapper { get; set; }

        protected BaseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
