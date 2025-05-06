using UnityEngine;

public class EarthDetect : MonoBehaviour
{
    // Variabler som skal fortelle oss om vi st�r i n�rheten av et fr�
    [SerializeField] private bool detectDryEarth = false;
    [SerializeField] private bool detectWetEarth = false;

    private GameObject otherGameObject = null;


    private PlayerMovement input;

    private void Start()
    {
        input = GetComponent<PlayerMovement>();
        input.OnGardeningAction += Input_OnGardeningAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dry"))
        {
            detectDryEarth = true;
        }
        if (other.CompareTag("Wet"))
        {
            detectWetEarth = true;
        }
        otherGameObject = other.gameObject;
    }

    // Setter boolen til false n�r spilleren g�r ut av collideren
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dry"))
        {
            detectDryEarth = false;
        }
        if (other.CompareTag("Wet"))
        {
            detectWetEarth = false;
        }
        otherGameObject = null;
    }

    private void Input_OnGardeningAction()
    {
        if (detectDryEarth) // + vannkannen har vann i seg (lage en bool)
        {
            if(otherGameObject != null)
            {
                otherGameObject.tag = "Wet";
                Debug.Log("Tag chenged to Wet");
                // Kalle p� metoden som fjerner vannet fra vannkannen i gameManager
                // Deaktivere DryEarthVisual
                // Aktivere WetEarthVisual
            }

        }
        else if (detectWetEarth) //
        {
            if(otherGameObject != null)
            {
                // Endre tagen p� jorda til planted eller null, kan endres senere
                otherGameObject.tag = "Planted";
                Debug.Log("Tag changed to Planted");
                // Kalle p� metoden som f�r den riktige planten til � vokse
                // Kalle p� metoden som fjerner fr�et som ble brukt fra gameManager
            }
        }
        else
        {
            // "The earth is not watered or you need the correct seed to plant" skrives til en infobox
        }
    }

    // Gj�re informasjonen i variabelene tilgjengelig for andre scripts
    public bool DetectDryEarth()
    {
        return detectDryEarth;
    }
    public bool DetectWetEarth()
    {
        return detectWetEarth;
    }

}