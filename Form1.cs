using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab14
{
    public partial class Form1 : Form
    {

        private static readonly string PATH_TO_CompositionList_FILE = "CompositionList.bin";

        private MusicCompositionList basic;

        private BindingList<MusicComposition> CompositionList;

        private BinaryFormatter binaryFormatter;

        public Form1()
        {
            binaryFormatter = new BinaryFormatter();
            basic = new MusicCompositionList();
            CompositionList = new BindingList<MusicComposition>(basic);
            InitializeComponent();
            Compositions.DataSource = CompositionList;
        }

        private void FillComposition_btn_Click(object sender, EventArgs e)
        {
            basic.FillComposition();
            CompositionList.ResetBindings();
        }

        private void Compositions_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString();
        }

        private void SortByGenre_btn_Click(object sender, EventArgs e)
        {
            basic.Sort((o1, o2) => o1.Genre.CompareTo(o2.Genre));
            CompositionList.ResetBindings();
        }

        private void SortByDuration_btn_Click(object sender, EventArgs e)
        {
            basic.Sort((o1, o2) => o1.Duration.CompareTo(o2.Duration));
            CompositionList.ResetBindings();
        }

        private void SortByTitle_btn_Click(object sender, EventArgs e)
        {
            basic.Sort((o1, o2) => o1.Title.CompareTo(o2.Title));
            CompositionList.ResetBindings();
        }

        private void writeToFile_btn_Click(object sender, EventArgs e)
        {
            basic.WriteToFile(binaryFormatter, PATH_TO_CompositionList_FILE);
        }

        private void readFromFile_btn_Click(object sender, EventArgs e)
        {
            basic.ReadFromFile(binaryFormatter, PATH_TO_CompositionList_FILE);
            CompositionList.ResetBindings();
        }

        private void DeleteComposition_btn_Click(object sender, EventArgs e)
        {
            if (Compositions.SelectedItem != null)
            {
                var composition = (MusicComposition)Compositions.SelectedItem;
                basic.Remove(composition);
                CompositionList.ResetBindings();
            }
        }

        private void ClearList_btn_Click(object sender, EventArgs e)
        {
            basic.Clear();
            CompositionList.ResetBindings();
        }

        private void AddComposition_btn_Click(object sender, EventArgs e)
        {
            AddComposition addComposition = new AddComposition(CompositionList);
            addComposition.Show();
        }
    }
}
