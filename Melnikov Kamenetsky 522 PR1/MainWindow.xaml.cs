using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Melnikov_Kamenetsky_522_PR1
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Вы точно хотите выйти?",
                "Да",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if(result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(InputX.Text))
                {
                    MessageBox.Show("Поле X не заполнено. Пожалуйста, введите значение.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(InputM.Text))
                {
                    MessageBox.Show("Поле M не заполнено. Пожалуйста, введите значение.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

               
                if (!double.TryParse(InputX.Text, out double x))
                {
                    MessageBox.Show("Поле X содержит некорректное значение. Введите число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!double.TryParse(InputM.Text, out double m))
                {
                    MessageBox.Show("Поле M содержит некорректное значение. Введите число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (RadioSh.IsChecked != true && RadioX2.IsChecked != true && RadioExp.IsChecked != true)
                {
                    MessageBox.Show("Не выбрана функция. Пожалуйста, выберите одну из функций (sh(x), x^2, e^x).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double fx = 0;
                if (RadioSh.IsChecked == true)
                {
                    fx = Math.Sinh(x); 
                }
                else if (RadioX2.IsChecked == true)
                {
                    fx = Math.Pow(x, 2); 
                }
                else if (RadioExp.IsChecked == true)
                {
                    fx = Math.Exp(x); 
                }

               
                double j = 0;

               
                if (-1 < m && m < x)
                {
                    j = Math.Sin(5 * fx + 3 * m * Math.Abs(fx)); 
                }
                else if (x > m)
                {
                    j = Math.Cos(3 * fx + 5 * m * Math.Abs(fx)); 
                }
                else if (x == m)
                {
                    j = Math.Pow(fx + m, 2);
                }

                
                ResultTextBox.Text = j.ToString("F4"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void ResultTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputM.Clear();
            ResultTextBox.Clear();

            RadioSh.IsChecked = false;
            RadioX2.IsChecked = false;
            RadioExp.IsChecked = false;
        }
    }
}
