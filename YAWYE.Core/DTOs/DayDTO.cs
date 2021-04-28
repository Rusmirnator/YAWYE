using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core.DTOs
{
    public class DayDTO
    {
        public int DayId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string OwnerName { get; set; }

    }
}
