using SQLite;
using ViajeiD_.Model;



namespace ViajeiD_.Data
{



    public class SQLiteData1
    {



        readonly SQLiteAsyncConnection _conexaoBD;

        public UsuarioData UsuarioDataTable { get; set; }
        public DestinoData DestinoDataTable { get; set; }
        public PostagemData PostagemDataTable { get; set; }





        public SQLiteData1(string path)
        {
            _conexaoBD = new SQLiteAsyncConnection(path);


            _conexaoBD.CreateTableAsync<Usuario>()
                .Wait();
            _conexaoBD.CreateTableAsync<PostagemDestino>()
                .Wait();
            _conexaoBD.CreateTableAsync<PostagemPub>()
               .Wait();

            PostagemDataTable = new PostagemData(_conexaoBD);
            DestinoDataTable = new DestinoData(_conexaoBD);
            UsuarioDataTable = new UsuarioData(_conexaoBD);



        }
    }
}
