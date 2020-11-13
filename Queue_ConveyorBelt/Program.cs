using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_ConveyorBelt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here we create our used queues
            Queue<Item> conveyorBelt = new Queue<Item>();
            Queue<Item> constructionMold = new Queue<Item>();

            // A do-while loop to keep the GUImenu method running
            do
            {
                GUImenu();
            } while (true); ;

            // A method which prints our GUI and then calls another method
            void GUImenu()
            {
                Console.WriteLine(@"
                                    ______________________________________
                                    |                                    |
                                    |    ###########################     |
                                    |          FACTORY CONSOLE           |
                                    |    ###########################     |
                                    |____________________________________|
                                    |                                    |
                                    |         CHOOSE AN ACTION           |
                                    |____________________________________|
                                    |                                    |
                                    |   1. Add new item to conveyor belt |
                                    |                                    |
                                    |   2. Remove item from conveyor belt|
                                    |                                    |
                                    |   3. Show the amount of items on   |
                                    |      the conveyor belt             |
                                    |                                    |
                                    |   4. Show the lightes and heaviest |
                                    |      on the conveyor belt          |
                                    |                                    |
                                    |   5. Show next item                |
                                    |                                    |
                                    |   6. Print all items currently     |
                                    |      on the conveyor belt          |
                                    |                                    |
                                    |   7.Leave the terminal             |
                                    |____________________________________|"
                );
                UserChoice();
            }

            // A method that contains the multiple choices the user can make 
            void UserChoice()
            {
                // Temporary string to store the users choice
                string choice = Console.ReadLine();

                // This switch statement makes it possible for the user to make a choice
                // Each choice calls a different method
                switch (choice)
                {
                    case "1":
                        AddItem();
                        break;

                    case "2":
                        RemoveItem();
                        break;

                    case "3":
                        PrintAmountOfItems();
                        break;

                    case "4":
                        ShowLightestAndHeaviestItems();
                        break;

                    case "5":
                        ShowNextItem();
                        break;

                    case "6":
                        PrintAllItems();
                        break;

                    case "7":
                        ExitProgram();
                        break;

                    default:
                        WrongInput();
                        break;
                }
            }

            #region Add Item
            // This method adds and item to the conveyorBelt queue
            void AddItem()
            {
                // Here we create an object with empty values and stores it in our constructionMold queue
                constructionMold.Enqueue(new Item("", "", 0));

                // Here we call the method that determines the "Material" value and adds it to our new object
                // and we have a temporary string to store the value
                ChooseMaterial();
                string tempMaterial = constructionMold.Peek().Material;

                // Here we call the method that determines the "TypeOfShape" value and adds it to our new object
                // and we have a temporary string to store the value
                ChooseShape();
                string tempShape = constructionMold.Peek().TypeOfShape;

                // Here we determine the "WeightInGrams" value of our object, by passing our 2 temporary strings to a method that calculates the value, which we then parse into an integer
                constructionMold.Peek().WeightInGrams = int.Parse(constructionMold.Peek().DetermineWeight(tempMaterial, tempShape));

                // Here we clear our console, and prints the three values of our newly created object
                Console.Clear();
                Console.WriteLine($"Added {constructionMold.Peek().Material} {constructionMold.Peek().TypeOfShape} to the conveyor belt. Weight {constructionMold.Peek().WeightInGrams} grams.");

                // Here we take our new object and transfers it from the constructionMold queue, to the conveyorBelt queue
                // Then we empty our constructionMold queue
                conveyorBelt.Enqueue(constructionMold.Peek());
                constructionMold.Dequeue();

                Console.ReadLine();
            }

            // In this method we choose the "Material" value for a new object
            void ChooseMaterial()
            {
                Console.Clear();

                Console.WriteLine(@"
                                    ______________________________________
                                    |                                    |
                                    |    ###########################     |
                                    |          FACTORY CONSOLE           |
                                    |    ###########################     |
                                    |____________________________________|
                                    |                                    |
                                    |         CHOOSE A MATERIAL          |
                                    |____________________________________|
                                    |                                    |
                                    |                                    |
                                    |   1. Iron                          |
                                    |                                    |
                                    |   2. Copper                        |
                                    |                                    |
                                    |   3. Steel                         |
                                    |                                    |
                                    |   4. Aluminium                     |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |____________________________________|"
                );

                string tempMaterial = Console.ReadLine().ToString();

                // In this If-statement we check if the user-input is a valid response
                if (tempMaterial == "1" || tempMaterial == "2" || tempMaterial == "3" || tempMaterial == "4")
                {
                    // If the input is a valid response, we then pass on the input to the method "DetermineMaterial" in order to get the corresponding preset value from the object class
                    // and pass it on to the object
                    constructionMold.Peek().Material = constructionMold.Peek().DetermineMaterial(tempMaterial);
                }
                else
                {
                    // Here we call the "WrongInput" method, which only runs if the input is invalid, and then we run the "ChooseMaterial" method again to get a correct input
                    WrongInput();
                    ChooseMaterial();
                }
            }

            // In this method we choose the "TypeOfShape" value for a new object
            void ChooseShape()
            {
                Console.Clear();

                Console.WriteLine(@"
                                    ______________________________________
                                    |                                    |
                                    |    ###########################     |
                                    |          FACTORY CONSOLE           |
                                    |    ###########################     |
                                    |____________________________________|
                                    |                                    |
                                    |           CHOOSE A SHAPE           |
                                    |____________________________________|
                                    |                                    |
                                    |                                    |
                                    |   1. Screw                         |
                                    |                                    |
                                    |   2. Rod                           |
                                    |                                    |
                                    |   3. Cube                          |
                                    |                                    |
                                    |   4. Nail                          |
                                    |                                    |
                                    |   5. Bolt                          |
                                    |                                    |
                                    |   6. Sheet                         |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |                                    |
                                    |____________________________________|"
                );

                string tempShape = Console.ReadLine().ToString();

                // In this If-statement we check if the user-input is a valid response
                if (tempShape == "1" || tempShape == "2" || tempShape == "3" || tempShape == "4" || tempShape == "5" || tempShape == "6")
                {
                    // If the input is a valid response, we then pass on the input to the method "DetermineShape" in order to get the corresponding preset value from the object class
                    // and pass it on to the object
                    constructionMold.Peek().TypeOfShape = constructionMold.Peek().DetermineShape(tempShape);
                }
                else
                {
                    // Here we call the "WrongInput" method, which only runs if the input is invalid, and then we run the "ChooseShape" method again to get a correct input
                    WrongInput();
                    ChooseShape();
                }
            }
            #endregion

            // In this method we remove an item from the "conveyorBelt" queue
            void RemoveItem()
            {
                Console.Clear();

                // This If-statement checks if the "conveyorBelt" queue is empty
                if (conveyorBelt.Count == 0)
                {
                    // If the "conveyorBelt" queue is empty you get a message
                    Console.WriteLine("Conveyor belt is currently empty.");
                }
                else
                {
                    // If the "conveyorBelt" queue is NOT empty, then we remove the next item in line
                    Console.WriteLine($"Removed {conveyorBelt.Peek().Material} {conveyorBelt.Peek().TypeOfShape}");
                    conveyorBelt.Dequeue();
                }

                Console.ReadLine();
            }

            // This method prints how many items currently in the "conveyorBelt" queue, including the total of all the "WeightInGrams" values from every object in the queue
            void PrintAmountOfItems()
            {
                Console.Clear();

                int totalWeight = 0;

                foreach (Item item in conveyorBelt)
                {
                    totalWeight = totalWeight + item.WeightInGrams;
                }

                Console.WriteLine($"The amount of items on the conveyor belt is: {conveyorBelt.Count}, total weight of the items: {totalWeight}");

                Console.ReadLine();
            }

            // In this method we determine which items have the highest and the lowest "WeightInGrams" values
            void ShowLightestAndHeaviestItems()
            {
                Console.Clear();

                if (conveyorBelt.Count == 0)
                {
                    Console.WriteLine("Conveyor belt is currently empty.");
                }
                else
                {
                    int minimumWeight = conveyorBelt.Peek().WeightInGrams;
                    string minMaterial = conveyorBelt.Peek().Material;
                    string minShape = conveyorBelt.Peek().TypeOfShape;

                    int maximumWeight = conveyorBelt.Peek().WeightInGrams;
                    string maxMaterial = conveyorBelt.Peek().Material;
                    string maxShape = conveyorBelt.Peek().TypeOfShape;

                    foreach (Item item in conveyorBelt)
                    {
                        if (item.WeightInGrams < minimumWeight)
                        {
                            minimumWeight = item.WeightInGrams;
                            minMaterial = item.Material;
                            minShape = item.TypeOfShape;
                        }
                        else if (item.WeightInGrams > maximumWeight)
                        {
                            maximumWeight = item.WeightInGrams;
                            maxMaterial = item.Material;
                            maxShape = item.TypeOfShape;
                        }
                    }

                    Console.WriteLine($"The lightest item on the conveyor belt is {minMaterial} {minShape}, it weighs {minimumWeight} grams");
                    Console.WriteLine($"The heaviest item on the conveyor belt is {maxMaterial} {maxShape}, it weighs {maximumWeight} grams");
                    Console.ReadLine();
                }
            }

            // This method is used to display the next item in the "conveyorBelt" queue, including the values of the object
            void ShowNextItem()
            {
                Console.Clear();

                if (conveyorBelt.Count == 0)
                {
                    Console.WriteLine("Conveyor belt is currently empty.");
                }
                else
                {
                    Console.WriteLine($"The next item on the conveyor belt is: {conveyorBelt.Peek().Material} {conveyorBelt.Peek().TypeOfShape}, which weighs {conveyorBelt.Peek().WeightInGrams} grams");
                }

                Console.ReadLine();
            }

            // In this method we print all items in the "conveyorBelt" queue including the values of each object, this is done through a foreach-loop
            void PrintAllItems()
            {
                Console.Clear();
                Console.WriteLine("All registrered items currently on the conveyor belt:");

                foreach (Item item in conveyorBelt)
                {
                    Console.WriteLine($" {item.Material} {item.TypeOfShape}, weight: {item.WeightInGrams} grams");
                }

                Console.ReadLine();
            }

            // Here we exit the application
            void ExitProgram()
            {
                Console.Clear();
                Console.WriteLine("Goodbye");

                Environment.Exit(0);
            }

            // This is used when the user gives wrongful inputs
            void WrongInput()
            {
                Console.Clear();
                Console.WriteLine("**************************** WRONG INPUT ****************************************");
                Console.ReadLine();
            }
        }
    }
}