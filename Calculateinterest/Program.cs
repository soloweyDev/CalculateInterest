using System;

// Вычисление величины начисленных процентов для вклада.
// Если процентная ставка или вклад отрицательный,
// генерируется сообщение об ошибке.
namespace Calculateinterest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            decimal principal, interest, interestPaid, total;

            principal = InputData("вклад");
            interest = InputData("ставка");

            try
            {
                checked
                {
                    // Вычисляем сумму величины процентных начислений по вкладу
                    interestPaid = principal * (interest / 100);

                    // Вычисление общей суммы
                    total = principal + interestPaid;
                }

                // Вывод результатов
                ViewData(principal, interest, interestPaid, total);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Ожидание реакции пользователя
            Console.WriteLine("Haжмитe <Enter> дпя завершения программы...");
            Console.Read();
        }

        private static decimal InputData(string text)
        {
            decimal interest;
            string info = string.Empty, error = string.Empty, exception = string.Empty;

            switch (text)
            {
                case "вклад":
                    info = "процентную ставку";
                    error = "Пpoцeнтнaя ставка";
                    exception = "процентная ставка";
                    break;

                case "ставка":
                    info = "сумму вклада";
                    error = "Bклaд";
                    exception = "сумма вклaда";
                    break;

                default:
                    break;
            }

            do
            {
                // Приглашение дпя ввода процентной ставки
                Console.Write($"Bвeдитe {info}: ");
                string interestinput = Console.ReadLine();
                try
                {
                    interest = Convert.ToDecimal(interestinput);

                    // Убеждаемся, что процентная ставка не отрицательна
                    if (interest < 0)
                    {
                        Console.WriteLine($"{error} не может быть отрицательной.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Введенная {exception} не может быть представлена как число.");
                    interest = -1;
                }
            } while (interest < 0);
            return interest;
        }

        private static void ViewData(decimal principal, decimal interest, decimal interestPaid, decimal total)
        {
            Console.WriteLine();
            Console.WriteLine($"Bклaд = {principal}");
            Console.WriteLine($"Пpoцeнтная ставка = {interest}%");
            Console.WriteLine();
            Console.WriteLine($"Haчиcлeнныe проценты = {interestPaid}");
            Console.WriteLine($"Oбщaя сумма = {total}");
        }
    }
}
