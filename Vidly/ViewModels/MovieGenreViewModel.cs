﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieGenreViewModel
    {
        public List<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}