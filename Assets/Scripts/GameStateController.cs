using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public enum GAME_STATE { START_LEVEL, END_LEVEL, EXPLORING, DEATH, MENU, SAVE, LOAD, QUIT, NONE};
    public GAME_STATE current_game_state = GAME_STATE.NONE;

    private List<MonoBehaviour> exploring_scripts;
    private List<MonoBehaviour> menu_scripts;
    private List<MonoBehaviour> level_scripts;
    private List<MonoBehaviour> enemies_scripts;
    private List<MonoBehaviour> cutscene_scripts;

    private ScriptLevelLoader script_level_loader;
    

    public void Start()
    {
        script_level_loader = FindObjectOfType<ScriptLevelLoader>();
        script_level_loader.LevelScriptLoad();
        StartCoroutine(EnableStartingScripts());
    }

    private IEnumerator EnableStartingScripts()
    {
        while (!script_level_loader)
            yield return null;

        LoadExploringScripts();
        LoadMenuScripts();

        EnableScripts(exploring_scripts, false);
        EnableScripts(menu_scripts, false);

        ChangeGameState(GAME_STATE.START_LEVEL);
        ChangeGameState(GAME_STATE.LOAD);
        ChangeGameState(GAME_STATE.EXPLORING);
    }

    public void LoadExploringScripts()
    {
        exploring_scripts = new List<MonoBehaviour>();
        exploring_scripts.Add(script_level_loader.Player_controller);
        exploring_scripts.Add(script_level_loader.Player_Movements);
    }

    public void LoadMenuScripts()
    {
        menu_scripts = new List<MonoBehaviour>();
        menu_scripts.Add(script_level_loader.Player_menu_controller);
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
                    EnableScripts(exploring_scripts, false);
                    EnableScripts(menu_scripts, true);
                    break;
                case GAME_STATE.END_LEVEL:
                    break;
                case GAME_STATE.QUIT:
                    //exit game
                    break;
                case GAME_STATE.DEATH:
                    EnableScripts(exploring_scripts, false);
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
                    EnableScripts(exploring_scripts, true);
                    EnableScripts(menu_scripts, false);
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
                    EnableScripts(exploring_scripts, true);
                    break;
                default:
                    break;
            }
        }

        current_game_state = next_state;
    }
}