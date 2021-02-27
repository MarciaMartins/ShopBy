using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(60, ErrorMessage = "Este campo dever ter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo dever ter entre 3 e 60 caracteres.")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo dever conter no máximo 1024 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage ="O preço deve ser maior que zero.")]//999999
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
