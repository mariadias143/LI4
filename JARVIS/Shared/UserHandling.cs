using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using static JARVIS.Models.Utilizador;

namespace JARVIS.Shared
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

        internal bool RegisterUser(Utilizador user)
        {
            throw new NotImplementedException();
        }
    }
}