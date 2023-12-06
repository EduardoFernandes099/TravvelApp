using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class NovoDestinoForm : ContentPage
{
	PostagemDestino _postagem;
	public NovoDestinoForm()
	{
		InitializeComponent();
		_postagem = new PostagemDestino();
		this.BindingContext = _postagem;
	}

    private async void btnPostarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_postagem.Titulo) ||
        string.IsNullOrEmpty(_postagem.Destino) ||
        string.IsNullOrEmpty(_postagem.Descricao) ||
        string.IsNullOrEmpty(_postagem.Gasto) ||
        _postagem.Data == DateTime.MinValue)
        {
            await DisplayAlert("Aten��o!", "Preencha todas as informa��es", "Fechar");
            return;
        }


        var destinoExistente = await App.BancoDados.DestinoDataTable.ObtemDestino(_postagem.Destino);

        if (destinoExistente != null)
        {
            await DisplayAlert("Aten��o!", "Este destino j� est� cadastrado", "Fechar");
            return;
        }

        var cadastro = await App.BancoDados.DestinoDataTable.SalvaPostagem(_postagem);

        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
            await Navigation.PopAsync();
        }
    }
}