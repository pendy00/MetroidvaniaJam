using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombactSystem : MonoBehaviour
{
    private PlayerStatsController player_stats_controller;
    private Whip whip; //sostituire con riferimento arma equipaggiata

    public PlayerStatsController Player_stats_controller { get => player_stats_controller; set => player_stats_controller = value; }

    public Whip Whip { get => whip; set => whip = value; }

    public void Init(PlayerStatsController controller)
    {
        player_stats_controller = controller;
    }

    public void EquipWhip(Whip w)
    {
        whip = w;
    }

    private void FixedUpdate()
    {
        if (whip != null && whip.Hit)
        {
            DamageEnemy(whip.Target);
        }
    }

    public void DamageEnemy(EnemyController target)
    {
        if (target != null)
        {
            target.DamageEnemy(player_stats_controller.Player_Stats.Forza_attuale);
            whip.EnemyHit();
        }
    }
}