using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YAWYE.Core;
using YAWYE.Data;

namespace YAWYE.Pages
{
    [Authorize]
    public class TodayModel : PageModel
    {
        private readonly IDayData dayData;

        public IEnumerable<Meal> Meals { get; set; }
        public Meal Meal { get; set; }
        public Day Day { get; set; }
        public TodayModel(IDayData dayData)
        {
            this.dayData = dayData;
        }

        public void OnGet(int? dayId)
        {
            if(!dayId.HasValue)
            {
                Day = new Day();
                Day.Date = DateTime.Now;
                Day.OwnerName = User.Identity.Name;
            }
            else
            {
                Day = dayData.GetById(dayId.Value);
            }
        }
    }
}
