using SQLite;
using ViajeiD_.Model;

namespace ViajeiD_.Data
{
    public class PostagemData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public PostagemData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD ?? throw new ArgumentNullException(nameof(conexaoBD));
        }

        public async Task<List<PostagemPub>> ListaPostagem()
        {
            return await _conexaoBD.Table<PostagemPub>().ToListAsync();
        }

        public async Task<int> SalvaPostagem(PostagemPub postagem)
        {
            return await _conexaoBD.InsertAsync(postagem);
        }

        public async Task<PostagemPub> ObtemPostagemPorId(Guid id)
        {
            return await _conexaoBD.Table<PostagemPub>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> ExcluirPostagem(Guid id)
        {
            return await _conexaoBD.DeleteAsync<PostagemPub>(id);
        }
    }
}
