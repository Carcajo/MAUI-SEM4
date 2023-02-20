namespace Calculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 360;
        const int newHeight = 600;

        window.Width = newWidth;
        window.Height = newHeight;

        window.MinimumHeight = newHeight;
        window.MinimumWidth = newWidth;

        return window;
    }
}
