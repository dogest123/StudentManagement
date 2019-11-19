using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsManagement
{
    public partial class IndexClassForm : Form
    {
        private ClassManagement Business;
        public IndexClassForm()
        {
            InitializeComponent();
            this.Business = new ClassManagement();
            this.Load += IndexClassForm_Load; //show classes
            this.btnCreate.Click +=btnCreate_Click; //Create a class
            this.btndelete.Click += btndelete_Click;    //delete a class
            this.grdClasses.DoubleClick += grdClasses_DoubleClick; // edit a class
        }

        private void LoadAllClasses()
        {
            var classes = this.Business.GetClasses();
            this.grdClasses.DataSource = classes;
        }
        void grdClasses_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                var @class = (CLASS)this.grdClasses.SelectedRows[0].DataBoundItem;

                var updateForm = new UpdateClassForm(@class.id);
                updateForm.ShowDialog();
                this.LoadAllClasses();
            }
        }

        void btndelete_Click(object sender, EventArgs e)
        {
            if (this.grdClasses.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this", "Confirm",
                    MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    var @class = (CLASS)this.grdClasses.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteClass(@class.id);
                    MessageBox.Show("Delete class successfully");
                    this.LoadAllClasses();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm();
            createForm.ShowDialog();
            this.LoadAllClasses();
        }

        void IndexClassForm_Load(object sender, EventArgs e)
        {
            this.LoadAllClasses();
        }

        
    }
}
