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
                //�÷��̾ ������Ű��, �� ��������Ʈ�� ����
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

                //�ϴÿ��� �������� õõ�� �÷��̾� ������ �ϰ�. �������� �� ��! �ϰ� �ѹ� ¢�´�.
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

        //�����մϴ�! �г� ����
        UI.instance.GameEnd();
        Sound.instance.GameEnd();
    }
}
