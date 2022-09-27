using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cember : MonoBehaviour
{
    public GameObject ait_oldugu_stand;
    public GameObject ait_oldugu_cember_soketi;
    public bool hareket_edebilirmi;
    public string renk;
    public game_manager gameManager;

    GameObject gidecegi_Stand;
    GameObject hareket_pozisyonu;

    bool secildi;
    bool pos_degistir;
    bool soket_otur;
    bool soket_geri_Git;
   
    public void hareket_et(string islem,GameObject stand=null,GameObject soket=null,GameObject gidilecekOjbe=null)
    {
        switch (islem)
        {
            case "secim":
                hareket_pozisyonu = gidilecekOjbe;
                secildi = true;
                break;
            case "pozisyondegistir":
                gidecegi_Stand = stand;
                ait_oldugu_cember_soketi = soket;
                hareket_pozisyonu = gidilecekOjbe;
                pos_degistir = true;

                break;
           
            case "soketeGeriGit":
                soket_geri_Git = true;
                break;

        }
    }
   
    void Update()
    {
        if (secildi)
        {
            transform.position = Vector3.Lerp(transform.position, hareket_pozisyonu.transform.position, .2f);
            if(Vector3.Distance(transform.position, hareket_pozisyonu.transform.position) < .10f){
                secildi = false;
            }
        }


        if (pos_degistir)
        {
            transform.position = Vector3.Lerp(transform.position, hareket_pozisyonu.transform.position, .2f);
            if (Vector3.Distance(transform.position, hareket_pozisyonu.transform.position) < .10f)
            {
                
                pos_degistir = false;
                soket_otur = true;
            }
        }

        if (soket_otur)
        {
            transform.position = Vector3.Lerp(transform.position, ait_oldugu_cember_soketi.transform.position, .2f);
            if (Vector3.Distance(transform.position, ait_oldugu_cember_soketi.transform.position) < .10f)
            {
                transform.position = ait_oldugu_cember_soketi.transform.position;
                soket_otur = false;
                ait_oldugu_stand = gidecegi_Stand;

                if (ait_oldugu_stand.GetComponent<stand>().cemberler.Count > 1)
                {
                    ait_oldugu_stand.GetComponent<stand>().cemberler[^2].GetComponent<cember>().hareket_edebilirmi = false;
                }
                gameManager.hareket_var = false;
            }
        }




        if (soket_geri_Git)
        {
            transform.position = Vector3.Lerp(transform.position, ait_oldugu_cember_soketi.transform.position, .2f);
            if (Vector3.Distance(transform.position, ait_oldugu_cember_soketi.transform.position) < .10f)
            {
                transform.position = ait_oldugu_cember_soketi.transform.position;
                soket_geri_Git = false;
                
                gameManager.hareket_var = false;
            }
        }
    }
}
