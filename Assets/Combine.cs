using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    //[SerializeField]
    private GameObject fruits;

    [SerializeField]
    private GameObject nextLevel;

    private GameObject instance;

    bool isCombined = false;

    private void Awake()
    {
        fruits = GameObject.Find("Fruits");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( string.Compare(this.gameObject.name, collision.gameObject.name) == 0 )
        {
            isCombined = true;

            Combine combine = collision.gameObject.GetComponent<Combine>();
            if (combine.isCombined)
            {
                return;
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                instance = Instantiate(nextLevel, transform.position, transform.rotation);
                
                if( instance.GetComponent<Rigidbody2D>() == null)
                {
                    instance.AddComponent<Rigidbody2D>();
                }

                instance.transform.parent = fruits.transform;

                StartCoroutine("CombineWait");
            }

        }
    }

    IEnumerator CombineWait()
    {
        yield return new WaitForSeconds(0.5f);
    }

    public GameObject GetInstance()
    {
        return instance;
    }
}
