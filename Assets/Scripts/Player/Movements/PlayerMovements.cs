using UnityEngine;

//gestisce tutti i movimenti del giocatore
public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb; // rigidbody del giocatore
    private bool ground; // determina se il giocatore sta saltando o è a terra

    public float player_walking_speed; // velocità di movimento
    public float player_running_speed; // velocità di corsa
    public float jump_strength; // forza del salto
    public float crouched_speed; // velocità di moviemento da accovacciato

    public bool Ground { get => ground; set => ground = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        //controlla se il giocatore è sul terreno o in aria
        if (rb.velocity.y != 0)
            ground = false;
        else
            ground = true;
    }

    // muove il giocatore nella direzione dell'asse indicato
    public void MovePlayer(Vector3 direction)
    {
        if (Mathf.Abs(rb.velocity.x) < 1.5f)
            rb.AddForce(direction * player_walking_speed, ForceMode2D.Force);
        else
            rb.AddForce(direction * player_running_speed, ForceMode2D.Force);

        this.transform.localScale = new Vector3(1.0f * direction.x, 1, 1);
    }

    //se su terreno il giocatore può saltare
    public void Jump()
    {
        if (ground)
            rb.AddForce(Vector2.up * jump_strength, ForceMode2D.Impulse);
    }
}