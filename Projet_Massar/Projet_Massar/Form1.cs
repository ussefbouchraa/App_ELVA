using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Projet_Massar
{
    public partial class Form1 : Form
    {
        ADO ado = new ADO();
        int position;
        public Form1()
        { 
            InitializeComponent(); 
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ado.connecter();
            DGV();
            txt_search.Focus();
           
        }
        public void reader()
        {
            txt_CodeEleve.Text = dataGridView1.Rows[position].Cells[0].Value.ToString();
            txt_NomEleve.Text = dataGridView1.Rows[position].Cells[1].Value.ToString();
            txt_PrenomEleve.Text = dataGridView1.Rows[position].Cells[2].Value.ToString();
            dtp1.Text = dataGridView1.Rows[position].Cells[3].Value.ToString();
            txt_Nationalite.Text = dataGridView1.Rows[position].Cells[4].Value.ToString();
            txt_NiveauScolaire.Text = dataGridView1.Rows[position].Cells[5].Value.ToString();
            txt_Etab_Nom.Text = dataGridView1.Rows[position].Cells[6].Value.ToString();
            txt_SituationFr.Text = dataGridView1.Rows[position].Cells[7].Value.ToString();
        
        
        }

        public void DGVPOSITION()
        {
            if (position < 0) { position = dataGridView1.Rows.Count - 1; return; }
            if (position > dataGridView1.Rows.Count - 1) { position = 0; }
        }

        public void SELECT_P()
        {
            dataGridView1.ClearSelection();
            dataGridView1.Rows[position].Selected = true;
        
        }

        public void DGV()
        {


            ado.DA = new OleDbDataAdapter("Select CodeEleve ,NomEleve,PrenomEleve, DateNaisEleve , Nationalite , Niveau , ETAB_Nom , SituationFr from Table_G  ", ado.cn);
            ado.DA.Fill(ado.DT);
            dataGridView1.DataSource = ado.DT;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            ado.deconnecter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            position = 0; DGVPOSITION(); SELECT_P(); reader();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            position += 1; DGVPOSITION(); SELECT_P(); reader();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            position -= 1; DGVPOSITION(); SELECT_P(); reader();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            position = dataGridView1.Rows.Count - 1; DGVPOSITION(); SELECT_P(); reader();

        }

        private void t10_TextChanged(object sender, EventArgs e)
        {

            ado.DT.Clear();
            ado.DA = new OleDbDataAdapter(@"Select CodeEleve ,NomEleve,PrenomEleve, DateNaisEleve , Nationalite , Niveau , ETAB_Nom , SituationFr from Table_G 
           where NomEleve like '%" + txt_search.Text.ToUpper() + "%'  or DateNaisEleve  like '%" + txt_search.Text + "%' or CodeEleve  like '%" + txt_search.Text + "%'  ", ado.cn);

            ado.DA.Fill(ado.DT);
            dataGridView1.DataSource = ado.DT;
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voullez vous vraiment Quitter !!", "Close", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) { this.Close(); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txt_CodeEleve.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_NomEleve.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().ToUpper();
          txt_PrenomEleve.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().ToLower();
            dtp1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_Nationalite.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
           txt_NiveauScolaire.Text= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_Etab_Nom.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_SituationFr.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}
