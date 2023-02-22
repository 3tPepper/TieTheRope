using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    public GameObject Item;

    public GameObject flyDoggi;
    bool isDoggi = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isDoggi)
            {
                //game end!
                Transform[] AllItem = Item.GetComponentsInChildren<Transform>();
                for (int i = 0; i < AllItem.Length; i++)
                {
                    Destroy(AllItem[i].gameObject);
                }
                //플레이어를 고정시키고, 선 스프라이트로 변경
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                //하늘에서 강아지가 천천히 플레이어 옆으로 하강. 내려앉은 뒤 왈! 하고 한번 짖는다.
                StartCoroutine(doggiBark());
                isDoggi = true;
            }

        }
        else if(collision.tag == "ItemBone" || collision.tag == "ItemRope")
        {
            Destroy(collision.gameObject);
        }
        
    }

    IEnumerator doggiBark()
    {
        GameObject doggi = Instantiate(flyDoggi);
        yield return new WaitUntil(() => doggi.transform.position.y <= -81f);


        //doggi bark sound
        Sound.instance.DoggiBark();
        new WaitForSeconds(1f);

        //축하합니다! 패널 띄우기
        UI.instance.GameEnd();
        Sound.instance.GameEnd();
    }
}
