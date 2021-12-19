using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemInterfaces : MonoBehaviour
{
    //item in the level that is added in the player inventory when player interact with it
    public abstract class Collectible : GameItem
    {
        public abstract void CollectItem(Inventory inventory);
    }
    
    //item in the level that makes an action if player activates it
    public abstract class Interactable: GameItem
    {
        public abstract void Action();
    }

    // items that are stored in multiple quantities in the player inventory and consumed on use
    public abstract class Consumable : Collectible
    {
        public override void CollectItem(Inventory inventory)
        {
            //check if item already in inventory than add item quantity
        }

        //check if item exist in iventory than reduce its quantity by one
        //when reducing quantity by a value higher than one check if wanted quantity is avaiable
        public abstract void UseItem(Inventory inventory);

        //delete item from the inventory
        public abstract void DropItem(Inventory inventory);
    }
}