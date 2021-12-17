using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : EnemyController
{
    public override Enemy Enemy { get => (Enemy1) enemy; set => enemy = (Enemy1) value; }
    public override EnemyFx Enemy_fx { get => (Enemy1Fx) enemy_fx; set => enemy_fx = (Enemy1Fx) value; }
    public override EnemyAnimations Enemy_animations { get => (Enemy1Animations)enemy_animations; set => enemy_animations = (Enemy1Animations)value; }
    public override EnemyMovements Enemy_movements { get => (Enemy1Movements) enemy_movements; set => enemy_movements = (Enemy1Movements) value; }
    public override EnemyAI Enemy_ai { get => (Enemy1AI)enemy_ai; set => enemy_ai = (Enemy1AI) value; }
    public override void DamageEnemy(int damage)
    {
        Enemy.Punti_Ferita_Attuali -= damage;

        if (Enemy.Punti_Ferita_Attuali > 0)
        {
            Enemy_animations.Hit();
        }
        else
        {
            Enemy_animations.KO();
            enemy.enabled = false;
            enemy_ai.enabled = false;
            enemy_movements.enabled = false;
            StartCoroutine(DestroyObject());
        }
    }
}