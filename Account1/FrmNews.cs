using System;
using System.Windows.Forms;

namespace Account1
{
    public partial class FrmNews : Form
    {
        public string veri;
        public FrmNews()
        {
            InitializeComponent();
        }
        public FrmNews(params string[] data)
        {
            InitializeComponent();
            listBox1.Items.AddRange(data);
        }

    }

}

