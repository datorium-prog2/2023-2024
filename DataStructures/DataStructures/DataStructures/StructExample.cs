using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct PersonStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static bool operator <(PersonStruct a, PersonStruct b)
        {
            return a.Id < b.Id;
        }

        public static bool operator >(PersonStruct a, PersonStruct b)
        {
            return a.Id > b.Id;
        }

        public static PersonStruct operator +(PersonStruct a, PersonStruct b)
        {
            return new PersonStruct { Id = a.Id + b.Id};
        }
    }

    public class StructExample
    {
        public StructExample()
        {
            //Reference type
            Console.WriteLine("Reference type");
            int size = 2;
            var array = new string[size];
            PopulateArray(array, size);

            var array2 = new string[size];
            PopulateArray(array2, size);

            var isEqual = array == array2; // false
            Console.WriteLine(isEqual);
            var isArrayEqual = IsArrayEqual(array, array2); // true
            Console.WriteLine(isArrayEqual);


            //value type
            Console.WriteLine("Value type");
            var number = 5;
            var number2 = 5; //number2 = 5
            var isNumberEqual = number == number2; // true
            ChangeNumber(number); //number paliek nemainīgs
            //Console.WriteLine(number2);
            Console.WriteLine(isNumberEqual);





            // class example
            Console.WriteLine("Class example");
            var person1 = new Person()
            {
                Id = 1,
                Name = "Foo",
            };

            var person2 = new Person()
            {
                Id = 1,
                Name = "Foo",
            };
            var isPeopleEqual = person1.Equals(person2); // False
            Console.WriteLine(isPeopleEqual);

            //Struct example
            Console.WriteLine("Struct example");
            var personStruct1 = new PersonStruct()
            {
                Id = 1,
                Name = "Foo",
            };

            var personStruct2 = new PersonStruct()
            {
                Id = 1,
                Name = "Foo",
            };
            Console.WriteLine(personStruct1.Name);
            ChangeName(ref personStruct1); //Name paliek nemainīgs
            Console.WriteLine(personStruct1.Name);

            var isStructPeopleEqual = personStruct1.Equals(personStruct2); // True

            personStruct2.Id = 2;
            var isStructPeopleEqual2 = personStruct1.Equals(personStruct2); // false

            Console.WriteLine(isStructPeopleEqual);
        }

        private void ChangeName(ref PersonStruct personStruct1)
        {
            personStruct1.Name = "oskars";
        }

        private bool IsArrayEqual(string[] array, string[] array2)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void ChangeNumber(int number)
        {
            number = 10;
        }

        private void PopulateArray(string[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = $"{i} vērtība";
            }
        }
    }
}
