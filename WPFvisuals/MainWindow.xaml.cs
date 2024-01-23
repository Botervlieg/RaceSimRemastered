using Controller;
using System.Windows;
using System.Windows.Threading;


namespace WPFvisuals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Window StatsWindow;

        public MainWindow()
        {
            Data.initialize();
            Data.NextRace();
            InitializeComponent();

            this.Dispatcher.BeginInvoke(
            DispatcherPriority.Render,
            new Action(() =>
            {
                StatsWindow = new StatsWindow();
            }));

        }

        private void MenuItem_OpenStats_Click(object sender, RoutedEventArgs e)
        {
            StatsWindow.Show();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}