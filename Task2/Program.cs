using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Task2
{
    public delegate void SortDelegate(string[] array, int a); // Создание делегата
    public class Student
    {
        public event SortDelegate SortProcess; // Создание события
        Exception exception = new Exception("Вы не ввели имя студента или имя студента слишком короткое"); // Добавление своего исключения по заданию
        public void EnterPerson() // Ввод студентов
        {
            string[] persons = new string[5];
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine("Введите имя {0} - го человека", i + 1);
                    persons[i] = Console.ReadLine();
                    if (persons[i].Length < 2) // Проверка на то, чтобы имя было введено
                    {
                        throw exception; // Срабатывает исключение
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Сработало исключение: " + ex.Message);
                }
            }
            ChooseSort(persons); // Вызывает метод, который вызовет событие
        }
        protected virtual void ChooseSort(string[] persons)
        {
            Console.WriteLine("Выберите способ сортировки: \n1. От А-Я \n2. От Я-А");
            try
            {
                int answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        {
                            int choose = answer;
                            SortProcess?.Invoke(persons, choose); // Вызывает делегат
                            break;

                        }
                    case 2:
                        {
                            int choose = answer;
                            SortProcess?.Invoke(persons, choose); // Вызывает делегат
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Выполняется задание 1: использование собственного типа исключений");
                            throw exception;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение: {0}\n Попробуйте еще раз", e.Message);
                ChooseSort(persons);
            }

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(); 
            student.SortProcess += Sorting; // Регистрация события
            student.EnterPerson(); 

        }
        //Перехватывает событие
        public static void Sorting(string[] persons, int answer)
        {
            string[] newPersons = new string[persons.Length];
            if (answer == 1)
            {
                Array.Sort(persons); // Сортировка от А до Я
                for (int i = 0; i < persons.Length; i++)
                {
                    newPersons[i] = persons[i];
                    Console.WriteLine(newPersons[i]);
                }
            }
            else
            {
                Array.Sort(persons); // Сортировка от Я до А
                for (int i = persons.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(persons[i]);
                }
            }

        }
    }
}
