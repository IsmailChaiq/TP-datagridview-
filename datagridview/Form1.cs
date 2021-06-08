using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datagridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string PictureFileName;
        private void btnParcourir_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            PictureFileName = openFileDialog1.FileName;
            pctBoxPicture.Image = Image.FromFile(PictureFileName);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            char sex;
            clsEmploye emp = new clsEmploye(txtNom.Text, txtPrenom.Text, PictureFileName, cmbSexe.Text[0], chkBoxMarié.Checked);
            clsEmploye.ListeEmployes.Add(emp);
            reloadDgv();
        }
        
        public void reloadDgv()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clsEmploye.ListeEmployes;

            DataGridViewCheckBoxColumn dgvCheckedColumn = new DataGridViewCheckBoxColumn();
            dgvCheckedColumn.HeaderText = "Marié";
            dgvCheckedColumn.Name = "Marié";

            DataGridViewImageColumn dgvPictureColumn = new DataGridViewImageColumn();
            dgvPictureColumn.HeaderText = "Image";
            dgvPictureColumn.Name = "Image";
            dgvPictureColumn.Width = 100;
            dgvPictureColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
            



            DataGridViewComboBoxColumn dgvCmbColumn = new DataGridViewComboBoxColumn();
            dgvCmbColumn.HeaderText = "Sexe";
            dgvCmbColumn.Name = "Sexe";


            dataGridView1.Columns["Marié"].Visible = false;
            dataGridView1.Columns["PictureFilename"].Visible = false;
            dataGridView1.Columns["Sex"].Visible = false;
            
            dataGridView1.Columns.Add(dgvCheckedColumn);
            dataGridView1.Columns.Add(dgvCmbColumn);
            dataGridView1.Columns.Add(dgvPictureColumn);
            dataGridView1.Columns["Image"].DisplayIndex = 0;


            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewImageCell imageCell = row.Cells["Image"] as DataGridViewImageCell;
                imageCell.Value = Image.FromFile(row.Cells["PictureFilename"].Value.ToString());
                //imageCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
