using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDEFFINAL
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                produtoBindingSource.DataSource = db.ListaProdutos.ToList();
            }
            metroPanel1.Enabled = false;
            Produto produto = produtoBindingSource.Current as Produto;
            Atualizar();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = true;
            produtoBindingSource.Add(new Produto());
            produtoBindingSource.MoveLast();
            metroTextBox2.Focus();
            


        }
        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Produto prt = produtoBindingSource.Current as Produto;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled= true;
            metroTextBox2.Focus();
            Produto produto = produtoBindingSource.Current as Produto;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem a certeza que deseja eliminar?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (ModelContext db = new ModelContext())
                {
                    Produto produto = produtoBindingSource.Current as Produto;
                    if (produto != null)
                    {
                        if (db.Entry<Produto>(produto).State == EntityState.Detached)
                            db.Set<Produto>().Attach(produto);
                        db.Entry<Produto>(produto).State = EntityState.Deleted;
                        db.SaveChanges();
                        MessageBox.Show(this, "Foi eliminado com sucesso.");
                        produtoBindingSource.RemoveCurrent();
                        metroPanel1.Enabled = false;
                    }
                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroPanel1.Enabled = true;
            produtoBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
                
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Produto produto = produtoBindingSource.Current as Produto;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Produto produto = produtoBindingSource.Current as Produto;
                if (produto != null)
                {
                    if (db.Entry<Produto>(produto).State == EntityState.Detached)
                        db.Set<Produto>().Attach(produto);
                    if (produto.ID == 0)
                        db.Entry<Produto>(produto).State = EntityState.Added;
                    else
                        db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show(this, "Foi adicionado.");
                    metroGrid1.Refresh();
                    metroPanel1.Enabled = false;
                    //aa
                }
            }
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Atualizar()
        {
            
        }
    }
}
