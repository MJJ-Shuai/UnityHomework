using DigitalRuby.RainMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;

    public float limit ;

    public RainScript RainScript;

    private int flag = 3;

    public GameObject barrelAfter;

    public GameObject wideFire;

    public GameObject bigFire;

    public GameObject smallFire;

    public AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        limit = Random.Range(1f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (limit<=0&& flag>=0)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            explosionFunc();
            if(transform.Find("ÅçÉäÅ¨ÑÌ(Clone)")!=null)
            {
                Destroy(transform.Find("ÅçÉäÅ¨ÑÌ(Clone)").gameObject);
            }
            
        }
        else if(limit>0)
        {
            limit = limit - RainScript.RainIntensity*Time.deltaTime;
        }
    }

    void explosionFunc()
    {
        
        while (flag >= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity, transform);
            flag = flag - 1;
        }
        GameObject afterExplosionBarrel = Instantiate(barrelAfter, transform);
        afterExplosionBarrel.transform.position = this.transform.position + new Vector3(0, Random.Range(0.5f, 2f), 0);
        afterExplosionBarrel.transform.eulerAngles = new Vector3(Random.Range(-55f, 55f), Random.Range(-55f, 55f), Random.Range(-55f, 55f));
        Instantiate(wideFire, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity, afterExplosionBarrel.transform);
        audioSource.Play();
    }
}
