using System.Runtime.CompilerServices;

public class GameManager
{
    private Player player;
    private List<Item> inventory;
    private List<Item> storeInventory;

    public GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player = new Player("창영", 1, "백수", 100, 100, 10, 5, 3000);

        inventory = new List<Item>();
        storeInventory = new List<Item>();
        inventory.Add(new Item("천 옷", "기본 옷", Itemtype.Armor, 50, 0, 0, 5, 100));
        inventory.Add(new Item("낡은 칼", "기본 칼", Itemtype.Weapon, 0, 0, 5, 0, 100));
        inventory.Add(new Item("루비 반지", "기본 체력 반지", Itemtype.Accessory, 50, 0, 0, 0, 100));
        inventory.Add(new Item("사파이어 반지", "기본 마나 반지", Itemtype.Accessory, 0, 50, 0, 0, 100));

        storeInventory.Add(new Item("판금 갑옷", "제법 쓸만한 갑옷", Itemtype.Armor, 100, 0, 0, 15, 1000));
        storeInventory.Add(new Item("기사의 검", "제법 쓸만한 검", Itemtype.Weapon, 0, 0, 15, 0, 1000));
        storeInventory.Add(new Item("블루 사파이어 반지", "마나 반지", Itemtype.Accessory, 50, 100, 0, 0, 1500));





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
        Console.Clear();

        ConsoleUitility.ShowTitle("던전 입구 상점");
        Console.WriteLine("던전입구 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        ConsoleUitility.PrintTextHighlights("Gold :", player.Gold.ToString(), "골드\n");
        Console.WriteLine("[아이템 목록]");
        for(int i = 0; i < storeInventory.Count; i++)
        {
            storeInventory[i].PrintStoreItemDescription();
        }
        Console.WriteLine("");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("0. 나가기 ");
        Console.WriteLine("");
        switch(ConsoleUitility.PromptMenuCholce(0, 1))
        {
            case 0:
                MainMenu();
                break;
            case 1:
                PurchaseMenu();
                break;
        }
    }

    private void PurchaseMenu(string? prompt = null)
    {
        if(prompt != null)
        {
            Console.Clear();
            ConsoleUitility.ShowTitle(prompt);
            Thread.Sleep(1000); // 몇밀리세컨동안 멈출것인지
        }
        Console.Clear();

        ConsoleUitility.ShowTitle("던전 입구 상점");
        Console.WriteLine("던전입구 상점입니다.\n");
        Console.WriteLine("[보유 골드]");
        ConsoleUitility.PrintTextHighlights("Gold :", player.Gold.ToString(), "골드\n");
        Console.WriteLine("[아이템 목록]");
        for (int i = 0; i < storeInventory.Count; i++)
        {
            storeInventory[i].PrintStoreItemDescription(true, i + 1);
        }
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");

        int keyInput = ConsoleUitility.PromptMenuCholce(0, storeInventory.Count);

        switch(keyInput)
        {
            case 0:
                StoreMenu();
                break;
            default:
                if (storeInventory[keyInput -1].IsPurch) //이미 구매한 물품
                {
                    PurchaseMenu("이미 구매한 아이템입니다.");
                }
                else if(player.Gold >= storeInventory[keyInput - 1].Price) //돈이 충분한경우
                {
                    player.Gold -= storeInventory[keyInput - 1].Price; ;
                    storeInventory[keyInput - 1].IsPurchased();
                    inventory.Add(storeInventory[keyInput - 1]);
                    PurchaseMenu();
                }
                else // 수중에 골드가 모자를 경우
                {
                    PurchaseMenu("골드가 부족합니다.");
                }
                break;
        }
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
