using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApp_Part3
{
    public partial class Window2 : Window
    {
        private string recipeName;
        public int numberOfIngredients { get; set; }
        public int numberOfSteps { get; set; }



        //initializing objects using a constructor(window2)
        public Window2(string name, int ingredients, int steps)
        {
            InitializeComponent();


            recipeName = name;
            numberOfIngredients = ingredients;
            numberOfSteps = steps;

        }



        // display a recipe name as wished
        private void slctChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOfRecipes.SelectedItem != null)
            {
                string clkRecipe = listOfRecipes.SelectedItem.ToString();
                // random cooking time between 15 and 60 minutes:
                int rdmCookingT = new Random().Next(15, 60); // Add random time as additional value
                MessageBox.Show($"You clicked on:  {clkRecipe}  " +
                    $"\nCooking time: {rdmCookingT} minutes", //display cooking time
                    "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }




        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Save the entered recipe name
            recipeName = tblRecipeName.Text;

            // Get the user added values
            numberOfIngredients = int.Parse(tblNumbOfIngredients.Text);
            numberOfSteps = int.Parse(tbNumberOfSteps.Text);





            // Save the entered number of ingredients
            if (int.TryParse(tblNumbOfIngredients.Text, out int ingredients))
            {
                numberOfIngredients = ingredients;
            }
            else
            {
                MessageBox.Show("Please enter a valid number for ingredients.");
                return; // Stops if input is invalid
            }

            // Save the entered number of steps
            if (int.TryParse(tbNumberOfSteps.Text, out int steps))
            {
                numberOfSteps = steps;
            }
            else
            {
                MessageBox.Show("Please enter a valid number for steps.");
                return; // Stop further processing if input is invalid
            }

         

            //Window3 nextWindow = new Window3(recipeName, numberOfIngredients, numberOfSteps);
      // Proceed to window 3
            Window3 w3 = new Window3();
            w3.Show();// redirect to window 3
            this.Close(); // close current window
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
           SelectTask Tback = new SelectTask();


            Tback.Show();// redirect to task window
            this.Close(); // close current window

        }

        private void AddRecipeNameButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = tblRecipeName.Text.Trim();
            if (!string.IsNullOrEmpty(recipeName))
            {
                listOfRecipes.Items.Add(recipeName);

                // Sort the ListBox items alphabetically:
                listOfRecipes.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));

                // Clears the TextBox 
                tblRecipeName.Clear();
            }
        }
    }
}
