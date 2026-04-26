using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int cherriesCollected = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private AudioSource cherryCollectSoundEffect;

    // when the player collides with an object tagged "Cherry", the object will be destroyed (collected)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherryCollectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherriesCollected++;
            cherriesText.text = "Cherries: " + cherriesCollected;
        }
    }
}
