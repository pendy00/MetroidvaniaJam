using UnityEngine;

// load and init all the menu's required script to work properly
public class MenuScriptsLoader : MonoBehaviour
{
    private PlayerInputController player_input_controller;
    private PlayerInventoryController inventory_controller;
    private PlayerAttributesController player_attributes_controller;
    private PlayerEquipmentController player_equipment_controller;

    private PlayerMenuController player_menu_controller;
    private CollectableItemController collectable_item_controller;
    private ItemLibrary item_library;

    private PlayerInventoryMenu player_inventory_menu;
    private PlayerEquipmentMenu player_equipment_menu;

    public PlayerMenuController Player_menu_controller { get => player_menu_controller; }
    public PlayerInventoryMenu Player_inventory_menu { get => player_inventory_menu; }
    public PlayerEquipmentMenu Player_equipment_menu { get => player_equipment_menu; }

    // find and load player scripts
    public void LoadMenu()
    {
        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();
        inventory_controller = ScriptsLoader.LoadScript<PlayerInventoryController>();
        player_attributes_controller = ScriptsLoader.LoadScript<PlayerAttributesController>();
        player_equipment_controller = ScriptsLoader.LoadScript<PlayerEquipmentController>();

        player_menu_controller = ScriptsLoader.LoadScript<PlayerMenuController>();
        collectable_item_controller = ScriptsLoader.LoadScript<CollectableItemController>();
        item_library = ScriptsLoader.LoadScript<ItemLibrary>();

        player_inventory_menu = ScriptsLoader.LoadScript<PlayerInventoryMenu>();
        player_equipment_menu = ScriptsLoader.LoadScript<PlayerEquipmentMenu>();
        
        InitMenu();
    }

    // initialize and connect scripts
    public void InitMenu()
    {
        collectable_item_controller.Init(player_attributes_controller, item_library, inventory_controller, player_equipment_controller);

        player_inventory_menu.Init(player_input_controller, inventory_controller, collectable_item_controller);

        player_equipment_menu.Init(player_input_controller, player_equipment_controller);

        player_menu_controller.Init(player_input_controller, player_attributes_controller, player_inventory_menu, player_equipment_menu);
    }
}