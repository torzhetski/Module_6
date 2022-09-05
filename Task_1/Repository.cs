using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

namespace Task_1
{
    public class Repository
    {
        /// <summary>
        /// приватная переменная пути к файлу
        /// </summary>
         static private string path = "Spisok.txt";
        /// <summary>
        /// метод выводящий на экран весь файл
        /// </summary>
        /// <returns></returns>
         static public void GetAllWorkers()
        {
            Clear();
            Worker[] workers = ReadAllFile();
            if (workers.Length == 0) WriteLine("File was Created");
            else
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    //изза идеи добавить время последнего изменения пршлось вводить
                    //дополнительную проверку чтобы не выводилась куча ненужных 
                    //минимальных дат
                    if (workers[i].DateOfEdit != DateTime.MinValue)
                        WriteLine("{0} {1} {2,35} {3,3} {4,3} {5} {6,10} {7}"
                            , workers[i].Id.ToString()
                            , workers[i].Date.ToString()
                            , workers[i].FIO.ToString()
                            , workers[i].Age.ToString()
                            , workers[i].Growth.ToString()
                            , workers[i].Born.ToString()
                            , workers[i].PlaceOfBorn.ToString()
                            , workers[i].DateOfEdit.ToString()
                                 );
                    else
                        WriteLine("{0} {1} {2,35} {3,3} {4,3} {5} {6,10}"
                        , workers[i].Id.ToString()
                        , workers[i].Date.ToString()
                        , workers[i].FIO.ToString()
                        , workers[i].Age.ToString()
                        , workers[i].Growth.ToString()
                        , workers[i].Born.ToString()
                        , workers[i].PlaceOfBorn.ToString()
                             );
                }
                WriteLine();
            }
        }
        /// <summary>
        /// поиск и вывод работника по заданному ID
        /// </summary>
        /// <param name="id"></param>
        static public void GetWorkerById(int id)
        {
            Worker[] workers = ReadAllFile();
            bool flag = true;
            if (workers.Length == 0) WriteLine("File was Created");
            else
                for (int i = 0; i < workers.Length; i++)
            {
                    if (workers[i].Id == id)
                    {
                        //та же проверка что и при выводе всех имен
                        if (workers[i].DateOfEdit != DateTime.MinValue)
                            WriteLine("{0} {1} {2,35} {3,3} {4,3} {5} {6,10} {7}"
                                , workers[i].Id.ToString()
                                , workers[i].Date.ToString()
                                , workers[i].FIO.ToString()
                                , workers[i].Age.ToString()
                                , workers[i].Growth.ToString()
                                , workers[i].Born.ToString()
                                , workers[i].PlaceOfBorn.ToString()
                                , workers[i].DateOfEdit.ToString()
                                     );
                        else
                            WriteLine("{0} {1} {2,35} {3,3} {4,3} {5} {6,10}"
                            , workers[i].Id.ToString()
                            , workers[i].Date.ToString()
                            , workers[i].FIO.ToString()
                            , workers[i].Age.ToString()
                            , workers[i].Growth.ToString()
                            , workers[i].Born.ToString()
                            , workers[i].PlaceOfBorn.ToString()
                                 );
                        flag = false;
                    } 
            }
            if(flag)
                WriteLine("Tere is no such ID");
        }
        /// <summary>
        /// удаляет работника с заданным ID
        /// </summary>
        /// <param name="id"></param>
        static public void DeleteWorker(int id)
        {
            Worker[] workers = ReadAllFile();
            bool falg = false;
            if (workers.Length == 0) WriteLine("File was Created");
            else
            {
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].Id == id)
                     falg = true;
                }
                if (falg)
                {
                    Worker[] workers1 = new Worker[workers.Length - 1];
                    int key = 0;
                    for (int i = 0; i < workers.Length; i++)
                    {

                        if (workers[i].Id != id)
                        {
                            workers1[key] = workers[i];
                            key++;
                        }
                    }
                    WriteText(workers1, false);
                    GetAllWorkers();
                }
                else WriteLine("Tere is no such ID");

            }
        }
        /// <summary>
        /// добавляет сотрудников
        /// </summary>
        static public void AddWorker()
        {
            WriteLine("Enter number of workers you want to add");
            int numb = Convert.ToInt32(ReadLine());
            Worker[] workers = new Worker[numb];
            for(int i = 0; i < workers.Length; i++)
            {
                WriteLine("\nEnter ID of employee");
                workers[i].Id = Convert.ToInt32(ReadLine());
                WriteLine($"DateTime is :{DateTime.Now}");
                workers[i].Date=DateTime.Now;
                WriteLine("Enter F.I.O. of employee");
                workers[i].FIO = ReadLine();
                WriteLine("Enter age of employee");
                workers[i].Age= Convert.ToInt32(ReadLine());
                WriteLine("Enter growth of employee");
                workers[i].Growth= Convert.ToInt32(ReadLine());
                WriteLine("Enter year, month and day of birth of employee divided by button -Enter-");
                int year = Convert.ToInt32(ReadLine());
                int month = Convert.ToInt32(ReadLine());
                int day = Convert.ToInt32(ReadLine());
                DateTime date = new DateTime(year, month, day);
                workers[i].Born=date.ToShortDateString();
                WriteLine("Enter place of birth of employee");
                workers[i].PlaceOfBorn = ReadLine();
            }
            WriteText(workers,true);
        }
        /// <summary>
        /// позволяет редактировать информацию о сотруднике 
        /// и добавляет время последнего изменения
        /// </summary>
        /// <param name="id"></param>
        static public void EditWorker(int id)
        {
            Worker[] workers = ReadAllFile();
            bool flag = true;
            if (workers.Length == 0) WriteLine("File was Created");
            else
                for (int i = 0; i < workers.Length; i++)
                {
                    if (workers[i].Id == id)
                    {
                        WriteLine("\nEnter new ID of employee");
                        workers[i].Id = Convert.ToInt32(ReadLine());
                        WriteLine($"DateTime of edit :{DateTime.Now}");
                        workers[i].DateOfEdit = DateTime.Now;
                        WriteLine("Enter new F.I.O. of employee");
                        workers[i].FIO = ReadLine();
                        WriteLine("Enter new age of employee");
                        workers[i].Age = Convert.ToInt32(ReadLine());
                        WriteLine("Enter new growth of employee");
                        workers[i].Growth = Convert.ToInt32(ReadLine());
                        WriteLine("Enter new year, month and day of birth of employee divided by button -Enter-");
                        int year = Convert.ToInt32(ReadLine());
                        int month = Convert.ToInt32(ReadLine());
                        int day = Convert.ToInt32(ReadLine());
                        DateTime date = new DateTime(year, month, day);
                        workers[i].Born = date.ToShortDateString();
                        WriteLine("Enter place of birth of employee");
                        workers[i].PlaceOfBorn = ReadLine();
                        flag = false;
                    }
                }
            if (flag) WriteLine("Tere is no such ID");
            else WriteText(workers,false);
        }
        /// <summary>
        /// выводит записи сделанные между двумя датами
        /// тк я не вижу смысла для этого метода возвращать что то
        /// он тничего не возвращает
        /// </summary>
        /// <param name="dateFrom">начальная дата</param>
        /// <param name="dateTo">конечная дата</param>
        static public void GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            IOrderedEnumerable<Worker> workers = Order(2,false);
            int start;int end=int.MaxValue;
            foreach (var e in workers)
            {
                if (e.Date >= dateFrom && e.Date <= dateTo)
                {
                    if (e.DateOfEdit != DateTime.MinValue)
                        WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}"
                            , e.Id.ToString()
                            , e.Date.ToString()
                            , e.FIO.ToString()
                            , e.Age.ToString()
                            , e.Growth.ToString()
                            , e.Born.ToString()
                            , e.PlaceOfBorn.ToString()
                            , e.DateOfEdit.ToString()
                                 );
                    else
                        WriteLine("{0} {1} {2} {3} {4} {5} {6} "
                            , e.Id.ToString()
                            , e.Date.ToString()
                            , e.FIO.ToString()
                            , e.Age.ToString()
                            , e.Growth.ToString()
                            , e.Born.ToString()
                            , e.PlaceOfBorn.ToString()
                             );
                }
            }
        }
        /// <summary>
        /// считывает весь файл
        /// </summary>
        /// <returns>возвращает массив всех сотрудников</returns>
        static Worker[] ReadAllFile()
        {
            if (File.Exists(path))
                using (StreamReader sr = new StreamReader(path))
                {
                    Worker[] worker = new Worker[File.ReadAllLines(path).Length];
                    int count = 0;
                    while (!(sr.EndOfStream))
                    {
                        string[] divededLine = new string[8];
                        divededLine = sr.ReadLine().Split("#");
                        {
                            worker[count].Id = Convert.ToInt32(divededLine[0]);
                            worker[count].Date = Convert.ToDateTime(divededLine[1]);
                            worker[count].FIO = divededLine[2];
                            worker[count].Age = Convert.ToInt32(divededLine[3]);
                            worker[count].Growth = Convert.ToInt32(divededLine[4]);
                            worker[count].Born = divededLine[5];
                            worker[count].PlaceOfBorn = divededLine[6];
                            if (divededLine[7]!=String.Empty)
                            worker[count].DateOfEdit = Convert.ToDateTime(divededLine[7]);
                        };
                        count++;

                    }
                    return worker;
                }
            else
            {
                File.Create(path);
                return null;
            }
        }
        /// <summary>
        /// записывает переданный массив рабочих в файл
        /// </summary>
        /// <param name="worker">массив рабочих для записи</param>
        /// <param name="flag">индикатор того надо переписать файл или добавить что то</param>
        static void WriteText(Worker[] worker,bool flag)
        {
            using(StreamWriter sw = new StreamWriter(path, flag))
            {
                for(int i = 0; i < worker.Length; i++)
                {
                    if (worker[i].DateOfEdit!=DateTime.MinValue)
                    sw.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}"
                        , worker[i].Id.ToString()
                        , worker[i].Date.ToString()
                        , worker[i].FIO.ToString()
                        , worker[i].Age.ToString()
                        , worker[i].Growth.ToString()
                        , worker[i].Born.ToString()
                        , worker[i].PlaceOfBorn.ToString()
                        , worker[i].DateOfEdit.ToString()
                             );
                    else
                        sw.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}#"
                        , worker[i].Id.ToString()
                        , worker[i].Date.ToString()
                        , worker[i].FIO.ToString()
                        , worker[i].Age.ToString()
                        , worker[i].Growth.ToString()
                        , worker[i].Born.ToString()
                        , worker[i].PlaceOfBorn.ToString()                       
                             );
                }
            }
        }
        /// <summary>
        /// перегрузка метода для записи в файл отсортированных данных
        /// </summary>
        /// <param name="worker">отсортированные данные</param>
        static void WriteText(IOrderedEnumerable<Worker> worker)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach(var e in worker) 
                {
                    if (e.DateOfEdit != DateTime.MinValue)
                        sw.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}"
                            , e.Id.ToString()
                            , e.Date.ToString()
                            , e.FIO.ToString()
                            , e.Age.ToString()
                            , e.Growth.ToString()
                            , e.Born.ToString()
                            , e.PlaceOfBorn.ToString()
                            , e.DateOfEdit.ToString()
                                 );
                    else
                        sw.WriteLine("{0}#{1}#{2}#{3}#{4}#{5}#{6}#"
                            , e.Id.ToString()
                            , e.Date.ToString()
                            , e.FIO.ToString()
                            , e.Age.ToString()
                            , e.Growth.ToString()
                            , e.Born.ToString()
                            , e.PlaceOfBorn.ToString()
                             );
                }
            }
        }
        /// <summary>
        /// сортирует массив
        /// </summary>
        /// <param name="key">ключ по которому определяется параметр сортировки</param>
        /// <param name="flag">показывает надо ли записать отсортированный массив в файл</param>
        /// <returns>отсортированный массив</returns
        static public IOrderedEnumerable<Worker> Order(int key,bool flag)
        {

            Worker[] worker = ReadAllFile();
            //не знаю как реализовать сортировку по другому
            //ввести структуру такого типа предложила Visual Studio
            //если можно сделать как-то по другому, то как?
            IOrderedEnumerable<Worker> workers;
            switch (key)
            {
                case 1:
                    workers = worker.OrderBy(w => w.Id);
                    WriteText(workers);
                    return workers;
                    break;
                case 2 :
                    workers = worker.OrderBy(w => w.Date);
                    if (flag)
                        WriteText(workers);
                    return workers;
                    break;
                case 3 :
                    workers = worker.OrderBy(w => w.FIO);
                    WriteText(workers);
                    return workers;
                    break;
                case 4:
                    workers = worker.OrderBy(w => w.Age);
                    WriteText(workers);
                    return workers;
                    break;
                case 5:
                    workers = worker.OrderBy(w => w.Growth);
                    WriteText(workers);
                    return workers;
                    break;
                case 6:
                    workers = worker.OrderBy(w => w.Born);
                    WriteText(workers);
                    return workers;
                    break;
                case 7:
                    workers = worker.OrderBy(w => w.PlaceOfBorn);
                    WriteText(workers);
                    return workers;
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
