using UnityEngine;

public class Watering : MonoBehaviour
{
    public void ChangeEarthVisual()
    {
        Debug.Log("ChangeEarthVisual kjører");
        if (GameManager.Instance.CurrentWater())
        {
            gameObject.tag = "Wet";
            Debug.Log("Tag = wet");

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform earthVisualChild = transform.GetChild(i);

                if (earthVisualChild.CompareTag("Dry"))
                {
                    earthVisualChild.gameObject.SetActive(false);
                }
                if (earthVisualChild.CompareTag("Wet"))
                {
                    earthVisualChild.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Det er ikke vann i vannkanna");
            // Legge til beskjed i UI
        }
    }
}
