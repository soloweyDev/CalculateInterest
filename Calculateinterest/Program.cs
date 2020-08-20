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

            do
            {
                // Приглашение дпя ввода вклада
                Console.Write("Bвeдитe сумму вклада: ");
                string principalinput = Console.ReadLine();
                try
                {
                    principal = Convert.ToDecimal(principalinput);

                    // Убеждаемся, что вклад не отрицателен
                    if (principal < 0)
                    {
                        Console.WriteLine("Bклaд не может быть отрицательным.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введенная сумма не может быть представлена как число.");
                    principal = -1;
                }
            } while (principal < 0);

            do
            {
                // Приглашение дпя ввода процентной ставки
                Console.Write("Bвeдитe процентную ставку: ");
                string interestinput = Console.ReadLine();
                try
                {
                    interest = Convert.ToDecimal(interestinput);

                    // Убеждаемся, что процентная ставка не отрицательна
                    if (interest < 0)
                    {
                        Console.WriteLine("Пpoцeнтнaя ставка не может быть отрицательной.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Введенная процентная ставка не может быть представлена как число.");
                    interest = -1;
                }
            } while (interest < 0);

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
                Console.WriteLine();
                Console.WriteLine($"Bклaд = {principal}");
                Console.WriteLine($"Пpoцeнтная ставка = {interest}%");
                Console.WriteLine();
                Console.WriteLine($"Haчиcлeнныe проценты = {interestPaid}");
                Console.WriteLine($"Oбщaя сумма = {total}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Ожидание реакции пользователя
            Console.WriteLine("Haжмитe <Enter> дпя завершения программы...");
            Console.Read();
        }
    }
}
