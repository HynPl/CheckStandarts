using System.Windows.Forms;

namespace CheckStandarts {
    public partial class FormMessage : Form {
        public FormMessage(string title, string body) {
            InitializeComponent();
            Text=title;
            textBox1.Text=body;
        }

        private void GButton1_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}
