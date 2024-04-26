public class GameManager
{
    private Player player;
    private List<Item> inventory;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player = new Player("창영", 1, "백수", 100, 100, 10, 5, 3000);

        inventory = new List<Item>();

        inventory.Add(new Item("천 옷", "기본 옷", Itemtype.Armor, 50, 0, 0, 5, 100));
        inventory.Add(new Item("낡은 칼", "기본 칼", Itemtype.Armor, 0, 0, 5, 0, 100));

    }

    public void StartG()
    {
        Console.Clear();
        ConsoleUitility.PrintGameHeader();
        MainMenu();
    }

    private void MainMenu()
    {

        Console.Clear();

        Console.WriteLine("던전에 입구에 오신 용사님 환영합니다.\n 던전에 들어가시기전에 이곳에서 장비를 점검해주세요");
        Console.WriteLine("");
        Console.WriteLine("1. 상태창");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");

        int choice = ConsoleUitility.PromptMenuCholce(1, 3);
        switch (choice)
        {
            case 1:
                StatusMenu();
                break;
            case 2:
                InventoryMenu();
                break;
            case 3:
                StoreMenu();
                break;

        }
        MainMenu();
    }
    private void StatusMenu()
    {
        Console.Clear();

        ConsoleUitility.ShowTitle("상태창");
        Console.WriteLine("캐릭터 정보");

        ConsoleUitility.PrintTextHighlights("Lv. ", player.Level.ToString("00"));
        Console.WriteLine("");
        Console.WriteLine($"{player.Name} ({player.Job})");

        int bonusAtk = inventory.Select(item => item.IsEqulp ? item.Atk : 0).Sum();
        int bonusDef = inventory.Select(item => item.IsEqulp ? item.Def : 0).Sum();
        int bonusHP = inventory.Select(item => item.IsEqulp ? item.HP : 0).Sum();
        int bonusMP = inventory.Select(item => item.IsEqulp ? item.MP : 0).Sum();

        ConsoleUitility.PrintTextHighlights("공격력 : ", (player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? $"(+{bonusAtk})" : "");
        ConsoleUitility.PrintTextHighlights("방어력 : ", (player.Def + bonusDef).ToString(), bonusDef > 0 ? $"(+{bonusDef})" : "");
        ConsoleUitility.PrintTextHighlights("체  력 : ", (player.Hp + bonusHP).ToString(), bonusHP > 0 ? $"(+{bonusHP})" : "");
        ConsoleUitility.PrintTextHighlights("마  나 : ", (player.Mp + bonusMP).ToString(), bonusMP > 0 ? $"(+{bonusMP})" : "");

        ConsoleUitility.PrintTextHighlights("Gold :", player.Gold.ToString());
        Console.WriteLine("");
        Console.WriteLine("0. 뒤로가기");
        Console.WriteLine("");

        switch(ConsoleUitility.PromptMenuCholce(0, 0))
        {
            case 0:
                MainMenu();
                break;
        }
            

    }
    private void InventoryMenu()
    {
        Console.Clear();

        ConsoleUitility.ShowTitle("인벤토리");
        Console.WriteLine("보관 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");

        for(int i = 0; i < inventory.Count; i++)
        {
            inventory[i].PrintItemStatDescription();

        }
        Console.WriteLine("");
        Console.WriteLine("0. 뒤로가기");
        Console.WriteLine("1. 장착관리");
        Console.WriteLine("");

        switch (ConsoleUitility.PromptMenuCholce(0, 1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                EquipMenu();
                break;
        }


    }

    private void EquipMenu()
    {
        Console.Clear();

        ConsoleUitility.ShowTitle("인벤토리");
        Console.WriteLine("보관 중인 아이템을 관리할 수 있습니다.\n");
        Console.WriteLine("[아이템 목록]");

        for(int i = 0; i < inventory.Count; i++)
        {
            inventory[i].PrintItemStatDescription(true, i + 1);
        }
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");

        int KeyInput = ConsoleUitility.PromptMenuCholce(0, inventory.Count);

        switch (KeyInput)
        {
            case 0:
                InventoryMenu();
                break;
            default:
                inventory[KeyInput - 1].ToggleEquipStatus();
                EquipMenu();
                break;
        }

    }

    private void StoreMenu()
    {

    }
}

public class Program
{ 
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        gameManager.StartG();
    }

}
