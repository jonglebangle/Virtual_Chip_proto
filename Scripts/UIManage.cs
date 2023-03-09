using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManage : MonoBehaviour
{
    public Player[] player;
    public GameObject[] ResultArr;
    public BettingChip bettingChip;
    public PlayerManage PlayerManager;
    public GameObject MainCamera;
    
    
    //Panel
    public GameObject GamePanel;
    public GameObject GameOverPanel;
    public GameObject ResultPanel;
    public GameObject StartPanel;
    public GameObject MenuPanel;
    
    //GamePanel
    public TextMeshProUGUI PlayerTXT;
    public int P;
    public TextMeshProUGUI BettingChipTXT;
    public int B;
    public TextMeshProUGUI MyChipTXT;
    public int MC;
    public TextMeshProUGUI RaiseTXT;
    public int R;
    public TextMeshProUGUI CallTXT;
    public int C;
    
    //ResultPanel
    public TextMeshProUGUI Result1TXT;
    public int R1;
    public TextMeshProUGUI Result2TXT;
    public int R2;
    public TextMeshProUGUI Result3TXT;
    public int R3;
    public TextMeshProUGUI Result4TXT;
    public int R4;

    //menu
     

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<PlayerManager.PlayerCnt; i++)
        {
            ResultArr[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Game
        P=PlayerManager.n;
        PlayerTXT.text="Player"+(P+1).ToString();

        B=bettingChip.BetChip;
        BettingChipTXT.text="Betting Chip : "+B.ToString();

        MC=player[P].Chips;
        MyChipTXT.text="My Chips        : "+MC.ToString();

        R=player[P].Raise;
        RaiseTXT.text="Raise               : "+R.ToString();

        C=player[P].Call;
        CallTXT.text="Call                  : "+C.ToString();

        //Result

        /*R1=player[0].Chips;
        Result1TXT.text="Player1 :"+R1.ToString();

        R2=player[1].Chips;
        Result1TXT.text="Player2 :"+R2.ToString();

        R3=player[2].Chips;
        Result1TXT.text="Player3 :"+R3.ToString();

        R4=player[3].Chips;
        Result1TXT.text="Player4 :"+R4.ToString();*/

        

        if(PlayerManager.GameOver == true)
        {
            GamePanel.SetActive(false);
            GameOverPanel.SetActive(true);
        }
       
    }

    public void Result()
    {
        PlayerManager.GameOver=false;
        GameOverPanel.SetActive(false);
        ResultPanel.SetActive(true);
    }
    
    public void TouchToPlay()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
    }
    
    public void StartGame()
    {
        MenuPanel.SetActive(false);
        StartPanel.SetActive(true);
        MainCamera.SetActive(false);

    }
}
