using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class Alunos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [MinLength(10,ErrorMessage = "O mínimo de caracteres para o nome é de 10")]
        [MaxLength(100,ErrorMessage = "O máximo de caracteres para o nome é de 100")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Matrícula não pode ser vazia")]
        [MinLength(10, ErrorMessage = "O número de caracteres necessários para a matrícula são de 10 dígitos")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Primeira nota não pode ser vazia")]
        [Range(0, 10, ErrorMessage = "Nota deve ser entre 0 a 10")]
        public double Nota1 { get; set; }
        [Required(ErrorMessage = "Segunda nota não pode ser vazia")]
        [Range(0,10,ErrorMessage="Nota deve ser entre 0 a 10")]
        public double Nota2 { get; set; }
        [Required(ErrorMessage = "Terceira nota não pode ser vazia")] 
        [Range(0,10,ErrorMessage="Nota deve ser entre 0 a 10")]
        public double Nota3 { get; set; }
        [Required(ErrorMessage = "Frequencia não pode ser vazia")]
        [Range(0, 100, ErrorMessage = "Frequencia deve ser entre 0% a 100%")]
        public int frequencia { get; set; }
        [Required(ErrorMessage = "Faltas não pode ser vazia")]
        [Range(0, 50, ErrorMessage = "Faltas devem estar entre 0 a 50 falta no ano letivo")]
        public int Faltas { get; set;  }
    }
}