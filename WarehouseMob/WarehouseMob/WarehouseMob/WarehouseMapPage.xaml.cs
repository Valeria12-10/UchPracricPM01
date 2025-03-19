using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WarehouseMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarehouseMapPage : ContentPage
    {       
        public WarehouseMapPage()
        {
            InitializeComponent();
            LoadСкладыOnMap();
        }
        private async void LoadСкладыOnMap()
        {
            try
            {
                // Получаем список складов из базы данных
                var склады = await App.Database.GetСкладыAsync();

                // Добавляем маркеры на карту
                foreach (var склад in склады)
                {
                    var position = new Position(склад.Широта, склад.Долгота);
                    var pin = new Pin
                    {
                        Label = склад.Название,
                        Address = склад.Адрес,
                        Type = PinType.Place,
                        Position = position
                    };

                    СкладMap.Pins.Add(pin);
                }

                // Центрируем карту на первом складе (если есть)
                if (склады.Any())
                {
                    var первыйСклад = склады.First();
                    СкладMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(первыйСклад.Широта, первыйСклад.Долгота),
                        Distance.FromKilometers(5))); // Масштаб карты
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось загрузить данные: {ex.Message}", "OK");
            }
        }
    }
}
