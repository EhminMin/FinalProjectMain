using FinalProject.GUI.Interfaces;
using FinalProject.GUI.Services;
using FinalProject.GUI.Models;

namespace FinalProject.GUI
{
    public partial class MainForm : Form
    {
        public class InventoryData
        {
            public List<Table> Tables { get; set; } = new();
            public List<Chair> Chairs { get; set; } = new();
        }

        private InventoryData _inventory = new InventoryData();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                string json = File.ReadAllText(Path.Combine("..", "..", "..", "input", "furniture.json"));
                var data = System.Text.Json.JsonSerializer.Deserialize<InventoryData>(json);

                if (data != null)
                {
                    _inventory = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження складу: " + ex.Message);
            }
        }
        private void btnCreateSet_Click(object sender, EventArgs e)
        {
            try
            {
                string material = txtMaterial.Text.ToLower();

                if (!Double.TryParse(txtWidth.Text, out double width) ||
                   !Double.TryParse(txtDepth.Text, out double depth))
                {
                    MessageBox.Show("Невірний формат ширини або глибини.");
                    return;
                }

                if (!Int32.TryParse(txtChairsCount.Text, out int chairsCount))
                {
                    MessageBox.Show("Невірний формат кількості стільців.");
                    return;
                }

                if (_inventory.Chairs.Count == 0 || _inventory.Tables.Count == 0)
                {
                    MessageBox.Show("Немає доступних стільців або столів.");
                    return;
                }

                FurnitureManager manager = new FurnitureManager();
                FurnitureSet firstSet = manager.CreateSet(_inventory.Chairs, _inventory.Tables, material, width, depth, chairsCount);

                var table = firstSet.GetAllFurniture().OfType<Table>().FirstOrDefault();

                rtbResult.Text = $"Set : {firstSet.Name}{Environment.NewLine}" +
                                 $"Table size: {table?.Width} x {table?.Depth}{Environment.NewLine}" +
                                 $"Material: {table?.Material}{Environment.NewLine}" +
                                 $"Chairs count: {firstSet.ChairsCount}{Environment.NewLine}" +
                                 $"Total price: {firstSet.TotalPrice}";

                var listToSave = new List<FurnitureSet> { firstSet };

                string set1Path = Path.Combine("..", "..", "..", "output", "set1.txt");
                ISaveLoad txtService = new FileService();
                txtService.Save(set1Path, listToSave);

                ISaveLoad jsonService = new JsonSerializerService();
                jsonService.Save(Path.Combine("..", "..", "..", "output", "set1Json.json"), listToSave);

                ISaveLoad xmlService = new XmlSerializerService();
                xmlService.Save(Path.Combine("..", "..", "..", "output", "set1Xml.xml"), listToSave);

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
                if (_inventory.Chairs.Count == 0 || _inventory.Tables.Count == 0)
                {
                    MessageBox.Show("Немає доступних стільців або столів.");
                    return;
                }

                FurnitureManager manager = new FurnitureManager();
                List<FurnitureSet> remainingSets = manager.CreateRemainingSets(_inventory.Chairs, _inventory.Tables);


                string text = string.Empty;
                foreach (var set in remainingSets)
                {
                    var table = set.GetAllFurniture().OfType<Table>().FirstOrDefault();

                    text += $"Set: {set.Name}{Environment.NewLine}";
                    if(table != null)
                    {
                        text += $"Table size: {table.Width} x {table.Depth}{Environment.NewLine}";
                        text += $"Table material: {table.Material}{Environment.NewLine}";
                    }
                    text += $"Chairs count: {set.ChairsCount}{Environment.NewLine}";
                    text += $"Total price: {set.TotalPrice}{Environment.NewLine}";
                    text += Environment.NewLine;
                }
                rtbRemainingSetsResult.Text = text;

                string set2Path = Path.Combine("..", "..", "..", "output", "set2.txt");
                ISaveLoad txtService = new FileService();
                txtService.Save(set2Path, remainingSets);

                ISaveLoad jsonService = new JsonSerializerService();
                jsonService.Save(Path.Combine("..", "..", "..", "output", "set2Json.json"), remainingSets);

                ISaveLoad xmlService = new XmlSerializerService();
                xmlService.Save(Path.Combine("..", "..", "..", "output", "set2Xml.xml"), remainingSets);

                lblRemainingFileResult.ForeColor = Color.Green;
                lblRemainingFileResult.Text = "Набори записано у файл.";
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        #region labels

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
        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
