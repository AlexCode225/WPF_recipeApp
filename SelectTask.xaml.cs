using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeApp_Part3
{
    /// <summary>
    /// Interaction logic for SelectTask.xaml
    /// </summary>
    public partial class SelectTask : Window
    {
        public SelectTask()
        {
            InitializeComponent();
        }

        private void FindingCall_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CreateRecipe_Checked(object sender, RoutedEventArgs e)
        {

            if (TaskEnterRecipe.IsChecked == true)
            {

                MessageBox.Show(" You Chose CREATE NEW RECIPE");

               Window2 w2 = new Window2("My new Recipe", 2, 2);
                w2.Show();
                this.Close();

            }


        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {

            if (ExitApp.IsChecked == true)
            {

                MessageBox.Show(" Hope you enjoyed, Come back soon");
                this.Close();

            }
        }



     

     
    }
}
