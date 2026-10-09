using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    public void Restart()
    {
        FlyCamera cam = FindFirstObjectByType<FlyCamera>();
        if (cam != null) FlyCamera.SavePose(cam.transform);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}