using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private static Rope _instance;
    public static Rope instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Rope>();
            }
            return _instance;
        }
    }

    public GameObject player;
    public GameObject hook;
    public GameObject[] prefabRopeSegs;
    int numLinkes = 15;

    List<GameObject> newSeg = new List<GameObject>();
    Rigidbody2D prevBod;
    // Start is called before the first frame update
    void Start()
    {
        prevBod = hook.GetComponent<Rigidbody2D>();
        GenerateRope();
        //hook�� ���� 90�� ư��.
        Quaternion hookRo = Quaternion.Euler(new Vector3(0, 0, 90));
        hook.transform.rotation = hookRo;
    }


    public void GenerateRope()
    {
        //GameObject[] newSeg = new GameObject[numLinkes];

        int ropeCnt = newSeg.Count;
        for(int i=ropeCnt; i < ropeCnt+numLinkes; i++)
        {
            int index = 0;
            if (i%10 == 0)
            {
                index = 0;
                
            }
            else if(i%10 == 9)
            {
                index = 2;
            }
            else
            {
                index = 1;
            }
            newSeg.Add(Instantiate(prefabRopeSegs[index]));
            newSeg[i].transform.parent = transform;
            if (i != 0)
            {
                newSeg[i].transform.position = newSeg[i - 1].transform.position;
            }
            else
            {
                newSeg[i].transform.position = transform.position;
            }

            //�� ������ ���� ���ٰ� ����
            FixedJoint2D hj = newSeg[i].GetComponent<FixedJoint2D>();
            hj.connectedBody = prevBod;
            //���� ���� ���� ���� ���� ���ٷ� ����
            prevBod = newSeg[i].GetComponent<Rigidbody2D>();
        }

        //�÷��̾ ���� ���� �Ŵ޾��ش�.
        player.GetComponent<FixedJoint2D>().connectedBody = prevBod;


    }
}
