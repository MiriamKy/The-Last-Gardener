using UnityEngine;

public class Gardening : MonoBehaviour
{
    // Variabler som skal fortelle oss om vi står i nærheten av et frø
    [SerializeField] private bool detectDryEarth = false;
    [SerializeField] private bool detectWetEarth = false;
    [SerializeField] private bool detectPlanted = false;

    private GameObject otherGameObject = null;

    private PlayerMovement input;
    public SeedPlant seedPlant;

    private void Start()
    {
        input = GetComponent<PlayerMovement>();
        input.OnGardeningAction += Input_OnGardeningAction;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Dry"))
        {
            detectDryEarth = true;
            detectWetEarth = false;
            detectPlanted = false;
        }
        if (other.CompareTag("Wet"))
        {
            detectWetEarth = true;
            detectDryEarth = false;
            detectPlanted = false;
        }
        if (other.CompareTag("Planted"))
        {
            detectDryEarth = false;
            detectWetEarth = false;
            detectPlanted = true;
        }
        otherGameObject = other.gameObject;
    }

    private void Input_OnGardeningAction()
    {
        if (detectPlanted)
        {
            Debug.Log("Jorda er allerede plantet");
            // Legge til beskjed i UI om at jorda er plantet
        }
        else if (detectWetEarth)
        {
            if (otherGameObject != null)
            {
                otherGameObject.tag = "Planted";
                Debug.Log("Tag changed to Planted");
                seedPlant.Plant();
                GameManager.Instance.RemoveClimbSeed();
                GameManager.Instance.RemoveWater();
            }
        }
        else if (detectDryEarth)
        {
            if (otherGameObject != null)
            {
                // START HER, DET ER NOE HER SOM IKKE FUNKER
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform earthVisualChild = transform.GetChild(i);
                    if (earthVisualChild.CompareTag("Dry"))
                    {
                        earthVisualChild.GetChild(0).gameObject.SetActive(false);
                    }
                    if (earthVisualChild.CompareTag("Wet"))
                    {
                        earthVisualChild.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
            otherGameObject.tag = "Wet";
            Debug.Log("Tag changed to Wet");

            // Kalle på metoden som fjerner vannet fra vannkannen i gameManager
            // Deaktivere DryEarthVisual
            // Aktivere WetEarthVisual
        }
        else
        {
            // "The earth is not watered or you need the correct seed to plant" skrives til en infobox
        }
    }

    // Gjøre informasjonen i variabelene tilgjengelig for andre scripts
    public bool DetectDryEarth()
    {
        return detectDryEarth;
    }
    public bool DetectWetEarth()
    {
        return detectWetEarth;
    }

}