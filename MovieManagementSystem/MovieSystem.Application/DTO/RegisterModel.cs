using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieSystem.Application.DTO
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }
    }
}
