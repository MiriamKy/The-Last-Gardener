using Unity.VisualScripting;
using UnityEngine;

public class Gardening : MonoBehaviour
{
    // Variabler som skal fortelle oss om vi st�r i n�rheten av et fr�
    [SerializeField] private bool detectDryEarth = false;
    [SerializeField] private bool detectWetEarth = false;
    [SerializeField] private bool detectPlanted = false;

    private GameObject otherGameObject = null;

    private PlayerMovement input;
    public SeedPlant seedPlant;
    public Watering watering;

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
        Debug.Log("Input registrert");

        if (detectPlanted)
        {
            Debug.Log("Jorda er allerede plantet");
            // Legge til beskjed i UI om at jorda er plantet
        }
        else if (detectWetEarth)
        {
            if (otherGameObject != null)
            {
                seedPlant.PlantGrow();
                GameManager.Instance.RemoveClimbSeed();
            }
        }
        else if (detectDryEarth)
        {
            if (otherGameObject != null)
            {
                Debug.Log("Rett f�r kallet p� ChangeEarthVisual");
                watering.ChangeEarthVisual();
                Debug.Log("Rett etter kallet p� ChangeEarthVisual");
                GameManager.Instance.RemoveWater();
            }
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