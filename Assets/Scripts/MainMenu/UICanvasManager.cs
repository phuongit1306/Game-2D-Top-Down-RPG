using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class UICanvasManager : Singleton<UICanvasManager>
{
    protected override void Awake()
    {
        base.Awake();

        destroyOnSpecificScenes = true;
        scenesToDestroy = new List<string> { "MainMenu" };

        // Đăng ký sự kiện khi chuyển scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Current Scene: " + scene.name);
        if (scenesToDestroy != null && scenesToDestroy.Contains(scene.name))
        {
            Debug.Log("Destroying UICanvas in scene: " + scene.name);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Hủy đăng ký sự kiện để tránh lỗi
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
