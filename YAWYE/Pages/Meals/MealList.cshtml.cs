using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;

namespace YAWYE.Pages.Meals
{
    public class MealListModel : PageModel
    {
        public string SearchTerm { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public void OnGet()
        {
        }
    }
}
