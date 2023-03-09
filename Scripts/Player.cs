using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    public GameObject CameraNum;
    public bool Die=false;
    public bool Winner=false;
    public int Chips;
    public int Raise;
    public int Call;
    public int PlayerNum;
    public int RecentBet;
    public bool isBet = false;
    int lenChip;

    public GameObject ChipSets;
    public GameObject[] ChipSetarr;

    public TextMeshProUGUI PlayerChipTXT;

    // Start is called before the first frame update
    void Start()
    {
        lenChip=ChipSetarr.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ChipActive();
        
    }
    

    void ChipActive()
    {
        

        if(Chips>750)
        {
            ChipTrue();
        }
        else if(Chips<=750 && Chips>500)
        {
            ChipTrue();
            ChipSetarr[0].SetActive(false);
           

        }
        else if(Chips<=500 && Chips>250)
        {
            ChipTrue(); 
            lenChip-=2; 
            ChipFalse();
            lenChip+=2;
            
        }
        else if(Chips<=250 && Chips>0)
        {
            ChipTrue();
            lenChip-=1;
            ChipFalse();
            lenChip+=1;
            
            
            
        }
        else if(Chips == 0)
        {
            ChipTrue();
            ChipFalse();
           
        }
    }
    
    void ChipTrue()
    {
        for(int i = 0;i<lenChip;i++)
            {
                ChipSetarr[i].SetActive(true);
            }
    }
    void ChipFalse()
    {
        for(int i = 0;i<lenChip;i++)
            {
                ChipSetarr[i].SetActive(false);
            }
    }
}
