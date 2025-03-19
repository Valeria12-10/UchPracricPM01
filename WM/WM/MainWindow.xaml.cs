using System;
using System.Linq;
using System.Windows;

namespace WM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Ru_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("ru-RU");
        }

        private void En_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void ChangeLanguage(string cultureCode)
        {
            // Загружаем соответствующий ResourceDictionary
            var uri = new Uri($"Resourses/{cultureCode}.xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            // Очищаем текущие ресурсы и добавляем новые
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (lg.Text == "" || pr.Password == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            using (var db = new СкладыEntities())
            {
                var user = db.Пользователи
                    .FirstOrDefault(u => u.Email== lg.Text && u.ХэшПароля == pr.Password);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.");
                    return;
                }
                var secretWindow = new _2FactorWindow(user, this);
                secretWindow.Show();
                this.Hide();
            }
        }
    }
}