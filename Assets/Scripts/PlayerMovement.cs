using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls playerInput;
    // private Animator animator;
    [SerializeField] PlantDetect plantDetect;

    //Deklarerer eventene for interactions og gardening // Heter det � deklarere??
    public event Action OnInteractAction;
    public event Action OnGardeningAction;

    private bool isWalking = false;
    [SerializeField] public float speed = 5f; // Definerer farten til spilleren
    // [SerializeField] private float climbingSpeed = 3f; // Bruke? denne til � justere farten p� klatring separat
    [SerializeField] private bool isClimbing = false;

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

    private void Update()
    {
        // Henter input fra bruker, og konverterer den til 3 dimensjoner
        Vector3 movementVector = playerInput.Player.Move.ReadValue<Vector3>();

        if (movementVector == Vector3.zero) // Hvis ingen input
        {
            isWalking = false; // Bruker bool til � fortelle at spilleren ikke kan g�
            // animator.SetBool("isWalking", false);
        }
        else
        {
            isWalking = true; // Bruker bool for � fortelle at spilleren kan g�
            // animator.SetBool("isWalking", true);
        }
        // Kobler p� transform-komponentet for � kontrollere posisjonen til spilleren via input
        // Forel�pig raskeste l�sning (kan bli behov for � legge til fysikk senere)
        transform.Translate(speed * Time.deltaTime * movementVector);

        float zMove = Input.GetAxis("Vertical");

        // animator.SetFloat("xMove", xMove);

        if (plantDetect.DetectClimbPlant() && zMove != 0)
        {
            isClimbing = true;
            // animator.SetBool("isClimbing", true);
        }
        else
        {
            isClimbing = false;
            // animator.SetBool("isClimbing", false);
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsClimbing()
    {
        return isClimbing;
    }

}
