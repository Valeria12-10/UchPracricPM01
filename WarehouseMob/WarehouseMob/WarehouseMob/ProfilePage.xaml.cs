using System;
using System.IO;
using System.Threading.Tasks;
using WarehouseMob.DataBase;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode.Internal;
using ZXing.QrCode;
using System.Collections.Generic;

namespace WarehouseMob
{
    public partial class ProfilePage : ContentPage
    {
        private Пользователи _currentUser;

        public ProfilePage()
        {
            InitializeComponent();
            if (App.CurrentUser == null)
            {
                DisplayAlert("Ошибка", "Пользователь не авторизован.", "OK");
                Navigation.PushAsync(new MainPage());
                return;
            }
            _currentUser = App.CurrentUser;
            BindingContext = _currentUser;
            LoadUserPhoto();
        }

        // Загрузка фотографии пользователя
        private void LoadUserPhoto()
        {
            if (!string.IsNullOrEmpty(_currentUser.Фото))
            {
                UserImage.Source = ImageSource.FromFile(_currentUser.Фото);
            }
            else
            {
                UserImage.Source = ImageSource.FromFile("account_avatar_face_man_people_profile_user_icon_123197.png"); // Заглушка
            }
        }

        // Изменение фотографии
        private async void OnChangePhotoClicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    UserImage.Source = ImageSource.FromStream(() => stream);

                    // Сохраняем путь к фотографии
                    _currentUser.Фото = photo.FullPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        // Сохранение изменений
        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            try
            {
                // Обновляем данные пользователя в базе данных
                await App.Database.SaveПользовательAsync(_currentUser);
                await DisplayAlert("Успех", "Данные сохранены!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
        //генерация куар кода
        private void OnGenerateQRClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentUser.ИмяПользователя) || string.IsNullOrEmpty(_currentUser.Роль))
            {
                DisplayAlert("Ошибка", "Данные пользователя не заполнены.", "OK");
                return;
            }

            var qrCodeData = $"Пользователь: {_currentUser.ИмяПользователя}, Роль: {_currentUser.Роль}";

            if (string.IsNullOrEmpty(qrCodeData))
            {
                DisplayAlert("Ошибка", "Не удалось сгенерировать QR-код: данные пустые.", "OK");
                return;
            }

            var encodingOptions = new ZXing.Common.EncodingOptions
            {
                Width = 300,
                Height = 300,
                Margin = 1
            };

            // Правильный способ задания Hints:
            encodingOptions.Hints[ZXing.EncodeHintType.CHARACTER_SET] = "UTF-8";

            QRCodeImage.BarcodeOptions = encodingOptions;
            QRCodeImage.BarcodeValue = qrCodeData;
        }
    }
}