using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int LerpTime = 2;

    public GameObject letter;
    public GameObject targetPos;
    public AudioClip audioClip;
    public bool isFirst;

    private bool canPickup;
    private float zoomTime;
    private bool done;

    private void PlayClip()
    {
        var narrationController = GameObject.FindGameObjectWithTag("Narration").GetComponent<NarrationController>();
        narrationController.PlayNarration(audioClip);
    }

    private void Start()
    {
        if (isFirst)
        {
            PlayClip();
        }
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Collectibles.AddCollectible();
            PlayClip();
            // Disable interaction
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().enabled = false;
            GetComponent<ParticleSystem>().Stop();
            letter.transform.rotation = Quaternion.identity;
            zoomTime = Time.time;
        }

        // Zoom
        if (zoomTime > 0 && !done)
        {
            float t = Mathf.Min((Time.time - zoomTime) / LerpTime, 1);
            letter.transform.localPosition = Vector3.Slerp(Vector3.zero, targetPos.transform.localPosition, t);
            if (t == 1)
                done = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickup = false;
        }
    }
}