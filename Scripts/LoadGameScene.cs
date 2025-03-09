using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        
        SceneManager.LoadScene("Game");
        Debug.Log("Load the game scene");
       
    }
}
