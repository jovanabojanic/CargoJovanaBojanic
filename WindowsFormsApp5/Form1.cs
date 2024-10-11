using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.DTOs;
using Core.Models;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "https://localhost:7084/api/";
        private string placeholderText = "Naziv proizvoda"; // Placeholder za pretragu proizvoda po nazivu


        public Form1()
        {
            InitializeComponent();
            InitializePlaceholder();
            dataGridViewCategories.SelectionChanged += dataGridViewCategories_SelectionChanged;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler);

            LoadData();
        }

        private void InitializePlaceholder()
        {
            searchedProdName.Text = placeholderText;
            searchedProdName.ForeColor = Color.Gray;

            searchedProdName.Enter += searchedProdName_Enter;
            searchedProdName.Leave += searchedProdName_Leave;
        }

        private void searchedProdName_Enter(object sender, EventArgs e)
        {
            if (searchedProdName.Text == placeholderText)
            {
                searchedProdName.Text = "";
                searchedProdName.ForeColor = Color.Black;
            }
        }

        private void searchedProdName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchedProdName.Text))
            {
                searchedProdName.Text = placeholderText;
                searchedProdName.ForeColor = Color.Gray;
            }
        }

        private async void LoadData()
        {
            try
            {
                // Učitajte proizvode
                var response = await _httpClient.GetAsync($"{_baseApiUrl}products/getAll");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };

                    var products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonContent, options);
                    dataGridView1.DataSource = products;
                }
                else
                {
                    MessageBox.Show("Failed to load products. Error: " + response.ReasonPhrase);
                }

                // Učitajte kategorije
                var categoriesResponse = await _httpClient.GetAsync($"{_baseApiUrl}category/getAll");

                if (categoriesResponse.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };

                    var categoriesJsonContent = await categoriesResponse.Content.ReadAsStringAsync();
                    var categories = JsonSerializer.Deserialize<List<CategoryDTO>>(categoriesJsonContent, options);

                    if (categories == null || !categories.Any())
                    {
                        MessageBox.Show("No categories found.");
                        return;
                    }

                    dataGridViewCategories.DataSource = categories;

                    cmbCategories.DataSource = categories;
                    cmbCategories.DisplayMember = "CategoryName";
                    cmbCategories.ValueMember = "CategoryId";

                }
                else
                {
                    MessageBox.Show("Failed to load categories. Error: " + categoriesResponse.ReasonPhrase);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Request error: " + httpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string productName = searchedProdName.Text;

            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Molimo unesite ime proizvoda.");
                return;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}products/getByName?productName={Uri.EscapeDataString(productName)}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };

                    var products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonContent, options);

                    if (products != null && products.Count > 0)
                    {
                        dataGridView1.DataSource = products;
                    }
                    else
                    {
                        MessageBox.Show("Nema proizvoda sa traženim imenom.");
                        dataGridView1.DataSource = null;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Proizvod sa traženim imenom nije pronađen.");
                    dataGridView1.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Greška prilikom učitavanja proizvoda: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private async void saveCreateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productName.Text) ||
                string.IsNullOrWhiteSpace(price.Text) ||
                string.IsNullOrWhiteSpace(description.Text) ||
                string.IsNullOrWhiteSpace(stockQuantity.Text) ||
                cmbCategories.SelectedValue == null) 
            {
                MessageBox.Show("Sva polja, uključujući kategoriju, moraju biti popunjena.");
                return;
            }

            var productDTO = new ProductDTO
            {
                ProductName = productName.Text,
                Price = decimal.Parse(price.Text),
                Description = description.Text,
                StockQuantity = int.Parse(stockQuantity.Text),
            };

            var jsonContent = JsonSerializer.Serialize(productDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                // Pošalji zahtev za kreiranje proizvoda
                var response = await _httpClient.PostAsync($"{_baseApiUrl}products/create", content);

                if (response.IsSuccessStatusCode)
                {
                    // Učitaj odgovor u JSON formatu
                    var createdProductJson = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        PropertyNameCaseInsensitive = true,
                    };

                    try
                    {
                        var createdProduct = JsonSerializer.Deserialize<Product>(createdProductJson, options);
                        if (createdProduct == null)
                        {
                            MessageBox.Show("Deserialization returned null.");
                        }
                        else
                        {
                            var productCategory = new ProductCategoryDto
                            {
                                ProductId = createdProduct.ProductId,
                                CategoryId = (int)cmbCategories.SelectedValue 
                            };

                            var jsonContent1 = JsonSerializer.Serialize(productCategory);
                            var content1 = new StringContent(jsonContent1, Encoding.UTF8, "application/json");

                            var linkResponse = await _httpClient.PostAsync($"{_baseApiUrl}productCategories/create", content1);

                            if (linkResponse.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Proizvod kreiran i uspesno spojen sa kategorijom!");
                            }
                            else
                            {
                                MessageBox.Show("Proizvod kreiran, ali nije uspeo sa se poveze sa kategorijom. Error: " + linkResponse.ReasonPhrase);
                            }
                        }

                        LoadData();
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show($"Deserialization error: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Nije mogice kreirati proizvod. Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void searchAllBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var productId = (int)selectedRow.Cells["ProductId"].Value;

                var confirmationResult = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj proizvod?", "Potvrda brisanja", MessageBoxButtons.YesNo);

                if (confirmationResult == DialogResult.Yes)
                {
                    try
                    {
                        var response = await _httpClient.DeleteAsync($"{_baseApiUrl}products/delete/{productId}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Proizvod je uspešno obrisan.");
                            LoadData();
                        }
                        else
                        {
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Greška prilikom brisanja proizvoda: " + response.ReasonPhrase + "\n" + errorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Molimo izaberite proizvod za brisanje.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;

            MessageBox.Show(
                  "Nakon što ste selektovali proizvod iz Grid-a informacije za ažuriranje ce vec biti dostupne. \n" +
                  "Izaberite sta zelite da promenite i pritisnite dugme 'SAVE'.",
                  "Uputstvo za ažuriranje",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }

        private async void saveUpdatebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var productId = (int)selectedRow.Cells["ProductId"].Value;

                // Učitaj trenutne informacije o proizvodu
                var response = await _httpClient.GetAsync($"{_baseApiUrl}products/getOne/{productId}");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Greška prilikom dobijanja trenutnog proizvoda: " + response.ReasonPhrase);
                    return;
                }

                var jsonContent = await response.Content.ReadAsStringAsync();
                var currentProductDto = JsonSerializer.Deserialize<ProductDTO>(jsonContent);

                var productDto = new ProductDTO
                {
                    ProductId = productId,
                    ProductName = string.IsNullOrWhiteSpace(updateNameTxt.Text) ? currentProductDto.ProductName : updateNameTxt.Text,
                    Price = string.IsNullOrWhiteSpace(updatePriceTxt.Text) || !decimal.TryParse(updatePriceTxt.Text, out var parsedPrice) ? currentProductDto.Price : parsedPrice,
                    Description = string.IsNullOrWhiteSpace(updateDescTxt.Text) ? currentProductDto.Description : updateDescTxt.Text,
                    StockQuantity = string.IsNullOrWhiteSpace(updateQuantTxt.Text) || !int.TryParse(updateQuantTxt.Text, out var parsedStockQuantity) ? currentProductDto.StockQuantity : parsedStockQuantity,
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(productDto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var updateResponse = await _httpClient.PutAsync($"{_baseApiUrl}products/update/{productId}", content);

                if (updateResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Proizvod je uspešno ažuriran.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Greška prilikom ažuriranja proizvoda: " + updateResponse.ReasonPhrase);
                }
            }
            else
            {
                MessageBox.Show("Molimo izaberite proizvod za ažuriranje.");
            }
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var productId = (int)selectedRow.Cells["ProductId"].Value;

                // Učitavanje trenutnih informacije o proizvodu
                LoadCurrentProductData(productId);
            }
        }

        private async void LoadCurrentProductData(int productId)
        {
            var response = await _httpClient.GetAsync($"{_baseApiUrl}products/getOne/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Greška prilikom dobijanja trenutnog proizvoda: " + response.ReasonPhrase);
                return;
            }

            var jsonContent = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var currentProductDto = JsonSerializer.Deserialize<ProductDTO>(jsonContent, options);

            if (currentProductDto == null)
            {
                MessageBox.Show("Greška prilikom deserializacije proizvoda.");
                return;
            }

            updateNameTxt.Text = currentProductDto.ProductName;
            updatePriceTxt.Text = currentProductDto.Price.ToString("F2");
            updateDescTxt.Text = currentProductDto.Description;
            updateQuantTxt.Text = currentProductDto.StockQuantity.ToString();
        }

        private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewCategories.SelectedRows[0];
                var categoryId = (int)selectedRow.Cells["CategoryId"].Value;

                LoadProductsByCategory(categoryId);
            }
        }
        private async void LoadProductsByCategory(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseApiUrl}products/getByCategory/{categoryId}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    var products = JsonSerializer.Deserialize<List<ProductDTO>>(jsonContent, options);
                    dataGridView1.DataSource = products;
                }
                else
                {
                    MessageBox.Show("Greska prilikom ucitavanja proizvoda za izabranu kategoriju. Error: " + response.ReasonPhrase);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Request error: " + httpEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void searchByCatbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Da biste uspešno pretražili proizvode po kategorijama, selektujte odgovarajuću kategoriju u gridu Kategorije." +
                "Proizvodi koji pripadaju odabranoj kategoriji će se zatim prikazati.", "Informacija", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
