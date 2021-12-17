using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    private EnemyController enemy_controller;

    protected EnemyController Enemy_controller { get => enemy_controller; set => enemy_controller = value; }

    public void Init(EnemyController controller)
    {
        enemy_controller = controller;
    }
}