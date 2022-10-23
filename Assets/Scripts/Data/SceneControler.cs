using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{
    public void SetScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}