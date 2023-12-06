using SQLite;
using ViajeiD_.Model;
using ViajeiD_.View;

namespace ViajeiD_.Data
{
    public class DestinoData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public DestinoData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        public Task<List<PostagemDestino>> ListaDestinos()
        {
            var lista = _conexaoBD
                .Table<PostagemDestino>()
                .ToListAsync();
            return lista;

        }


        public async Task<int> SalvaPostagem(PostagemDestino postagem)
        {
            var postagemIsSalvo = await ObtemDestino(postagem.Destino);

            //Checagem de usuário

            if (postagemIsSalvo == null)
            {
                return await _conexaoBD.InsertAsync(postagem);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(postagem);
            }



        }



        public Task<PostagemDestino> ObtemUsuarioId(Guid Id)
        {
            var usuario = _conexaoBD
                .Table<PostagemDestino>()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
            return usuario;


        }



        public async Task<int> ExcluirUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }

        public Task<PostagemDestino> ObtemDestino(string destino)
        {
            var postagem = _conexaoBD.Table<PostagemDestino>().Where(x => x.Destino == destino).FirstOrDefaultAsync();
            return postagem;
        }

        internal Task<int> SalvaPostagem(NovaPostagemForm npostagem)
        {
            throw new NotImplementedException();
        }

        internal Task ObtemDestino(object destino)
        {
            throw new NotImplementedException();
        }
    }
}
