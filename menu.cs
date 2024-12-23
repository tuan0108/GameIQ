using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void batdau()
    {
        SceneManager.LoadScene("CHONCAP"); // Thay "GameScene" bằng tên Scene của bạn
    }

    public void huongdan()
    {
        SceneManager.LoadScene("HUONGDAN");
    }
    public void trove()
    {
        SceneManager.LoadScene("MENU");
    }
    public void level1()
    {
        SceneManager.LoadScene("LEVEL1");
    }
    public void level2()
    {
        SceneManager.LoadScene("LEVEL2");
    }
    public void level3()
    {
        SceneManager.LoadScene("LEVEL3");
    }

    public void thoat()
    {
        
        Application.Quit();
    }
}
