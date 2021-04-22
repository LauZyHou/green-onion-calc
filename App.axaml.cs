using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Goc._VM;
using Goc._V;

namespace Goc
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow_V
                {
                    DataContext = new MainWindow_VM(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
