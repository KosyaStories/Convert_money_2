using System;

namespace Convert_money_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double walletRub;
            double walletUsd;
            double walletEur;

            double rubToUsd = 70.4, usdToRub = 79.4;
            double rubToEur = 75.4, eurToRub = 84.4;
            double usdToEur = 1.05, eurToUsd = 0.94;

            double canToSolvency;
            string exchangeOperation;

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Курсы Валют на сегодня:");
            Console.WriteLine($"Покупка рубля - USD: {rubToUsd}, EUR: {rubToEur}");
            Console.WriteLine($"Продажа рубля - USD: {usdToRub}, EUR: {eurToRub}");
            Console.WriteLine($"Покупка/продажа доллара - EUR: {usdToEur} / {eurToUsd}");

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Добро пожаловать в наш обменник валют!");
            Console.Write("Введите баланс рублей: ");
            walletRub = Convert.ToSingle(Console.ReadLine());
            if (walletRub < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            Console.Write("Введите баланс долларов: ");
            walletUsd = Convert.ToSingle(Console.ReadLine());
            if (walletUsd < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            Console.Write("Введите баланс евро: ");
            walletEur = Convert.ToSingle(Console.ReadLine());
            if (walletEur < 0)
            {
                WriteError("Введено недопустимое значение.");
            }
            if (walletRub < 0 || walletUsd < 0 || walletEur < 0)
            {
                WriteError("Ошибка операции.");
            }
            else
            {
                Console.WriteLine("Выберите необходимую операцию.");
                Console.WriteLine("1 - обмен рублей в доллары.");
                Console.WriteLine("2 - обмен долларов в рубли.");
                Console.WriteLine("3 - обмен рублей в евро.");
                Console.WriteLine("4 - обмен евро в рубли.");
                Console.WriteLine("5 - обмен долларов в евро.");
                Console.WriteLine("6 - обмен евро в доллары.");
                Console.Write("Ваш выбор: ");
                exchangeOperation = Console.ReadLine();
                Console.Write("Сколько валюты желаете обменять? - ");
                canToSolvency = Convert.ToSingle(Console.ReadLine());
                if (walletRub >= canToSolvency && walletUsd >= canToSolvency && walletEur >= canToSolvency && canToSolvency > 0)
                {
                    switch (exchangeOperation)
                    {
                        case "1":
                            walletRub -= canToSolvency;
                            walletUsd += canToSolvency / rubToUsd;
                            break;
                        case "2":
                            walletUsd -= canToSolvency;
                            walletRub += canToSolvency * usdToRub;
                            break;
                        case "3":
                            walletRub -= canToSolvency;
                            walletEur += canToSolvency / rubToEur;
                            break;
                        case "4":
                            walletEur -= canToSolvency;
                            walletRub += canToSolvency * eurToRub;
                            break;
                        case "5":
                            walletUsd -= canToSolvency;
                            walletEur += canToSolvency / usdToEur;
                            break;
                        case "6":
                            walletEur -= canToSolvency;
                            walletUsd += canToSolvency * eurToUsd;
                            break;
                        default:
                            Console.WriteLine("Выбрана неверная операция.");
                            break;
                    }
                }
                else
                {
                    WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
                }
                Console.WriteLine($"Ваш баланс: {walletRub} руб., " + $" {walletUsd} usd., " + $" {walletEur} eur. ");
            }
        }
        static void WriteError(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}