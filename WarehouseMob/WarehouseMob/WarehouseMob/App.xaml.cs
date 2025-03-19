using System;
using WarehouseMob.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarehouseMob
{
    public partial class App : Application
    {
        public static DatabaseContext Database { get; private set; }
        public static Пользователи CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();
            Database = new DatabaseContext();            
            MainPage = new NavigationPage(new MainPage());
            
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
