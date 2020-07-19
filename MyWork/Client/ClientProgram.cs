using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Text.RegularExpressions;


namespace ConsoleClient
{
    class Program
    {
        const int port = 8888;              //   Порт сервера.
        const string address = "127.0.0.1"; //   Адресс сервера.


        static TcpClient client;            //   Клиентское подключение по TCP.
        static NetworkStream stream;        //   Поток данных для доступа к сети.
        static StreamWriter writer;         //   Переменная для записи в поток.
        static StreamReader reader;         //   Переменная для считывания в поток.


        static FileStream fileStream = new FileStream("Result.txt", FileMode.Create, FileAccess.Write); //   Создание файла для сохранения.
        static StreamWriter streamWriter = new StreamWriter(fileStream);                                //   Поток для записи в файл.


        //   Соединяемся с сервером.
        static void Connect()
        {
            client = new TcpClient(address, port);
            stream = client.GetStream();
        }

        //   Получаем файлы на обработку.
        static string[] GetFiles()
        {
            string[] files = null;

            do
            {
                while(true)
                {
                    try
                    {
                        Console.Write("Введите полный путь к папке с файлами: ");
                        var dir = @"" + Console.ReadLine();

                        files = Directory.EnumerateFiles(dir, "*.txt")
                            .Select(File.ReadAllText).ToArray();

                        break;
                    }
                    catch (Exception e)
                    {

                    }
                }
            } while (files.Length == 0 || files.Length > 127 || files == null);

            return files;
        }

        //   Отправляем запрос.
        static void StreamWriter(string files)
        {
            
            string s = Regex.Replace(files, @"[ \r\n\t]", "");
            s.ToLower();

            writer.WriteLine(s.ToCharArray(),0,s.Length);
            writer.Flush();

            Thread.Sleep(1000);
            
        }

        //   Получаем ответ.
        static void StreamReader()
        {
            while (true)
            {
                try
                {
                    reader = new StreamReader(stream);

                    string message = reader.ReadLine();
                    Console.WriteLine(message);

                    streamWriter.WriteLine(message);
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        //   Отключаем соединение с сервером.
        static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

            Environment.Exit(0); 
        }

        //   Создание потока для получение ответа.
        static void NewThread()
        {
            Thread readThread = new Thread(new ThreadStart(StreamReader));
            readThread.Start(); //старт потока
        }

        //   Закрытие открытых полтоков.
        static void ThreadClose()
        {
            Console.WriteLine("Фаил сохранен в: " + fileStream.Name);

            streamWriter.Close();
            fileStream.Close();

        }

        //   Главный метод
        static void MainProcess()
        {
            TcpClient client = null;

            try
            {
                Connect();
                NewThread();

                string[] files = GetFiles();
             
                for (int i = 0; i < files.Length; i++)
                {
                    writer = new StreamWriter(stream);
                    StreamWriter(files[i]);
                }

                Thread.Sleep(5000);

                ThreadClose();

                Console.WriteLine("Нажмите любую кнопку для выхода...");
                Console.ReadLine();
                Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }

        }

        //   Настоящий главный метод.
        static void Main(string[] args)
        {
            MainProcess();
        }
    }
}
