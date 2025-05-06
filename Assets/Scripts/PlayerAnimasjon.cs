using UnityEngine;
using UnityEngine.UIElements;

public class playerAnimasjon : MonoBehaviour
{
    
    [SerializeField] PlayerMovement player;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player.IsWalking() == true)
        {
            animator.SetBool("isWalking", true);
            Debug.Log("WALKING");
        }
        if (player.IsWalking() == false) 
        {
            animator.SetBool("isWalking", false);
        }
    }

}
