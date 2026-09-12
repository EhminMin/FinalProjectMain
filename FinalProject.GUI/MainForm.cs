using FinalProject.Models;
using FinalProject.Services;
using Microsoft.Testing.Platform.Extensions.Messages;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private FurnitureData? data;
        private FurnitureManager _manager = new FurnitureManager();

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            JsonSerializerService jsonService = new JsonSerializerService();
            data = jsonService.DeserializeFromFile(Path.Combine("input", "furniture.json"));
        }
        private void btnCreateSet_Click(object sender, EventArgs e)
        {
            try
            {
                string material = txtMaterial.Text;
                string size = txtSize.Text;
                int chairsCount = Int32.Parse(txtChairsCount.Text);

                if (data == null)
                {
                    MessageBox.Show("Не вдалось завантажити дані.");
                    return;
                }

                FurnitureManager manager = new FurnitureManager();
                FurnitureSet firstSet = manager.CreateSet(data.Chairs, data.Tables, material, size, chairsCount);

                rtbResult.Text = $"Set : {firstSet.Name}{Environment.NewLine}" +
                                 $"Table size: {firstSet.Table?.Size}{Environment.NewLine}" +
                                 $"Material: {firstSet.Table?.Material}{Environment.NewLine}" +
                                 $"Chairs count: {firstSet.ChairsCount}{Environment.NewLine}" +
                                 $"Total price: {firstSet.TotalPrice}";


                string set1Path = Path.Combine("..", "..", "..", "output", "set1.txt");
                FileService.WriteSetToFile(set1Path, firstSet);

                JsonSerializerService jsonService = new JsonSerializerService();
                jsonService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set1Json.json"), firstSet);
                

                XmlSerializerService xmlService = new XmlSerializerService();
                xmlService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set1Xml.xml"), firstSet);
                

                lblFileResult.ForeColor = Color.Green;
                lblFileResult.Text = "Набір записано у файл.";

            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateRemainingSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (data == null)
                {
                    MessageBox.Show("Не вдалось завантажити дані.");
                    return;
                }

                FurnitureManager manager = new FurnitureManager();
                List<FurnitureSet> remainingSets = manager.CreateRemainingSets(data.Chairs, data.Tables);


                string text = null;
                foreach (var set in remainingSets)
                {
                    text += $"Set: {set.Name}{Environment.NewLine}";
                    text += $"Table size: {set.Table?.Size}{Environment.NewLine}";
                    text += $"Table material: {set.Table?.Material}{Environment.NewLine}";
                    text += $"Chairs count: {set.ChairsCount}{Environment.NewLine}";
                    text += $"Total price: {set.TotalPrice}{Environment.NewLine}";
                    text += Environment.NewLine;
                }
                rtbRemainingSetsResult.Text = text;

                string set2Path = Path.Combine("..", "..", "..", "output", "set2.txt");
                FileService.WriteSetsToFile(set2Path, remainingSets);

                JsonSerializerService jsonService = new JsonSerializerService();
                jsonService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set2Json.json"), remainingSets);

                XmlSerializerService xmlService = new XmlSerializerService();
                xmlService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set2Xml.xml"), remainingSets);

                lblRemainingFileResult.ForeColor = Color.Green;
                lblRemainingFileResult.Text = "Набори записано у файл.";
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
