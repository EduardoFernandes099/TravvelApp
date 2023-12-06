using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ViajeiD_.Data
{
   
    public class ImageData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public ImageData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
            
        }
        [PrimaryKey]
        public Guid Id { get; set; }    
        public byte[] DadosImagem { get; set; }


        public async Task<int> SalvarImagem()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
                return await _conexaoBD.InsertAsync(this);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(this);
            }
        
            
        }

    }

    
}
