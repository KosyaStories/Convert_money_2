using System;

namespace Convert_money_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float walletRub;
            float walletUsd;
            float walletEur;

            float rubToUsd = 0.0173f, usdToRub = 79.4f;
            float rubToEur = 0.0164f, eurToRub = 84.4f;
            float usdToEur = 0.94f, eurToUsd = 1.05f;

            float canToSolvency;
            string exchangeOperation;

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Курсы Валют на сегодня:");
            Console.WriteLine($"Покупка рубля - USD: {rubToUsd}, EUR: {rubToEur}");
            Console.WriteLine($"Продажа рубля - USD: {usdToRub}, EUR: {eurToRub}");
            Console.WriteLine($"Покупка/продажа доллара - EUR: {usdToEur} / {eurToUsd}");

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Добро пожаловать в наш обменник валют!");
            //CheckCrash("Введите баланс рублей: ", out walletRub);
            Console.Write("Введите баланс рублей: ");
            walletRub = Convert.ToSingle(Console.ReadLine());

            CheckWallet(walletRub);

            Console.Write("Введите баланс долларов: ");
            walletUsd = Convert.ToSingle(Console.ReadLine());

            CheckWallet(walletUsd);

            Console.Write("Введите баланс евро: ");
            walletEur = Convert.ToSingle(Console.ReadLine());

            CheckWallet(walletEur);

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

                switch (exchangeOperation)
                {
                    case "1":
                        ConversionFormula(ref walletUsd, out canToSolvency, ref rubToUsd, ref walletRub);
                        break;
                    case "2":
                        ConversionFormula(ref walletRub, out canToSolvency, ref usdToRub, ref walletUsd);
                        break;
                    case "3":
                        ConversionFormula(ref walletEur, out canToSolvency, ref rubToEur, ref walletRub);
                        break;
                    case "4":
                        ConversionFormula(ref walletRub, out canToSolvency, ref eurToRub, ref walletEur);
                        break;
                    case "5":
                        ConversionFormula(ref walletEur, out canToSolvency, ref usdToEur, ref walletUsd);
                        break;
                    case "6":
                        ConversionFormula(ref walletUsd, out canToSolvency, ref eurToUsd, ref walletEur);
                        break;
                    default:
                        WriteError("\nВыбрана неверная операция.");
                        break;
                }
                Console.WriteLine($"Ваш баланс: {walletRub} руб., " + $" {walletUsd} usd., " + $" {walletEur} eur. ");
            }
        }

        static void ConversionFormula(ref float increaseBalance, out float solvency, ref float rate, ref float decreaseBalance)
        {
            solvency = Convert.ToSingle(Console.ReadLine());

            if (solvency > 0)
            {
                increaseBalance = solvency * rate + increaseBalance;
                decreaseBalance -= solvency;
            }
            else
            {
                WriteError("Недостаточно средств на балансе либо введено недопустимое значение.");
            }
        }

        static void WriteError(string text)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
        }

        static bool CheckWallet(double wallet)
        {
            if (wallet < 0)
            {
                WriteError("Введено недопустимое значение.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //private static float CheckCrash(string text, out float value)
        //{
        //    float number;
        //    Console.Write("text");

        //    while (float.TryParse(value = Console.ReadLine(), out number) == false)        // не дает преобразовать string во float, а если убрать value, будет 2 ввода
        //    {
        //        Console.WriteLine("Ввод не распознан, введите еще раз.");
        //    }
        //    return number;
        //}
    }
}
