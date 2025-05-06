using UnityEngine;

public class SeedDetect : MonoBehaviour
{
    // Variabler som skal fortelle oss om vi st�r i n�rheten av et fr�
    [SerializeField] private bool detectClimbSeed = false;
    [SerializeField] private bool detectWaterSeed = false;

    private PlayerMovement input;

    private void Start()
    {
        input = GetComponent<PlayerMovement>();
        input.OnInteractAction += Input_OnInteractAction;
    }

    // Metode: Hvis detectClimbSeed er true - kj�r metode increaseClimbSeed, for � �ke antallet climbSeeds.
    // - Samme for WaterSeed
    // Else - logg til konsollen
    private void Input_OnInteractAction()
    {
        if(detectClimbSeed)
        {
            GameManager.Instance.AddClimbSeed();
        } if (detectWaterSeed) {
            GameManager.Instance.AddWaterSeed();
        } else
        {
            Debug.Log("Ikke legg til");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Hvis spilleren v�r g�r inn i triggeren, sett pickSeed til true
        if (other.CompareTag("ClimbSeed")) //"ClimbSeed" er navnet p� taggen, husk � tagge
        {
            detectClimbSeed = true;
            //F� opp et symbol som sier at du kan plukke (canvas)
            Debug.Log("Climb seed = " + detectClimbSeed);
        }
        if (other.CompareTag("WaterSeed")) //"WaterSeed" er navnet p� taggen, husk � tagge
        {
            //F� opp et symbol som sier at du kan plukke (canvas)
            detectWaterSeed = true;
            Debug.Log("Water Seed = " + detectWaterSeed);
        }
    }

    // Setter boolen til false n�r spilleren g�r ut av collideren
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ClimbSeed"))
        {
            detectClimbSeed = false;
            Debug.Log("Climb seed = " + detectClimbSeed);
        }
        if (other.CompareTag("WaterSeed"))
        {
            detectWaterSeed = false;
            Debug.Log("Water Seed = " + detectWaterSeed);
        }
    }

    // Gj�re informasjonen i variabelene tilgjengelig for andre scripts
    public bool DetectClimbSeed()
    {
        return detectClimbSeed;
    }
    public bool DetectWaterSeed()
    {
        return detectWaterSeed;
    }


}
