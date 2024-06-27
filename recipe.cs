using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecipeApp_Part3.Window3;

namespace RecipeApp_Part3
{
    public class recipe
    {
        /// <summary>
        /// /getters and setters method for the recipe 
        /// </summary>
        
        public string Name { get; set; }
        public List<IngredientV>  Ingredients { get; set; }
        public List<Steps> steps { get; set; }

       
        public int Calories { get; set; }
        public string FoodGroup { get; set; }



      


    }









    public class Steps
    {
        public string StepsTofollow { get; set; }
    }
}
