using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Animator ani;
    // �����ĸ����������
    private Ray upRay;
    private Ray downRay;
    private Ray leftRay;
    private Ray rightRay;

    Ray innerRay;
    public bool isup;
    public bool isdown;
    public bool isright;
    public bool isleft;

   
    // �������ߵĳ���
    private float rayLength = 0.6f;

    // �������ߵ���ɫ
    private Color rayColor = Color.red;

    // ����������ײ�Ĳ�
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
        // ����������ײ�Ĳ�Ϊ Default ��
        rayLayer = LayerMask.GetMask("ħ��");

    }

    // Update is called once per frame  
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal*vertical==0f)
            if (ħ��.Instance.�Ƿ�������ת == false)
            {
                Collider[] a=Physics.OverlapBox(transform.position +transform.up * vertical + transform.right*horizontal + 0.5f * transform.forward,
                    Vector3.one *0.5f);
                Debug.Log(a.Length);
                Debug.DrawLine(transform.position +transform.up * vertical + transform.right*horizontal  + 1f * transform.forward,
                    transform.position +transform.up * vertical + transform.right*horizontal  ,Color.red);
                if (false && isup&& !ismove)
                {
                    //����Ӧ������һ�����Ч��������ʵ�ֵĲ���
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
                

                ////�������Ҳ�������߼�⣬���ڸ�����ҵ�ƫ����
                //if (Physics.Raycast(innerRay, out hitInner, innner_Length, rayLayer))
                //{
                //    this.transform.GetComponent<С����>().�����ħ�����ĵ�ƫ���� = hitInner.collider.GetComponent<С����>().�����ħ�����ĵ�ƫ����;
                //}

            }
    }
    

}