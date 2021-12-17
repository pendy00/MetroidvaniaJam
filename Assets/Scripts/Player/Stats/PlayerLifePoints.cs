using UnityEngine;

public class PlayerLifePoints : MonoBehaviour
{
    private int punti_ferita_attuali;
    private int punti_ferita_massimi;
    public int punti_ferita_base;

    public int Punti_ferita_attuali { get => punti_ferita_attuali; set => punti_ferita_attuali = value; }
    public int Punti_ferita_massimi { get => punti_ferita_massimi; set => punti_ferita_massimi = value; }
    public int Punti_ferita_base { get => punti_ferita_base; set => punti_ferita_base = value; }

    public void UpdateLifePoints(int value, PlayerLives vite)
    {
        if(punti_ferita_attuali <= punti_ferita_massimi && punti_ferita_base > 0)
        {
            punti_ferita_attuali += value;

            if (punti_ferita_attuali <= 0)
                vite.UpdateViteAttuale(-1);
        }
            
    }

    public void UpdateLifePointsMax(int value)
    {
        punti_ferita_massimi += value;
    }
}