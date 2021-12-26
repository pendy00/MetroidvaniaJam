using UnityEngine;

public class MenuScriptsLoader : MonoBehaviour
{
    private PlayerMenuController player_menu_controller;
    private PlayerInputController player_input_controller;
    private PlayerAttributesController player_attributes_controller;

    private bool menu_loaded;

    public bool Menu_loaded { get => menu_loaded; set => menu_loaded = value; }
    public PlayerMenuController Player_menu_controller { get => player_menu_controller; set => player_menu_controller = value; }

    public void LoadMenu()
    {
        player_menu_controller = ScriptsLoader.LoadScript<PlayerMenuController>();
        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();
        player_attributes_controller = ScriptsLoader.LoadScript<PlayerAttributesController>();

        InitMenu();

        menu_loaded = true;
    }

    public void InitMenu()
    {
        player_menu_controller.Init(player_input_controller, player_attributes_controller);
    }
}