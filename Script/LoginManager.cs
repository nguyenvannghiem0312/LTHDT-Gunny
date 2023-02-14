using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class LoginManager : MonoBehaviour
{
    public TextMeshProUGUI User;
    public TextMeshProUGUI Pass;
    public TextMeshProUGUI Notify;
    public static string Account;
    public static string History;
    public static string Who;
    public bool CheckDup(string In, int i)
    {
        string[] lines = File.ReadAllLines(Account);
        foreach (string a in lines)
        {
            string[] b = a.Split('\t');
            if (Comp(In, b[i]))
            {
                return true;
            }
        }
        return false;
    }
    public bool CheckValid(string In)
    {
        foreach (var a in In)
        {
            if (a == ' ')
            {
                return false;
            }
        }
        return true;
    }
    public int Add(string In, string In1, string hihi)
    {
        string[] lines = File.ReadAllLines(hihi);
        int Max = 0;
        foreach (var s in lines)
        {
            string[] b = s.Split('\t');
            if (Max < Int32.Parse(b[0]))
            {
                Max = Int32.Parse(b[0]);
            }
        }
        Max++;
        string Out1 = Max.ToString() + "\t" + In + "\t" + In1 + "\n";
        File.AppendAllText(hihi, Out1);
        return Max;
    }
    public int CheckLog(string In, string In1)
    {
        string[] lines = File.ReadAllLines(Account);
        foreach (var s in lines)
        {
            string[] b = s.Split('\t');
            if (Comp(In, b[1]) && Comp(In1, b[2]))
            {
                return Int32.Parse(b[0]);

            }
        }
        return 0;
    }
    public bool Comp(string In, string In1)
    {
        if(In.Length- In1.Length > 2)
        {
            return false;
        }
        for(int i = 0; i< In1.Length; i++)
        {
            if(In[i]!= In1[i])
            {
                return false;
            }
        }
        return true;
    }
    public void Login()
    {
        if (CheckLog(User.text, Pass.text)!=0)
        {
            Notify.text = "Đăng nhập thành công dmm";
            File.WriteAllTextAsync(Who, CheckLog(User.text, Pass.text).ToString());
            Add(DateTime.Now.ToString(), CheckLog(User.text, Pass.text).ToString(), History);
            SceneManager.LoadScene(0);

        }
        else
        {
            Notify.text = "Đăng nhập thất bại";
        }
    }
    public void Signup()
    {
        if (!CheckValid(User.text))
        {
            Notify.text = "Tài khoản không hợp lệ";
            return;
        }
        if (!CheckValid(Pass.text))
        {
            Notify.text = "Mật khẩu không hợp lệ";
            return;
        }
        if (CheckDup(User.text, 1))
        {
            Notify.text = "Tài khoản đã tồn tại";
            return;
        }
        Add(User.text, Pass.text, Account);
        Notify.text = "Đăng kí tài khoản thành công!";
        User.text = " ";
        Pass.text = " ";
        return;
    }
    // Start is called before the first frame update
    public void Start()
    {
        Account = Application.dataPath + "/Resources/Accounts.txt";
        History = Application.dataPath + "/Resources/History.txt";
        Who = Application.dataPath + "/Resources/Who.txt";
        Account = Account.Replace(@"/", @"\");
        History = History.Replace(@"/", @"\");
        Who = Who.Replace(@"/", @"\");
    }
    public void SelectScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
