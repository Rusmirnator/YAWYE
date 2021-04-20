using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages.Days
{
    [Authorize]
    public class DayListModel : PageModel
    {
        private readonly IDayData dayData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [ViewData]
        public IEnumerable<Day> Days { get; set; } = new List<Day>();
        public DayListModel(IDayData dayData)
        {
            this.dayData = dayData;
        }
        public void OnGet()
        {
            Days = dayData.GetAllByOwner(User.Identity.Name);
        }
    }
}
