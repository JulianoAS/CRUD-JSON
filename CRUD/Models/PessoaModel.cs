using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exemplos.Models
{
    public class PessoaModel
    {
        'teste 2'

        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required]
        public string CPF { get; set; }
        
        [Required]
        public string RG { get; set; }

        [Required]
        public string Logradouro { get; set; }
        
        [Required]
        public string Cidade { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }
        
        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Celular { get; set; }

    }
}