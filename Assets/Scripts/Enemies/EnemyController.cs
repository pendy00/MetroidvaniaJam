using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected Enemy enemy;
    protected EnemyFx enemy_fx;
    protected EnemyAnimations enemy_animations;
    protected EnemyMovements enemy_movements;
    protected EnemyAI enemy_ai;

    public float despawn_time;

    public abstract Enemy Enemy { get; set; }
    public abstract EnemyFx Enemy_fx { get; set; }
    public abstract EnemyAnimations Enemy_animations { get; set; }
    public abstract EnemyMovements Enemy_movements { get; set; }
    public abstract EnemyAI Enemy_ai { get; set; }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        enemy_movements = GetComponent<EnemyMovements>();
        enemy_fx = GetComponent<EnemyFx>();
        enemy_animations = GetComponentInChildren<EnemyAnimations>();
        enemy_ai = GetComponentInChildren<EnemyAI>();

        enemy_ai.Init(this);
        enemy.Punti_Ferita_Attuali = enemy.punti_ferita_massimi;
    }

    public abstract void DamageEnemy(int damage);

    public IEnumerator DestroyObject()
    {
        yield return new WaitForSecondsRealtime(despawn_time);
        Destroy(this.gameObject);
    }
}