using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    public GameObject player;
    public GameObject princessHide;
    public GameObject congraulations;
    public GameObject theEnd;
    public GameObject white;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Disable interaction
            GetComponent<Collider2D>().enabled = false;
            princessHide.SetActive(false);
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Animator>().StopPlayback();
            if (Collectibles.count == 15)
                theEnd.SetActive(false);
            else
                congraulations.SetActive(false);
            white.GetComponent<Image>().CrossFadeAlpha(0, 1, false);
        }
    }
}