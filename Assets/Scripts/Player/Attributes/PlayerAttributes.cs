//defines all the values for the player
public class PlayerAttributes
{
    private Attribute life_point;
    private Attribute exp_point;
    private Attribute level;
    private Attribute lives;

    private Attribute strenght;
    private Attribute constitution;
    private Attribute intelligence;
    private Attribute luck;

    public Attribute Life_point { get => life_point; set => life_point = value; }
    public Attribute Exp_point { get => exp_point; set => exp_point = value; }
    public Attribute Level { get => level; set => level = value; }
    public Attribute Lives { get => lives; set => lives = value; }
    public Attribute Strenght { get => strenght; set => strenght = value; }
    public Attribute Constitution { get => constitution; set => constitution = value; }
    public Attribute Intelligence { get => intelligence; set => intelligence = value; }
    public Attribute Luck { get => luck; set => luck = value; }

    //initializing values
    public void Init()
    {
        life_point = new Attribute();
        exp_point = new Attribute();
        level = new Attribute();
        lives = new Attribute();
        strenght = new Attribute();
        constitution = new Attribute();
        intelligence = new Attribute();
        luck = new Attribute();
    }

    public void UpdateAllValues(int life_point, int exp_points, int level, int lives, int strenght, int constitution, int intelligence, int luck)
    {
        this.life_point.ChangeAttributeValue(life_point);
        this.exp_point.ChangeAttributeValue(exp_points);
        this.level.ChangeAttributeValue(level);
        this.lives.ChangeAttributeValue(lives);
        this.strenght.ChangeAttributeValue(strenght);
        this.constitution.ChangeAttributeValue(constitution);
        this.intelligence.ChangeAttributeValue(intelligence);
        this.luck.ChangeAttributeValue(luck);
    }

    public void UpdateAllMaxValues(int life_point, int exp_points, int level, int lives, int strenght, int constitution, int intelligence, int luck)
    {
        this.life_point.Max_value = life_point;
        this.exp_point.Max_value = exp_points;
        this.level.Max_value = level;
        this.lives.Max_value = lives;
        this.strenght.Max_value = strenght;
        this.constitution.Max_value = constitution;
        this.intelligence.Max_value = intelligence;
        this.luck.Max_value = luck;
    }
}