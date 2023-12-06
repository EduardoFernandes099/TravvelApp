using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;
using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class EditaUsuarioView : ContentPage
{
	Usuario _usuario;

    

    public EditaUsuarioView()
	{
		InitializeComponent();
		_usuario = new Usuario();
		
		this.BindingContext = _usuario;
	}

    

    private async void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_usuario.Email) || string.IsNullOrWhiteSpace(_usuario.Senha) || string.IsNullOrWhiteSpace(_usuario.Nome) || string.IsNullOrWhiteSpace(_usuario.NomeUsuario))
        {
            await DisplayAlert("Aten��o!", "Preencha todas as informa��es", "Fechar");
            return;
        }

        if (!IsValidEmail(_usuario.Email))
        {
            await DisplayAlert("Aten��o!", "Digite um email v�lido", "Fechar");
            return;
        }

        if (_usuario.Senha.Length < 6)
        {
            await DisplayAlert("Aten��o!", "A senha deve ter pelo menos 6 caracteres", "Fechar");
            return;
        }

        var nomeUsuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemNomeUsuario(_usuario.NomeUsuario);

        if (nomeUsuarioExistente != null)
        {
            await DisplayAlert("Aten��o!", "Este nome de usuario j� est� cadastrado", "Fechar");
            return;
        }

        // Verificar se o e-mail j� est� cadastrado
        var usuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemUsuario(_usuario.Email, _usuario.Senha);

        if (usuarioExistente != null)
        {
            await DisplayAlert("Aten��o!", "Este e-mail j� est� cadastrado", "Fechar");
            return;
        }

        

        // Se o e-mail n�o existe, salvar o usu�rio
        var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);
        
        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
            await Navigation.PopAsync();
        }
    }

    private bool IsValidEmail(string email)
    {
        // Express�o regular para validar um endere�o de email simples.
        string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUsuarioView());
    }
}