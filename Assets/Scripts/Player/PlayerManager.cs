using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //Đảm bảo không bị hủy khi load scene
        SceneManager.sceneLoaded += OnSceneLoaded; //Đăng ký sự kiện khi scene được load
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        //Hủy đăng ký sự kiện để tránh lỗi
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
