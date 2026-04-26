using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool isLevelComplete = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();    
    }

    //trigger when the player collide with the flag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isLevelComplete)
        {
            finishSound.Play();
            isLevelComplete = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
