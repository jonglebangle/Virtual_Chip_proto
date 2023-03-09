using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerManageBackup : MonoBehaviour
{
    //Arr
    public Player[] PlayerArr;
    public bool[] DieArr;
    public bool[] WinnerArr;
    public GameObject[] CameraArr;

    public GameObject Win;
    public BettingChip BT; 
    int lenP;
    public int n = 0;

    //Raise
    bool rDown=false;
    bool rDown1;
    bool rDown2;
    bool rU;
    bool rD;
    int RaiseSave;

    //Call
    bool cDown=false;
    bool cDown1;

    //Die
    bool dDown;
    int DieCnt=0;
    
    
    //Winner
    bool iswDown=false;
    bool wDown;
    bool eDown;
    bool num1;
    bool num2;
    public bool GameOver=false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        lenP = PlayerArr.Length;//Die 한후 길이 생각해야함
        
        PlayerArr[n].Raise = PlayerArr[n].Call;
        CameraArr=new GameObject[lenP];
        DieArr=new bool[lenP];
        for(int i=0;i<(lenP-1);i++)
        {
            CameraArr[i]=PlayerArr[i].CameraNum;
            CameraArr[i].SetActive(false);
            if(PlayerArr[i]!=null)
            {
                DieArr[i]=PlayerArr[i].Die;
            }
            else
            {
                DieArr[i]=true;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ChipRaise();
        ChipCall();
        PlayerDie();
        WinnerChoice();
        CameraManager();
        DiePass();
        
    
    }
    
    void GetInput()
    {
        rDown1 = Input.GetButtonDown("Raise1"); //r
        rDown2 = Input.GetButtonDown("Raise2"); //t
        rU = Input.GetKey(KeyCode.RightArrow);
        rD = Input.GetKey(KeyCode.LeftArrow);


        cDown1 = Input.GetButtonDown("Call1"); //c

        dDown = Input.GetButtonDown("Die"); //d

        wDown = Input.GetButtonDown("Winner"); //w
        eDown = Input.GetButtonDown("Cancel"); //esc
        num1 = Input.GetButtonDown("num1");//[
        num2 = Input.GetButtonDown("num2");//]

        
    }
    
    void ChipRaise()
    {
        

        if(cDown==false && rDown==false && rDown1)
        {   
            rDown=true;
            Debug.Log("rtrue");
            RaiseSave=PlayerArr[n].Raise;
        }
        if(rDown==true && rU)
            {
                if(PlayerArr[n].Chips>PlayerArr[n].Raise)
                {
                    PlayerArr[n].Raise++;
                    Debug.Log("RaiseUP");
                }
            }
        else if(rDown==true && rD)
        {
            if(n<(lenP-2))
            {
                if(PlayerArr[n].Raise>PlayerArr[n+1].Raise)
                {
                    PlayerArr[n].Raise--;
                    Debug.Log("RaiseDown");
                }
            }
            else
            {
                if(PlayerArr[n].Raise>PlayerArr[0].Raise)
                {
                    PlayerArr[n].Raise--;
                    Debug.Log("RaiseDown");
                }
            }
        }
        
        if(rDown==true && eDown)
        {
            PlayerArr[n].Raise=RaiseSave;
            rDown=false;
        }

        if(PlayerArr[n].Raise>=PlayerArr[n].Call && rDown==true && rDown2)
        {
            rDown=false;
            Debug.Log("rfalse");
            PlayerArr[n].Chips-=PlayerArr[n].Raise;
            Debug.Log("Chips-Raise");
            BT.BetChip+=PlayerArr[n].Raise;
            Debug.Log("Betting Chip");
            
            if(n<(lenP-2))
            {   
                if(PlayerArr[n].Raise>=PlayerArr[n+1].Chips)
                {
                    PlayerArr[n+1].Call=PlayerArr[n+1].Chips;
                    PlayerArr[n+1].Raise=PlayerArr[n+1].Chips;
                    Debug.Log("ALL IN");
                }
                else
                {
                    PlayerArr[n+1].Call=PlayerArr[n].Raise;
                    PlayerArr[n+1].Raise=PlayerArr[n].Raise;
                }
                
                PlayerArr[n].Raise = 0;
                n++;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("n++ :" +n);
            }
            else
            {   
                if(PlayerArr[n].Raise>=PlayerArr[0].Chips)
                {
                    PlayerArr[0].Call=PlayerArr[0].Chips;
                    PlayerArr[0].Raise=PlayerArr[0].Chips;
                }
                else
                {
                    PlayerArr[0].Call=PlayerArr[n].Raise;
                    PlayerArr[0].Raise=PlayerArr[n].Raise;
                }
                
                PlayerArr[n].Raise = 0;
                n=0;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("n-- :" +n);
            }
        }

    }

    void ChipCall()
    {
        if(PlayerArr[n].Die!=true && rDown==false && cDown==false && cDown1)
        {   
            /*cDown=true;
            Debug.Log("ctrue");*/
            Debug.Log("Call");
            PlayerArr[n].Chips-=PlayerArr[n].Call;
            Debug.Log("Chips-Call");
            BT.BetChip+=PlayerArr[n].Call;
            Debug.Log("Betting Chip");
            
            if(n<(lenP-2))
            {   
                if(PlayerArr[n].Call>=PlayerArr[n+1].Chips) //Die에서 call하면 오류
                {
                    PlayerArr[n+1].Call=PlayerArr[n+1].Chips;
                    PlayerArr[n+1].Raise=PlayerArr[n+1].Chips;
                    Debug.Log("ALL IN");
                }
                else
                {
                    PlayerArr[n+1].Call=PlayerArr[n].Call;
                    PlayerArr[n+1].Raise=PlayerArr[n].Raise;
                }
                
                PlayerArr[n].Call = 0;
                n++;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("n++ :" +n);
            }
            else
            {   
                if(PlayerArr[n].Call>=PlayerArr[0].Chips)
                {
                    PlayerArr[0].Call=PlayerArr[0].Chips;
                    PlayerArr[0].Raise=PlayerArr[0].Chips;
                }
                else
                {
                    PlayerArr[0].Call=PlayerArr[n].Call;   
                    PlayerArr[0].Raise=PlayerArr[0].Call;
                }
                
                PlayerArr[n].Call = 0;
                n=0;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("n-- :" +n);
            }
        }
        
      

    }

    void PlayerDie()
    {
        if(DieCnt<(lenP-2) && PlayerArr[n].Die==false && rDown==false && cDown==false && dDown)
        {
            if(n<(lenP-2))
            {   
                PlayerArr[n+1].Call=PlayerArr[n].Call;
                PlayerArr[n+1].Raise=PlayerArr[n].Raise;
                Debug.Log("Player"+(n+1)+" Die!");
                PlayerArr[n].Die = true;
                DieArr[n]=true;
                DieCnt++;
                Debug.Log(DieCnt);
                n++;
                PlayerArr[n].PlayerNum = n+1;
                DieCheck();
                Debug.Log("n++ :" +n);
                
            }
            else
            {   
                PlayerArr[0].Call=PlayerArr[n].Call;   
                PlayerArr[0].Raise=PlayerArr[0].Call;
                Debug.Log("Player"+(n+1)+" Die!");
                PlayerArr[n].Die = true;
                DieArr[n]=true;
                DieCnt++;
                Debug.Log(DieCnt);
                n=0;
                PlayerArr[n].PlayerNum = n+1;
                DieCheck();
                Debug.Log("n-- :" +n);
                
            }
            
        }
    }

    void DieCheck()
    {
        if(DieCnt==(lenP-2))
        {
            for(int i=0; i<lenP; i++)
            {
                if(DieArr[n]!=true)
                {
                    PlayerArr[n].Winner=true;
                    Debug.Log("WINNER IS : "+PlayerArr[n]);
                    GameOver=true;
                    Debug.Log("GameOver");
                    PlayerArr[n].Chips+=BT.BetChip;
                    BT.BetChip = 0;
                    n=0;
                    PlayerArr[n].PlayerNum = n+1;
                    break;
                    
                }
            }
        }    
    }

    void DiePass()
    {
        if(PlayerArr[n].Die ==true)
        {
            if(n<(lenP-2))
            {
                n++;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("SystemCheck : n++");
            }
            else
            {
                n=0;
                PlayerArr[n].PlayerNum = n+1;
                Debug.Log("SystemCheck : n=0");
            }
        }
    }

    void WinnerChoice()
    {
        if(iswDown==false && wDown)
        {
            iswDown=true;
            WinnerArr=DieArr;
            Debug.Log("WinnerArr = DieArr");
        }
        //중복
        if(iswDown==true && num1)
        {
            
            PlayerArr[0].Winner=true;
            Debug.Log("WINNER IS : Player1");
            PlayerArr[0].Chips+=BT.BetChip;
            BT.BetChip = 0;
            iswDown=false;
            GameOver=true;
            n=0;
            PlayerArr[n].PlayerNum = n+1;
            
        }
        if(iswDown == true && num2)
        {
            PlayerArr[1].Winner=true;
            Debug.Log("WINNER IS : Player2");
            PlayerArr[1].Chips+=BT.BetChip;
            BT.BetChip = 0;
            iswDown=false;
            GameOver=true;
            n=0;
            PlayerArr[n].PlayerNum = n+1;
        }
        if(iswDown==true && eDown)
        {
            iswDown=false;
            Debug.Log("wCancel");
        }
        
    }

    void CameraManager()
    {
        for(int i=0;i<(lenP-1);i++)
        {
            CameraArr[i].SetActive(false);
            CameraArr[n].SetActive(true);
        }
    }
}
