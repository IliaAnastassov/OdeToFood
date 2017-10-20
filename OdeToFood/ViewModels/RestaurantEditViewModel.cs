﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the restaurant")]
        [MaxLength(80)]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
