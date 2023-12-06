using ViajeiD_.Data;
using ViajeiD_.Model;
using ViajeiD_.View;

namespace ViajeiD_
{


    public partial class App : Application
    {

        static SQLiteData1 _bancoDados;



        public static SQLiteData1 BancoDados
        {
            get
            {
                if (_bancoDados == null)
                {
                    _bancoDados =
                        new SQLiteData1(Path.Combine
                        (Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),
                        ("Dados.db3")));

                }
                return _bancoDados;
            }
        }

        public static Usuario Usuario { get; set; }
        public static PostagemDestino Postagem { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUsuarioView());

        }
    }
}