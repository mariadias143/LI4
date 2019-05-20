using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LI4.Models;

namespace LI4.Views.Shared
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserHandling
    {
        private readonly UserContext _context;

        public UserHandling(UserContext context)
        {
            _context = context;
        }

        public Utilizador[] getUsers()
        {
            return null;
        }

    }
}