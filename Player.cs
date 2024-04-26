internal class Player
{
    public string Name { get; }
    public int Level { get; }
    public string Job { get; }
    public int Hp { get; }
    public int Mp { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Gold { get; set; }

    public Player(string name, int level, string job, int hp,int mp, int atk, int def, int gold)
    {
        Name = name;
        Level = level;
        Job = job;
        Hp = hp;
        Mp = mp;
        Atk = atk;
        Def = def;
        Gold = gold;
    }
}