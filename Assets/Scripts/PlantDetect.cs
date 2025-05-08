using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlantDetect : MonoBehaviour
{
    [SerializeField] private bool canClimb = false;

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
            canClimb = true;
            Debug.Log("Detected climbable object");
            //Endre bevegelsesretning fra X til Y på "w"-tastetrykk
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            canClimb = false;
            //Endre bevegelsesretning fra Y til X på "w"-tastetrykk
        }
    }

    public bool CanClimb()
    {
        return canClimb;
    }
}
