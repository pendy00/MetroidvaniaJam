using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int vite_base;
    private int vite_attuale;
    public int vite_massime;

    public int Vite_base { get => vite_base; set => vite_base = value; }
    public int Vite_attuale { get => vite_attuale; set => vite_attuale = value; }
    public int Vite_massime { get => vite_massime; set => vite_massime = value; }

    public void ResetValues()
    {
        vite_attuale = vite_massime = vite_base;
    }
    public void UpdateViteAttuale(int value)
    {
        if(vite_attuale <= vite_massime && vite_attuale > 0)
            vite_attuale += value;

        if (vite_attuale <= 0)
            FindObjectOfType<GameStateController>().ChangeGameState(GameStateController.GAME_STATE.DEATH);
    }

    public void UpdateViteMassime(int value)
    {
        vite_massime += value;
    }
}