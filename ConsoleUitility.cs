
internal class ConsoleUitility
{
    public static void PrintGameHeader()
    {
        Console.WriteLine("██████╗ ██╗   ██╗███╗   ██╗ ██████╗ ███████╗ ██████╗ ███╗   ██╗");
        Console.WriteLine("██╔══██╗██║   ██║████╗  ██║██╔════╝ ██╔════╝██╔═══██╗████╗  ██║");
        Console.WriteLine("██║  ██║██║   ██║██╔██╗ ██║██║  ███╗█████╗  ██║   ██║██╔██╗ ██║");
        Console.WriteLine("██║  ██║██║   ██║██║╚██╗██║██║   ██║██╔══╝  ██║   ██║██║╚██╗██║");
        Console.WriteLine("██████╔╝╚██████╔╝██║ ╚████║╚██████╔╝███████╗╚██████╔╝██║ ╚████║");
        Console.WriteLine("╚═════╝  ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝  ╚═══╝");
        Console.WriteLine("                    아무키나 눌러주세요                        ");
        Console.ReadKey();
    }

    public static int PromptMenuCholce(int min, int max)
    {
        while(true) 
        {
            Console.Write("원하시는 번호를 입력해주세요: ");
            if(int.TryParse(Console.ReadLine(), out int choice) && choice>= min && choice <= max)
            {
                return choice;
            }
            Console.Clear();
            Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");

        }
    }

    internal static void ShowTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(title);
        Console.ResetColor();
    }

    public static void PrintTextHighlights(string s1, string s2, string s3 = "")
    {
        Console.Write(s1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(s2);
        Console.ResetColor();
        Console.WriteLine(s3);
    }

    public static int GetPrintableLength(string str)
    {
        int length = 0;
        foreach(char c in str)
        {
            //한글과 같은 넓은 무자에 대해 길이를 2로 취급하기위해 사용
            if (char.GetUnicodeCategory(c)== System.Globalization.UnicodeCategory.OtherLetter) 
            {
                length += 2;
            }
            // 나머지 문자에 대해선 길이 1로 취급
            else
            {
                length += 1;
            }
        }
        return length;
    }

    internal static string PadRightForMixedText(string str, int totalLength)
    {
        int currentLength = GetPrintableLength(str);
        int padding = totalLength - currentLength;
        return str.PadRight(str.Length + padding);
    }
}