using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFruit2 : MonoBehaviour
{
    private GameObject fruit;

    [SerializeField]
    private GameObject fruits;
    [SerializeField]
    private GameObject cherry;
    [SerializeField]
    private GameObject strawberry;
    [SerializeField]
    private GameObject grape;
    [SerializeField]
    private GameObject orange;
    [SerializeField]
    private GameObject apple;

    private GameObject instance;

    private int fruitNumber = 0;
    private int fruitCount = 0;
    private int boundaryPoint = 30;

    private bool drop = false;

    void Awake()
    {
        instance = Instantiate(cherry, fruits.transform.position, transform.rotation);
        instance.transform.parent = fruits.transform;
        drop = true;

        fruitCount = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveFruit();
            drop = true;
        }
    }
    
    void Make()
    {
        fruitNumber = Random.Range(1, 15);
        
        if ( fruitCount <= boundaryPoint ) { Front(); }
        if ( fruitCount > boundaryPoint ) { Back(); }

        instance = Instantiate(fruit, fruits.transform.position, transform.rotation);
        instance.transform.parent = fruits.transform;

        fruitCount++;
        //Debug.Log("fruitCount: " + fruitCount);
    }

    void Front()
    {
        switch (fruitNumber)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                fruit = cherry;
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                fruit = strawberry;
                break;
            case 9:
            case 10:
            case 11:
                fruit = grape;
                break;
            case 12:
            case 13:
                fruit = orange;
                break;
            case 14:
                fruit = apple;
                break;
            default:
                break;
        }
    }

    void Back()
    {
        switch (fruitNumber)
        {
            case 1:
                fruit = cherry;
                break;
            case 2:
            case 3:
                fruit = strawberry;
                break;
            case 5:
            case 6:
            case 7:
                fruit = grape;
                break;
            case 8:
            case 9:
            case 10:
            case 11:
                fruit = orange;
                break;
            case 12:
            case 13:
            case 14:
                fruit = apple;
                break;
            default:
                break;
        }
    }

    private void MoveFruit()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float clampedX = Mathf.Clamp(pos.x, -3.5f, 3.5f);

        Vector3 clamPos = new Vector3(clampedX, instance.transform.position.y, 0);

        instance.transform.position = clamPos;

        if (instance.GetComponent<Rigidbody2D>() == null)
        {
            instance.AddComponent<Rigidbody2D>();
        }

        StartCoroutine("DropWait");
    }

    IEnumerator DropWait()
    {
        yield return new WaitForSeconds(1f);
        if (drop)
        {
            drop = false;
            Make();
        }
    }

}
