namespace FinalProject.GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            lblFileResult = new Label();
            rtbResult = new TextBox();
            btnCreateSet = new Button();
            txtSize = new TextBox();
            txtChairsCount = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtMaterial = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            lblRemainingFileResult = new Label();
            rtbRemainingSetsResult = new TextBox();
            btnCreateRemainingSet = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.DarkOrange;
            label1.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(776, 38);
            label1.TabIndex = 0;
            label1.Text = "Фінальний проєкт";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblFileResult);
            panel1.Controls.Add(rtbResult);
            panel1.Controls.Add(btnCreateSet);
            panel1.Controls.Add(txtSize);
            panel1.Controls.Add(txtChairsCount);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtMaterial);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 379);
            panel1.TabIndex = 1;
            // 
            // lblFileResult
            // 
            lblFileResult.AutoSize = true;
            lblFileResult.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFileResult.Location = new Point(3, 325);
            lblFileResult.Name = "lblFileResult";
            lblFileResult.Size = new Size(0, 23);
            lblFileResult.TabIndex = 9;
            // 
            // rtbResult
            // 
            rtbResult.BackColor = SystemColors.ButtonFace;
            rtbResult.BorderStyle = BorderStyle.None;
            rtbResult.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbResult.Location = new Point(3, 182);
            rtbResult.Multiline = true;
            rtbResult.Name = "rtbResult";
            rtbResult.ScrollBars = ScrollBars.Vertical;
            rtbResult.Size = new Size(375, 140);
            rtbResult.TabIndex = 8;
            // 
            // btnCreateSet
            // 
            btnCreateSet.Anchor = AnchorStyles.None;
            btnCreateSet.BackColor = Color.CornflowerBlue;
            btnCreateSet.FlatStyle = FlatStyle.Flat;
            btnCreateSet.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCreateSet.ForeColor = Color.White;
            btnCreateSet.Location = new Point(3, 131);
            btnCreateSet.Name = "btnCreateSet";
            btnCreateSet.Size = new Size(375, 45);
            btnCreateSet.TabIndex = 7;
            btnCreateSet.Text = "Створити набір";
            btnCreateSet.UseVisualStyleBackColor = false;
            btnCreateSet.Click += btnCreateSet_Click;
            // 
            // txtSize
            // 
            txtSize.BackColor = SystemColors.ButtonFace;
            txtSize.BorderStyle = BorderStyle.None;
            txtSize.Font = new Font("Bahnschrift", 12F);
            txtSize.Location = new Point(116, 102);
            txtSize.Multiline = true;
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(262, 23);
            txtSize.TabIndex = 6;
            // 
            // txtChairsCount
            // 
            txtChairsCount.BackColor = SystemColors.ButtonFace;
            txtChairsCount.BorderStyle = BorderStyle.None;
            txtChairsCount.Font = new Font("Bahnschrift", 12F);
            txtChairsCount.Location = new Point(151, 73);
            txtChairsCount.Multiline = true;
            txtChairsCount.Name = "txtChairsCount";
            txtChairsCount.Size = new Size(227, 23);
            txtChairsCount.TabIndex = 5;
            txtChairsCount.TextChanged += textBox2_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 73);
            label5.Name = "label5";
            label5.Size = new Size(142, 19);
            label5.TabIndex = 4;
            label5.Text = "Кількість стільців:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(3, 102);
            label4.Name = "label4";
            label4.Size = new Size(107, 19);
            label4.TabIndex = 3;
            label4.Text = "Розмір стола:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 42);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 2;
            label3.Text = "Матеріал:";
            label3.Click += label3_Click_1;
            // 
            // txtMaterial
            // 
            txtMaterial.BackColor = SystemColors.ButtonFace;
            txtMaterial.BorderStyle = BorderStyle.None;
            txtMaterial.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtMaterial.Location = new Point(89, 42);
            txtMaterial.Multiline = true;
            txtMaterial.Name = "txtMaterial";
            txtMaterial.Size = new Size(289, 23);
            txtMaterial.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(310, 23);
            label2.TabIndex = 0;
            label2.Text = "Введіть параметри набору меблів:";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblRemainingFileResult);
            panel2.Controls.Add(rtbRemainingSetsResult);
            panel2.Controls.Add(btnCreateRemainingSet);
            panel2.Location = new Point(407, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(381, 379);
            panel2.TabIndex = 2;
            // 
            // lblRemainingFileResult
            // 
            lblRemainingFileResult.AutoSize = true;
            lblRemainingFileResult.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRemainingFileResult.Location = new Point(3, 325);
            lblRemainingFileResult.Name = "lblRemainingFileResult";
            lblRemainingFileResult.Size = new Size(0, 23);
            lblRemainingFileResult.TabIndex = 10;
            // 
            // rtbRemainingSetsResult
            // 
            rtbRemainingSetsResult.BackColor = SystemColors.ButtonFace;
            rtbRemainingSetsResult.BorderStyle = BorderStyle.None;
            rtbRemainingSetsResult.Font = new Font("Bahnschrift", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rtbRemainingSetsResult.Location = new Point(3, 54);
            rtbRemainingSetsResult.Multiline = true;
            rtbRemainingSetsResult.Name = "rtbRemainingSetsResult";
            rtbRemainingSetsResult.ScrollBars = ScrollBars.Vertical;
            rtbRemainingSetsResult.Size = new Size(375, 268);
            rtbRemainingSetsResult.TabIndex = 9;
            // 
            // btnCreateRemainingSet
            // 
            btnCreateRemainingSet.Anchor = AnchorStyles.None;
            btnCreateRemainingSet.BackColor = Color.CornflowerBlue;
            btnCreateRemainingSet.FlatStyle = FlatStyle.Flat;
            btnCreateRemainingSet.Font = new Font("Bahnschrift SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCreateRemainingSet.ForeColor = Color.White;
            btnCreateRemainingSet.Location = new Point(3, 3);
            btnCreateRemainingSet.Name = "btnCreateRemainingSet";
            btnCreateRemainingSet.Size = new Size(375, 45);
            btnCreateRemainingSet.TabIndex = 0;
            btnCreateRemainingSet.Text = "Створити набори з залишків";
            btnCreateRemainingSet.UseVisualStyleBackColor = false;
            btnCreateRemainingSet.Click += btnCreateRemainingSet_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private TextBox txtMaterial;
        private Button btnCreateRemainingSet;
        private Label label3;
        private Label label4;
        private TextBox txtChairsCount;
        private Label label5;
        private TextBox txtSize;
        private Button btnCreateSet;
        private TextBox rtbResult;
        private Label lblFileResult;
        private Label lblRemainingFileResult;
        private TextBox rtbRemainingSetsResult;
    }
}
