using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator animator;

    public void Restart()
    {
        animator.Play("Restart");
    }
    
    public void OnAnimationComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
