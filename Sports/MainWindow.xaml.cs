using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        SportsContext db;

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Workout> Workout { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            db = new SportsContext();
            Workout = db.Workouts.ToList();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var work = MessageBox.Show("ДАША УЧИ ПРОГРАММИРОВАНИЕ СПАСИБО!!!!!!!!! ОТ ЯРИКА!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", "Подтверждение", MessageBoxButton.YesNo);

            if (work == MessageBoxResult.Yes)
            {
                WorkoutDob window = new WorkoutDob();
                Hide();
                window.ShowDialog();
                Show();

            }
            else if (work == MessageBoxResult.No) 
            {
                Registration window = new Registration();
                Hide();
                window.ShowDialog();
                Show();
            }
            
        }

        private void Filtrrr(object sender, RoutedEventArgs e)
        {
            Filtr window = new Filtr();
            Hide();
            window.ShowDialog();
            Show();
        }

        private void AthletDob(object sender, RoutedEventArgs e)
        {
            AthletDob window = new AthletDob();
            Hide();
            window.ShowDialog();
            Show();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            Registration window = new Registration();
            Hide();
            window.ShowDialog();
            Show();
        }

        private void WorkoutDob(object sender, RoutedEventArgs e)
        {
            WorkoutDob window = new WorkoutDob();
            Hide();
            window.ShowDialog();
            Show();
        }
    }
}