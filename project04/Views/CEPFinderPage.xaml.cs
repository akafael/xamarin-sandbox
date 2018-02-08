using System;
using System.Collections.Generic;
using project04.Services;

using Xamarin.Forms;

namespace project04.Views
{
    public partial class CEPFinderPage : ContentPage
    {
        public CEPFinderPage()
        {
            InitializeComponent();
        }

        public async void OnZIPSearchAsync(Object sender, EventArgs e)
        {

            if (txtCEP.Text != null && txtCEP.Text.Length == 8)
            {
                // WebService
                lblResult.Text = await CEPWebService.FindCEP(txtCEP.Text);
                lblResult.TextColor = Color.Black;
            }
            else
            {
                lblResult.Text = "Invalid ZIP Code!";
                lblResult.TextColor = Color.Red;
            }
        }
    }
}
