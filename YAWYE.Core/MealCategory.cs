using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public enum MealCategory
    {
        [Description("groceries.png")]
        Groceries,
        [Description("breakfast.png")]
        Breakfast,
        [Description("lunch.png")]
        Lunch,
        [Description("dinner.png")]
        Dinner,
        [Description("supper.png")]
        Supper,
        [Description("snacks.png")]
        Snacks

    }
}
