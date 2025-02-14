﻿using System.ComponentModel.DataAnnotations;

namespace EokulMvc.Models
{
    public class loginUserDto
    {
        [Required(ErrorMessage = "kullancıı adı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "sifre  giriniz")]
        public string Password { get; set; }
    }
}
