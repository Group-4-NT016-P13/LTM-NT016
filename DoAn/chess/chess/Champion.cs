using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chess
{
    public partial class Champion : Form
    {
        private TCPClient tcpClient;
        public Champion(TCPClient client)
        {
            InitializeComponent();
            tcpClient = client;

        }

        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txbRank_TextChanged(object sender, EventArgs e)
        {
         
        }

      
    }
}
