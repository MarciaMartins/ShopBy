using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo dever ter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo dever ter entre 3 e 60 caracteres.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo dever ter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo dever ter entre 3 e 60 caracteres.")]
        public int Password { get; set; }

        public string Role { get; set; }
    }
}
