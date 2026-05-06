using UnityEngine;
using UnityEngine.Audio;

public class TrapScript : MonoBehaviour
{
    Vector2 trapped_position;
    GameObject trapped_object;
    bool TrapActive;
    //Math Stuff
    float range = 0.2f;
    float amp = 0.6f; // how far
    float freq = 4f; // how fast

    //holds two sprites - active and non active trap.
    public Sprite[] sprites;
    public AudioResource destroyedSFX;
    public ParticleSystem particle;

    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        TrapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TrapActive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            UseTrap();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!TrapActive)
        {
            trapped_position = collision.gameObject.transform.position;
            trapped_object = collision.gameObject;
            TrapActive = true;
            GetComponent<AudioSource>().Play();
        }
    }


    private void UseTrap()
    {
        
        //if players y position isnt frozen thorough Rigidbody jump inputs stack and are added all at once when trap is destroyed.
        if(trapped_object.name == "Player")
        {
            trapped_object.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
            Debug.Log("Trap Active for : "+timer);
            float x = Mathf.Sin(Time.time * freq) * amp;
            x = Mathf.Round(x);
            x = x * range;
            trapped_object.transform.position = new Vector2(transform.position.x + x, trapped_position.y);
            freq = freq + freq * 0.05f * Time.deltaTime;
            amp = amp + 0.3f * Time.deltaTime;
        }

        else
        {
            if (trapped_object.name == "Player")
            {
                trapped_object.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            trapped_object.transform.position = trapped_position;
        }

    }
}
