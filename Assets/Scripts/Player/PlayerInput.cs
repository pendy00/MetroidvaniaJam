public class PlayerInput
{
    private bool right;
    private bool left;
    private bool up;
    private bool down;

    private bool right_single_press;
    private bool left_single_press;
    private bool up_single_press;
    private bool down_single_press;

    private bool jump;
    private bool action;
    private bool attack;
    private bool run;

    private bool menu;
    private bool cancel;

    public bool Right { get => right; set => right = value; }
    public bool Left { get => left; set => left = value; }
    public bool Up { get => up; set => up = value; }
    public bool Down { get => down; set => down = value; }
    public bool Jump { get => jump; set => jump = value; }
    public bool Action { get => action; set => action = value; }
    public bool Attack { get => attack; set => attack = value; }
    public bool Run { get => run; set => run = value; }
    public bool Menu { get => menu; set => menu = value; }
    public bool Cancel { get => cancel; set => cancel = value; }
    public bool Right_single_press { get => right_single_press; set => right_single_press = value; }
    public bool Left_single_press { get => left_single_press; set => left_single_press = value; }
    public bool Up_single_press { get => up_single_press; set => up_single_press = value; }
    public bool Down_single_press { get => down_single_press; set => down_single_press = value; }

    public void ResetAll()
    {
        right = left = up = down = jump = action = attack = run = menu = cancel = false;
    }

    public void ResetAxis()
    {
        right = left = up = down = false;
        right_single_press = left_single_press = up_single_press = down_single_press = false;
    }

    public void ResetButtons()
    {
        jump = action = attack = false;
    }

    public void ResetRun()
    {
        run = false;
    }

    public void ResetOptions()
    {
        menu = cancel = false;
    }
}