using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Skal kun eksistere EN GameManager i spillet vårt
    // Den skal eksistere på tvers av scener
    // Ta med informasjon mellom scener
    // Tilgjengeliggjøre informasjon for mange GameObjects

    // Deklarerer singleten og bestemmer global tilgjengelighet og rettigheter til endring
    public static GameManager Instance { get; private set; }

    // Se nåværende liv spilleren har
    // Se maks liv spilleren kan ha

    // Variabler til de ulike typene frø
    private int waterSeeds = 0;
    private int climbSeeds = 0;
    private bool water = true;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            // Gjøre gameObject tilgjengelig på tvers av scener
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Når det opprettes nytt GameObject, skal det gamle umiddelbart ødelegges
            Destroy(gameObject);
        }
    }

    // Disse metodene legger til frø i climbSeed osv.
    // Husk at det ikke skjer før du kaller metodene/
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

    // Returnerer variablene for frø for å gjøre dem tilgjengelige overalt
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
