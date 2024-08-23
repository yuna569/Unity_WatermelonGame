using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFruit : MonoBehaviour
{
    private int fruitNumber = 0;
    private Vector3 position;
    private int click = 0;
    private int drop;

    private GameObject fruit;
    [SerializeField]
    private GameObject cherry;
    [SerializeField]
    private GameObject strawberry;
    [SerializeField]
    private GameObject grape;
    [SerializeField]
    private GameObject lemon;
    [SerializeField]
    private GameObject orange;

    void Start()
    {
        fruit = cherry;
        
        Make();
    }

    void LateUpdate()
    {
        Drop();

        if ( drop == 1 )
        {
            fruitNumber = Random.Range(8, 13);

            Make();

            drop = 0;
        }
    }

    private void Drop()
    {
        if ( Input.GetMouseButton(0) && (click == 0) )
        {
            click = 1;

            Vector3 pos = Input.mousePosition;

            fruit.transform.position += new Vector3(pos.x, 0, 0);
        }
        else if (Input.GetMouseButton(0) && (click == 1))
        {
            click = 0;

            fruit.AddComponent<Rigidbody2D>();

            while (true)
            {
                if (fruit.transform.position.y <= -3) break;
            }

            drop = 1;

        }
    }

    private void Make()
    {
        fruitNumber = Random.Range(8, 13);
        Vector3 pos = transform.position;
        pos.y += 3.5f;
        // Vector3 ro = transform.rotation;

        switch (fruitNumber)
        {
            case 8:
                fruit = cherry;
                Instantiate(cherry, pos, transform.rotation);
                break;
            case 9:
                fruit = strawberry;
                Instantiate(strawberry, pos, transform.rotation);
                break;
            case 10:
                fruit = grape;
                Instantiate(grape, pos, transform.rotation);
                break;
            case 11:
                fruit = lemon;
                Instantiate(lemon, pos, transform.rotation);
                break;
            case 12:
                fruit = orange;
                Instantiate(orange, pos, transform.rotation);
                break;
            default:
                break;
        }

        /*
        if (fruit.layer == num)
        {
            Instantiate(fruit, position, transform.rotation);
            Destroy(fruit.GetComponent<Rigidbody2D>());
        }
        */
    }
}
