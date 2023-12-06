using ViajeiD_.Model;
namespace ViajeiD_.View;


public partial class NovaPostagemForm : ContentPage
{
    PostagemPub _postagem;

    public NovaPostagemForm()
    {
        InitializeComponent();
        _postagem = new PostagemPub();
        this.BindingContext = _postagem;

    }
    private FeedView feedView;
    private IFileSaver fileSaver;
    private byte[] fotoBytes;

    // Adicione as propriedades para acesso aos elementos do XAML
    private Entry entryTitulo => this.FindByName<Entry>("txtTitulo");
    private Entry entryDescricao => this.FindByName<Entry>("txtDescricao");
    private ImageButton photoButtonControl => this.FindByName<ImageButton>("photoButton");

    private async void OnSavePhotoClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Selecione uma imagem"
            });

            if (result != null)
            {
                using (var stream = await result.OpenReadAsync())
                {
                    using (var ms = new MemoryStream())
                    {
                        await stream.CopyToAsync(ms);
                        fotoBytes = ms.ToArray();
                    }
                }

                // Exiba a imagem, substitua 'imageView' pelo seu controle de imagem
                photoButtonControl.Source = ImageSource.FromStream(() => new MemoryStream(fotoBytes));

            }
        }
        catch (Exception ex)
        {
            // Adicione informações de log ou mensagens de erro
            Console.WriteLine($"Erro ao selecionar imagem: {ex.Message}");
            await DisplayAlert("Erro", "Ocorreu um erro ao selecionar a imagem. Por favor, tente novamente.", "OK");
        }
    }

    public async Task<string> SalvarImagem()
    {
        try
        {
            if (fotoBytes != null && fotoBytes.Length > 0 && fileSaver != null)
            {
                // Gere um nome único para a imagem (opcional)
                string imageName = Guid.NewGuid().ToString() + ".jpg";

                // Salve a imagem no armazenamento local usando IFileSaver
                await fileSaver.SaveFileAsync(imageName, fotoBytes);

                // Retorne o caminho completo da imagem
                return fileSaver.GetFilePath(imageName);
            }

            return null;
        }
        catch (Exception ex)
        {
            // Adicione informações de log ou mensagens de erro
            Console.WriteLine($"Erro ao salvar imagem: {ex.Message}");
            return null;
        }
    }

    // Adicione uma propriedade para acessar a postagem
    private PostagemPub GetPostagem()
    {
        return new PostagemPub
        {
            Titulo = entryTitulo.Text,
            Descricao = entryDescricao.Text,
            Data = DateTime.Now
            // Não use await aqui, pois _postagem não pode ser um método assíncrono
        };
    }



    public interface IFileSaver
    {
        Task SaveFileAsync(string fileName, byte[] fileData);
        string GetFilePath(string fileName);
    }

    private async void btnPostarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_postagem.Titulo) ||
        string.IsNullOrEmpty(_postagem.Descricao) ||
        _postagem.Data == DateTime.MinValue)
        {
            await DisplayAlert("Atenção!", "Preencha todas as informações", "Fechar");
            return;
        }

        var cadastro = await App.BancoDados.PostagemDataTable.SalvaPostagem(_postagem);

        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Postagem feita com sucesso!", "Fechar");
            if (Navigation.NavigationStack.LastOrDefault() is FeedView feedView)
            {
                feedView.LoadPostagens(); // Chama o método para carregar novamente as postagens no feed
            }
            await Navigation.PopAsync();
        }


    }
}
