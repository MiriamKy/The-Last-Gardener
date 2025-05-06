using UnityEngine;

public class Climbing : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    private Animator animator;

    private bool isClimbing = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        animator.SetFloat("xMove", xMove);

        if (isClimbing && xMove > 0)
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true);
        }
        else
        {
            isClimbing = false;
            animator.SetBool("isClimbing", false);
        }
    }

    public bool IsClimbing()
    {
        return isClimbing;
    }
}
