
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System;

// п unit testov, ответ пишется два раза
    public class Chislo 
    {
    // поля и их свойства
        private int int_part = 0;
        private int numerator;
        private int denumerator;
        public int Num
        {
            get
            {
                return numerator;
            }
            private set { }
        }
        public int Den
        {
            get
            {
                return denumerator;
            }
            private set { }
        }
        public int Int_part
        {
            get
            {
                return int_part;
            }
            private set { }
        }


    // конструкторы

    public Chislo(){ }
        public Chislo(int a, int b)
        {
            numerator = a;
            denumerator = b;
        }

        // ввод\вывод и предварительная обработка

        public static int Print_Enter_Num_Message(int number)
        {
            Console.WriteLine("Введите " + number + " число\n");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Введите числитель:");
            int a = Convert.ToInt32(Console.ReadLine());
            return a;
            
         }
        public static int Print_Enter_Den_Message()
        {
            int b;
            do
            {
                Console.WriteLine("Введите знаменатель:");
            

            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("------------------------------------------------");
        }
            while (b == 0);
            return b;
          }
        public static Chislo sokrashenie(Chislo a)
        {
        for (int i = Math.Min(a.numerator, a.denumerator); i > 0; i--)
        {
            if (a.numerator % i == 0 && a.denumerator % i == 0)
            {
                a.numerator /= i; a.denumerator /= i;
            }
        }
            return a;
        }   
        public static Chislo integer_part(Chislo a)
        {
            if(a.numerator > a.denumerator)
            {
                a.int_part = a.numerator / a.denumerator;
                a.numerator = a.numerator % a.denumerator;   
            }
            return a;
        }
        public void toString()
        {   if (denumerator == 1) { Console.WriteLine("Ответ:" + int_part); }
            if (numerator == 0) { Console.WriteLine("0"); }
            if (int_part == 0)
                Console.WriteLine(numerator + "/" + denumerator);
            else if(denumerator!=1) Console.WriteLine(int_part + " " + numerator + "/" + denumerator);
        }
        
        // перегрузка операторов

        public static Chislo operator /(Chislo U1, Chislo U2)
        {
            Chislo Ans = new Chislo();
            Ans.numerator = U1.numerator * U2.denumerator;
            Ans.denumerator = U1.denumerator * U2.numerator;
            Ans = sokrashenie(Ans);
            if (Ans.Den == 1)
            {
                Ans.int_part = Ans.Num;
                Ans.numerator = 1;
            }
            else
                Ans = integer_part(Ans);
        return (Ans);
        }
        public static Chislo operator *(Chislo U1, Chislo U2) {
            Chislo Ans = new Chislo();
       
            Ans.numerator = U1.numerator * U2.numerator;
            Ans.denumerator = U1.denumerator * U2.denumerator;

            Ans = sokrashenie(Ans);
            if (Ans.Den == 1)
            {
                Ans.int_part = Ans.Num;
                Ans.numerator = 1;
            }
            else
                Ans = integer_part(Ans);
             return Ans;
        }
        public static Chislo operator +(Chislo U1, Chislo U2)
        {
            Chislo Ans = new Chislo();

            Ans.denumerator = U1.denumerator * U2.denumerator;
            Ans.numerator = (U1.numerator * U2.denumerator + U2.numerator * U1.denumerator);
            
            Ans = sokrashenie(Ans);
            if (Ans.Den == 1)
            {
                Ans.int_part = Ans.Num;
                Ans.numerator = 1;
            }
            else
            Ans = integer_part(Ans);
        return Ans;
        }
        public static Chislo operator -(Chislo U1, Chislo U2)
        {
            Chislo Ans = new Chislo();

            if (U1.Den == U2.Den) {
            Ans.Den = U1.Den;
            Ans.Num = U1.Num - U2.Num;
            }
            else
            {
            Ans.denumerator = U1.denumerator * U2.denumerator;
            Ans.numerator = (U1.numerator * U2.denumerator - U2.numerator * U1.denumerator);
            }

            Ans = sokrashenie(Ans);
            if (Ans.Den == 1)
            {
                Ans.int_part = Ans.Num;
                Ans.numerator = 1;
            }
            else
                Ans = integer_part(Ans);
           
            return Ans;
        }
        public static bool operator ==(Chislo U1, Chislo U2)
        {
            if (U1.numerator == U2.numerator && U1.denumerator == U2.denumerator) return true;
            else return false;
        }
        public static bool operator !=(Chislo U1, Chislo U2)
        {
            if (U1.numerator == U2.numerator && U1.denumerator == U2.denumerator) return false;
            else return true;
        }
        public static bool operator >=(Chislo U1, Chislo U2)
        {
            U1.denumerator = U1.denumerator * U2.denumerator;
            U2.denumerator = U1.denumerator * U2.denumerator;
            U1.numerator = U1.numerator * U2.denumerator;
            U2.numerator = U2.numerator * U1.denumerator;
            if(U1.numerator >= U2.numerator)
            return true;
            else return false;
        }
        public static bool operator <=(Chislo U1, Chislo U2)
        {
            U1.denumerator = U1.denumerator * U2.denumerator;
            U2.denumerator = U1.denumerator * U2.denumerator;
            U1.numerator = U1.numerator * U2.denumerator;
            U2.numerator = U2.numerator * U1.denumerator;
            if (U1.numerator <= U2.numerator)
                return true;
            else return false;  
         }
        public static bool operator >(Chislo U1, Chislo U2)
        {
            U1.denumerator = U1.denumerator * U2.denumerator;
            U2.denumerator = U1.denumerator * U2.denumerator;
            U1.numerator = U1.numerator * U2.denumerator;
            U2.numerator = U2.numerator * U1.denumerator;
            if (U1.numerator > U2.numerator)
                return true;
            else return false;
        }
        public static bool operator <(Chislo U1, Chislo U2)
        {
            U1.denumerator = U1.denumerator * U2.denumerator;
            U2.denumerator = U1.denumerator * U2.denumerator;
            U1.numerator = U1.numerator * U2.denumerator;
            U2.numerator = U2.numerator * U1.denumerator;
            if (U1.numerator < U2.numerator)
                return true;
            else return false;
        }


    static void Main()
        {
            //ввод первого числа

            int a = Print_Enter_Num_Message(1);
            int b = Print_Enter_Den_Message();
            Chislo UserChislo1 = new Chislo(a, b);
            UserChislo1 = sokrashenie(UserChislo1);

            //ввод второго числа

            a = Print_Enter_Num_Message(2);
            b = Print_Enter_Den_Message();
            Chislo UserChislo2 = new Chislo(a, b);
            UserChislo1 = sokrashenie(UserChislo1);

           
            Chislo ans = new Chislo();
            Console.WriteLine();
            Console.WriteLine("1 - умножить два числа");
            Console.WriteLine("2 - разделить два числа");
            Console.WriteLine("3 - сложить два числа");
            Console.WriteLine("4 - вычесть два числа");
            Console.WriteLine("5 - равны ли два числа?");
            Console.WriteLine("6 - разные ли числа?");
            Console.WriteLine("7 - первое число больше второго?");
            Console.WriteLine("8 - первое число больше/или равно второму?");
            Console.WriteLine("9 - первое число меньше второго?");
            Console.WriteLine("10 -первое число меньше/или равно второму?\n");
            


            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ответ: ");
            switch (m)
                {
 
                    case (1):
                        {
                            ans = UserChislo1 * UserChislo2;
                            ans.toString();
                            break;
                        }

                    case (2):
                        {
                            ans = UserChislo1 / UserChislo2;
                            ans.toString();
                            break;
                        }
                    case (3):
                        {
                            ans = UserChislo1 + UserChislo2;
                            ans.toString();
                            break;
                        }
                    case (4):
                        {
                            ans = UserChislo1 - UserChislo2;
                            ans.toString();
                            break;
                        }
                    case (5):
                        {
                            if (UserChislo1 == UserChislo2) Console.WriteLine("два числа равны");
                            else Console.WriteLine("два числа не равны");
                            break;
                        }
                    case (6):
                        {
                            if (UserChislo1 != UserChislo2) Console.WriteLine("два числа не равны");
                            else Console.WriteLine("два числа равны");
                            break;
                        }
                    case (7):
                    {
                        if (UserChislo1 > UserChislo2) Console.WriteLine("первое число больше второго");
                        break;
                    }
                    case (8):
                        {
                            if (UserChislo1 >= UserChislo2) Console.WriteLine("первое число больше/или равно второго");
                            break;
                        }
                    case (9):
                        {
                            if (UserChislo1 < UserChislo2) Console.WriteLine("первое число меньше второго");
                            else Console.WriteLine("первое число больше или равно второго");
                            break;
                        }
                    case (10):
                        {
                            if (UserChislo1 <= UserChislo2) Console.WriteLine("первое число меньше/или равно второго");
                            else Console.WriteLine("Бу бу бу");
                            break;
                        }
               

            }
            }
    }
    

