using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace AdvancedTodo;

public class ApplicationData
{
    // create a class to handle the data we will read from the json file
    public bool LoggedBefore {get; set;}
    public string DarkOrLight {get; set;}
};




public class QuestionForm : Form
{

    public static string dataJSONpath = @"ApplicationData/data.json";

    public static ApplicationData LoadData(string path) // `static` so this function can be accessed from anywhere in this project
    {
        // load the data from data.json
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ApplicationData JSONdata = JsonSerializer.Deserialize<ApplicationData>(json);
            return JSONdata;
        } else
        {
            MessageBox.Show("ApplicationData/data.json doesn't exist. If you moved the directory on purpose, please move it back, or change the source code to point at its current location.");
            return new ApplicationData();
        }
    }

    public static void WriteData(ApplicationData dataToIntegrate, string pathToJSONFile)
    {
        string json = JsonSerializer.Serialize(dataToIntegrate, new JsonSerializerOptions {WriteIndented = true}); // writeIndented makes it human readable
        File.WriteAllText(pathToJSONFile, json);
    }

    public QuestionForm()
    {
        this.Text = "AdvancedTodo";
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;
    
        InitializeEverything();
    }

    private void InitializeEverything()
    {
        Label mainTitle = new()
        {
            Text = "Pick one.",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Font = new Font("Arial", 16, FontStyle.Bold)
        };

        Button buttonLight = new()
        {
            Text = "Light Theme",
            AutoSize = true,
            Location = new Point(225, 150),
            Font = new Font("Arial", 14),
            Cursor = Cursors.Hand
        };
        
        Button buttonDark = new()
        {
            Text = "Dark Theme",
            AutoSize = true,
            Location = new Point(425, 150),
            Font = new Font("Arial", 14),
            BackColor = Color.Black,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };

        buttonDark.FlatAppearance.BorderSize = 0;
        buttonDark.Cursor = Cursors.Hand;
        buttonLight.Cursor = Cursors.Hand;

        buttonDark.MouseEnter += (s, e) =>
        {
            buttonDark.ForeColor = Color.Black;
            buttonDark.BackColor = Color.White;
            buttonDark.FlatAppearance.BorderSize = 1;
            
        };

        buttonDark.MouseLeave += (s, e) =>
        {
            buttonDark.ForeColor = Color.White;
            buttonDark.BackColor = Color.Black;
        };

        

        // depending on which button you click, it will log that data into ApplicationData/data.json.
        buttonLight.Click += (e, sender) =>
        {
            ApplicationData readData = LoadData(dataJSONpath);
            if (readData.LoggedBefore)
            {
                MessageBox.Show("You already picked an option. You can change it later in the settings.");
                return;
            }
            
            ApplicationData freshData = new ApplicationData()
            {
                LoggedBefore = true,
                DarkOrLight = "light"
            };
            WriteData(freshData, dataJSONpath);

            Form1 MainApp = new Form1();
            MainApp.Show();
            this.Hide(); // hide the window, cause if we close it then MainApp.Show() wont execute
        };

        buttonDark.Click += (e, sender) =>
        {
            // just in case...
            ApplicationData readData = LoadData(dataJSONpath);
            if(readData.LoggedBefore)
            {
                MessageBox.Show("You already picked an option. You can change it later in the settings.");
                return;
            }
            
            // the set of data to update data.json with
            ApplicationData freshData = new ApplicationData()
            {
                LoggedBefore = true,
                DarkOrLight = "dark"
            };
            WriteData(freshData, dataJSONpath);

            
            
            Form1 MainApp = new Form1(); // this is the main app's class
            MainApp.Show(); // Present this bad boy to the user
            this.Hide();
        };

        Controls.Add(mainTitle);
        Controls.Add(buttonLight);
        Controls.Add(buttonDark);
    }


}