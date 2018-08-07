using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Models
{
    public class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public int frequencia { get; set; }
    }
}