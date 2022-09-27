using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stand : MonoBehaviour
{
    public GameObject hareket_pozisyonu;
    public GameObject[] soketler;
    public int bos_soket;
    public List<GameObject> cemberler = new();
    [SerializeField] private game_manager gamemanager;
    int cember_tamamlanma_Sayisi;
    public GameObject en_ust_cember_ver()
    {
        return cemberler[^1];
    }
    public GameObject musait_soketi_Ver()
    {
        return soketler[bos_soket];
    }


    public void soket_degistirme_islemleri(GameObject silinecek_obje)
    {
        cemberler.Remove(silinecek_obje);

        if (cemberler.Count != 0)
        {
            bos_soket--;
            cemberler[^1].GetComponent<cember>().hareket_edebilirmi = true;
        }
        else
        {
            bos_soket = 0;
        }

    }

    public void cemberleri_kontrol_Et()
    {
        
        if (cemberler.Count == 4)
        {
            
            string renk = cemberler[0].GetComponent<cember>().renk;
            foreach (var item in cemberler)
            {
                if (renk == item.GetComponent<cember>().renk)
                {
                    cember_tamamlanma_Sayisi++;
                }
            }
                if (cember_tamamlanma_Sayisi == 4)
                {
                    gamemanager.stand_tamamlandi();
                    tamamlanmis_stand();
                }
                else
                {
                    cember_tamamlanma_Sayisi = 0;            }
            
        }
    }

    public void tamamlanmis_stand()
    {
        foreach (var item in cemberler)
        {
            item.GetComponent<cember>().hareket_edebilirmi = false;
            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "TamamlanmisStand";
        }
    }
}
