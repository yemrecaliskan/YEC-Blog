﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Controllers
{
    public class DefaultController : Controller
    {
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
