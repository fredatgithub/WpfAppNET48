using System;
using System.Windows;
using System.Threading.Tasks;

namespace WpfAppNET48
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Créer et afficher le splash screen
            var splashScreen = new SplashScreen();
            splashScreen.Show();

            // Démarrer le chargement de l'application en arrière-plan
            Task.Factory.StartNew(() =>
            {
                // Simuler un chargement
                splashScreen.Dispatcher.Invoke(() => 
                    splashScreen.UpdateStatus("Chargement des modules..."));
                System.Threading.Thread.Sleep(1000);

                splashScreen.Dispatcher.Invoke(() => 
                    splashScreen.UpdateStatus("Préparation de l'interface..."));
                System.Threading.Thread.Sleep(1000);

                // Une fois le chargement terminé, ouvrir la fenêtre principale
                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    
                    // Fermer le splash screen
                    splashScreen.Close();
                });
            });

            base.OnStartup(e);
        }
    }
}
