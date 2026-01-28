using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void changeScene(int a)
    {
        SceneManager.LoadScene(a);
    }
    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }
}
