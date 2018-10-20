using Lab9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            string input = "";
            bool isInputValid = false;
            bool shouldContinue = false;
            List<StudentInfo> studentList;
            StudentInfo student = null;

            studentList = PopulateStudentList();

            studentList = SortStudentList(studentList);

            do
            {
                shouldContinue = false;

                do
                {
                    try
                    {
                        isInputValid = true;
                        Console.WriteLine("Welcome to our C# class! Which student would you like to learn more about? (enter a number 1-20:)");
                        input = Console.ReadLine();
                        num = int.Parse(input);//declared the students as a number to get information
                        student = studentList[num - 1];
                    }
                    catch (IndexOutOfRangeException ex)//caught that the user input an invalid number
                    {
                        Console.WriteLine("That student does not exist, try again (1-20)");
                        isInputValid = false;//user has to type valid number
                    }
                } while (!isInputValid);//keep doing while invalid number

                do
                {
                    try
                    {
                        Console.WriteLine("Student {0} is {1}. What would you like to know about {1}?(enter hometown or favorite food)", num, People[num - 1, 0]);
                        Console.WriteLine($"Student {num} is {student.Name}. What would you like to know about {student.Name}?(enter hometown or favorite food)");
                        input = Console.ReadLine();

                        if (!input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase) && !input.Equals("favorite food", StringComparison.InvariantCultureIgnoreCase))
                        { //if the input doesn't equal to "hometown" or "favorite food" throw to FormatException
                            throw new FormatException("That data does not exist.  Try again (hometown or favorite food)");
                        }
                    }
                    catch (FormatException ex)//FormatException reads the message above and shows as false/invalid
                    {
                        Console.WriteLine(ex.Message);
                        isInputValid = false;
                    }
                } while (!isInputValid);//user keep doing this until input is valid

                if (input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase))
                { //if user inputs "hometown" display name and hometown
                    Console.WriteLine($"{student.Name}'s hometown is {student.Hometown}.");
                }
                else
                { //if user inputs "favorite food" display name and food
                    Console.Write("{0}'s favorite food is {1} ", People[num - 1, 0], People[num - 1, 2]);
                    Console.Write($"{student.Name}'s favorite food is {student.FavoriteFood}.");
                } //People[num - 1,0]... displays row and columns of the students and their information

                Console.WriteLine("Would you like to know more students?(enter yes or no)");
                input = Console.ReadLine();

                if (input.Equals("yes", StringComparison.InvariantCultureIgnoreCase)) //if the input reads "yes" continue
                {
                    shouldContinue = true;
                }
            } while (shouldContinue);
            Console.ReadKey();
        }

        private static List<StudentInfo> SortStudentList(List<StudentInfo> studentList)
        {
            return studentList.OrderBy(s => s.Name).ToList();
        }

        private static List<StudentInfo> PopulateStudentList()
        {
            List<StudentInfo> studentList = new List<StudentInfo>();

            for (int i = 0; i < People.Length; i++)
            {
                StudentInfo student = new StudentInfo();
                student.Name = People[i, 0];
                student.Hometown = People[i, 1];
                student.FavoriteFood = People[i, 2];
            }

            return studentList;
        }

        static string[,] People = new string[,]
        {
            {"Adriana", "New York", "French Toast"},
            {"Milton", "Atlanta", "Biscuts and Gravy"},
            {"Marilyn", "Baltimore", "Fish"},
            {"Andrew", "Memphis", "Grits"},
            {"John", "Las Vegas", "Tacos"},
            {"Johnny", "Austin", "T-Bone Steak"},
            {"Keith", "Bismarck", "Fries"},
            {"Chaz", "Los Angeles", "Salad"},
            {"Blake", "Detroit", "Bratwurst"},
            {"Richard", "Boston", "Scallops"},
            {"Julia", "El Paso", "Chicken Wings"},
            {"Bill", "San Antonio", "BBQ"},
            {"Louis", "Buffalo", "Tiramisu"},
            {"Zoey", "Newark", "Spring Roll"},
            {"Francis", "Seattle", "Quiche"},
            {"Rochelle", "St.Louis", "Chicken Nuggets"},
            {"Nick", "San Fransico", "Dulce De Leche"},
            {"Ellis", "Kansas City", "Waffles"},
            {"Darrel", "Chicago", "Hotdogs"},
            //populate array using collections initializer
        };
    }
}
