using System.Threading.Tasks;
using UnityEngine;

//gestisce tutti i movimenti del giocatore
public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb; // rigidbody del giocatore
    private bool ground; // determina se il giocatore sta saltando o è a terra
    private bool crouched; //determina se il giocatore è accovacciato

    private Vector3 direction;

    public float player_walking_speed; // velocità di movimento
    public float player_running_speed; // velocità di corsa
    private float walk_to_speed_treshold;
    public float jump_strength; // forza del salto
    public int fallback_light_strenght; // forza di rimbalzo quando il giocatore viene colpito

    public bool Ground { get => ground; set => ground = value; }
    public bool Crouched { get => crouched; set => crouched = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    public Vector3 Direction { get => direction; set => direction = value; }
    public float Walk_to_speed_treshold { get => walk_to_speed_treshold; set => walk_to_speed_treshold = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        //controlla se il giocatore è sul terreno o in aria
        if (rb.velocity.y != 0)
        {
            ground = false;
        }
        else
            ground = true;
    }

    // muove il giocatore nella direzione dell'asse indicato
    public void MovePlayer(Vector3 vector, float running)
    {
        if (!crouched)
        {
            if (running >= walk_to_speed_treshold)
                rb.MovePosition(this.transform.position + (vector * player_running_speed * Time.fixedDeltaTime));
            else
                rb.MovePosition(this.transform.position + (vector * player_walking_speed * Time.fixedDeltaTime));
        }

        this.transform.localScale = new Vector3(1.0f * vector.x, 1, 1);
        direction = vector;

    }

    public void FallBackLight()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        Rb.AddForce(Vector3.right * direction.x * -1 * fallback_light_strenght, ForceMode2D.Impulse);
    }

    //se su terreno il giocatore può saltare
    public async void Jump()
    {
        await Task.Delay(300);

        if (ground)
            rb.AddForce(Vector2.up * jump_strength, ForceMode2D.Impulse);
    }
}