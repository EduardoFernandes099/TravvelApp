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
    [Table("PostagemData2")]
    public class PostagemPub
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemPath { get; set; }

        [Range(0.1, double.MaxValue)]
        

        public DateTime Data { get; set; }

        public PostagemPub()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }


    }
}