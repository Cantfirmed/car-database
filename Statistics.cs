using System;
using System.Collections.Generic;
using System.Text;

namespace CarDatabase
{
    public class Statistics
    {
        CarDbContext context;
        public Statistics(CarDbContext context)
        {
            this.context = context;
        }

        public string GetNumberOfCarMakes()
        {
            string s = "";
            foreach (CarMake c in context.CarMakes)
            {
                int counter = 0;
                if (c.CarModels != null)
                {
                    foreach (CarModel cm in c.CarModels)
                    {
                        if (cm.Ownerships != null)
                        {
                            counter += cm.Ownerships.Count;
                        }
                    }
                    s += "CarMake: " + c.Make + "\nNumberOfOwnerships: " + counter + "\n\n";
                }
            }
            return s;
        }

        public string GetUnassignedCarModels()
        {
            string s = "";
            foreach (CarModel c in context.CarModels)
            {
                if (c.Ownerships == null)
                {
                 
                   s += "CarModel: " + c.Model + "\t\tNo assigned Ownership\n";
                    
                }
               
            }
            return s;
        }
    }
}
