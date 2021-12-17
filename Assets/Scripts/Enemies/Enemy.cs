using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int punti_ferita_massimi;
    private int punti_ferita_attuali;

    public int forza;
    public int costituzione;
    public int livello;

    public int Punti_Ferita_Attuali { get => punti_ferita_attuali; set => punti_ferita_attuali = value; }
    public int Forza { get => forza; set => forza = value; }
    public int Contituzione { get => costituzione; set => costituzione = value; }
    public int Livello { get => livello; set => livello = value; }
}