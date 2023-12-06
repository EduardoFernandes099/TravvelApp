namespace ViajeiD_.View;

public partial class ViagensView : ContentPage
{
	public ViagensView()
	{
		InitializeComponent();
	}

    private void AddDestinyClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NovoDestinoForm());
    }
}