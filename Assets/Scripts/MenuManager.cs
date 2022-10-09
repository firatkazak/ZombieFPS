using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);//0'ýncý sahneyi yükle.(Ana oyun sahnemiz.)
    }
    public void ExitGame()
    {
        Application.Quit();//Oyundan çýk.
    }
}
