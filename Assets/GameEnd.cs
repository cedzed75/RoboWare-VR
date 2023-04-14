using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text scoreText;
    public Text attemptText;
    public Text fastText;
    public Text slowText;

    private string labels = "score,attempts,fastest,slowest";
    private string filename = "log.csv";

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = $"Games Won: {PlayerPrefs.GetInt("score")}";
        attemptText.text = $"Games Attempted: {PlayerPrefs.GetInt("attempts")}";
        fastText.text = $"Fastest Minigame: {PlayerPrefs.GetFloat("fastest")}";
        slowText.text = $"Slowest Minigame: {PlayerPrefs.GetFloat("slowest")}";

        // create the log file for this run
       if (!File.Exists(Directory.GetCurrentDirectory() + filename))
       {
            WriteNewFile(filename, labels);
       }
       AddRecord();
    }

    // creates a log file
    private void WriteNewFile(string filename, string labels)
    {
        if (!File.Exists(Directory.GetCurrentDirectory() + @"\" + filename))
        {
            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\" + filename, false);
            writer.WriteLine(labels);
            writer.Flush();
            writer.Close();
        }
    }

    // adds a record to log file
    public void AddRecord()
    {
        string recordStr = PlayerPrefs.GetInt("score") + "," + PlayerPrefs.GetInt("attempts") + "," + PlayerPrefs.GetFloat("fastest") + "," + PlayerPrefs.GetFloat("slowest");
        AppendToFile(filename, recordStr);
    }

    // appends to a log file
    private void AppendToFile(string filename, string fileContent)
    {
        StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\" + filename, true);
        writer.WriteLine(fileContent);
        writer.Flush();
        writer.Close();
    }

}
