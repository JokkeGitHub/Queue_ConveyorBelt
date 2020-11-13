using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_ConveyorBelt
{
    class Item
    {
        private string _material;
        private string _typeOfShape;
        private int _weightInGrams;

        // In this region, we have all the encapsulations used by the object class
        #region Encapsulations
        public string Material
        {
            get
            {
                return this._material;
            }
            set
            {
                this._material = value;
            }
        }

        public string TypeOfShape
        {
            get
            {
                return this._typeOfShape;
            }
            set
            {
                this._typeOfShape = value;
            }
        }

        public int WeightInGrams
        {
            get
            {
                return this._weightInGrams;
            }
            set
            {
                this._weightInGrams = value;
            }
        }
        #endregion

        // Here we have our constructor
        public Item(string _material, string _typeOfShape, int _weightInGrams)
        {
            Material = _material;
            TypeOfShape = _typeOfShape;
            WeightInGrams = _weightInGrams;
        }

        // In this method, we are passed on a string from a user input, the method then determines the return value based on the input
        public string DetermineMaterial(string material)
        {
            if (material == "1")
            {
                material = "Iron";
            }
            else if (material == "2")
            {
                material = "Copper";
            }
            else if (material == "3")
            {
                material = "Steel";
            }
            else
            {
                material = "Aluminium";
            }
            return material;
        }

        // In this method, we are passed on a string from a user input, the method then determines the return value based on the input
        public string DetermineShape(string shape)
        {
            if (shape == "1")
            {
                shape = "Screw";
            }
            else if (shape == "2")
            {
                shape = "Rod";
            }
            else if (shape == "3")
            {
                shape = "Cube";
            }
            else if (shape == "4")
            {
                shape = "Nail";
            }
            else if (shape == "5")
            {
                shape = "Bolt";
            }
            else
            {
                shape = "Sheet";
            }
            return shape;
        }

        // This string method is used to determine our "WeightInGrams" integer by giving our temporary integers values based on the input we are passed
        // Then we calculate and transform the result to a string and returns it
        public string DetermineWeight(string material, string shape)
        {
            int mass = 0;
            int size = 0;

            switch (material)
            {
                case "Iron":
                    mass = 55;
                    break;

                case "Copper":
                    mass = 63;
                    break;

                case "Steel":
                    mass = 58;
                    break;

                case "Aluminium":
                    mass = 23;
                    break;

                default:
                    break;
            }

            switch (shape)
            {
                case "Screw":
                    size = 3;
                    break;

                case "Rod":
                    size = 9;
                    break;

                case "Cube":
                    size = 5;
                    break;

                case "Nail":
                    size = 2;
                    break;

                case "Bolt":
                    size = 4;
                    break;

                case "Sheet":
                    size = 11;
                    break;

                default:
                    break;
            }

            string weight = (mass * size).ToString();
            return weight;
        }
    }
}
