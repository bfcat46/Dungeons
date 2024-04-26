public enum Itemtype
{
    Weapon,
    Armor,
    Accessory
}


internal class Item
{
    public string Name { get; }
    public string Desc { get; }

    private Itemtype Type;
    public int HP { get; }
    public int MP { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Price { get; }
    public bool IsEqulp { get; private set; }
    public bool IsPurch { get; private set; }

    public Item(string name, string desc, Itemtype type, int hP, int mP, int atk, int def, int price, bool isEqulp = false, bool isPurch = false)
    {
        Name = name;
        Desc = desc;
        Type = type;
        HP = hP;
        MP = mP;
        Atk = atk;
        Def = def;
        Price = price;
        IsEqulp = isEqulp;
        IsPurch = isPurch;
    }

    //기본이름만 보여주고 필요할때 정보요청을하여 아이탬을 확인하는용도
    internal void PrintItemStatDescription(bool withNuber = false, int idx = 0)
    {
        Console.Write("- ");
        if (withNuber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx}");
            Console.ResetColor();
        }
        if (IsEqulp)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("E");
            Console.ResetColor();
            Console.Write("]");
            Console.Write(ConsoleUitility.PadRightForMixedText(Name, 9));
        }
        else Console.Write(ConsoleUitility.PadRightForMixedText(Name, 12));

        Console.Write(" ㅣ ");

        if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk} ");
        if (Def != 0) Console.Write($"방어력 {(Atk >= 0 ? " + " : "")}{Def} ");
        if (HP != 0) Console.Write($"체  력 {(Atk >= 0 ? " + " : "")}{HP} ");
        if (MP != 0) Console.Write($"마  나 {(Atk >= 0 ? " + " : "")}{MP} ");

        Console.Write(" ㅣ ");

        Console.WriteLine(Desc);
    }

    internal void ToggleEquipStatus()
    {
        IsEqulp = !IsEqulp;
    }

    internal void PrintStoreItemDescription(bool withNuber = false, int idx = 0)
    {
        Console.Write("- ");
        if (withNuber)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($"{idx}");
            Console.ResetColor();
        }

        else Console.Write(ConsoleUitility.PadRightForMixedText(Name, 12));

        Console.Write(" ㅣ ");

        if (Atk != 0) Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk} ");
        if (Def != 0) Console.Write($"방어력 {(Atk >= 0 ? " + " : "")}{Def} ");
        if (HP != 0) Console.Write($"체  력 {(Atk >= 0 ? " + " : "")}{HP} ");
        if (MP != 0) Console.Write($"마  나 {(Atk >= 0 ? " + " : "")}{MP} ");

        Console.Write(" ㅣ ");

        Console.Write(ConsoleUitility.PadRightForMixedText(Desc, 12));

        Console.Write(" ㅣ ");
        if(IsPurch)
        {
            Console.WriteLine("구매 완료");
        }
        else
        {
            ConsoleUitility.PrintTextHighlights("", Price.ToString(), "골드");
        }
    }

    internal void IsPurchased()
    {
        IsPurch = true;
    }
}