using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Skal kun eksistere EN GameManager i spillet v�rt
    // Den skal eksistere p� tvers av scener
    // Ta med informasjon mellom scener
    // Tilgjengeliggj�re informasjon for mange GameObjects

    // Deklarerer singleten og bestemmer global tilgjengelighet og rettigheter til endring
    public static GameManager Instance { get; private set; }

    // Se n�v�rende liv spilleren har
    // Se maks liv spilleren kan ha

    // Variabler til de ulike typene fr�
    private int waterSeeds = 0;
    private int climbSeeds = 0;
    private bool water = true;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            // Gj�re gameObject tilgjengelig p� tvers av scener
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // N�r det opprettes nytt GameObject, skal det gamle umiddelbart �delegges
            Destroy(gameObject);
        }
    }

    // Disse metodene legger til fr� i climbSeed osv.
    // Husk at det ikke skjer f�r du kaller metodene/
    public void AddClimbSeed()
    {
        climbSeeds++;
    }

    public void RemoveClimbSeed()
    {
        climbSeeds--;
    }

    public void AddWaterSeed()
    {
        waterSeeds ++;
    }

    public void RemoveWaterSeed()
    {
        waterSeeds--;
    }

    public void AddWater()
    {
        water = true;
    }

    public void RemoveWater()
    {
        water = false;
    }

    // Returnerer variablene for fr� for � gj�re dem tilgjengelige overalt
    public int CurrentWaterSeeds()
    {
        return waterSeeds;
    }

    public int CurrentClimbSeeds()
    {
        return climbSeeds;
    }

    public bool CurrentWater()
    {
        return water;
    }
}
