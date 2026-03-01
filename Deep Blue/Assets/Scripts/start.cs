using UnityEngine;
using TMPro;  // Required for TextMeshPro
using UnityEngine.UI;

public class TMPStartButton : MonoBehaviour
{
    private void Start()
    {
        // Pause the game at start
        Time.timeScale = 0f;
    }

    // Assign this method to your Button OnClick event
    public void OnButtonClick()
    {

        // Resume time
        Time.timeScale = 1f;

        // Hide the button's parent panel
        if (transform.parent != null)
        {
            transform.parent.gameObject.SetActive(false);
        }


    }
}