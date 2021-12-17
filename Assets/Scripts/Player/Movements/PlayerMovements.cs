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
    public float jump_strength; // forza del salto
    private bool is_jumping;
    public int fallback_light_strenght; // forza di rimbalzo quando il giocatore viene colpito

    public bool Ground { get => ground; set => ground = value; }
    public bool Crouched { get => crouched; set => crouched = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    public Vector3 Direction { get => direction; set => direction = value; }

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
        {
            ground = true;
        } 
    }

    // muove il giocatore nella direzione dell'asse indicato
    public void MovePlayer(Vector3 vector)
    {
        if (!crouched)
        {
            if (Mathf.Abs(rb.velocity.x) < 1.5f)
                rb.AddForce(vector * player_walking_speed, ForceMode2D.Force);
            else
                rb.AddForce(vector * player_running_speed, ForceMode2D.Force);
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
        is_jumping = true;
        await Task.Delay(300);
        is_jumping = false;

        if (ground && !is_jumping)
            rb.AddForce(Vector2.up * jump_strength, ForceMode2D.Impulse);
    }
}