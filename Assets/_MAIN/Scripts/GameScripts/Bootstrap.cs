using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.UIElements.ToolbarMenu;
[DefaultExecutionOrder(-1000)]
public class Bootstrap : MonoBehaviour
{
    [Scene]
    public string VnScene;
    private void Awake()
    {
        SceneManager.LoadSceneAsync(VnScene,LoadSceneMode.Additive);
    }
}
