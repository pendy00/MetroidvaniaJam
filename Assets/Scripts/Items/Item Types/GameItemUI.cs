using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemUI : MonoBehaviour
{
    private GameItem game_item;
    private Sprite sprite;

    public GameItem Game_item { get => game_item; set => game_item = value; }
    public Sprite Game_item_sprite { get => sprite; set => sprite = value; }

    private void Awake()
    {
        game_item = new GameItem();
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void Collect()
    {
        Destroy(this.gameObject);
    }
}