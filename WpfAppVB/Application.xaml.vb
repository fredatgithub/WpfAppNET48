Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Threading

Namespace WpfAppVB
  ''' <summary>
  ''' Logique d'interaction pour Application.xaml
  ''' </summary>
  Partial Public Class Application
    Inherits System.Windows.Application
    
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs)
      ' Appeler OnStartup pour assurer la compatibilité avec le code existant
      OnStartup(e)
    End Sub

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
      ' Créer et afficher le splash screen
      Dim splashScreen = New SplashScreen()
      splashScreen.Show()

      ' Démarrer le chargement de l'application en arrière-plan
      Task.Factory.StartNew(Sub()
                              ' Simuler un chargement
                              splashScreen.Dispatcher.Invoke(Sub()
                                                               splashScreen.UpdateStatus("Vérification de la connexion à la base de données...")
                                                             End Sub)
                              Thread.Sleep(3000)

                              splashScreen.Dispatcher.Invoke(Sub()
                                                               splashScreen.UpdateStatus("Préparation de l'interface...")
                                                             End Sub)
                              Thread.Sleep(3000)

                              ' Une fois le chargement terminé, ouvrir la fenêtre principale
                              Dispatcher.Invoke(Sub()
                                                  Dim mainWindow = New MainWindow()
                                                  mainWindow.Show()

                                                  ' Fermer le splash screen
                                                  splashScreen.Close()
                                                End Sub)
                            End Sub)

      MyBase.OnStartup(e)
    End Sub
  End Class
End Namespace
