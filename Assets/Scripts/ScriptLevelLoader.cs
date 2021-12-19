using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ScriptLevelLoader : MonoBehaviour
{
    //Input Controller
    private InputController input_controller;
    private InputKeyboard input_keyboard;
    private PlayerInput player_input;

    //Player Scripts Reference
    private Player player;
    private PlayerStats player_stats;
    private PlayerLifePoints player_life;
    private PlayerExp player_exp;
    private PlayerLives player_live;
    private PlayerLevel player_level;
    private PlayerAnimations player_animations;
    private PlayerMovements player_movements;


    private PlayerUIStats player_ui_stats;
    private PlayerLifeBeatUI player_life_beat_ui;
    private PlayerUIExpBar player_ui_expbar;
    private PlayerUILives player_ui_lives;
    private PlayerUILevel player_ui_level;
    private PlayerUIForza player_ui_forza;
    private PlayerUICostituzione player_ui_costituzione;
    private PlayerUIIntelligenza player_ui_intelligenza;
    private PlayerUIFortuna player_ui_fortuna;

    private PlayerFx player_fx;

    //Weapon
    private Whip whip;
    private PlayerCombactSystem player_combact_system;

    //@TODO inseire script fx

    //Inventory
    private Inventory inventory;

    private InventoryUI inventory_ui;

    //Player Controllers
    private PlayerController player_controller;
    private PlayerStatsController player_stats_controller;
    private PlayerInventoryController player_inventory_controller;
    private PlayerCollisionController player_collisione_controller;
    private PlayerMenuController player_menu_controller;

    //Dialogue
    private DialogueSystem dialogue_system;
    private DialogueUI dialogue_ui;

    //Dialogue Controller
    private DialogueSystemController dialogue_system_controller;

    //Doors
    private DoorController door_controller;

    public PlayerController Player_controller { get => player_controller; set => player_controller = value; }
    public DialogueSystemController Dialogue_system_controller { get => dialogue_system_controller; set => dialogue_system_controller = value; }
    public PlayerInventoryController Player_inventory_controller { get => player_inventory_controller; set => player_inventory_controller = value; }

    public PlayerAnimations Player_Animations { get => player_animations; set => player_animations = value; }
    public PlayerMovements Player_Movements { get => player_movements; set => player_movements = value; }
    public PlayerMenuController Player_menu_controller { get => player_menu_controller; set => player_menu_controller = value; }

    private bool level_loaded;
    public bool Level_loaded { get => level_loaded; set => level_loaded = value; }


    //Inizializzazione del livello
    public void LevelScriptLoad()
    {
        LoadInputController();
        LoadPlayerStats();
        LoadPlayerUI();
        LoadPlayerControllers();
        LoadPlayerMovements();
        LoadInventory();
        LoadLevelItem();

        LevelLoaded();
    }

    //Ricerca e caricamento script
    public T LoadScript<T>() where T : MonoBehaviour
    {
        T temp = null;
        while (temp == null)
        {
            temp = FindObjectOfType<T>();
        }

        return temp;
    }

    //carica script input
    private void LoadInputController()
    {
        input_controller = LoadScript<InputController>();
        input_keyboard = LoadScript<InputKeyboard>();
        player_input = LoadScript<PlayerInput>();
    }

    //carica script attributi e statistiche giocatore
    private void LoadPlayerStats()
    {
        player = LoadScript<Player>();
        player_stats = LoadScript<PlayerStats>();
        player_life = LoadScript<PlayerLifePoints>();
        player_exp = LoadScript<PlayerExp>();
        player_live = LoadScript<PlayerLives>();
        player_level = LoadScript<PlayerLevel>();
    }

    //carica script UI giocatore
    private void LoadPlayerUI()
    {
        player_ui_stats = LoadScript<PlayerUIStats>();
        player_life_beat_ui = LoadScript<PlayerLifeBeatUI>();
        player_ui_expbar = LoadScript<PlayerUIExpBar>();
        player_ui_lives = LoadScript<PlayerUILives>();
        player_ui_level = LoadScript<PlayerUILevel>();
        player_ui_forza = LoadScript<PlayerUIForza>();
        player_ui_costituzione = LoadScript<PlayerUICostituzione>();
        player_ui_intelligenza = LoadScript<PlayerUIIntelligenza>();
        player_ui_fortuna = LoadScript<PlayerUIFortuna>();
    }

    //carica script movimenti giocatore
    private void LoadPlayerMovements()
    {
        player_movements = LoadScript<PlayerMovements>();
        player_animations = LoadScript<PlayerAnimations>();
    }

    //carica script controller giocatore
    private void LoadPlayerControllers()
    {
        player_controller = LoadScript<PlayerController>();
        player_stats_controller = LoadScript<PlayerStatsController>();
        player_inventory_controller = LoadScript<PlayerInventoryController>();
        player_collisione_controller = LoadScript<PlayerCollisionController>();
        player_fx = LoadScript<PlayerFx>();
        whip = LoadScript<Whip>();
        player_combact_system = LoadScript<PlayerCombactSystem>();
        player_menu_controller = LoadScript<PlayerMenuController>();
    }

    //carica script inventario
    private void LoadInventory()
    {
        inventory = LoadScript<Inventory>();
        inventory_ui = LoadScript<InventoryUI>();
    }

    //carica script dialogo
    private void LoadDialogueSystem()
    {
        dialogue_system = LoadScript<DialogueSystem>();
        dialogue_ui = LoadScript<DialogueUI>();
        Dialogue_system_controller = LoadScript<DialogueSystemController>();
    }

    private void LoadLevelItem()
    {
        door_controller = LoadScript<DoorController>();
    }

    //inizializza i componenti del gioco e abilita attivazione livello
    public void LevelLoaded()
    {
        input_controller.Init(player_input, input_keyboard);

        player_controller.Init(input_controller, player_movements, player_animations, player_inventory_controller, player_stats_controller, player_collisione_controller, player_fx);
        player_controller.EquipWhip(whip);

        //player_inventory_controller.Init(input_controller, player_stats_controller, inventory, inventory_ui);

        player_stats_controller.Init(player_stats, player_ui_stats, player_life, player_life_beat_ui, player_exp, player_ui_expbar, player_level, player_ui_level, player_live, player_ui_lives);

        

        player_ui_stats.Init(player_life_beat_ui, player_ui_expbar, player_ui_lives, player_ui_level, player_ui_forza, player_ui_costituzione, player_ui_intelligenza, player_ui_fortuna);

        player_menu_controller.Init(input_controller, player_ui_stats);

        player_combact_system.Init(player_stats_controller);
        player_combact_system.EquipWhip(whip);

        door_controller.Init(player.gameObject);

        level_loaded = true;
    }
}