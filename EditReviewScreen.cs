using MAS_Final_Music_Store.Models;
using MAS_Final_Music_Store.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAS_Final_Music_Store
{
    public partial class EditReviewScreen : Form
    {
        private Review _modifiedReview;
        private MyReviewsScreen _prevScreen;

        public EditReviewScreen()
        {
            InitializeComponent();
        }

        public EditReviewScreen(Review review, MyReviewsScreen prevScreen)
        {
            InitializeComponent();
            _modifiedReview = review;
            richTextBox1.Text = review.Content;
            trackBar1.Value = (int)(review.Rating / 5 * 100);
            _prevScreen = prevScreen;
    }

    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void save_Click(object sender, EventArgs e)
        {
            int id = _modifiedReview.ReviewId;
            var reviewModifications = new Review
            {
                Content = richTextBox1.Text,
                Rating = 5.0 * trackBar1.Value / 100.0,
                Date = _modifiedReview.Date,
                Image = _modifiedReview.Image,
                WasEdited = true
            };

            ICollection<ValidationResult> results = null;

            if(!GlobalValidator.Validate(reviewModifications, out results))
            {
                MessageBox.Show("the content length must be in range [1;500] characters :)");
            }
            else 
            { 
                DbService.UpdateReview(id, reviewModifications);
                var reviewsFetched = DbService.FetchReviewsByCustomerId(_modifiedReview.CustomerId);

                _prevScreen.Size = Size;
                _prevScreen.Location = Location;
                _prevScreen.LoadReviews(reviewsFetched);
                _prevScreen.Show();
                Close();
             }

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            _prevScreen.Size = Size;
            _prevScreen.Location = Location;
            _prevScreen.Show();
            Close();
        }

        private void EditReviewScreen_Load(object sender, EventArgs e)
        {
            byte[] data = _modifiedReview.Image;
            if (data is null)
            {
                return;
            }
            pictureBox1.Image = GetImage(data);
        }

        private static Image GetImage(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
