using static System.Console;

class Program
{
    static string FillInfo(string text)
    {
        WriteLine("\nEnter ID of employee");
        text = ReadLine() + "#";
        WriteLine($"DateTime is :{DateTime.Now}");
        text += Convert.ToString(DateTime.Now) + "#";
        WriteLine("Enter F.I.O. of employee");
        text += ReadLine() + "#";
        WriteLine("Enter age of employee");
        text += ReadLine() + "#";
        WriteLine("Enter growth of employee");
        text += ReadLine() + "#";
        WriteLine("Enter year, month and day of birth of employee divided by button -Enter-");
        int year = Convert.ToInt32(ReadLine());
        int month = Convert.ToInt32(ReadLine());
        int day = Convert.ToInt32(ReadLine());
        DateTime date = new DateTime(year, month, day);
        text += date.ToShortDateString() + "#";
        WriteLine("Enter place of birth of employee");
        text += ReadLine();
        return text;
    }
    static void Main()
    {
        var file = "Spisok.txt";
        ConsoleKeyInfo key;
        while (true)
        {
            WriteLine("\nPress 1 to view file\nPress 2 to add new record\nPress any other button to exit");
            key = ReadKey();
            switch (key.KeyChar)
                //у меня есть вопрос можно ли сделать так чтоб считывался ровно 1 введенный символ
                // например в с++ есть метод getch который позволяет сразу после нажатия любой клавиши
                //считать ее не вводя Enter после, есть ли что то такое в с#?
            {
                case '1':
                    if (File.Exists(file))
                        using (StreamReader sr = new StreamReader(file))
                        {
                            while (!(sr.EndOfStream))
                            {
                                var text = sr.ReadLine();
                                var textToSee = text.Split('#');
                                foreach (var line in textToSee)
                                    Write("{0} ", line);
                                WriteLine();
                            }
                        }
                    else WriteLine("File is not created ");
                    break;
                case '2':
                    using (StreamWriter sw = new StreamWriter(file, true))
                    {
                        string text=string.Empty;
                        text=FillInfo(text);
                        sw.WriteLine(text);
                    }
                    break;
                default: return;
            }
        }

    }
}