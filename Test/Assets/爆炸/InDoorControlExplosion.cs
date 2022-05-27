using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDoorControlExplosion : MonoBehaviour
{
    public GameObject explosion;

    private int flag = 3;

    public GameObject barrelAfter;

    public GameObject wideFire;

    public AudioSource audioSource;
    // Start is called before the first frame update
    public bool isInFire;
    void Awake()
    {
        isInFire = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void explosionFunc()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        while (flag >= 0)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity, transform);
            flag = flag - 1;
        }
        GameObject afterExplosionBarrel = Instantiate(barrelAfter, transform);
        afterExplosionBarrel.transform.position = this.transform.position + new Vector3(0, Random.Range(0.5f, 2f), 0);
        afterExplosionBarrel.transform.eulerAngles = new Vector3(Random.Range(-55f, 55f), Random.Range(-55f, 55f), Random.Range(-55f, 55f));
        Instantiate(wideFire, this.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity, afterExplosionBarrel.transform);
        audioSource.Play();
    }

    public void beginFire()
    {
        isInFire = true;
        Invoke("explosionFunc", Random.Range(1f, 20f));
    }
}
