﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int count = 0;
        private void btnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = " Você clicou " + count.ToString() + "Vezes";

        }
    }
}