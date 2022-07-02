using OOP.domain.Model;
using OOP.EF.Services;
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

namespace oop_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PizzeriaDBServices _crudServices;
        public MainWindow()
        {
            InitializeComponent();
            _crudServices = new PizzeriaDBServices();

            ButtonAdd.Click += ButtonAdd_Click;
            ButtonList.Click += ButtonList_Click;
            DataGridBrand.SelectionChanged += DataGridBrand_SelectionChanged;

            ButtonEdit.Click += ButtonEdit_Click;

            ButtonDelete.Click += ButtonDelete_Click;

            //ButtonSearch.Click += ButtonSearch_Click;
        }

        private async void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                await _crudServices.UpdateBrand(txtOrderID.Text, txtPizzaID.Text, txtSizeID.Text, txtOrderDate.Text, txtAddress.Text);
                throw new Exception("Data Successfully Updateddd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await ListBrands();
            }


        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtOrderID.Text != string.Empty)
                {
                    await _crudServices.DeleteBrand(int.Parse(txtOrderID.Text));
                    throw new Exception("Data Successfully Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await ListBrands();
            }
        }

        //private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    var SearchName = await _crudServices.SearchBrandByName(txtStudent.Text);
        //    DataGridBrand.ItemsSource = SearchName.ToList();
        //}

        private void DataGridBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var activelist = (Order)DataGridBrand.CurrentItem;

                if (activelist != null)
                {
                    txtOrderID.Text = activelist.id.ToString();
                    txtPizzaID.Text = activelist.pizzaId.ToString();
                    txtSizeID.Text = activelist.sizeId.ToString();
                    txtOrderDate.Text = activelist.orderDate;
                    txtAddress.Text = activelist.address;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ButtonList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ListBrands();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ListBrands()
        {
            var brandList = await _crudServices.ListBrands();
            DataGridBrand.ItemsSource = brandList.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _crudServices.AddBrand(txtPizzaID.Text, txtSizeID.Text, txtOrderDate.Text, txtAddress.Text);


                throw new Exception("Data Successfully Addedd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                txtOrderID.Clear();
                txtPizzaID.Clear();
                txtSizeID.Clear();
                txtOrderDate.Clear();
                txtAddress.Clear();
                txtOrderID.Focus();
            }
        }
    }
}
