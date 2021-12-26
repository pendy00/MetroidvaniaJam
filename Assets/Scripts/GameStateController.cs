using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public enum GAME_STATE { START_LEVEL, END_LEVEL, EXPLORING, DEATH, MENU, SAVE, LOAD, QUIT, TRANSICTION, NONE};
    public GAME_STATE current_game_state = GAME_STATE.NONE;

    private List<MonoBehaviour> player_scripts;
    private List<MonoBehaviour> menu_scripts;
    private List<MonoBehaviour> level_scripts;
    private List<MonoBehaviour> enemies_scripts;
    private List<MonoBehaviour> cutscene_scripts;

    private InventoryScriptsLoader inventory_scripts_loader;
    private PlayerScriptsLoader player_scripts_loader;
    private MenuScriptsLoader menu_scripts_loader;
    private InteractionsScriptsLoader interaction_scripts_loader;
    

    public void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
        
        player_scripts_loader = ScriptsLoader.LoadScript<PlayerScriptsLoader>();
        player_scripts_loader.LoadPlayer();

        inventory_scripts_loader = ScriptsLoader.LoadScript<InventoryScriptsLoader>();
        inventory_scripts_loader.LoadInventory();

        interaction_scripts_loader = ScriptsLoader.LoadScript<InteractionsScriptsLoader>();
        interaction_scripts_loader.LoadInteractions();

        menu_scripts_loader = ScriptsLoader.LoadScript<MenuScriptsLoader>();
        menu_scripts_loader.LoadMenu();

        StartCoroutine(EnableStartingScripts());
    }

    private IEnumerator EnableStartingScripts()
    {
        LoadExploringScripts();
        EnableScripts(player_scripts, false);

        LoadMenuScripts();

        yield return new WaitForFixedUpdate();
        ChangeGameState(GAME_STATE.START_LEVEL);
        ChangeGameState(GAME_STATE.LOAD);
        ChangeGameState(GAME_STATE.EXPLORING);
    }

    public void LoadExploringScripts()
    {
        player_scripts = new List<MonoBehaviour>();
        player_scripts.Add(player_scripts_loader.Player_movements_controller);
        player_scripts.Add(player_scripts_loader.Player_fx_controller);
        player_scripts.Add(interaction_scripts_loader.Player_collect_controller);
        player_scripts.Add(interaction_scripts_loader.Player_interact_controller);
    }

    public void LoadMenuScripts()
    {
        menu_scripts = new List<MonoBehaviour>();
        menu_scripts.Add(menu_scripts_loader.Player_menu_controller);
    }

    public void EnableScripts(List<MonoBehaviour> scripts, bool value)
    {
        foreach (MonoBehaviour m in scripts)
            m.enabled = value;
    }

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
                    break;
                default:
                    break;
            }
        }

        current_game_state = next_state;
    }
}