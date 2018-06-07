using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GlazerCalc
{
    public sealed partial class MainPage : Page
    {
        bool heightIsValid = false;
        bool widthIsValid = false;
        bool tintSelected = false;

        double width, height, qty, woodLength, glassArea;
        string tint;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Selection_Changed_Tint(object sender, SelectionChangedEventArgs e)
        {
            if (null != tintInput.SelectedValue)
            {
                tintSelected = true;
            }
            else
            {
                tintSelected = false;
            }
        }

        private static bool checkIsNumber(string text)
        {
            Regex regex = new Regex("[0-9]+");
            return regex.IsMatch(text);
        }

        private void Text_Changed_Width(object sender, TextChangedEventArgs e)
        {
            if (checkIsNumber(widthInput.Text))  
            {
                widthIsValid = true;
            }
            else
            {
                widthIsValid = false;
            }
            // could also just use : if (Int32.TryParse(widthInput.Text))
            // but would require exception handling
        }

        private void Text_Changed_Height(object sender, TextChangedEventArgs e)
        {
            if (checkIsNumber(heightInput.Text))
            {
                heightIsValid = true;
            }
            else
            {
                heightIsValid = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (heightIsValid && widthIsValid && tintSelected)
            {
                // get height, width, tint and qty
                width = Double.Parse(widthInput.Text);
                height = Double.Parse(heightInput.Text);

                // requires casting : here are two ways to do it
                tint = ((ComboBoxItem)tintInput.SelectedItem).Content.ToString();
                // tint = (tintInput.SelectedItem as ComboBoxItem).Content.ToString();

                qty = Double.Parse(qtyValue.Text);
                // calculate length of wood frame : woodLength = 2 * ( width + height ) * 3.25
                woodLength = 2 * (width + height) * 3.25;
                // calculate area of glass : glassArea = 2 * ( width * height )
                glassArea = 2 * (width * height);
                // send values to display area with current date
                widthOutput.Text = width.ToString();
                heightOutput.Text = height.ToString();
                tintOutput.Text = tint;
                quantityOutput.Text = qty.ToString();
                woodLengthOutput.Text = woodLength.ToString();
                glassAreaOutput.Text = glassArea.ToString();
                dateOrdered.Text = DateTime.Now.ToString();
            }
        }
    }
}
