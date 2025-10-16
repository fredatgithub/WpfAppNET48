using System.Windows;

namespace WpfAppNET48
{
  public partial class SplashScreen: Window
  {
    public SplashScreen()
    {
      InitializeComponent();
    }

    public void UpdateStatus(string status)
    {
      Dispatcher.Invoke(() =>
      {
        StatusText.Text = status;
      });
    }
  }
}
