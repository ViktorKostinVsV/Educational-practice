using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;


namespace ConsoleServer
{
    class Program
    {
        const int port = 8888;              //   Порт для подключения.


        static TcpListener listener;        //   Прослушивание подключениев TCP.
        static public TcpClient client;     //   Подключенный TCP клиент.
        static public NetworkStream stream; //   Поток данных для доступа к сети.


        static int maxThread;               //   Максимальное кол-во потоков.
        static int indexFile = 1;           //   Нумерация файла.


        //   Запускаем сервер.
        static void StartServer()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
        }

        //   Останавливаем сервер.
        static void StopServer()
        {
            if (listener != null)
                listener.Stop();
        }

        //   Вводим ограничение по потокам.
        static int InputUser()
        {
            bool check;
            int number;

            Console.WriteLine("Введите кол-во потоков (от 1 до 10): ");

            do
            {
                check = int.TryParse(Console.ReadLine(), out number);

                if (!check || number < 1 || number > 10)
                {
                    Console.Write("Неверное значение!" +
                        "\nПовторите попытку: ");
                }

            } while (!check || number < 1 || number > 10);

            return number;
        }

        //   Считываем поток.
        static string StreamReader()
        {            
            try
            {
                StreamReader reader = new StreamReader(stream);
                string message = reader.ReadLine();
                Thread.Sleep(1000);

                return message;
            }
            catch
            {
                return null;
            }
        }

        //   Записываем поток.
        static void StreamWriter(string message)
        {           
            try
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(message.ToCharArray(), 0, message.Length);
                writer.Flush();
            }
            catch
            {
            }
        }

        //   Получаем значение палиндрома.
        public static string Palindromtest(string s)
        {
            if (s != null)
            {
                for (int i = 0, j = s.Length - 1; i < j; i++, j--)
                {
                    if (s[i] != s[j])
                        return "false";
                }
                return "true";
            }
            else
            {
                return null;
            }

        }

        //   Процесс передоваемый пулу.
        static void Process(object o)
        {
            string result = (string)o;

            if (result != null)
            {
                int i = indexFile;  //   Индексируем файл.
                indexFile++;        //   Добавляем к индексу единицу.

                result = Palindromtest(result);

                Thread.Sleep(1000);

                StreamWriter("Номер файла: "+i+" : "+result);
            }
            else if(client!=null)
            {
                indexFile = 1;
                client = null;
                Disconnect();
            }
        }

        //   Добавляем в пул новый поток
        static void NewThread(string result)
        {
            ThreadPool.QueueUserWorkItem(Process, result);      //   Добавляем метод Process в пулл.
            ThreadPool.SetMaxThreads(maxThread, maxThread);     //   Устанавливаем максимальное кол-во потоков.
            ThreadPool.SetMinThreads(1, 1);                     //   Устанавливаем минимльное кол-во потоков.
        }

        //   Ожидаем клиента.
        static void ConnectListner()
        {
            Console.WriteLine("Ожидание клиента...");

            client = listener.AcceptTcpClient();
            stream = client.GetStream();

            Console.WriteLine("Подключение.");
        }

        //   Отключаем клиента.
        static void Disconnect()
        {
            try
            {
                stream.Close();          
                client.Close();                
            }
            catch
            {

            }
            client = null;
            Console.WriteLine("Клиент был отключен.");
        }

        //   Главный метод.
        static void MainProcess()
        {
            maxThread = InputUser();
           
            try
            {
                StartServer();

                int worker = 1;
                int io;

                while (true)
                {
                    if (client == null)
                    {
                        worker = 1;
                        ConnectListner();
                    }

                    try
                    {
                        string result = StreamReader();

                        if (worker != 0) 
                        {
                            NewThread(result);
                        }
                        else
                        {
                            indexFile++;
                            StreamWriter("Сервер перегружен...");
                        }
                        ThreadPool.GetAvailableThreads(out worker, out io);
                    }
                    catch 
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                StopServer();
            }
        }

        //   Настоящий главный метод.
        static void Main(string[] args)
        {
            MainProcess();
        }
    }
}
