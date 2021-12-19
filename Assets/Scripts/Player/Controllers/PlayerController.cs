using UnityEngine;

//gestisce l'interazione fra le varie classi del giocatore
public class PlayerController : MonoBehaviour
{
    private InputController input_controller;
    private PlayerMovements player_movements;
    private PlayerAnimations player_animations;
    private PlayerInventoryController player_inventory_controller;
    private PlayerStatsController player_stats;
    private PlayerCollisionController player_collisions;
    private PlayerFx player_fx;

    private Whip whip;

    public InputController Input_controller { get => input_controller; set => input_controller = value; }
    public PlayerMovements Player_movements { get => player_movements; set => player_movements = value; }
    public PlayerAnimations Player_animations { get => player_animations; set => player_animations = value; }
    public PlayerInventoryController Player_inventory_controller { get => player_inventory_controller; set => player_inventory_controller = value; }
    public PlayerFx Player_fx { get => player_fx; set => player_fx = value; }
    public PlayerStatsController Player_stats { get => player_stats; set => player_stats = value; }
    public PlayerCollisionController Player_collision { get => player_collisions; set => player_collisions = value; }

    public Whip Whip { get => whip; set => whip = value; } //sostituire con inventory controller

    public void Init(InputController input, PlayerMovements movements, PlayerAnimations animations, PlayerInventoryController pic, PlayerStatsController psc,
                    PlayerCollisionController pcc, PlayerFx pfx)
    {
        input_controller = input;
        player_movements = movements;
        player_animations = animations;
        player_inventory_controller = pic;
        player_stats = psc;
        player_collisions = pcc;
        player_fx = pfx;
    }

    public void EquipWhip(Whip w) { whip = w; } // sostituire con inventoryc controller

    //attiva le azioni necessarie in base all'input ricevuto dal'utente
    private void FixedUpdate()
    {
        PlayerIdle();

        if (input_controller.Player_input.Jump && player_movements.Ground)
        {
            PlayerJump();
        }

        if (input_controller.Player_input.Up)
        {
            if (player_collisions.Interactable != null)
                player_collisions.Interactable.Action();
        }

        if (input_controller.Player_input.Right)
            PlayerWalk(Vector3.right, input_controller.Player_input.Running);

        if (input_controller.Player_input.Left)
            PlayerWalk(Vector3.left, input_controller.Player_input.Running);

        if (input_controller.Player_input.Crouch)
            PlayerCrouching(true);
        else
            PlayerCrouching(false);

        if (input_controller.Player_input.Attack)
        {
            PlayerIdle();
            PlayerAttack();
        }
    }

    private void Update()
    {
        if (input_controller.Player_input.Action)
        {
            //do action based on item
        }

        if (input_controller.Player_input.Menu)
        {
            PlayerIdle();
            player_stats.ShowStatsCard(true);
            FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.MENU);
        }

        if (input_controller.Player_input.Cancel)
        {
            player_stats.ShowStatsCard(false);
            FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.EXPLORING);
        }
    }

    //azioni effetuate quando il personaggio è fermo (idle)
    public void PlayerIdle()
    {
        player_animations.Idle();
        player_fx.StopAudio();
    }

    //azioni effettuate quando il personaggio cammina
    public void PlayerWalk(Vector3 direction, float running)
    {
        if(running <= player_movements.Walk_to_speed_treshold)
        {
            player_animations.Walking();
            player_fx.PlayFX(PlayerFx.AUDIO_CLIP.WALKING);
        }
        else
        {
            player_animations.Running();
            player_fx.PlayFX(PlayerFx.AUDIO_CLIP.RUNNING);
        }

        player_movements.MovePlayer(direction, running);
    }

    //azioni effetuate quando il personaggio salta
    public void PlayerJump()
    {
        player_movements.Jump();
        player_animations.Jumping();
        player_fx.PlayFX(PlayerFx.AUDIO_CLIP.JUMPING);
    }

    //azioni effettuate quando il personaggio si accovaccia
    public void PlayerCrouching(bool value)
    {
        player_movements.Crouched = value;

        if (value)
        {
            player_animations.Crouching();
            player_fx.PlayFX(PlayerFx.AUDIO_CLIP.CROUCHING);
        }
    }

    //azioni effettuate quando il personaggio attacca
    public void PlayerAttack()
    {
        if (!player_movements.Crouched)
        {
            whip.Attack(); //sostituire con arma equipaggiata inventario
            Player_animations.BaseAttack();
            player_fx.PlayFX(PlayerFx.AUDIO_CLIP.ATTACK_1);
        }
    }

    public void CancelAttack()
    {
        whip.ResetAttack();
    }

    public void LightHit(int damage)
    {
        Player_movements.FallBackLight();
        player_stats.UpdatePlayerLifePoints(-damage);
        player_animations.LightHit();
        player_fx.PlayFX(PlayerFx.AUDIO_CLIP.HIT);
    }
}