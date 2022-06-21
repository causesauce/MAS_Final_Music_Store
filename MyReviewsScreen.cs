using MAS_Final_Music_Store.Models;
using MAS_Final_Music_Store.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MAS_Final_Music_Store
{
    public partial class MyReviewsScreen : BasicLayoutScreen
    {
        private Form _formCaller;
        private List<Review> _reviews;
        public MyReviewsScreen()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
        }

        public MyReviewsScreen(Form formCaller)
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
            dataGridView.RowHeadersVisible = false;
            _formCaller = formCaller;
        }

        public void LoadReviews(List<Review> reviews)
        {
            _reviews = reviews;
            UpdateDataGrid();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetLabel(string str)
        {
            string text = "my reviews " + str + ":";
            label1.Text = text;
            var labelWidthHalf = label1.Width / 2;
            label1.Location = new Point { X = Width / 2 - labelWidthHalf, Y = label1.Location.Y };
        }


        private void UpdateDataGrid()
        {
            var columns = from r in _reviews
                          select new
                          {
                              ReviewId = r.ReviewId,
                              InstrumentName = r.Content,
                              ReviewDate = r.Date,
                              Action = "modify"
                          };
            dataGridView.DataSource = columns.ToList();
        }
        private void MyReviewsScreen_Load(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
                var reviewToEdit = _reviews.Where(r => r.ReviewId == id).First();
                var editScreen = new EditReviewScreen(reviewToEdit, this);
                editScreen.Size = Size;
                editScreen.Location = Location;
                Hide();
                editScreen.Show();
            }    
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (_formCaller is MyInstrumentScreen)
            {
                ((MyInstrumentScreen)_formCaller)
                    .LoadData(
                        DbService.FetchInstrumentsBoughtByCustomerId(Program.GlobalCustomer.PersonId),
                        DbService.FetchReviewsByCustomerId(Program.GlobalCustomer.PersonId)
                     );
            }
            _formCaller.Size = Size;
            _formCaller.Location = Location;
            Hide();
            _formCaller.Show();
        }
    }
}
