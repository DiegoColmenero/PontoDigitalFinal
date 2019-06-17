using System;

namespace PontoDigital.Models
{
    public class ComentarioModel
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public DateTime Data {get;set;}
        public string Texto {get;set;}
        public bool Aprovado {get;set;}

    }
}