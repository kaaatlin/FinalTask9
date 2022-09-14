using System;

/*
 * Создайте свой тип исключения.
 * Сделайте массив из пяти различных видов исключений, включая собственный тип исключения. 
 * Реализуйте конструкцию TryCatchFinally, в которой будет итерация на каждый тип исключения (блок finally по желанию).
 * В блоке catch выведите в консольном сообщении текст исключения.
 * Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек. 
 * Сортировка должна происходить при помощи события.
 * Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
 * Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.
 */
namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception exception = new Exception("Собственное исключение");
            Exception exception1 = new FormatException();
            Exception exception2 = new IndexOutOfRangeException();
            Exception exception3 = new TimeoutException();
            Exception exception4 = new ArgumentException();
            Exception[] array = { exception, exception1, exception2, exception3, exception4 };
            foreach (Exception e in array)
            {
                try
                {
                    throw e;
                }
                catch
                {
                    Console.WriteLine(e.GetType());
                    Console.WriteLine("Исключение: " + e.Message);
                }
            }

        }
    }
}
