namespace AdvancedTodo;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;



static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // read data from the data.json file
        ApplicationData data = QuestionForm.LoadData(@"ApplicationData/data.json");
        if(data.LoggedBefore)
        {
            Application.Run(new Form1());
        } else {
            Application.Run(new QuestionForm());
        }
    }    
}