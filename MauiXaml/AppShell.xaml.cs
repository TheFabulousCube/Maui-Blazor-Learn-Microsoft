using MauiXaml.Views;

namespace MauiXaml;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("DetailPage", typeof(DetailPage));
    }
}
