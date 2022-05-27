using System.Collections;
using UnityEngine;

public class ControlFireExplosion : MonoBehaviour
{

    public GameObject flameJet;

    private Quaternion quaternion;

    public bool isJet;
    // Use this for initialization
    void Start()
    {
        isJet = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void jetFire()
    {
        GameObject fire=Instantiate(flameJet,transform);
        fire.transform.position = this.transform.position + new Vector3(0, Random.Range(1.4f, 1.5f), 0);
        fire.transform.eulerAngles= new Vector3(Random.Range(-135f, -45f), 0, 0);
        isJet = true;
    }

}
