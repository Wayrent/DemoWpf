using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DemoWpf.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWpf
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            try
            {
                using (var context = new HotelManagementContext())
                {
                    var users = await context.Users.ToListAsync();
                    UsersListBox.Items.Clear();
                    foreach (var user in users)
                    {
                        var userItem = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Margin = new Thickness(5),
                            Tag = user.Id
                        };

                        var textBlock = new TextBlock
                        {
                            Text = $"{user.Lastname}, {user.Firstname} ({user.Username}) - {user.Email} — ",
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        var checkBox = new CheckBox
                        {
                            Content = "Заблокирован",
                            IsChecked = user.IsLocked,
                            Tag = user.Id,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(5, 0, 0, 0)
                        };
                        checkBox.Checked += (s, e) => UpdateUserLockStatus(user.Id, true);
                        checkBox.Unchecked += (s, e) => UpdateUserLockStatus(user.Id, false);

                        userItem.Children.Add(textBlock);
                        userItem.Children.Add(checkBox);
                        UsersListBox.Items.Add(userItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке пользователей: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void UpdateUserLockStatus(int userId, bool isLocked)
        {
            try
            {
                using (var context = new HotelManagementContext())
                {
                    var user = await context.Users.FindAsync(userId);
                    if (user != null)
                    {
                        user.IsLocked = isLocked;
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении статуса блокировки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Owner = this;
            addEmployeeWindow.ShowDialog();
            LoadUsers();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is StackPanel selectedPanel &&
                selectedPanel.Tag is int userId)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var context = new HotelManagementContext())
                        {
                            var user = context.Users.FirstOrDefault(u => u.Id == userId);
                            if (user != null)
                            {
                                context.Users.Remove(user);
                                context.SaveChanges();
                                LoadUsers();
                                MessageBox.Show("Сотрудник успешно удалён.",
                                                "Успешно",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}",
                                        "Ошибка",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления.",
                                "Предупреждение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is StackPanel selectedPanel &&
                selectedPanel.Tag is int userId)
            {
                var changePasswordWindow = new ChangePassword(userId);
                changePasswordWindow.Owner = this;
                changePasswordWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для смены пароля.",
                                "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private int GetCurrentAdminId()
        {
            return 1;
        }
    }
}
