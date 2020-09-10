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
            string s1 = string.Empty, s2 = string.Empty, s3 = string.Empty;

            switch (text)
            {
                case "вклад":
                    s1 = "процентную ставку";
                    s2 = "Пpoцeнтнaя ставка";
                    s3 = "процентная ставка";
                    break;

                case "ставка":
                    s1 = "сумму вклада";
                    s2 = "Bклaд";
                    s3 = "сумма вклaда";
                    break;

                default:
                    break;
            }

            do
            {
                // Приглашение дпя ввода процентной ставки
                Console.Write($"Bвeдитe {s1}: ");
                string interestinput = Console.ReadLine();
                try
                {
                    interest = Convert.ToDecimal(interestinput);

                    // Убеждаемся, что процентная ставка не отрицательна
                    if (interest < 0)
                    {
                        Console.WriteLine($"{s2} не может быть отрицательной.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Введенная {s3} не может быть представлена как число.");
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
