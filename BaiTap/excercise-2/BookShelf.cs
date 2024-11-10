using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_2
{
    public   class BookShelf
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? VolumeCount { get; set; } // Số lượng sách trong kệ
    }
    public class ShelvesResponse
    {
        public List<BookShelf> Items { get; set; }
    }
}
