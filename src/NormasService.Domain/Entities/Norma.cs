using NormasService.Domain.Core.Entities;
using System;

namespace NormasService.Domain.Entities
{
    public class Norma : Entity, IAggregateRoot
    {
        public string Codigo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Titulo { get; set; }
        public string Comite { get; set; }
        public string Status { get; set; }
        public string Idioma { get; set; }
        public string Organismo { get; set; }
        public string Objetivo { get; set; }
    }
}
