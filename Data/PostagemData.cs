using SQLite;
using ViajeiD_.Model;
using ViajeiD_.View;

namespace ViajeiD_.Data
{
    public class PostagemData
    {

        private SQLiteAsyncConnection _conexaoBD;

        public PostagemData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }


        public Task<List<PostagemPub>> ListaPostagem()
        {
            var lista = _conexaoBD
                .Table<PostagemPub>()
                .ToListAsync();
            return lista;

        }

        public async Task<int> SalvaPostagem(PostagemPub postagem)
        {

            return await _conexaoBD.InsertAsync(postagem);

        }




        public Task<PostagemPub> ObtemUsuarioId(Guid Id)
        {
            var usuario = _conexaoBD
                .Table<PostagemPub>()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
            return usuario;


        }



        public async Task<int> ExcluirUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }

        internal Task<int> SalvaPostagem(NovaPostagemForm npostagem)
        {
            throw new NotImplementedException();
        }

        internal Task ObtemPub(object destino)
        {
            throw new NotImplementedException();
        }
    }
}
