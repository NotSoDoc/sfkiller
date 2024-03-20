using SFKiller.Properties;

namespace SFKiller
{
    partial class SFKiller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFKiller));
            comboBox1 = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.BackColor = SystemColors.InactiveCaptionText;
            comboBox1.ForeColor = SystemColors.Window;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 184);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Select Drive";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Exo 2", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 157);
            label1.Name = "label1";
            label1.Size = new Size(110, 24);
            label1.TabIndex = 1;
            label1.Text = "Drive to clear";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(135, 184);
            button1.Name = "button1";
            button1.Size = new Size(237, 23);
            button1.TabIndex = 2;
            button1.Text = "NUKE IT!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.FromArgb(32, 32, 32);
            progressBar1.Location = new Point(12, 220);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(360, 29);
            progressBar1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resources.SFKiller;
            pictureBox1.Location = new Point(34, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(318, 76);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Orbitron", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Firebrick;
            label2.Location = new Point(343, 9);
            label2.Name = "label2";
            label2.Size = new Size(29, 26);
            label2.TabIndex = 5;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // SFKiller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(384, 261);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "SFKiller";
            Text = "SFKiller";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private ProgressBar progressBar1;
        private PictureBox pictureBox1;
        private Label label2;
    }
}
