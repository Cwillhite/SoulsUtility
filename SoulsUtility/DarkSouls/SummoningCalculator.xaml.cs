using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoulsUtility.DarkSouls
{
    public partial class SummoningCalculator : ContentPage
    {
        public SummoningCalculator()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var val = Convert.ToInt32(level.Text);
            level.Text = (Button)sender == plus ? (val + 1).ToString() : (val - 1).ToString();
            Validate();
        }

        void Numeric_Click(object sender, System.EventArgs e)
        {
            var pressed = (Button)sender;
            if(pressed.Text != "del")
            {
                level.Text += pressed.Text;
            } else {
                var length = Convert.ToInt32(level.Text?.Length);
                if(length > 1) {
                    level.Text = level.Text.Remove(length - 1);
                } else {
                    level.Text = null;
                    min.Text = "0";
                    max.Text = "0";
                }
            }

            Validate();
        }

        void Validate()
        {
            var enteredLevel = Convert.ToInt32(level.Text); 
            var modifier = 10 + enteredLevel / 10;
            minus.IsEnabled = enteredLevel > 1;
            min.Text = enteredLevel - modifier > 0 ? (enteredLevel - modifier).ToString() : "1";
            max.Text = (enteredLevel + modifier).ToString();
        }
    }
}
