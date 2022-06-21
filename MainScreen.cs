using MAS_Final_Music_Store.Models;
using MAS_Final_Music_Store.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MAS_Final_Music_Store
{
    public partial class MainScreen : Form
    {
        private MyReviewsScreen _reviewsView;
        private MyInstrumentScreen _myInstrumentsView;

        public MainScreen()
        {
            InitializeComponent();
            _reviewsView = new MyReviewsScreen(this);
            _reviewsView.SetLabel(" for not");
            _myInstrumentsView = new MyInstrumentScreen(this);
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _myInstrumentsView.Size = Size;
            _myInstrumentsView.Location = Location;
            _myInstrumentsView.LoadData(
                DbService.FetchInstrumentsBoughtByCustomerId(Program.GlobalCustomer.PersonId), 
                DbService.FetchReviewsByCustomerId(Program.GlobalCustomer.PersonId)
                );
            Hide();
            _myInstrumentsView.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var reviewsView = new MyReviewsScreen(this, DbService.FetchReviewsByCustomerId(Program.GlobalCustomer.PersonId));
            _reviewsView.Size = Size;
            _reviewsView.Location = Location;
            _reviewsView.LoadReviews(DbService.FetchReviewsByCustomerId(Program.GlobalCustomer.PersonId));
            Hide();
            _reviewsView.Show();
            
        }
    }
}
