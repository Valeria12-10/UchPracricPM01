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
    public partial class ProductsPage : ContentPage
    {
        private DatabaseContext _db;
        private List<Склады> _warehouses;

        public ProductsPage()
        {
            InitializeComponent();
            _db = new DatabaseContext();
            LoadData();
        }

        private async void LoadData()
        {
            _warehouses = await _db.GetСкладыAsync();
            warehouseCollectionView.ItemsSource = _warehouses;
        }

        private async void OnWarehouseSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Склады selectedWarehouse)
            {
                // Получаем товары на выбранном складе
                var warehouseItems = await _db.GetТоварыНаСкладеAsync(selectedWarehouse.IDСклада);

                // Создаем строку для отображения информации о товарах
                var stockInfo = new StringBuilder();
                stockInfo.AppendLine($"Товары на складе: {selectedWarehouse.Название}");
                stockInfo.AppendLine("-----------------------------");

                foreach (var item in warehouseItems)
                {
                    // Получаем информацию о товаре
                    var product = await _db.GetТоварAsync(item.IDТовара);

                    // Добавляем информацию о товаре в строку
                    stockInfo.AppendLine($"Название: {product.Название}");
                    stockInfo.AppendLine($"Количество: {item.Количество} {product.ЕдиницаИзмерения}");
                    stockInfo.AppendLine("-----------------------------");
                }

                // Показываем информацию о товарах через DisplayAlert
                await DisplayAlert("Товары на складе", stockInfo.ToString(), "OK");

                // Сброс выбора
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}