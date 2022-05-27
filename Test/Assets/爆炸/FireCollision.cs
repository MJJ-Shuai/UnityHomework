using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //���汻��ײʱ����
    void OnParticleCollision(GameObject other)
    {
        if(other.name=="���ըΣ��Ʒ")
        {
            ControlFireExplosion controlFireExplosion = other.GetComponent<ControlFireExplosion>();
            if (Random.Range(0f, 1f) > 0.7 && controlFireExplosion.isJet==false)
            {
                controlFireExplosion.jetFire();
            }
        }

        if(other.name=="����ըΣ��Ʒ")
        {
            InDoorControlExplosion inDoorControlExplosion = other.GetComponent<InDoorControlExplosion>();
            if (inDoorControlExplosion.isInFire == false)
                inDoorControlExplosion.beginFire();
        }
    }
}
