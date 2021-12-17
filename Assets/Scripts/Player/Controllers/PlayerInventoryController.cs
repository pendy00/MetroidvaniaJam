using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    /*
    private InputController input_controller;

    private PlayerStatsController player_stats_controller;

    private int selected_menu;
    private GameItem temp;

    private Inventory inventory;

    private InventoryUI inventory_ui;

    public void Init(InputController ic, PlayerStatsController psc, Inventory i, InventoryUI iui)
    {
        input_controller = ic;
        player_stats_controller = psc;
        inventory = i;
        inventory_ui = iui;

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
                    FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
                    ShowInventory(false);
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
    }

    public void ShowInventory(bool value)
    {
        inventory_ui.ShowInventory(value);
    }
    /*
    public void ItemAction(GameItem item)
    {
        switch (item.Game_Item_Type)
        {
            case GameItem.GAME_ITEM_TYPE.ARMOR:
                //EquipItem(item);
                break;
            case GameItem.GAME_ITEM_TYPE.WEAPON:
                //EquipItem(item);
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

    public void UseConsumableItem(GameItem item)
    {
        // attiva effetto del consumabile
    }

    public void UseKeyItem(GameItem item)
    {
        //attiva effetto del key item se può essere utilizzato
    }

    /*
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

    public void UnequipItem(GameItem item)
    {
        Equipable unequipped_item = equipped_inventory.UnequipItem((Equipable) item);
        inventory.AddItem(unequipped_item);
        player_attributes_controller.UpdateEnergiaMax(-1 * unequipped_item.Energia_Massima);
        player_attributes_controller.UpdateForza(-1 * unequipped_item.Forza);
        player_attributes_controller.UpdateCostituzione(-1 * unequipped_item.Costituzione);
        player_attributes_controller.UpdateFortuna(-1 * unequipped_item.Fortuna);
    }
    */
}