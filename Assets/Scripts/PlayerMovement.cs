using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerInput;

    // Definerer farten til spilleren
    [SerializeField] public float speed = 5f;
    [SerializeField] public float rotationSpeed = 1f;

    // staret med står i ro 
    private bool isWalking = false;

    //Deklarerer eventene for interactions og gardening // Heter det å deklarere??
    public event Action OnInteractAction;
    public event Action OnGardeningAction;

    void Awake()
    {
        playerInput = new PlayerControls();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    public void OnMove()
    {
        
    }
    void Start()
    {
        //Setter opp lyttere til eventene
        playerInput.Player.Interact.performed += Interact_performed;
        playerInput.Player.Gardening.performed += Gardening_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        // Trigger den Action som ble laget legner opp og sjekker om noen lytter
        OnInteractAction?.Invoke();
    }

    private void Gardening_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Gardening_performed in PlayerMovement");
        OnGardeningAction?.Invoke();
    }


    // Sjekker om en tast trykkes og kaller Move-funksjonen hvis ja
    void Update()
    {
        // Henter input fra bruker, og konverterer den til 3 dimensjoner
        Vector3 movementVector = playerInput.Player.Move.ReadValue<Vector3>();

        Vector3 moveDirection = new Vector3(movementVector.x, 0, movementVector.y);




        //Animasjon av karakteren ved gange
        if (movementVector == Vector3.zero)
        {
            isWalking = false;
        }
        // Kanskje legge til betingelse for bevegelsesretning her??
        else
        {
            isWalking = true;

            //rotasjon på karitene
            Vector3 rotationVector = movementVector.normalized;
           transform.rotation = Quaternion.LookRotation(moveDirection.normalized);
        }
        // Kobler på transform-komponentet for å kontrollere posisjonen til spilleren via input
        // Foreløpig raskeste løsning (kan bli behov for å legge til fysikk senere)
        transform.Translate(speed * Time.deltaTime * movementVector, Space.Self);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

}
