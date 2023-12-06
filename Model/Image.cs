using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.Model
{
    public class Image
    {
        [PrimaryKey] 
        public string Imagem { get; set; }
    }
}
