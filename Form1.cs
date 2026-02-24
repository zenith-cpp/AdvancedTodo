namespace AdvancedTodo;

public partial class Form1 : Form
{
    public Color lightThemeBG = Color.White;
    public Color lightThemeFG = Color.Black;
    public Color darkThemeBG = Color.Black;
    public Color darkThemeFG = Color.White;

    public void darkMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Color.White;
        btn.ForeColor = Color.Black;
    }

    public void lightMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Color.Black;
        btn.ForeColor = Color.White;
    }

    public void darkMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;
        btn.BackColor = Color.Black;
        btn.ForeColor = Color.White;
    }

    public void lightMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;
        btn.BackColor = Color.White;
        btn.ForeColor = Color.Black;
    }

    public Form1()
    {
        this.Text = "AdvancedTodo";
        this.Width = 1200;
        this.Height = 800;
        this.StartPosition = FormStartPosition.CenterScreen;

        InitializeWidgets();
    }

    private void InitializeWidgets()
    {
        ApplicationData dataJSON = QuestionForm.LoadData(QuestionForm.dataJSONpath);


        Panel buttonPanel = new()
        {
            Width = 300,
            Dock = DockStyle.Left, // stick to the left side
            BackColor = Color.Gray
        };

        Controls.Add(buttonPanel);

        // Button widgets that get added onto the buttonPanel panel
        Button addTask = new()
        {
            Text = "Add Task",
            Font = new Font("Consolas", 14),
            Width = 300,
            Height = 50,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top // Stick to the panel's top
        };

        Button removeTask = new()
        {
            Text = "Remove Task",
            Font = new Font("Consolas", 14),
            Width = 300,
            Height = 50,
            Cursor = Cursors.Hand, // make it look like you're actually clicking something yk
            Dock = DockStyle.Top
        };

        Button profile = new()
        {
            Text = "Profile",
            Font = new Font("Consolas", 14),
            Width = 300,
            Height = 50,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        Button shop = new()
        {
            Text = "Shop",
            Font = new Font("Consolas", 14),
            Width = 300,
            Height = 50,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        Button settings = new()
        {
            Text = "Settings",
            Font = new Font("Consolas", 14),
            Width = 300,
            Height = 50,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        

        


        // Checks if the dark or light theme is selected, sets the back and forecolor to the specified theme's
        if(dataJSON.DarkOrLight == "dark")
        {
            // addtask
            addTask.BackColor = darkThemeBG;
            addTask.ForeColor = darkThemeFG;
            // remove task
            removeTask.BackColor = darkThemeBG;
            removeTask.ForeColor = darkThemeFG;
            // profile
            profile.BackColor = darkThemeBG;
            profile.ForeColor = darkThemeFG;
            // shop
            shop.BackColor = darkThemeBG;
            shop.ForeColor = darkThemeFG;
            // settings
            settings.BackColor = darkThemeBG;
            settings.ForeColor = darkThemeFG;
            // main form
            this.BackColor = ColorTranslator.FromHtml("#333");
            // sidepanel
            buttonPanel.BackColor = Color.Black;



            // Button Hover Effects
            addTask.MouseEnter += darkMouseEnter;
            removeTask.MouseEnter += darkMouseEnter;
            profile.MouseEnter += darkMouseEnter;
            shop.MouseEnter += darkMouseEnter;

            addTask.MouseLeave += darkMouseLeave;
            removeTask.MouseLeave += darkMouseLeave;
            profile.MouseLeave += darkMouseLeave;
            shop.MouseLeave += darkMouseLeave;
            // Button functionalities
            addTask.Click += BtnFunc.AddTaskFunction;


        } else // default to light
        {
            // addtask
            addTask.BackColor = lightThemeBG;
            addTask.ForeColor = lightThemeFG;
            // remove task
            removeTask.BackColor = lightThemeBG;
            removeTask.ForeColor = lightThemeFG;
            // profile
            profile.BackColor = lightThemeBG;
            profile.ForeColor = lightThemeFG;
            // shop
            shop.BackColor = lightThemeBG;
            shop.ForeColor = lightThemeFG;
            // settings
            settings.BackColor = lightThemeBG;
            settings.ForeColor = lightThemeFG;

            // Button Hover Effects
            addTask.MouseEnter += lightMouseEnter;
            removeTask.MouseEnter += lightMouseEnter;
            profile.MouseEnter += lightMouseEnter;
            shop.MouseEnter += lightMouseEnter;

            addTask.MouseLeave += lightMouseLeave;
            removeTask.MouseLeave += lightMouseLeave;
            profile.MouseLeave += lightMouseLeave;
            shop.MouseLeave += lightMouseLeave;
            
            
        }

        buttonPanel.Controls.Add(settings);
        buttonPanel.Controls.Add(shop);
        buttonPanel.Controls.Add(profile);
        buttonPanel.Controls.Add(removeTask);
        buttonPanel.Controls.Add(addTask);
        
    }
}
