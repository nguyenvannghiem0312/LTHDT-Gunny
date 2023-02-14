using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryTable : MonoBehaviour
{
    private Transform Container;
    private Transform Content;
    private string History;
    private string Who;
    private int who;
    private string[] lines;
    private void Awake()
    {
        History = Application.dataPath + "/Resources/History.txt";
        Who = Application.dataPath + "/Resources/Who.txt";
        History = History.Replace(@"/", @"\");
        Who = Who.Replace(@"/", @"\");

        lines = File.ReadAllLines(History);
        who = Int32.Parse(File.ReadAllText(Who));
        Container = transform.Find("Hiscontainer");
        Content = Container.Find("Content");
        Content.gameObject.SetActive(false);
        int i = 1;
        foreach (var s in lines)
        {
            string[] tmp = s.Split('\t');
            if(Int32.Parse( tmp[2]) == who)
            {
                Transform New = Instantiate(Content, Container);
                RectTransform Rec = New.GetComponent<RectTransform>();
                Rec.anchoredPosition = new Vector2(0, 120f - i*20f);
                New.gameObject.SetActive(true);
                New.GetComponent<Text>().text = tmp[1];
                i++;
                if (i >5)
                {
                    break;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
