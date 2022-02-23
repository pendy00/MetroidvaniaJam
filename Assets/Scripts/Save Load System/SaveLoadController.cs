using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    public float save_delay;
    private bool save_enable;

    public bool enable_load;

    private const string player_file = "player";
    private const string collectables_file = "collectables";
    private const string enemies_file = "enemies";

    private void Awake()
    {
        save_enable = true;
    }

    void Start()
    {
        if (enable_load)
        {
            FindObjectOfType<LoadPlayer>().LoadPlayerData(player_file);
            LoadCollectablesData();
            LoadEnemiesData();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (save_enable)
            {
                save_enable = false;
                SaveLoad.ClearDirectory();
                FindObjectOfType<SavePlayer>().SavePlayerData(player_file);
                SaveBulk<GameItemUI>(collectables_file);
                SaveBulk<EnemyController>(enemies_file);
                StartCoroutine(EnableSaving());
            }
        }
    }

    private IEnumerator EnableSaving()
    {
        yield return new WaitForSecondsRealtime(save_delay);
        save_enable = true;
    }

    public void SaveBulk<T>(string file_name) where T : MonoBehaviour
    {
        List<T> objects = new List<T>();
        foreach (T obj in FindObjectsOfType<T>())
            objects.Add(obj);

        SaveLoad.Save.SaveData(file_name, objects.ToArray());
    }

    public void LoadCollectablesData()
    {
        SaveLoad.Load.LoadGameObjects(collectables_file, typeof(ConsumableUI));
    }

    public void LoadEnemiesData()
    {
        SaveLoad.Load.LoadGameObjects(enemies_file, typeof(EnemyController));
    }
}