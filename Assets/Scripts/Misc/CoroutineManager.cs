using System.Collections;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager Instance { get; private set; }

    // Ensure there's only one instance of CoroutineManager in the scene
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    // Start a coroutine through CoroutineManager
    public new Coroutine StartCoroutine(IEnumerator routine)
    {
        return base.StartCoroutine(routine);
    }

    // Stop a coroutine via CoroutineManager
    public void StopCoroutine(IEnumerator routine)
    {
        base.StopCoroutine(routine);
    }

    // Stop all coroutines via CoroutineManager
    public void StopAllCoroutines()
    {
        base.StopAllCoroutines();
    }
}
