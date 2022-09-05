using static System.Console;
using Task_1;

class Program
{

    
    static void Main()
    {
        while (true)
        {
            WriteLine("Press:\n0 to exit\n1 to show all text\n2 to find worker by ID\n3 to add worker\n4 to delete worker\n5 to edit information\n6 to sort information\n7 to see info added between to dates");
            ConsoleKeyInfo key = ReadKey();
            switch (key.KeyChar)
            {
                case '0': 
                    return;
                case '1':
                    Repository.GetAllWorkers();                   
                    break;
                case '2':
                    WriteLine("\nEnter ID of worker");
                    int idToAdd = Convert.ToInt32(ReadLine());
                    Repository.GetWorkerById(idToAdd);
                    break;
                case '3':
                    Repository.AddWorker();
                    break;
                case '4':
                    WriteLine("\nEnter ID of worker");
                    int idToDelete = Convert.ToInt32(ReadLine());
                    Repository.DeleteWorker(idToDelete);
                    break;
                case '5':
                    WriteLine("\nEnter ID of worker");
                    int idToEdit = Convert.ToInt32(ReadLine());
                    Repository.EditWorker(idToEdit);
                    break;
                case '6':
                    Clear();
                    WriteLine("Choose how do you want to sort your document:\n1 - by ID\n2 - by Date of adding\n3 - by FIO\n4 - by Age\n5 - by Growth\n6 - by Date of birth\n7 - by Place of birth");
                    var key1=Convert.ToInt32(ReadLine());
                    switch (key1)
                    {
                        case 1:
                            Repository.Order(1, true);
                            Repository.GetAllWorkers();
                            break;
                        case 2:
                            Repository.Order(2, true);
                            Repository.GetAllWorkers();
                            break;
                        case 3:
                            Repository.Order(3, true);
                            Repository.GetAllWorkers();
                            break;
                        case 4:
                            Repository.Order(4, true);
                            Repository.GetAllWorkers();
                            break;
                        case 5:
                            Repository.Order(5, true);
                            Repository.GetAllWorkers();
                            break;
                        case 6:
                            Repository.Order(6, true);
                            Repository.GetAllWorkers();
                            break;
                        case 7:
                            Repository.Order(7, true);
                            Repository.GetAllWorkers();
                            break;
                        default: WriteLine("There is no such option");
                            break;
                    }
                    break;
                case '7':
                    WriteLine("Enter DateFrom in format dd.MM.yyyy ");
                    var dateFrom = ReadLine();
                    var dividedDateFrom1 = dateFrom.Split(".");
                    int[] dividedDateFrom = new int[dividedDateFrom1.Length];
                    for (int i = 0; i < dividedDateFrom1.Length; i++)
                    {
                        dividedDateFrom[i] = Convert.ToInt32(dividedDateFrom1[i]);
                    }
                    DateTime finalDateFrom = new DateTime(dividedDateFrom[2], dividedDateFrom[1], dividedDateFrom[0]);
                    WriteLine("Enter DatetTo in format dd.MM.yyyy");
                    var dateTo = ReadLine();
                    var dividedDateTo1 = dateTo.Split(".");
                    int[] dividedDateTo = new int[dividedDateTo1.Length];
                    for (int i = 0; i < dividedDateTo1.Length; i++)
                    {
                        dividedDateTo[i] = Convert.ToInt32(dividedDateTo1[i]);
                    }
                    DateTime finalDateTo = new DateTime(dividedDateTo[2], dividedDateTo[1], dividedDateTo[0]);
                    Repository.GetWorkersBetweenTwoDates(finalDateFrom, finalDateTo);
                    break;
            }
        }
    }
}