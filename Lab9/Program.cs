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
                        Console.WriteLine($"Student {num} is {student.Name}. What would you like to know about {student.Name}?(enter hometown, favorite food, or favorite animal)");
                        input = Console.ReadLine();

                        if(!input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase) 
                            && !input.Equals("favorite food", StringComparison.InvariantCultureIgnoreCase)
                            && !input.Equals("favorite animal", StringComparison.InvariantCultureIgnoreCase))
                        { //if the input doesn't equal to "hometown" or "favorite food" throw to FormatException
                            throw new FormatException("That data does not exist.  Try again (hometown or favorite food)");
                        }
                    }
                    catch(FormatException ex)//FormatException reads the message above and shows as false/invalid
                    {
                        Console.WriteLine(ex.Message);
                        isInputValid = false;
                    }
                } while(!isInputValid);//user keep doing this until input is valid

                if(input.Equals("hometown", StringComparison.InvariantCultureIgnoreCase))
                { //if user inputs "hometown" display name and hometown
                    Console.WriteLine($"{student.Name}'s hometown is {student.Hometown}.");
                }
                else if(input.Equals("favorite food", StringComparison.InvariantCultureIgnoreCase))
                { //if user inputs "favorite food" display name and food
                    Console.Write($"{student.Name}'s favorite food is {student.FavoriteFood}.");
                } //People[num - 1,0]... displays row and columns of the students and their information
                else
                {
                    Console.WriteLine($"{student.Name}'s favorite animal is {student.FavoriteAnimal}.");
                }

                Console.WriteLine("Would you like to know more info about a student or add a student?(enter info or add)");
                input = Console.ReadLine();

                if (input.Equals("info", StringComparison.InvariantCultureIgnoreCase)) //if the input reads "yes" continue
                {
                    shouldContinue = true;
                }
                else
                {
                    shouldContinue = true;
                    AddStudent();
                }
            } while (shouldContinue);
            Console.ReadKey();
        }

        private static void AddStudent()
        {
            bool isValidInput = false;
            StudentInfo student = new StudentInfo();
            string input = "";

            do
            {
                Console.WriteLine("Enter student name: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a value");
                }
                else
                {
                    student.Name = input;
                    isValidInput = true;
                }
            } while (!isValidInput);

            isValidInput = false;

            do
            {
                Console.WriteLine("Enter student hometown: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a value");
                }
                else
                {
                    student.Hometown = input;
                    isValidInput = true;
                }
            } while (!isValidInput);

            isValidInput = false;

            do
            {
                Console.WriteLine("Enter student favorite food: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a value");
                }
                else
                {
                    student.FavoriteFood = input;
                    isValidInput = true;
                }
            } while (!isValidInput);

            do
            {
                Console.WriteLine("Enter student favorite animal: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a value");
                }
                else
                {
                    student.FavoriteAnimal = input;
                    isValidInput = true;
                }
            } while (!isValidInput);

            studentList.Add(student);

            studentList = SortStudentList(studentList);
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
                studentList.Add(student);
            }

            return studentList;
        }

        static string[,] People = new string[,]
        {
            {"Adriana", "New York", "French Toast", "Poodle"},
            {"Milton", "Atlanta", "Biscuts and Gravy", "Turle"},
            {"Marilyn", "Baltimore", "Fish", "Monkey"},
            {"Andrew", "Memphis", "Grits", "Giraffe"},
            {"John", "Las Vegas", "Tacos", "Coyote"},
            {"Johnny", "Austin", "T-Bone Steak", "Horse"},
            {"Keith", "Bismarck", "Fries", "Cheetah"},
            {"Chaz", "Los Angeles", "Salad", "Parrot"},
            {"Blake", "Detroit", "Bratwurst", "Crocodile"},
            {"Richard", "Boston", "Scallops", "Dolphin"},
            {"Julia", "El Paso", "Chicken Wings", "Donkey"},
            {"Bill", "San Antonio", "BBQ", "Komodo Dragon"},
            {"Louis", "Buffalo", "Tiramisu", "Snake"},
            {"Zoey", "Newark", "Spring Roll", "Panda"},
            {"Francis", "Seattle", "Quiche", "Owl"},
            {"Rochelle", "St.Louis", "Chicken Nuggets", "Rooster"},
            {"Nick", "San Fransico", "Dulce De Leche", "Panther"},
            {"Ellis", "Kansas City", "Waffles", "Hawk"},
            {"Darrel", "Chicago", "Hotdogs", "Lion"},
            //populate list using collections initializer
        };

        static List<StudentInfo> studentList;

    }
}
