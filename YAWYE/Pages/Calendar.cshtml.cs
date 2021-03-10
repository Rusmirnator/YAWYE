using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;

namespace YAWYE.Pages
{
    [Authorize]
    public class CalendarModel : PageModel
    {
        public Day Today { get; set; }
        public void OnGet()
        {
        }
    }
}
