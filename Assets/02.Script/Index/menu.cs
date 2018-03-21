using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

    public Material box;
    public Material box_null;
    public GameObject[] boxs;
    public GameObject[] subs;

    //public GameObject subCamera;
    //public GameObject mCamera;

    Renderer r;
    Renderer r_old;
    bool ifClk = false;
    bool ifCls = false;
    bool ifBack = false;

    float mov_time = 1.9f;
    Color color = Color.white;

    float mov = 0f;
    float mov_old = 0f;

    public int box_now = 0;
    int box_old = 999;

    // Use this for initialization
    void Awake()
    {
        //subCamera.SetActive(false);
        //mCamera.SetActive(true);

    }

    // Use this for initialization
    void Start () {
       
        
    }
	
	// Update is called once per frame
	void Update () {
        if (ifClk)
        {
            menu_mov();
        }

        if (ifBack)
        {
            //menu_cls();
        }
    }

    public void menu_clk(int id)
    {
        //if (ifCls) return;
        //ifCls = true;
        //if (id == box_now) return;
        box_old = box_now;
        box_now = id;

        //if (boxs[box_old])
        //{
        //    r_old = boxs[box_old].GetComponent<Renderer>();
        //    mov_old = 1f;
        //}



        for (int i = 0; i < subs.Length; i++)
        {
            subs[i].SetActive(false);
        }
        subs[id].SetActive(true);


        r = boxs[id].GetComponent<Renderer>();
        r.material = box;
        r.sharedMaterial.SetFloat("_Phase", 0);

        r.enabled = true;
        ifClk = true;

    }

    void menu_mov()
    {
        float mm;
        mov += Time.deltaTime * mov_time;
        if (mov > 1) mm = 1;
        else mm = mov;

        color.a = 1 * mm;
        r.sharedMaterial.SetFloat("_Phase", 1 * mm);
        r.sharedMaterial.SetColor("_Color", color);

        if (mov >= 1)
        {
            mov = 0f;
            ifClk = false;
            return;
        }

    }

    void menu_cls()
    {
        float mm;
        mov -= Time.deltaTime * mov_time;
        if (mov <= 0) mm = 0;
        else mm = mov;

        color.a = 1 * mm;
        r.sharedMaterial.SetFloat("_Phase", 1 * mm);
        r.sharedMaterial.SetColor("_Color", color);

        if (mov <= 0)
        {
            mov = 0f;
            ifBack = false;
            return;
        }

    }

    public void menu_reset()
    {
        r = boxs[box_now].GetComponent<Renderer>();
        r.enabled = false;
    }

}
