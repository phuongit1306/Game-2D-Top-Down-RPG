using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }

    // Sửa thành protected để lớp con có thể truy cập
    protected bool destroyOnSpecificScenes = false;
    protected List<string> scenesToDestroy;

    // Avoid duplication
    protected virtual void Awake()
    {
        if (instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = (T)this;
        }

        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (destroyOnSpecificScenes && scenesToDestroy != null && scenesToDestroy.Count > 0)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    if (scenesToDestroy != null && scenesToDestroy.Contains(scene.name))
    {
        Debug.Log("Destroying Singleton object in scene: " + scene.name);
        Destroy(gameObject);
    }
}
    private void OnDestroy()
    {
        if (destroyOnSpecificScenes)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
    
}
