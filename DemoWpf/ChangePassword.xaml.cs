using DemoWpf.Models;
using System;
using System.Linq;
using System.Windows;
using System.Security.Cryptography;
using System.Text;

namespace DemoWpf
{
    public partial class ChangePassword : Window
    {
        private int _userId;

        // Конструктор по умолчанию для XAML
        public ChangePassword()
        {
            InitializeComponent();

            // Для дизайнера в Visual Studio
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                txtCurrentPassword.Password = "********";
                txtNewPassword.Password = "********";
                txtConfirmNewPassword.Password = "********";
            }
            else
            {
                _userId = -1; // Значение по умолчанию для ошибки
            }
        }

        // Основной конструктор для использования в коде
        public ChangePassword(int userId) : this()
        {
            _userId = userId;
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            // Проверка инициализации ID пользователя
            if (_userId <= 0)
            {
                MessageBox.Show("Ошибка идентификации пользователя. Пожалуйста, войдите снова.",
                                "Ошибка сессии",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            string currentPassword = txtCurrentPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmNewPassword = txtConfirmNewPassword.Password;

            // Валидация входных данных
            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                MessageBox.Show("Все поля обязательны для заполнения",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (newPassword.Length < 8)
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов",
                                "Ненадежный пароль",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new HotelManagementContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == _userId);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден.",
                                        "Ошибка",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                        return;
                    }

                    // ВРЕМЕННО: прямое сравнение (ЗАМЕНИТЕ НА ХЕШИРОВАНИЕ!)
                    if (user.Password != currentPassword)
                    {
                        MessageBox.Show("Текущий пароль неверен",
                                        "Ошибка",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                        return;
                    }

                    // ВРЕМЕННО: прямое сохранение (ЗАМЕНИТЕ НА ХЕШИРОВАНИЕ!)
                    user.Password = newPassword;
                    user.IsFirstLogin = false;

                    context.SaveChanges();

                    MessageBox.Show("Пароль успешно изменен",
                                    "Успех",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

    }
}