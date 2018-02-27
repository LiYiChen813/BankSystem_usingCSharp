using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManage
{

    class Program
    {
        class Bank
        {
            private int NewID = 0;
            private int K = 0;
            private Account[] account = new Account[4]; // 物件陣列 4個物件 能用的只有3個

            public void Append()
            {
                NewID = NewID + 1;
                Boolean bo = true;
                while (bo)
                {
                    if (K >= 3)
                    {
                        Console.WriteLine("帳戶已滿!!");
                        bo = false;
                        break;
                    }
                    else
                    {
                        int id = NewID;
                        string name;
                        float initialMoney = 0;

                        Console.WriteLine("請輸入新帳戶的姓名");
                        name = Console.ReadLine();

                        Console.WriteLine("請輸入新帳戶的初始存款");
                        initialMoney = float.Parse(Console.ReadLine());

                        account[id] = new Account(NewID, name, initialMoney); //0不能用
                        account[id].ShowMe();
                        bo = false;
                        K++;
                    }
                }
            }

            public void Delete()
            {
                Console.WriteLine("請輸入要刪除的帳戶");
                int id = int.Parse(Console.ReadLine());

                account[id] = null;
                K--;
                NewID =id-1;
                Console.WriteLine("帳戶已經刪除");
                
               
            }

            public void Query()
            {

                Console.WriteLine("請輸入要查詢的帳戶");
                int id = int.Parse(Console.ReadLine());
                int choice;

                try
                {
                    account[id].ShowMe();
                    Console.WriteLine("1.存款  2.取款  3.回上一步");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            account[id].Saving();
                            break;
                        case 2:
                            account[id].Withdraw();
                            break;
                        case 3:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("無此帳戶");
                }
              
            }
        }

        class Account
        {
            int ID;
            string name;
            float Balance;

            public Account(int id, string name, float balance)
            {
                ID = id;
                this.name = name;
                Balance = balance;
            }

            public void ShowMe()
            {
                Console.WriteLine();
                Console.WriteLine("帳號為：" + ID + "  姓名為：" + name + "  存款：" + Balance);
                Console.WriteLine();
            }

            public void Saving()
            {
                Console.WriteLine("請輸入存款金額");
                float money = float.Parse(Console.ReadLine());
                Balance += money;

                
            }

            public void Withdraw()
            {
                Console.WriteLine("請輸入提款金額");
                float money = float.Parse(Console.ReadLine());
                Balance -= money;

               
            }
        }

        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int choice;
            Boolean b = true;
            try
            {
                while (b)
                {
                    Console.WriteLine("1.新增帳戶  2.刪除帳戶  3.查詢帳戶  4.退出系統");


                    switch (choice = int.Parse(Console.ReadLine()))
                    {

                        case 1:
                            bank.Append();
                            break;
                        case 2:
                            bank.Delete();
                            break;
                        case 3:
                            bank.Query();
                            break;
                        case 4:
                            b = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                while (b)
                {
                    Console.WriteLine("1.新增帳戶  2.刪除帳戶  3.查詢帳戶  4.退出");

                    switch (choice = int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            bank.Append();
                            break;
                        case 2:
                            bank.Delete();
                            break;
                        case 3:
                            bank.Query();
                            break;
                        case 4:
                            b = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

    }
}
