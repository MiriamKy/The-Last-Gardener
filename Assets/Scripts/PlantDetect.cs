using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlantDetect : MonoBehaviour
{
    [SerializeField] private bool detectClimbPlant = false;

    private PlayerControls playerInput;
    void Start()
    {
        playerInput = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Climbable"))
        {
            detectClimbPlant = true;
            Debug.Log("Detect Plant");
            //Endre bevegelsesretning fra X til Y på "w"-tastetrykk
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            detectClimbPlant = false;
            Debug.Log("Detect ikke sant");
            //Endre bevegelsesretning fra Y til X på "w"-tastetrykk
        }
    }

    public bool DetectClimbPlant()
    {
        return detectClimbPlant;
    }
}
