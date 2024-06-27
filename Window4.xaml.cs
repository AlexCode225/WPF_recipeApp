using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO.Ports;
using System.Runtime.Remoting.Messaging;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace RecipeApp_Part3
{
    public partial class Window4 : Window
    {
        public Window4(string recipeName, int numQuantity, string UnitMeasurement, int calories, string foodGroup, string steps)
        {
            InitializeComponent();
          


            // Set the title of the window
            this.Title = "Ingredient Details";

            // Create a object stack panel to hold the details
            StackPanel stackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical, //set to vertical
                Margin = new Thickness(20)
            };

            // Add the recipe name
            TextBlock recipeNameBlock = new TextBlock
            {
                Text = $"Ingredient Name: {recipeName}",
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(recipeNameBlock);//save entered Ingredient name details to stackpanel

            // Add the number of ingredients
            TextBlock QuantityBlock = new TextBlock
            {
                Text = $"Quantity: {numQuantity}",
                FontSize = 18,
                Foreground = Brushes.DarkGreen,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(QuantityBlock);//save entered quantity ingredients details to stackpanel

            // Add the number of steps
            TextBlock numOfStepsBlock = new TextBlock
            {
                Text = $"Unit : {UnitMeasurement}",
                FontSize = 18,
                Foreground = Brushes.DarkGreen,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(numOfStepsBlock); ////save entered unit details to stackpanel

            // Add the calories
            TextBlock caloriesBlock = new TextBlock
            {
                Text = $"Calories: {calories}",
                FontSize = 18,
                Foreground = Brushes.DarkGreen,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(caloriesBlock);//save entered calories details to stackpanel

            // Add the food group
            TextBlock foodGroupBlock = new TextBlock
            {
                Text = $"Food Group: {foodGroup}",
                FontSize = 18,
                Foreground = Brushes.DarkGreen,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(foodGroupBlock); //save entered foodgroup details to stackpanel





            // Add the steps to follow
            TextBlock StepsBlock = new TextBlock
            {
                Text = $"Steps to Follow: {steps}",
                FontSize = 24,
                FontWeight = FontWeights.Light,
                Foreground = Brushes.DarkOrange,
                Margin = new Thickness(0, 0, 0, 10)
            };
            stackPanel.Children.Add(StepsBlock);// save entered steps details to stackpanel




            // Set the content of the window to the stack panel
            this.Content = stackPanel;
        }


        //use of dictiomary to handle scale factor
        private Dictionary<string, double> originalQuantities = new Dictionary<string, double>();




        //method to reset factor to original values
        private void resetFactor_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in originalQuantities)
            {
                // Reset  ingredient quantities to their original values

                Console.WriteLine($"{item.Key}: {item.Value}"); // dictionary uses key and value pair 
            }
        }
      

        //method to scale factor
        private void scaleFactor_Click(object sender, RoutedEventArgs e)
        {
            if (CbxScaleF.SelectedItem != null)
            {
                double scaleFactor = double.Parse(((ComboBoxItem)CbxScaleF.SelectedItem).Content.ToString());

                foreach (var item in originalQuantities)
                {


                    // Update the ingredient quantities with the selected scale factor
                    Console.WriteLine($"{item.Key}: {item.Value * scaleFactor}");
                }
            }
        }

        private void CbxFactorschanged(object sender, SelectionChangedEventArgs e)
        {
            // Save the original quantities when the scale factor is selected
            originalQuantities.Clear();


        }

        private void txtFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFilter.Text == "Filter by Name or Food Group")
            {
                txtFilter.Text = string.Empty;
                txtFilter.Foreground = Brushes.Black;
            }
        }

        private void txtFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                txtFilter.Text = "Filter by Name or Food Group";
                txtFilter.Foreground = Brushes.Gray;
            }
        }

    }
}




