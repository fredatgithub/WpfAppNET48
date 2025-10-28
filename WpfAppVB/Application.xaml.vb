Imports System.Threading

Namespace WpfAppVB
  ''' <summary>
  ''' Logique d'interaction pour Application.xaml
  ''' </summary>
  Partial Public Class Application
    Inherits System.Windows.Application

    Protected Overrides Sub OnStartup(e As StartupEventArgs)
      MyBase.OnStartup(e)

      ' Créer et afficher le splash screen
      Dim splashScreen = New SplashScreen()
      Me.MainWindow = splashScreen
      splashScreen.Show()

      ' Démarrer le chargement de l'application en arrière-plan
      Dim task = Tasks.Task.Factory.StartNew(Sub()
                                               ' Simuler un chargement
                                               UpdateSplashScreen(splashScreen, "Vérification de la connexion à la base de données...")
                                               Thread.Sleep(1000)

                                               UpdateSplashScreen(splashScreen, "Préparation de l'interface...")
                                               Thread.Sleep(1000)

                                               ' Une fois le chargement terminé, ouvrir la fenêtre principale
                                               Dispatcher.Invoke(Sub()
                                                                   ' Créer et afficher la fenêtre principale
                                                                   Dim mainWindow = New MainWindow()
                                                                   Me.MainWindow = mainWindow

                                                                   ' Fermer le splash screen et afficher la fenêtre principale
                                                                   splashScreen.Close()
                                                                   mainWindow.Show()
                                                                 End Sub)
                                             End Sub)
    End Sub

    Private Sub UpdateSplashScreen(splashScreen As SplashScreen, status As String)
      If Not splashScreen.Dispatcher.CheckAccess() Then
        splashScreen.Dispatcher.Invoke(Sub() UpdateSplashScreen(splashScreen, status))
        Return
      End If
      splashScreen.UpdateStatus(status)
    End Sub
  End Class
End Namespace
