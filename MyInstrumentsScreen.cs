using MAS_Final_Music_Store.DTOs;
using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAS_Final_Music_Store
{
    public partial class MyInstrumentScreen : BasicLayoutScreen
    {
        //private MainScreen _mainScreen;
        private Form _formCaller;
        private MyReviewsScreen _reviewView;
        private List<Review> _reviews;
        private List<InstrumentDto> _instruments;
        public MyInstrumentScreen(Form formCaller)
        {
            InitializeComponent();
            _formCaller = formCaller;
            _reviewView = new MyReviewsScreen(this);
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoGenerateColumns = false;
        }

        public MyInstrumentScreen()
        {
            InitializeComponent();
            dataGridView.RowHeadersVisible = false;
        }
        public void LoadData(List<InstrumentDto> instruments, List<Review> reviews)
        {
            _reviews = reviews;
            _instruments = instruments;
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            var columns = from i in _instruments
                          select new
                          {
                              InstrumentId = i.InstrumentId,
                              InstrumentName = i.Name,
                              DateBought = i.DateLastPurchase
                          };
            dataGridView.DataSource = columns.ToList();
        }

        private void MyInstrumentsScreen_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value;
            var instrument = _instruments.Where(i => i.InstrumentId == id).First();
            var reviewsForInstrument = _reviews.Where(r => r.InstrumentId == id).ToList();
            _reviewView.LoadReviews(reviewsForInstrument);
            _reviewView.SetLabel(instrument.Name);
            _reviewView.Size = Size;
            _reviewView.Location = Location;
            Hide();
            _reviewView.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            _formCaller.Size = Size;
            _formCaller.Location = Location;
            Hide();
            _formCaller.Show();
        }
    }
}
