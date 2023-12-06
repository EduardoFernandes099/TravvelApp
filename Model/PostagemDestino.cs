using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLenghtAttribute =
    System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace ViajeiD_.Model
{
    [Table("PostagemData")]
    public class PostagemDestino
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Destino { get; set; }

        public string Descricao { get; set; }

        [Range(0.1, double.MaxValue)]
        public string Gasto { get; set; }

        public DateTime Data { get; set; } 

        public PostagemDestino()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }

        
    }
}