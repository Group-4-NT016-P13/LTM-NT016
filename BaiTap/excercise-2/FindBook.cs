using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Google.Apis.Auth.OAuth2;

namespace excercise_2
{
    public partial class FindBook : Form
    {
        private string accessToken;
        private string Username;
        private string Emaiil;
        private bool isFirstLoad = true;
        public FindBook()
        {
            InitializeComponent();
            InitializeOAuth();

        }

        private async void InitializeOAuth()
        {
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = "1065370628148-m71rrp4b3uhge5g0rkkbckua619n6t51",
                    ClientSecret = "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"
                },
                new[] { "https://www.googleapis.com/auth/books" },
                "user",
                CancellationToken.None
            );

            accessToken = await credential.GetAccessTokenForRequestAsync();
        }


        private async void Search_btn_Click(object sender, EventArgs e)
        {
            string keyword = Search_txt.Text;  // TextBox chứa từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
            {
                var books = await SearchBooks(keyword);
                DisplayBooks(books);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
            }
        }

        private async Task<List<Book>> SearchBooks(string keyword)
        {
            string apiKey = "AIzaSyA02f3GRfEboWT2M4Rg_kgX_LGgyqZV7uE"; 
            string url = $"https://www.googleapis.com/books/v1/volumes?q={keyword}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<GoogleBooksResponse>(response);
                return data.Items.Select(item => new Book
                {
                    Title = item.VolumeInfo.Title ?? "Chưa có tiêu đề",  
                    Authors = item.VolumeInfo.Authors != null ? string.Join(", ", item.VolumeInfo.Authors): "Chưa có tác giả", 
                    Description = item.VolumeInfo.Description ?? "Không có mô tả",  
                    PublishedDate = item.VolumeInfo.PublishedDate ?? "Chưa có thông tin",  
                    Thumbnail = item.VolumeInfo.ImageLinks?.Thumbnail 
                }).ToList();
            }
        }

        private void DisplayBooks(List<Book> books)
        {
            dgvBooks.Rows.Clear();
            foreach(var book in books)
            {
                dgvBooks.Rows.Add(book.Title, book.Authors, book.PublishedDate);
            }
        }

        private async void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (isFirstLoad)
            {
                isFirstLoad = false;
                return;  
            }

            if (dgvBooks.SelectedRows.Count > 0)
            { 
                var selectedBookTitle = dgvBooks.SelectedRows[0].Cells["Title"].Value?.ToString();
                if (!string.IsNullOrEmpty(selectedBookTitle))
                {
                    
                    var bookDetail = await GetBookDetails(selectedBookTitle);

                    if (bookDetail != null)
                    {
                       
                        BookInfor detailForm = new BookInfor(bookDetail);
                        detailForm.ShowDialog(); 
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin chi tiết của cuốn sách.");
                    }
                }
            }
        }

        private async Task<Book> GetBookDetails(string title)
        {
            string apiKey = "AIzaSyA02f3GRfEboWT2M4Rg_kgX_LGgyqZV7uE";  
            string url = $"https://www.googleapis.com/books/v1/volumes?q={title}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<GoogleBooksResponse>(response);

               
                var item = data.Items.FirstOrDefault();

                if (item != null)
                {
                    return new Book
                    {
                        Title = item.VolumeInfo.Title,
                        Authors = string.Join(", ", item.VolumeInfo.Authors),
                        Description = item.VolumeInfo.Description,
                        PublishedDate = item.VolumeInfo.PublishedDate,
                        Thumbnail = item.VolumeInfo.ImageLinks?.Thumbnail
                    };
                }
            }

            return null;
        }

        private async void Addbookshelf_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                MessageBox.Show("Please authenticate first.");
                return;
            }
            string shelfName = Shelfname_txt.Text;
            string shelfDescription = Description_txt.Text;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Thiết lập header Authorization với access token
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    // Tạo nội dung JSON cho kệ sách mới
                    var bookshelfData = new
                    {
                        title = shelfName,
                        description = shelfDescription,
                        access = "PRIVATE"//  "PUBLIC" nếu muốn chia sẻ kệ sách
                    };

                    // Chuyển đổi thành JSON
                    var content = new StringContent(JsonConvert.SerializeObject(bookshelfData), Encoding.UTF8, "application/json");

                    // Gửi yêu cầu POST
                    var response = await client.PostAsync("https://www.googleapis.com/books/v1/mylibrary/bookshelves", content);

                    // Kiểm tra kết quả
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Bookshelf created successfully.");
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error creating bookshelf: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }

        }
        private void DisplayShelves(List<BookShelf> shelves)
        {
            dgvShelves.Rows.Clear();

            foreach (var shelf in shelves)
            {
                dgvShelves.Rows.Add(shelf.Title, shelf.Description, shelf.VolumeCount);
            }
        }
    }
}
