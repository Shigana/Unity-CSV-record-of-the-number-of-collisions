using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class countCSV : MonoBehaviour
{
    void Start()
    {GameObject.Find("CSVStop").GetComponent<Button>().interactable = false;}

    public int wallF = 0;
    public int wallB = 0;
    public int wallR = 0;
    public int wallL = 0;

    public bool saves;

    void Update()
    {}

    private string DataName;
    byte filenum_1 = 0;
    byte filenum_10 = 0;
    byte filenum_100 = 0;

    public void RecStart()
    {
        if (!saves)
        {
            saves = true;
            GameObject.Find("CSVStart").GetComponent<Button>().interactable = false;
            GameObject.Find("CSVStop").GetComponent<Button>().interactable = true;

            DataName = "000衝突回数.csv";
            while (true)
            {
                if (File.Exists(Application.persistentDataPath + "/" + DataName)) //If it is a stand-alone HMD, the path may not pass, so use the path of the persistent data directory.
                {
                    filenum_1++;
                    if (filenum_1 > 9)
                    {
                        filenum_10++;
                        filenum_1 = 0;
                        if (filenum_10 > 9)
                        {
                            filenum_100++;
                            filenum_10 = 0;
                        }
                    }
                    DataName = "";
                    DataName += filenum_100;
                    DataName += filenum_10;
                    DataName += filenum_1;
                    DataName += "衝突回数.csv";
                }
                else
                {
                    break;
                }
            }
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + DataName, false); //If it is a stand-alone HMD, the path may not pass, so use the path of the persistent data directory.
            // ヘッダー出力
            string[] s1 = { "壁(前)","壁(後)","壁(右)","壁(左)" };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
            sw.Close();
        }
        else
        {
            StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + DataName, true);
            string[] onepos = { wallF.ToString(), wallB.ToString(), wallR.ToString(), wallL.ToString()};
            string poslog = string.Join(",", onepos);
            sw.WriteLine(poslog);
            sw.Flush();
            sw.Close();

            saves = false;
            GameObject.Find("CSVStart").GetComponent<Button>().interactable = true;
            GameObject.Find("CSVStop").GetComponent<Button>().interactable = false;
        }
    }
}