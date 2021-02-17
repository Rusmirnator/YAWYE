using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YAWYE.Core
{
    public class User
    {
        public int UserId { get; set; }
        [Required, StringLength(30)]
        public string UserName { get; set; }
        [Required, StringLength(16)]
        public string Password { get; set; }
        [Required, StringLength(30)]
        public string Nickname { get; set; }

    }
}
