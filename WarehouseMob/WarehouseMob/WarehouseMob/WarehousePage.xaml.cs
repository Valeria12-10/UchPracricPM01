using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMob.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WarehouseMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarehousePage : ContentPage
    {
        public WarehousePage()
        {
            InitializeComponent();
            LoadСкладыAsync();
        }
        private async void LoadСкладыAsync()
        {
            // Получаем список складов из базы данных
            var склады = await App.Database.GetСкладыAsync();

            // Преобразуем данные в ViewModel для отображения
            var складыViewModels = склады.Select(s => new Склады
            {

                Название = s.Название,
                Адрес = s.Адрес,
                ТипСклада = s.ТипСклада,
                ЗонаХранения = s.ЗонаХранения

            }).ToList();

            // Устанавливаем источник данных для CollectionView
            СкладыCollectionView.ItemsSource = складыViewModels;
        }

        // Обработка выбора элемента
        private async void OnСкладSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Склады selectedСклад)
            {
                // Действие при выборе склада
                await DisplayAlert("Выбран склад", $"Название: {selectedСклад.Название}, Адрес: {selectedСклад.Адрес}", "OK");               
            }

            // Сброс выбора
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}