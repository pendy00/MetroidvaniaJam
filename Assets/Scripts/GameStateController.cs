using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//state machine to manage the flow of the game
public class GameStateController : MonoBehaviour
{    
    public enum GAME_STATE { START_LEVEL, END_LEVEL, EXPLORING, DEATH, MENU, SAVE, LOAD, QUIT, TRANSICTION, DIALOGUE, NONE}; //defines all the state the game can translate into
    public GAME_STATE current_game_state = GAME_STATE.NONE; // current state of the game

    private List<MonoBehaviour> player_scripts; // stores scripts that enable player gameplay
    private List<MonoBehaviour> menu_scripts; //stores scripts that enable menus informations
    private List<MonoBehaviour> level_scripts; // stores scripts that enable level interactions
    private List<MonoBehaviour> enemies_scripts; // stores scripts that enable enemies
    private List<MonoBehaviour> cutscene_scripts; // stores scripts that are used in the cutscenes

    private PlayerScriptsLoader player_scripts_loader; // load all the scripts that are required for the player
    private InventoryScriptsLoader inventory_scripts_loader; // load all the scripts that are required for the inventory system
    private EquipmentScriptsLoader equipment_scripts_loader; // load all the scripts that are required for the equipment system
    private InteractionsScriptsLoader interaction_scripts_loader; // load all the scripts that are required for the player to interact with objects
    private MenuScriptsLoader menu_scripts_loader; // load all the scripts for the menu system
    private AttributesScriptsLoader attributes_scripts_loader; // load all the scripts that defines player attributes and statis
    
    // TODO move loaders into a funcrion that will be loaded on level start
    public void Awake()
    {
        QualitySettings.vSyncCount = 0; // disable vsync
        Application.targetFrameRate = 120; // cap frame rate to avoid resource drainage
        
        // finds loader and load associated scripts
        player_scripts_loader = ScriptsLoader.LoadScript<PlayerScriptsLoader>();
        player_scripts_loader.LoadPlayer();

        inventory_scripts_loader = ScriptsLoader.LoadScript<InventoryScriptsLoader>();
        inventory_scripts_loader.LoadInventory();

        equipment_scripts_loader = ScriptsLoader.LoadScript<EquipmentScriptsLoader>();
        equipment_scripts_loader.LoadEquipment();

        interaction_scripts_loader = ScriptsLoader.LoadScript<InteractionsScriptsLoader>();
        interaction_scripts_loader.LoadInteractions();

        menu_scripts_loader = ScriptsLoader.LoadScript<MenuScriptsLoader>();
        menu_scripts_loader.LoadMenu();

        attributes_scripts_loader = ScriptsLoader.LoadScript<AttributesScriptsLoader>();
        attributes_scripts_loader.LoadAttributes();
        
        //enable starting scripts
        StartCoroutine(EnableStartingScripts());
    }

    // change name function to StartingLevelScripts
    // TODO create function to enable proper starti scripts of main menu
    private IEnumerator EnableStartingScripts()
    {
        LoadExploringScripts();
        EnableScripts(player_scripts, false);

        LoadMenuScripts();
        EnableScripts(menu_scripts, false);

        yield return new WaitForFixedUpdate();
        ChangeGameState(GAME_STATE.START_LEVEL);
        ChangeGameState(GAME_STATE.LOAD);
        ChangeGameState(GAME_STATE.EXPLORING);
    }

    // loads level scripts that enable all player's interactions with the level
    public void LoadExploringScripts()
    {
        player_scripts = new List<MonoBehaviour>();
        player_scripts.Add(player_scripts_loader.Player_movements_controller);
        player_scripts.Add(player_scripts_loader.Player_animations_controller);
        player_scripts.Add(player_scripts_loader.Player_fx_controller);
        player_scripts.Add(interaction_scripts_loader.Player_collect_controller);
        player_scripts.Add(interaction_scripts_loader.Player_interact_controller);
    }

    // loads level scripts that enable all menu's interactions with the level
    public void LoadMenuScripts()
    {
        menu_scripts = new List<MonoBehaviour>();
        menu_scripts.Add(menu_scripts_loader.Player_menu_controller);
        menu_scripts.Add(menu_scripts_loader.Player_inventory_menu);
        menu_scripts.Add(menu_scripts_loader.Player_equipment_menu);
    }

    // enable/disable all the given scripts
    public void EnableScripts(List<MonoBehaviour> scripts, bool value)
    {
        foreach (MonoBehaviour m in scripts)
            m.enabled = value;
    }

    // change current game state and enable/disable proper scripts base of the state transiction
    public void ChangeGameState(GAME_STATE next_state)
    {
        if (current_game_state == GAME_STATE.NONE)
        {
            switch (next_state)
            {
                case GAME_STATE.START_LEVEL:
                    break;
                case GAME_STATE.QUIT:
                    //exit game
                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.START_LEVEL)
        {
            switch (next_state)
            {
                case GAME_STATE.LOAD:
                    //load or init the level

                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.TRANSICTION)
        {
            switch (next_state)
            {
                case GAME_STATE.EXPLORING:
                    EnableScripts(player_scripts, true);
                    EnableScripts(menu_scripts, true);
                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.DIALOGUE)
        {
            switch (next_state)
            {
                case GAME_STATE.EXPLORING:
                    EnableScripts(player_scripts, true);
                    EnableScripts(menu_scripts, true);
                    SceneController.TimeScale(1);
                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.EXPLORING)
        {
            switch (next_state)
            {
                case GAME_STATE.SAVE:
                    break;
                case GAME_STATE.LOAD:
                    break;
                case GAME_STATE.MENU:
                    EnableScripts(player_scripts, false);
                    EnableScripts(menu_scripts, true);
                    SceneController.TimeScale(0);
                    break;
                case GAME_STATE.TRANSICTION:
                    EnableScripts(player_scripts, false);
                    EnableScripts(menu_scripts, false);
                    break;
                case GAME_STATE.DIALOGUE:
                    EnableScripts(player_scripts, false);
                    EnableScripts(menu_scripts, false);
                    SceneController.TimeScale(0);
                    break;
                case GAME_STATE.END_LEVEL:
                    break;
                case GAME_STATE.QUIT:
                    //exit game
                    break;
                case GAME_STATE.DEATH:
                    EnableScripts(player_scripts, false);
                    EnableScripts(menu_scripts, false);
                    StartCoroutine(FindObjectOfType<GameOver>().ShowGameOverScreen());
                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.MENU)
        {
            switch (next_state)
            {
                case GAME_STATE.EXPLORING:
                    EnableScripts(player_scripts, true);
                    EnableScripts(menu_scripts, true);
                    SceneController.TimeScale(1);
                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.SAVE)
        {
            switch (next_state)
            {
                case GAME_STATE.EXPLORING:

                    break;
                default:
                    break;
            }
        }

        if (current_game_state == GAME_STATE.LOAD)
        {
            switch (next_state)
            {
                case GAME_STATE.EXPLORING:
                    EnableScripts(player_scripts, true);
                    EnableScripts(menu_scripts, true);
                    break;
                default:
                    break;
            }
        }

        current_game_state = next_state;
    }
}