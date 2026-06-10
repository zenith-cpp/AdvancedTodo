using System.Drawing;

namespace AdvancedTodo;

// TODO: Work on the Profile system ;)

public partial class Form1 : Form
{
    private System.Windows.Forms.Timer refreshTimer;
    private Label users_wealth_inform;
    private Label total_tasks_user_completed_inform;
    private List<Label> taskLabels = new();
    private List<Label> taskPoints = new();

    private int appearanceAmountBT = 0;
    private int appearanceAmountLUC = 0;
    private int appearanceAmountMLC = 0;
    private int appearanceAmountUC = 0;
    

    public static void darkMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = ColorTranslator.FromHtml("#7c3aed");
        btn.ForeColor = Color.Black;
    }
    public static void darkRoseMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.darkRoseThemeCursorEnterBG;
        btn.ForeColor = Theme.darkRoseThemeFG;
    }

    public static void blackAndGoldMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.blackAndGoldThemeCursorEnterBG;
        btn.ForeColor = Theme.blackAndGoldThemeFG;
    }

    public static void blackAndGreenMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.blackAndGreenThemeCursorEnterBG;
        btn.ForeColor = Theme.blackAndGreenThemeFG;
    }


    public static void lightMouseEnter(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = ColorTranslator.FromHtml("#dcd8f5");
    }

    public static void darkMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;
        btn.BackColor = Theme.darkThemeSidePanelBG;
        btn.ForeColor = Color.White;
    }

    public static void lightMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;
        btn.BackColor = Color.White;
        btn.ForeColor = Color.Black;
    }

    public static void darkRoseMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.darkRoseThemeBG;
        btn.ForeColor = Theme.darkRoseThemeFG;
    }

    public static void blackAndGoldMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.blackAndGoldThemeBG;
        btn.ForeColor = Theme.blackAndGoldThemeFG;
    }

    public static void blackAndGreenMouseLeave(object s, EventArgs e)
    {
        Button btn = (Button)s;

        btn.BackColor = Theme.blackAndGreenThemeBG;
        btn.ForeColor = Theme.blackAndGreenThemeFG;
    }

    private void RefreshUI(object? sender, EventArgs e) //* To refresh the UI cleanly
    {
        UserStats stats = BtnFunc.LoadUserStats();
        BadgeData badgeData = BtnFunc.LoadBadgeData();

        users_wealth_inform.Text = "💵 To-do coins: " + stats.currency_points;
        total_tasks_user_completed_inform.Text = "📋 Total Tasks Completed: " + stats.total_tasks_completed;
        LoadTasks();

        
        // check for badges
        if(stats.total_tasks_completed >= 10 && badgeData.hasBadgeBeginnerTasker == false)
        {
            
            appearanceAmountBT++;
            if(appearanceAmountBT == 1)
            {
                MessageBox.Show("Congratulations! You got the badge `Beginner Tasker`! Check your profile!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                // pass
            }

            BadgeData freshData = new BadgeData()
            {
                hasBadgeBeginnerTasker = true,
                hasBadgeLowerUpperClass = badgeData.hasBadgeLowerUpperClass,
                hasBadgeMiddleLowerClass = badgeData.hasBadgeMiddleLowerClass,
                hasBadgeUpperClass = badgeData.hasBadgeUpperClass
            };

            BtnFunc.OverwriteBadgeData(freshData);
        
        }
        if(stats.currency_points >= 250 && badgeData.hasBadgeLowerUpperClass == false)
        {
            
            appearanceAmountLUC++;
            if(appearanceAmountLUC == 1)
            {
                MessageBox.Show("Congratulations! You got the badge 'Lower-Upper Class'!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                // pass
            }

            BadgeData freshData = new BadgeData()
            {
                hasBadgeBeginnerTasker = badgeData.hasBadgeBeginnerTasker,
                hasBadgeLowerUpperClass = true,
                hasBadgeMiddleLowerClass = badgeData.hasBadgeMiddleLowerClass,
                hasBadgeUpperClass = badgeData.hasBadgeUpperClass
            };

            BtnFunc.OverwriteBadgeData(freshData);
        }
        if(stats.currency_points >= 400 && badgeData.hasBadgeMiddleLowerClass == false)
        {
            
            appearanceAmountMLC++;
            if(appearanceAmountMLC == 1)
            {
                MessageBox.Show("Congratulations! You got the badge 'Middle-Lower Class'!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                // pass
            }

            BadgeData freshData = new BadgeData()
            {
                hasBadgeBeginnerTasker = badgeData.hasBadgeBeginnerTasker,
                hasBadgeLowerUpperClass = badgeData.hasBadgeLowerUpperClass,
                hasBadgeMiddleLowerClass = true,
                hasBadgeUpperClass = badgeData.hasBadgeUpperClass
            };

            BtnFunc.OverwriteBadgeData(freshData);
        }
        if(stats.currency_points >= 1000 && badgeData.hasBadgeUpperClass == false)
        {
            
            appearanceAmountUC++;
            if(appearanceAmountUC == 1)
            {
                MessageBox.Show("Congratulations! You got the badge 'Upper Class'!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                // pass
            }

            BadgeData freshData = new BadgeData()
            {
                hasBadgeBeginnerTasker = badgeData.hasBadgeBeginnerTasker,
                hasBadgeLowerUpperClass = badgeData.hasBadgeLowerUpperClass,
                hasBadgeMiddleLowerClass = badgeData.hasBadgeMiddleLowerClass,
                hasBadgeUpperClass = true
            };

            BtnFunc.OverwriteBadgeData(freshData);
        }
    }

    public static void StyleButton(Button btn, bool Dark, Color borderColor, Color BackGroundColor)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderColor = borderColor;
        btn.FlatAppearance.BorderSize = 2;

        if(Dark)
        {
            btn.BackColor = BackGroundColor;
            btn.ForeColor = Theme.darkThemeFG;
        } else
        {
            btn.BackColor = BackGroundColor;
            btn.ForeColor = Theme.lightThemeFG;
        }
    }

    public void LoadTasks()
    {
        foreach (var l in taskLabels) this.Controls.Remove(l);
        foreach (var p in taskPoints) this.Controls.Remove(p);

        taskLabels.Clear();
        taskPoints.Clear();

        string[] task_lines = File.ReadAllLines("ApplicationData/tasks.txt");
        string[] task_pts = File.ReadAllLines("ApplicationData/pts.txt");
        string[] task_desc = File.ReadAllLines("ApplicationData/desc.txt");

        ApplicationData dataJSON = QuestionForm.LoadData(QuestionForm.dataJSONpath);

        for (int i = 0; i < task_lines.Length; i++)
        {
            int index = i;

            Label newTask = new()
            {
                Text = task_lines[i].Trim(),
                AutoSize = true,
                Location = new Point(320, 50 + (i * 50)),
                Font = new Font("Ubuntu Mono", 12)
            };

            Label points = new()
            {
                Text = task_pts[i].Trim(),
                AutoSize = true,
                Location = new Point(1100, 50 + (i * 50)),
                Font = new Font("Ubuntu Mono", 13)
            };

            newTask.Click += (s, e) => 
            {
                BtnFunc.MainContentTaskOverView(s, e, newTask.Text, points.Text, task_desc[index], newTask, points);
            };

            


            this.Controls.Add(newTask);
            this.Controls.Add(points);

            taskLabels.Add(newTask);
            taskPoints.Add(points);

            if (dataJSON.DarkOrLight == "dark")
            {
                newTask.BackColor = points.BackColor = Theme.darkThemeBG;
                newTask.ForeColor = points.ForeColor = Theme.darkThemeFG;

                newTask.MouseEnter += (s, e) =>
                {
                    newTask.ForeColor = ColorTranslator.FromHtml("#181818ff");
                    Cursor = Cursors.Hand;
                };
                newTask.MouseLeave += (s, e) =>
                {
                    newTask.ForeColor = Color.White;
                    Cursor = Cursors.Default;
                };

            }
            else
            {
                newTask.BackColor = points.BackColor = Theme.lightThemeBG;
                newTask.ForeColor = points.ForeColor = Theme.lightThemeFG;
                
                newTask.MouseEnter += (s, e) =>
                {
                    newTask.ForeColor = ColorTranslator.FromHtml("#d3d3d3ff");
                    Cursor = Cursors.Hand;
                };
                newTask.MouseLeave += (s, e) =>
                {
                    newTask.ForeColor = Color.Black;
                    Cursor = Cursors.Hand;
                };
            }
        }
    }

    public Form1()
    {
        this.DoubleBuffered = true;

        this.Text = "AdvancedTodo";
        this.Width = 1200;
        this.Height = 800;
        this.StartPosition = FormStartPosition.CenterScreen;
        

        InitializeWidgets();

        //? The timer for automatic window refreshing
        refreshTimer = new System.Windows.Forms.Timer();
        refreshTimer.Interval = 1200; // 1.2 seconds
        refreshTimer.Tick += RefreshUI;
        refreshTimer.Start();
        
    }

    
    private void InitializeWidgets()
    {
        

        ApplicationData dataJSON = QuestionForm.LoadData(QuestionForm.dataJSONpath);
        UserStats userStatistics = BtnFunc.LoadUserStats();

        Panel buttonPanel = new()
        {
            Width = 300,
            Dock = DockStyle.Left, // stick to the left side
            AutoScroll = true
        };

        /*
        Panel buttonPanelSeparator = new()
        {
            Width = 2,
            Dock = DockStyle.Left
        };

        ! the buttonpanelSeperator looks bad, so I'll just comment it out for now.
        */
        // Button widgets that get added onto the buttonPanel panel
        Button addTask = new()
        {
            Text = "Add Task",
            Font = new Font(Theme.universalFont, 14),
            Width = 300,
            Height = 45,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top // Stick to the panel's top
        };

        /*Button removeTask = new()
        {
            Text = "Remove Task",
            Font = new Font(Theme.universalFont, 14),
            Width = 300,
            Height = 45,
            Cursor = Cursors.Hand, // make it look like you're actually clicking something yk
            Dock = DockStyle.Top
        };*/ // Commented out cause I dont find it neccessary yet

        Button profile = new()
        {
            Text = "Profile",
            Font = new Font(Theme.universalFont, 14),
            Width = 300,
            Height = 45,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        Button shop = new()
        {
            Text = "Shop",
            Font = new Font(Theme.universalFont, 14),
            Width = 300,
            Height = 45,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        Button settings = new()
        {
            Text = "Settings",
            Font = new Font(Theme.universalFont, 14),
            Width = 300,
            Height = 45,
            Cursor = Cursors.Hand,
            Dock = DockStyle.Top
        };

        //? Displaying user data
        users_wealth_inform = new()
        {
            Text = "To-do coins: " + userStatistics.currency_points.ToString(),
            Font = new Font(Theme.universalFont, 12),
            AutoSize = true,
            Dock = DockStyle.Top
        };

        total_tasks_user_completed_inform = new()
        {
            Text = "Total Tasks Completed: " + userStatistics.total_tasks_completed.ToString(),
            Font = new Font(Theme.universalFont, 12),
            AutoSize = true,
            Dock = DockStyle.Top
        };
        

        // to the main form:
        Label task_inform = new()
        {
            Text = "TASKS",
            Font = new Font(Theme.universalFont, 16),
            AutoSize = true,
            Location = new Point(315, 0)

        };

        Label AOPTS_inform = new()
        {
            Text = "VALUES",
            Font = new Font(Theme.universalFont, 16),
            AutoSize = true,
            Location = new Point(1100, 0)
        };

        

        
        //! Alright now comes the juicy and hard stuff
        //? ADDING THE TASKS AND THE POINTS IT GIVES TO THE MAIN PANEL
        //* spooky, right?

        LoadTasks();

        Controls.Add(task_inform);
        Controls.Add(AOPTS_inform);
        Controls.Add(buttonPanel);
        

        // Checks if the dark or light theme is selected, sets the back and forecolor to the specified theme's
        if(dataJSON.DarkOrLight == "dark")
        {

            // Custom function for more readable code; the parameters: Button buttonWidget, isDark, borderColor
            StyleButton(addTask,  true, Theme.darkThemeBorderColor, Theme.darkThemeSidePanelBG);
            StyleButton(profile,  true, Theme.darkThemeBorderColor, Theme.darkThemeSidePanelBG);
            StyleButton(shop,     true, Theme.darkThemeBorderColor, Theme.darkThemeSidePanelBG);
            StyleButton(settings, true, Theme.darkThemeBorderColor, Theme.darkThemeSidePanelBG);


            // main form
            this.BackColor = Theme.darkThemeBG;
            // sidepanel
            buttonPanel.BackColor          = Theme.darkThemeSidePanelBG;
            users_wealth_inform.BackColor = total_tasks_user_completed_inform.BackColor = Theme.darkThemeSidePanelBG; // because it's a widget part of the side panel
            users_wealth_inform.ForeColor = total_tasks_user_completed_inform.ForeColor = task_inform.ForeColor = AOPTS_inform.ForeColor = Theme.darkThemeFG; // the forecolor should be white tho

            task_inform.BackColor = AOPTS_inform.BackColor = Theme.darkThemeBG;

            // Button Hover Effects
            addTask.MouseEnter    += darkMouseEnter;
            profile.MouseEnter    += darkMouseEnter;
            shop.MouseEnter       += darkMouseEnter;
            settings.MouseEnter   += darkMouseEnter;

            addTask.MouseLeave    += darkMouseLeave;
            profile.MouseLeave    += darkMouseLeave;
            shop.MouseLeave       += darkMouseLeave;
            settings.MouseLeave   += darkMouseLeave;
            // Button functionalities
            


        } else // default to light
        {
            StyleButton(addTask,  false, Theme.lightThemeBorderColor, Theme.lightThemeSidePanelBG);
            StyleButton(profile,  false, Theme.lightThemeBorderColor, Theme.lightThemeSidePanelBG);
            StyleButton(shop,     false, Theme.lightThemeBorderColor, Theme.lightThemeSidePanelBG);
            StyleButton(settings, false, Theme.lightThemeBorderColor, Theme.lightThemeSidePanelBG);

            // Button Hover Effects
            addTask.MouseEnter    += lightMouseEnter;
            profile.MouseEnter    += lightMouseEnter;
            shop.MouseEnter       += lightMouseEnter;
            settings.MouseEnter   += lightMouseEnter;

            this.BackColor                 = Theme.lightThemeBG;
            buttonPanel.BackColor          = Theme.lightThemeSidePanelBG;


            addTask.MouseLeave    += lightMouseLeave;
            profile.MouseLeave    += lightMouseLeave;
            shop.MouseLeave       += lightMouseLeave;
            settings.MouseLeave   += lightMouseLeave;
            
        }
        
        //! Functionalities
        addTask.Click  += BtnFunc.AddTaskFunction ; 
        profile.Click  += BtnFunc.ProfileFunction ;
        shop.Click     += BtnFunc.ShopFunction    ;
        settings.Click += BtnFunc.SettingsFunction;


        //! Adding the widgets to the left-side panel
        buttonPanel.Controls.Add(total_tasks_user_completed_inform); //* label
        buttonPanel.Controls.Add(users_wealth_inform);               //* label
        buttonPanel.Controls.Add(settings);                          //* button
        buttonPanel.Controls.Add(shop);                              //* button
        buttonPanel.Controls.Add(profile);                           //* button
        buttonPanel.Controls.Add(addTask);                           //* button
        
    }
}
