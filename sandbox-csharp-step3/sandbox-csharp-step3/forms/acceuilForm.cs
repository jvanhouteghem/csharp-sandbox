using sandbox_csharp_step3.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sandbox_csharp_step3 {
    public partial class acceuilForm : Form {
        public acceuilForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        private void button1_Click(object sender, EventArgs e) {
            // new questionnaire.Show()
            //Application.Run(new questionnaireForm());
            new questionnaireForm().Show();
        }

        private void button2_Click(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {

        }
    }
}
