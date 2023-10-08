using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Manager : MonoBehaviour
{
    public void sceneLoad(int number)
    {
        SceneManager.LoadScene(number);
    }


}
