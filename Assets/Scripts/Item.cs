using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] itemPrebs = new GameObject[2];
    public GameObject parent;
    public static bool is_end = false;


    public void StartDrop()
    {
        StartCoroutine(DropItem());
    }

    IEnumerator DropItem()
    {
        while (!is_end)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 6.0f));

            Sound.instance.DoggiThrow();
            int rand = Random.Range(0, 2);
            GameObject newItem = Instantiate(itemPrebs[rand], parent.transform);
            newItem.transform.position = this.transform.position;

            Rigidbody2D rd = newItem.GetComponent<Rigidbody2D>();
            int randd = Random.Range(14, 30);
            Vector2 moveDir = new Vector2(this.transform.position.x- randd, this.transform.position.y+3);
            rd.velocity = moveDir;
        }
    }

}
