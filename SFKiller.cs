using System.Linq;
using System.Text.RegularExpressions;

namespace SFKiller
{
    public partial class SFKiller : Form
    {

        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        public SFKiller()
        {
            InitializeComponent();
            PopulateDriveComboBox();

            this.MouseDown += SFKiller_MouseDown;
            this.MouseUp += SFKiller_MouseUp;
            this.MouseMove += SFKiller_MouseMove;
        }

        private void PopulateDriveComboBox()
        {
            comboBox1.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                comboBox1.Items.Add(drive.Name);
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Check if a drive is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid drive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Select the Drive
            string selectedDrive = comboBox1.Text;

            // Check if the selected drive exists
            if (!Directory.Exists(selectedDrive))
            {
                MessageBox.Show("The selected drive does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show loading bar
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Visible = true;

            // Search for the .sfk files
            List<string> sfkFiles = await SearchSFKFilesAsync(selectedDrive);

            // Stop loading bar (or specifically the animation)
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;

            // Count the number of .sfk files found
            int sfkFileCount = sfkFiles.Count;

            // Prompt for Deleting
            DialogResult result = MessageBox.Show($"Found {sfkFileCount} .sfk files on drive {selectedDrive}. Do you want to delete them?",
                                                   "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delete Files
                DeleteSFKFiles(sfkFiles);
                MessageBox.Show("Files deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Abrort
                MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSFKFiles(List<string> sfkFiles)
        {
            foreach (string file in sfkFiles)
            {
                File.Delete(file);
            }
        }

        private Task<List<string>> SearchSFKFilesAsync(string directory)
        {
            return Task.Run(() =>
            {
                List<string> sfkFiles = new List<string>();
                SearchSFKFiles(directory, ref sfkFiles);
                return sfkFiles;
            });
        }

        private void SearchSFKFiles(string directory, ref List<string> sfkFiles)
        {
            try
            {
                // Search for files matching the regex pattern -> thanks to angelolz
                string[] files = Directory.GetFiles(directory)
                    .Where(file => Regex.IsMatch(Path.GetFileName(file), @"^.*(?:\.sf(?:k|ap)\d*)$"))
                    .ToArray();

                sfkFiles.AddRange(files);

                // Search subdirectories recursively
                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                    SearchSFKFiles(subdirectory, ref sfkFiles);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Skip this directory if access is denied
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SFKiller_MouseDown(object sender, MouseEventArgs e)
        {
            // On Mouse Press get position and set dragging
            isDragging = true;
            lastCursor = Cursor.Position;
            lastForm = this.Location;
        }

        private void SFKiller_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void SFKiller_MouseMove(object sender, MouseEventArgs e)
        {
            // Calculate differenc in mouse position
            if (isDragging)
            {
                Point currentCursor = Cursor.Position;
                int deltaX = currentCursor.X - lastCursor.X;
                int deltaY = currentCursor.Y - lastCursor.Y;
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);
            }
        }
    }
}
