using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab14
{
    public partial class AddComposition : Form
    {

        private BindingList<MusicComposition> CompositionList;

        public AddComposition(BindingList<MusicComposition> CompositionList)
        {
            this.CompositionList = CompositionList;
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            MusicComposition musicComposition;

            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
                    || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
                {
                    throw new Exception("Please fill in all fields.");
                }
                else
                {
                    string title = textBox1.Text;
                    string artist = textBox2.Text;
                    string album = textBox3.Text;
                    string genre = textBox4.Text;
                    double duration = double.Parse(textBox5.Text);

                    musicComposition = new MusicComposition(title, artist, album, genre, duration);

                    CompositionList.Add(musicComposition);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
