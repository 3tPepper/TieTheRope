using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool discharge = false;
    float charge = 0f;
    private Rigidbody2D player;


    private float anchor_x = 0.4f;
    private float anchor_y = 0.0f;

    public static int hp = 3;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            discharge = true;
        }

    }

    private void FixedUpdate()
    {
        if (discharge)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Sound.instance.Jump();
            float force = charge * 10;
            if (force > 30)
            {
                force = 30f;
            }
            player.velocity = new Vector2(force, player.velocity.y);
            charge = 0;
            discharge = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "ItemRope")
        {
            Sound.instance.GetRope();
            Destroy(collision.gameObject);
            Rope.instance.GenerateRope();
            //�ش� collision��(������) ��ü�� ����
        }
       else if(collision.gameObject.tag == "ItemBone")
        {
            Sound.instance.GetBone();
            Destroy(collision.gameObject);
            //ü�� 1 ����
            if (hp >= 1)
            {
                hp -= 1;
                //ü���� 0���ϰ� �Ǿ����� �˻� �� ���ӿ��� ó��
                if (hp <= 0)
                {
                    Item.is_end = true;
                    Sound.instance.GameOver();
                    UI.instance.GameOver();
                }
            }

        }
    }

}
