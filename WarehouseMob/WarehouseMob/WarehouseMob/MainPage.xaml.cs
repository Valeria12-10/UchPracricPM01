using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WarehouseMob
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthService _authService;

        public MainPage()
        {
            InitializeComponent();
            _authService = new AuthService(App.Database);
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            try
            {
                // Первый этап: проверка почты и пароля
                var пользователь = await _authService.AuthenticateAsync(email, password);

                // Второй этап: двухфакторная аутентификация (ввод кода подтверждения)
                var кодПодтверждения = await DisplayPromptAsync("Двухфакторная аутентификация", "Введите код подтверждения, отправленный на вашу почту:");

                if (_authService.VerifyToken(пользователь, кодПодтверждения))
                {
                    // Успешная аутентификация
                    App.CurrentUser = пользователь;
                    await DisplayAlert("Успех", "Аутентификация прошла успешно!", "OK");
                    await Navigation.PushAsync(new MainTabbedPage());
                }
                else
                {
                    await DisplayAlert("Ошибка", "Неверный код подтверждения.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
    }
}