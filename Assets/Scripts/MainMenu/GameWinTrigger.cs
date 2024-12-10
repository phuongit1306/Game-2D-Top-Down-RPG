using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinTrigger : MonoBehaviour
{
    public GameObject winPanel; // UI Panel xuất hiện khi thắng

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false); // Đảm bảo Panel ban đầu không hiển thị
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra đối tượng chạm có tag "Player"
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true); // Hiển thị UI Panel
                Time.timeScale = 0; // Dừng trò chơi
            }
        }
    }

    public void OnClickOK()
    {
        Time.timeScale = 1; // Khôi phục thời gian
        SceneManager.LoadScene("MainMenu"); // Quay lại MainMenu
    }
}
