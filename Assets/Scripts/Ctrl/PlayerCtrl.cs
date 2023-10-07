using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator ani;
    // 定义四个方向的射线
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    Ray innerRay;
    public bool isup;
    public bool isdown;
    public bool isright;
    public bool isleft;

   
    // 定义射线的长度
    private float rayLength = 0.6f;

    // 定义射线的颜色
    private Color rayColor = Color.red;

    // 定义射线碰撞的层
    private LayerMask rayLayer;

    private float innner_Length=0.1f;

    private float time;
    public bool ismove;
    public void PlayAtkAnim()
    {
        if(ani.speed != 0)
        {
            ani.SetBool("ishurt", true);
           
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        isup = true;
        isright = true;
        isleft = true;
        isdown = true;
        // 设置射线碰撞的层为 Default 层
        rayLayer = LayerMask.GetMask("魔方");

    }

    // Update is called once per frame  
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal*vertical==0f)
            if (魔方.Instance.是否正在旋转 == false)
            {
                Collider[] a=Physics.OverlapBox(transform.position +transform.up * vertical + transform.right*horizontal + 0.5f * transform.forward,
                    Vector3.one *0.5f);
                Debug.Log(a.Length);
                Debug.DrawLine(transform.position +transform.up * vertical + transform.right*horizontal  + 1f * transform.forward,
                    transform.position +transform.up * vertical + transform.right*horizontal  ,Color.red);
                if (false && isup&& !ismove)
                {
                    //这里应该是玩家缓动的效果，这里实现的不对
                    // transform.position += transform.up;
      
                    transform.DOMove(transform.position + transform.up*vertical+transform.right*horizontal, 1F);
                    ismove = true;

                }
                if (ismove) {
                    time += Time.deltaTime;
                    if (time > 0.8f)
                    {
                        time= 0;
                        ismove = false;
                    }
                }
                

                ////玩家往里也发出射线检测，用于更新玩家的偏移量
                //if (Physics.Raycast(innerRay, out hitInner, innner_Length, rayLayer))
                //{
                //    this.transform.GetComponent<小方块>().相对于魔方中心的偏移量 = hitInner.collider.GetComponent<小方块>().相对于魔方中心的偏移量;
                //}

            }
    }
    

}