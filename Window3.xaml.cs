using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;


namespace RecipeApp_Part3
{
    public partial class Window3 : Window
    {
        //list to store entered ingredients
        public List<IngredientV> Ingredient { get; set; }




        //delegate to notify user on excess calory
        public delegate void CalorieExcess(string recipeName, int calories);




        public Window3()
        {
            InitializeComponent();
        }

        private void CalorieNotify(string recipeName, int calories)
        {
            MessageBox.Show($"Warning: Calories entered exceed 300 Cal",
                "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        //foodGrouplist
        private void FoodGroupList_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.IsChecked == true)
            {
                string selectedFG = radioButton.Content.ToString(); //select and display chosen radioBtn into string
                                                                    // Perform actions based on the selected food group



                MessageBox.Show($"Selected Food Group: " +
               $"  {selectedFG} ",
               "Food Group", MessageBoxButton.OK, MessageBoxImage.Information); //DISPLAY msgBox SELECTED FG to user 

                // MessageBox.Show("Selected Food Group: " + selectedFG, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnSaveRecipes_Click(object sender, RoutedEventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(tblRecipeName.Text) || string.IsNullOrWhiteSpace(tblNumbQuantity.Text)
                || string.IsNullOrWhiteSpace(UnitMeasurement.Text) || string.IsNullOrWhiteSpace(tblCalories.Text) || string.IsNullOrWhiteSpace(tblSteps.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save entered details
            string recipeName = tblRecipeName.Text;
            int numQuantity = Convert.ToInt32(tblNumbQuantity.Text);
            string Unit = UnitMeasurement.Text;
            int calories = Convert.ToInt32(tblCalories.Text);
            string steps = tblSteps.Text;
            string foodGroup = ((RadioButton)foodGroupList.Children
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.IsChecked == true))?.Content.ToString();



            // Check if calories exceed 300
            if (calories > 300)
            {
                CalorieNotify("", calories); //notifies user
                return;
            }

            // Display details in Window4
            Window4 window4 = new Window4(recipeName, numQuantity, Unit, calories, foodGroup, steps);
            window4.Show();


            // Clear input fields after saving
            tblRecipeName.Text = "";
            tblNumbQuantity.Text = "";
            UnitMeasurement.Text = "";
            tblCalories.Text = "";
            tblSteps.Text = "";
            foreach (RadioButton Rbtn in foodGroupList.Children.OfType<RadioButton>())
            {
                Rbtn.IsChecked = false;
            }



        }



        //public class of ingredients
        public class IngredientV
        {
            //ingredients props to be stored

            public string IngredientName { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }


            //initializing ingredient object using constructor 
            public IngredientV(string Ingredientname, double quantity, string unit, int calories, string foodGroup)
            {
                IngredientName = Ingredientname;
                Quantity = quantity;
                Unit = unit;
                Calories = calories;
                FoodGroup = foodGroup;

            }

        }















    }
}
