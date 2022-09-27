using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    GameObject secili_obje;
    GameObject secili_stand;
    cember _cember;
    public bool hareket_var;
    public int hedef_stand_sayisi;
    int tamamlananStand_Sayisi;
    void Start()
    {
        
    }
    public void stand_tamamlandi()
    {
        tamamlananStand_Sayisi++;
        if (tamamlananStand_Sayisi == hedef_stand_sayisi)
        {
            Debug.Log("kazandin"); // kazandin paneli çýkýcak!
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit,100))
            {
                if (hit.collider != null && hit.collider.CompareTag("stand"))
                {
                    if(secili_obje != null && secili_stand != hit.collider.gameObject)
                    {
                        stand _Stand = hit.collider.GetComponent<stand>();
                        if (_Stand.cemberler.Count != 4 && _Stand.cemberler.Count != 0)
                        {
                            if (_cember.renk==_Stand.cemberler[^1].GetComponent<cember>().renk)
                            {
                                secili_stand.GetComponent<stand>().soket_degistirme_islemleri(secili_obje);
                                _cember.hareket_et("pozisyondegistir", hit.collider.gameObject, _Stand.musait_soketi_Ver(), _Stand.hareket_pozisyonu);

                                _Stand.bos_soket++;
                                _Stand.cemberler.Add(secili_obje);
                                _Stand.cemberleri_kontrol_Et();
                                secili_obje = null;
                                secili_stand = null;

                            }
                            else
                            {
                                _cember.hareket_et("soketeGeriGit");
                                secili_obje = null;
                                secili_stand = null;
                            }




                            
                        }
                        else if (_Stand.cemberler.Count == 0)
                        {
                            secili_stand.GetComponent<stand>().soket_degistirme_islemleri(secili_obje);
                            _cember.hareket_et("pozisyondegistir", hit.collider.gameObject, _Stand.musait_soketi_Ver(), _Stand.hareket_pozisyonu);

                            _Stand.bos_soket++;
                            _Stand.cemberler.Add(secili_obje);
                            _Stand.cemberleri_kontrol_Et();
                            secili_obje = null;
                            secili_stand = null;
                        }
                        else
                        {
                            _cember.hareket_et("soketeGeriGit");
                            secili_obje = null;
                            secili_stand = null;
                        }

                    }
                    else if (secili_stand== hit.collider.gameObject)
                    {
                        _cember.hareket_et("soketeGeriGit");
                        secili_obje = null;
                        secili_stand = null;
                    }
                    else
                    {
                        stand _stand = hit.collider.GetComponent<stand>();
                        secili_obje = _stand.en_ust_cember_ver();
                        _cember = secili_obje.GetComponent<cember>();
                        hareket_var = true;

                        if (_cember.hareket_edebilirmi)
                        {
                            _cember.hareket_et("secim",null,null,_cember.ait_oldugu_stand.GetComponent<stand>().hareket_pozisyonu);
                            secili_stand = _cember.ait_oldugu_stand;
                        }
                    }
                }
                
            }
        }
    }
}
