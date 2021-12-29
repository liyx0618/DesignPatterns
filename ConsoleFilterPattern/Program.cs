using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//过滤模式
namespace ConsoleFilterPattern
{
    public class Person
    {
        private String name;
        private String gender;
        private String maritalStatus;

        public Person(String name, String gender, String maritalStatus)
        {
            this.name = name;
            this.gender = gender;
            this.maritalStatus = maritalStatus;
        }

        public String getName()
        {
            return name;
        }

        public String getGender()
        {
            return gender;
        }

        public String getMaritalStatus()
        {
            return maritalStatus;
        }
    }

    public interface Criteria
    {
        List<Person> meetCriteria(List<Person> persons);
    }

    public class CriteriaMale : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> malePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getGender().Equals("MALE", StringComparison.CurrentCultureIgnoreCase))
                {
                    malePersons.Add(person);
                }
            }
            return malePersons;
        }
    }

    public class CriteriaFemale : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> femalePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getGender().Equals("FEMALE", StringComparison.CurrentCultureIgnoreCase))
                {
                    femalePersons.Add(person);
                }
            }
            return femalePersons;
        }
    }

    public class CriteriaSingle : Criteria
    {
        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> singlePersons = new List<Person>();
            foreach (Person person in persons)
            {
                if (person.getMaritalStatus().Equals("SINGLE", StringComparison.CurrentCultureIgnoreCase))
                {
                    singlePersons.Add(person);
                }
            }
            return singlePersons;
        }
    }

    public class AndCriteria : Criteria
    {
        private Criteria criteria;
        private Criteria otherCriteria;

        public AndCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaPersons = criteria.meetCriteria(persons);
            return otherCriteria.meetCriteria(firstCriteriaPersons);
        }
    }

    public class OrCriteria : Criteria
    {
        private Criteria criteria;
        private Criteria otherCriteria;

        public OrCriteria(Criteria criteria, Criteria otherCriteria)
        {
            this.criteria = criteria;
            this.otherCriteria = otherCriteria;
        }

        public List<Person> meetCriteria(List<Person> persons)
        {
            List<Person> firstCriteriaItems = criteria.meetCriteria(persons);
            List<Person> otherCriteriaItems = otherCriteria.meetCriteria(persons);

            foreach (Person person in otherCriteriaItems)
            {
                if (!firstCriteriaItems.Contains(person))
                {
                    firstCriteriaItems.Add(person);
                }
            }
            return firstCriteriaItems;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            persons.Add(new Person("Robert", "Male", "Single"));
            persons.Add(new Person("John", "Male", "Married"));
            persons.Add(new Person("Laura", "Female", "Married"));
            persons.Add(new Person("Diana", "Female", "Single"));
            persons.Add(new Person("Mike", "Male", "Single"));
            persons.Add(new Person("Bobby", "Male", "Single"));

            Criteria male = new CriteriaMale();
            Criteria female = new CriteriaFemale();
            Criteria single = new CriteriaSingle();
            Criteria singleMale = new AndCriteria(single, male);
            Criteria singleOrFemale = new OrCriteria(single, female);

            Console.WriteLine("Males: ");
            printPersons(male.meetCriteria(persons));

            Console.WriteLine("\nFemales: ");
            printPersons(female.meetCriteria(persons));

            Console.WriteLine("\nSingle Males: ");
            printPersons(singleMale.meetCriteria(persons));

            Console.WriteLine("\nSingle Or Females: ");
            printPersons(singleOrFemale.meetCriteria(persons));

            Console.ReadKey();
        }

        public static void printPersons(List<Person> persons)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Person person in persons)
            {
                string str = string.Format("Person:[ Name:{0}, Gender:{1}, Marital Status:{2} ]", person.getName(), person.getGender(), person.getMaritalStatus());
                Console.WriteLine(str);
            }
        }
    }
}