using SportStoreStonks.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace SportStoreStonks
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            using (SportStoreContext db = new SportStoreContext())
            {

                try
                {
                    Product product = new Product()
                    {

                        ArticleNumber = articleBox.Text,
                        Name = nameBox.Text,
                        Description = descriptionBox.Text,
                        Category = categoryBox.Text,
                        Photo = imageBox.Text, // "picture.png",
                        Manufacturer = manufacturerBox.Text,
                        Cost = Convert.ToDecimal(costBox.Text),
                        DiscountAmount = Convert.ToInt32(discountAmountBox.Text),
                        QuantityInStock = Convert.ToInt32(quantityInStockBox.Text),
                        Status = statusBox.Text


                    };


                    if (product.Cost < 0)
                    {
                        MessageBox.Show("Цена должна быть положительной!");
                        return;
                    }

                    if (product.QuantityInStock < 0)
                    {
                        MessageBox.Show("Количество товаров на складе не может быть меньше нуля!");
                        return;
                    }

                    db.Products.Add(product);

                    if (String.IsNullOrEmpty(imageBox.Text))
                    {
                        product.Photo = "picture.png";  
                        BitmapImage image = new BitmapImage(new Uri(product.imageBoxPath));
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        imageBoxPath.Source = image;
                    }

                    db.SaveChanges();

                    MessageBox.Show("Продукт успешно добавлен!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
            }
            InitializeComponent();
        }

        private void saveProductButtonClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(articleBox.Text))
                errors.AppendLine("Укажите артикль");
            if (string.IsNullOrWhiteSpace(nameBox.Text))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
                errors.AppendLine("Укажите описание");
            if (string.IsNullOrWhiteSpace(categoryBox.Text))
                errors.AppendLine("Укажите категорию");
            if (string.IsNullOrWhiteSpace(manufacturerBox.Text))
                errors.AppendLine("Укажите производителя");
            if (string.IsNullOrWhiteSpace(costBox.Text))
                errors.AppendLine("Укажите цену");

            if (string.IsNullOrWhiteSpace(discountAmountBox.Text))
                errors.AppendLine("Укажите размер скидки");
            if (string.IsNullOrWhiteSpace(quantityInStockBox.Text))
                errors.AppendLine("Укажите количество на складе");
            if (string.IsNullOrWhiteSpace(statusBox.Text))
                errors.AppendLine("Укажите статус");
            if (string.IsNullOrWhiteSpace(discountAmountBox.Text))
                errors.AppendLine("Укажите максимальную скидку");
            if (string.IsNullOrWhiteSpace(supplierBox.Text))
                errors.AppendLine("Укажите поставщика");
            if (string.IsNullOrWhiteSpace(unitBox.Text))
                errors.AppendLine("Укажите единицы измерения");

            //
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
        }

        private void AddImageToUser(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
