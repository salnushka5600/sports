using System;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        SportsContext db;
        private Progress insertProgress = new Progress();
        private List<Progress> progress;

        public event PropertyChangedEventHandler? PropertyChanged;

        void Signal([CallerMemberName] string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public List<Progress> Progresses
        {
            get => progress;
            set
            {
                progress = value;
                Signal();
            }
        }
        public Progress InsertProgress
        {
            get => insertProgress;
            set
            {
                insertProgress = value;
                Signal();
            }
        }
        public List<Athlet> Athlets { get; set; }
        public List<Workout> Workouts { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            db = new SportsContext();
            Athlets = db.Athlets.ToList();
            Workouts = db.Workouts.ToList();
            //db.Suppliers.ToList(); // поставщики сохранятся в dbcontext
            SelectProgresses();
            DataContext = this;
        }

        private void UpdateProgress(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
        private void InsertProgressMethod(object sender, RoutedEventArgs e)
        {
            db = new SportsContext();
            // костыль для исключения добавления уже существующих объектов
            // в связанные таблицы
            //InsertProgress.IdAthlet = InsertProgress.IdAthlet.Id;
            //InsertProgress.Athlet = null;
            //InsertProgress.IdWorkout = InsertProgress.Workout.Id;
            //InsertProgress.Workout = null;
            // чаще должен быть вариант, что DbContext уже содержит существующие данные
            // метод Add добавляет всю иерархию объекта в отслеживание
            db.Progresses.Add(InsertProgress);
            db.SaveChanges();
            InsertProgress = new Progress();
            SelectProgresses();
        }

        private void SelectProgresses()
        {
            //var query = db.Progresses
                        //.Include(s => s.Athlet)
                        //.Include(s => s.Workut)
                        //.Where(s => s.Count == 1) // условие
                        //.Skip(1)   // пропуск кол-ва записей
                        //.Take(1);   // ограничение кол-ва записей

            //Progresses = query.ToList();
        }

        private void RemoveProgress(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно????", "Заголовок", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
            {
                var progress = (sender as Button).CommandParameter as Progress;

                db.Progresses.Remove(progress);
                db.SaveChanges();

                SelectProgresses();
            }
        }
    }
}