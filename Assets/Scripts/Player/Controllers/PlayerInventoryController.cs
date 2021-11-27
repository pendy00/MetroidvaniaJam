using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private PlayerStatsController player_stats_controller;
    private PlayerAttributesController player_attributes_controller;
    private InputController input_controller;

    private int selected_menu;
    private GameItem temp;

    private Inventory inventory;
    private EquippedInventory equipped_inventory;

    private InventoryUI inventory_ui;
    private EquippedInventoryUI equipped_inventory_ui;

    private void Start()
    {
        player_stats_controller = FindObjectOfType<PlayerStatsController>();
        player_attributes_controller = FindObjectOfType<PlayerAttributesController>();
        input_controller = FindObjectOfType<InputController>();
        inventory = FindObjectOfType<Inventory>();
        inventory_ui = FindObjectOfType<InventoryUI>();
        equipped_inventory = FindObjectOfType<EquippedInventory>();
        equipped_inventory_ui = FindObjectOfType<EquippedInventoryUI>();

        selected_menu = 0;
        temp = null;
    }

    private void Update()
    {
        if(selected_menu == 0)
        {
            if(temp == null)
            {
                if (input_controller.Right)
                    inventory.SelectNextItem();

                if (input_controller.Left)
                    inventory.SelectPreviousItem();

                if (input_controller.Action)
                    temp = inventory.Inventory_Items[inventory.Selected_Item];

                if (input_controller.Cancel)
                {
                    //torna alla fase di gioco
                }
            }
            else
            {
                if (input_controller.Action)
                    ItemAction(temp);

                if (input_controller.Crouch)
                    temp = null;

                if (input_controller.Cancel)
                    temp = null;
            }            
        }

        if (selected_menu == 1)
        {
            if(temp == null)
            {
                if (input_controller.Right)
                    equipped_inventory.SelectNextItem();

                if (input_controller.Left)
                    inventory.SelectPreviousItem();

                if (input_controller.Action)
                    temp = inventory.Inventory_Items[inventory.Selected_Item];

                if(input_controller.Cancel)
                {
                    //torna alla fase di gioco
                }
            }
            else
            {
                if (input_controller.Action)
                    temp = null;

                if (input_controller.Crouch)
                {
                    UnequipItem(temp);
                    temp = null;
                }                    

                if (input_controller.Cancel)
                    temp = null;
            }
            
        }            
    }

    public void ItemAction(GameItem item)
    {
        switch (item.Game_Item_Type)
        {
            case GameItem.GAME_ITEM_TYPE.ARMOR:
                EquipItem(item);
                break;
            case GameItem.GAME_ITEM_TYPE.WEAPON:
                EquipItem(item);
                break;
            case GameItem.GAME_ITEM_TYPE.CONSUMABLE:
                UseConsumableItem(temp);
                break;
            case GameItem.GAME_ITEM_TYPE.KEY_ITEM:
                UseKeyItem(temp);
                break;
            default:
                break;
        }
    }

    public void EquipItem(GameItem item)
    {
        Equipable equip = (Equipable)item;

        if(player_stats_controller.Player_level.Livello_attuale >= equip.Livello)
        {
            Equipable unequipped_item = equipped_inventory.EquipItem(equip);

            if (unequipped_item != null)
                UnequipItem(item);

            player_attributes_controller.UpdateEnergiaMax(equip.Energia_Massima);
            player_attributes_controller.UpdateForza(equip.Forza);
            player_attributes_controller.UpdateCostituzione(equip.Costituzione);
            player_attributes_controller.UpdateFortuna(equip.Fortuna);

        }
        else
        {
            //messaggio livello giocatore troppo basso;
        }
        
    }

    public void UseConsumableItem(GameItem item)
    {

    }

    public void UseKeyItem(GameItem item)
    {

    }
    public void UnequipItem(GameItem item)
    {
        Equipable unequipped_item = equipped_inventory.UnequipItem((Equipable) item);
        inventory.AddItem(unequipped_item);
        player_attributes_controller.UpdateEnergiaMax(-1 * unequipped_item.Energia_Massima);
        player_attributes_controller.UpdateForza(-1 * unequipped_item.Forza);
        player_attributes_controller.UpdateCostituzione(-1 * unequipped_item.Costituzione);
        player_attributes_controller.UpdateFortuna(-1 * unequipped_item.Fortuna);
    }
}