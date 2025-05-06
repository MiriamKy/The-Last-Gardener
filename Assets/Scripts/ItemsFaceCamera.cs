using UnityEngine;

public class ItemsFaceCamera : MonoBehaviour

// Kilde:  https://www.youtube.com/watch?v=FjJJ_I9zqJo
// Hentet fra denne videoen. Trengs denne kilden?

{
    private void Start()
    {
        Debug.Log("ItemsFaceCamera");
    }
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
