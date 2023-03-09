using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingChip : MonoBehaviour
{
    public GameObject[] BArr;
    public GameObject BettedChip;

    public int BetChip=0;
    int lenChip;


    // Start is called before the first frame update
    void Start()
    {
        lenChip=BArr.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ChipActive();
    }


    void ChipActive()
    {
        

        if(BetChip>1750)
        {
            ChipTrue();
        }
        else if(BetChip<=1750 && BetChip>1500)
        {
            ChipTrue();
            BArr[0].SetActive(false);
           

        }
        else if(BetChip<=1500 && BetChip>1250)
        {
            ChipTrue();
            lenChip-=6;
            ChipFalse();
            lenChip+=6;
        }
        else if(BetChip<=1250 && BetChip>1000)
        {
            ChipTrue();
            lenChip-=5;
            ChipFalse();
            lenChip+=5; 
        }
        else if(BetChip<=1000 && BetChip>750)
        {
            ChipTrue();
           
            lenChip-=4;
            ChipFalse();
            lenChip+=4;
        }
        else if(BetChip<=750 && BetChip>500)
        {
            ChipTrue();
           
            lenChip-=3;
            ChipFalse();
            lenChip+=3;
        }
        else if(BetChip<=500 && BetChip>250)
        {
            ChipTrue();
            lenChip-=2;
            ChipFalse();
            lenChip+=2;  
        }
        else if(BetChip<=250 && BetChip>0)
        {
            ChipTrue();
            lenChip-=1;
            ChipFalse();
            lenChip+=1;
        }
        else if(BetChip == 0)
        {
            ChipTrue();
            ChipFalse();
           
        }
    }

    void ChipTrue()
    {
        for(int i = 0;i<lenChip;i++)
            {
                BArr[i].SetActive(true);
            }
    }
    void ChipFalse()
    {
        for(int i = 0;i<lenChip;i++)
            {
                BArr[i].SetActive(false);
            }
    }
}








