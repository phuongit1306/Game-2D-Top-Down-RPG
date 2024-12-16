using UnityEngine;

public class FakeFlagTrigger : MonoBehaviour
{
    public GameObject fakeText;

    private void Start()
    {
        if (fakeText != null)
        {
            fakeText.SetActive(false); // hide
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // check Player
        {
            if (fakeText != null)
            {
                fakeText.SetActive(true); // show text FAKE
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fakeText != null)
            {
                fakeText.SetActive(false);
            }
        }
    }
}
