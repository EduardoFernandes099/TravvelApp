using System;
using System.Threading.Tasks;
using ViajeiD_.ViewModel;

namespace ViajeiD_.View
{
    public partial class FeedView : ContentPage
    {
        private FeedViewModel viewModel;

        public FeedView()
        {
            InitializeComponent();

            // Inicialize o contexto de dados (ViewModel)
            viewModel = new FeedViewModel();
            this.BindingContext = viewModel;

            // Chame o m�todo para carregar postagens
            LoadPostagens();
        }

        // M�todo para carregar postagens no feed
        internal async void LoadPostagens()
        {
            try
            {
                // Carregue as postagens do banco de dados (ou de onde quer que venham)
                var postagens = await App.BancoDados.PostagemDataTable.ListaPostagem();

                // Atualize o ViewModel com as postagens obtidas
                viewModel.SetPostagens(postagens);

                // Indique que houve uma mudan�a na lista de postagens
                viewModel.NotifyPostagensChanged();
            }
            catch (Exception ex)
            {
                // Lidere com exce��es (por exemplo, log de erros ou exibi��o de mensagem ao usu�rio)
                Console.WriteLine($"Erro ao carregar postagens: {ex.Message}");
            }
        }

        private void OnNovaPostagemClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaPostagemForm());
        }
    }
}
