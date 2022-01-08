using UnityEngine;

public class MenuScriptsLoader : MonoBehaviour
{
    private PlayerInputController player_input_controller;
    private InventoryController inventory_controller;
    private PlayerAttributesController player_attributes_controller;

    private PlayerMenuController player_menu_controller;
    private CollectableItemController collectable_item_controller;
    private ItemLibrary item_library;

    private PlayerInventoryMenu player_inventory_menu;

    private bool menu_loaded;

    public bool Menu_loaded { get => menu_loaded; set => menu_loaded = value; }
    public void LoadMenu()
    {
        player_input_controller = ScriptsLoader.LoadScript<PlayerInputController>();
        inventory_controller = ScriptsLoader.LoadScript<InventoryController>();
        player_menu_controller = ScriptsLoader.LoadScript<PlayerMenuController>();
        player_attributes_controller = ScriptsLoader.LoadScript<PlayerAttributesController>();

        player_inventory_menu = ScriptsLoader.LoadScript<PlayerInventoryMenu>();
        collectable_item_controller = ScriptsLoader.LoadScript<CollectableItemController>();
        item_library = ScriptsLoader.LoadScript<ItemLibrary>();
        InitMenu();
    }

    public void InitMenu()
    {
        collectable_item_controller.Init(player_attributes_controller, item_library);

        player_inventory_menu.Init(player_input_controller, inventory_controller, player_attributes_controller, collectable_item_controller);

        player_menu_controller.Init(player_input_controller, inventory_controller, player_attributes_controller, player_inventory_menu);

        menu_loaded = true;
    }
}