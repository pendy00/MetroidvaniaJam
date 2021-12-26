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
}