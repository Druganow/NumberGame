using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {

        static string Name1;
        static string Name2;
        static int countStep;
        static Random r;
        static void Main(string[] args)
        {
            
            r = new Random();
            countStep = r.Next(12, 31);
            welcome();
            string selectGame = "Выберите режим игры\n" +
                "1-Однопользовательский\n" + "2-Многопользовательский\n";
            if (selectNumber(selectGame, 1, 2) == 1)
                SingleGame();
            else
                MultiGame();
            Console.ReadKey();
        }

        static void Named(int i)
        {
            Console.Clear();
            Console.Write("Введите ваше имя: ");
            Name1 = Console.ReadLine();
            if (i==2)
            {
                Console.Write("Введите имя соперника: ");
                Name2 = Console.ReadLine();
            }
            else
                Name2 = "ИИ";
            Console.Clear();
        }

        static bool EndGame()
        {
            return countStep <= 0;
        }

        static void MultiGame()
        {
            Console.Clear();
            Named(2);
            bool step = true;
            while(!EndGame())
            {
                Console.Clear();
                Console.WriteLine("Количество спичек: {0}", countStep);
                if (step)
                {
                    string s = Name1 + ": ";
                    countStep -= selectNumber(s, 1, 3);
                }
                else
                {
                    string s = Name2 + ": ";
                    countStep -= selectNumber(s, 1, 3);
                }
                step = !step;
            }
            if (step)
            {
                Console.Clear();
                Console.WriteLine("Победа {0}", Name2);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Победа {0}", Name1);
            }
                
        }

        static void SingleGame()
        {
            Console.Clear();
            Named(1);
            string str = "Выберите режим сложности\n1-Простой\n2-Cложный\n";
            int level = selectNumber(str, 1, 2);
            bool step = true;
            while (!EndGame())
            {
                Console.Clear();
                Console.WriteLine("Количество спичек: {0}", countStep);
                if (step)
                {
                    string s = Name1 + ": ";
                    countStep -= selectNumber(s, 1, 3);
                }
                else
                {
                    string s = Name2 + ": ";
                    countStep -= II(level);
                }
                step = !step;
            }
            if (step)
            {
                Console.Clear();
                Console.WriteLine("Победа {0}", Name2);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Победа {0}", Name1);
            }
        }

        static int II(int level)
        {
            if(level==1)
                return r.Next(1, 4);
            else
            {
                if (countStep % 4 == 0)
                    return r.Next(1, 4);
                else
                    return countStep % 4;
            }
        }
        static void welcome()
        {
            Console.WriteLine("Добро Пожаловать в игру \"Спички\"");
            Console.WriteLine("Правила игры:" +
                "перед участниками N-ное количество спичек. " +
                "Ходят по очереди.Каждый в свой черёд может взять от 1 до 3 палочек." +
                "Выигрывает тот, кто берёт последние." +
                "Для продоления нажите Enter");
            Console.ReadKey();
            Console.Clear();

        }

        static int selectNumber(string text, int n1, int n2)
        {
            Console.Write(text);
            string stringRead = Console.ReadLine();
            int result;
            while (!(int.TryParse(stringRead, out result) && result >= n1 && result <= n2))
            {
                Console.WriteLine("Некорректный ввод");
                Console.Write(text);
                stringRead = Console.ReadLine();
            }
            return result;
        }
    }
        
}
