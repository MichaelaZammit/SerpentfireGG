using UnityEngine;
using UnityEngine.SceneManagement; // Import the SceneManager class

public partial class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame method called");

        // Load the "SampleScene" when the button is clicked
        SceneManager.LoadScene("SampleScene");
    }

}

