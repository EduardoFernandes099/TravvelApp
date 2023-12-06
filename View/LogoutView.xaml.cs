using ViajeiD_.ViewModel;

namespace ViajeiD_.View;

public partial class ExibirUsuarioView : ContentPage
{
	public ExibirUsuarioView()
	{
		InitializeComponent();
        this.BindingContext = new ExibirUsuarioViewModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUsuarioView());
    }

    
}