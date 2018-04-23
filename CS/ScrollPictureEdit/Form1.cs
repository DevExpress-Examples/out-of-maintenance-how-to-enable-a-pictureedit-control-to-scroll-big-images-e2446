using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using nsScrollPictureEdit.Properties;

namespace nsScrollPictureEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = CreateTable(3);
            gridView1.RowHeight = 100;

            gridView1.Columns["Image"].ColumnEdit = new RepositoryItemScrollPictureEdit();
            ((RepositoryItemScrollPictureEdit)gridView1.Columns["Image"].ColumnEdit).Scrollable = true;
            ((RepositoryItemScrollPictureEdit)gridView1.Columns["Image"].ColumnEdit).PictureAlignment = ContentAlignment.TopLeft;
        }

        private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Image", typeof(Image));

            for ( int i = 0; i < RowCount; i++ )
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), Resources.Image });

            return tbl;
        }
    }
}