Namespace WpfAppVB
  Partial Public Class SplashScreen
    Inherits Window

    Public Sub New()
      InitializeComponent()
    End Sub

    Public Sub UpdateStatus(status As String)
      Dispatcher.Invoke(Sub()
                          StatusText.Text = status
                        End Sub)
    End Sub
  End Class
End Namespace
