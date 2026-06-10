using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.Json;


public class UserStats
{
    public int currency_points           {get; set;}
    public int total_tasks_completed     {get; set;}
};

public class BadgeData
{
    public bool hasBadgeBeginnerTasker   {get; set;}
    public bool hasBadgeLowerUpperClass  {get; set;}
    public bool hasBadgeMiddleLowerClass {get; set;}
    public bool hasBadgeUpperClass       {get; set;}
};

public class ShopItemsData
{
    public bool ownsDarkRoseTheme         {get; set;}
    public bool ownsBlackAndGreenTheme    {get; set;}
    public bool ownsBlackAndGoldTheme     {get; set;}
    public bool ownsTBGTitle              {get; set;}
    public bool ownsTIGTitle              {get; set;}
    public bool ownsTPGTitle              {get; set;}
    public bool ownsTUGTitle              {get; set;}
    public bool ownsThousandareTitle      {get; set;}
    public bool ownsMultiThousandareTitle {get; set;}
    public bool ownsUCGolden              {get; set;}
    public bool ownsUCGreen               {get; set;}
    public bool ownsUCRed                 {get; set;}
};



namespace AdvancedTodo
{
    public static class BtnFunc // `static` so it can be used in other files. this is a util file after all
    {

        public static UserStats LoadUserStats()
        {
            string path = @"ApplicationData/user_stats.json";
            if(File.Exists(path))
            {
                string json = File.ReadAllText(path);
                UserStats userData = JsonSerializer.Deserialize<UserStats>(json);
                return userData;
            } else
            {
                MessageBox.Show("File `ApplicationData/user_stats.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return new UserStats();
            }
        }
        public static ShopItemsData LoadShopItemsData()
        {
            string path = @"ApplicationData/shop_items.json";
            if(File.Exists(path))
            {
                string json = File.ReadAllText(path);
                ShopItemsData SIData = JsonSerializer.Deserialize<ShopItemsData>(json);
                return SIData;
            } else
            {
                MessageBox.Show("File `ApplicationData/shop_items.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return new ShopItemsData();
            }
        }
        public static void OverwriteBadgeData(BadgeData dataToWriteIntoJSON)
        {
            string path = @"ApplicationData/badges.json";
            if(File.Exists(path))
            {
                string json = JsonSerializer.Serialize(dataToWriteIntoJSON, new JsonSerializerOptions 
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                return;
            } else
            {
                MessageBox.Show("File `ApplicationData/user_stats.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return;
            }
        }
        public static void OverwriteUserStats(UserStats dataToWriteIntoJSON)
        {
            string path = @"ApplicationData/user_stats.json";
            if(File.Exists(path))
            {
                string json = JsonSerializer.Serialize(dataToWriteIntoJSON, new JsonSerializerOptions 
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                return;
            } else
            {
                MessageBox.Show("File `ApplicationData/user_stats.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return;
            }
        }
        public static void OverwriteShopItems(ShopItemsData dataToWriteIntoJSON)
        {
            string path = @"ApplicationData/shop_items.json";
            if(File.Exists(path))
            {
                string json = JsonSerializer.Serialize(dataToWriteIntoJSON, new JsonSerializerOptions 
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                return;
            } else
            {
                MessageBox.Show("File `ApplicationData/shop_items.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return;
            }
        }   
        
        public static void OverwriteData(ApplicationData dataToWriteIntoJSON)
        {
            string path = @"ApplicationData/data.json";
            if(File.Exists(path))
            {
                string json = JsonSerializer.Serialize(dataToWriteIntoJSON, new JsonSerializerOptions 
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                return;
            } else
            {
                MessageBox.Show("File `ApplicationData/shop_items.json` is not found. This error often occurs because you deleted/moved the user_stats.json file from ApplicationData.");
                return;
            }
        }
        public static void LoadThemePreview(string themeName, Panel parentPanel)
        {
            Panel themePreview = new()
            {
                Width = 200,
                Height = 50,
                Location = new Point(10, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            Label testLabel = new()
            {
                Text = "Theme Test",
                Font = new Font(Theme.universalFont, 12),
                AutoSize = true
            };

            // Here comes the shit ton of if-statements
            if(themeName == "Dark Rose Theme")
            {
                themePreview.BackColor = Theme.darkRoseThemeBG;
                testLabel.ForeColor = Theme.darkRoseThemeFG;
                testLabel.BackColor = Theme.darkRoseThemeBG;
            } else if(themeName == "Black and Gold Theme")
            {
                themePreview.BackColor = Theme.blackAndGoldThemeBG;
                testLabel.ForeColor = Theme.blackAndGoldThemeFG;
                testLabel.BackColor = Theme.blackAndGoldThemeBG;
            } else if(themeName == "Black and Green Theme")
            {
                themePreview.BackColor = Theme.blackAndGreenThemeBG;
                testLabel.ForeColor = Theme.blackAndGreenThemeFG;
                testLabel.BackColor = Theme.blackAndGreenThemeBG;
            }
            parentPanel.Controls.Add(themePreview);
            themePreview.Controls.Add(testLabel);
        }
        
        public static void AddTaskFunction(object s, EventArgs e)
        {
            

            Form at = new()
            {
                Text = "AdvancedTodo - Add Task",
                Width = 800,
                Height = 500,
                StartPosition = FormStartPosition.CenterScreen
            };

            
            at.Show();
            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            bool dark = data.DarkOrLight == "dark";

            FlowLayoutPanel panel = new()
            {
                Dock          = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents  = false,
                Padding       = new Padding(20),
                AutoScroll    = true,
                BackColor     = dark ? Theme.darkThemeBG : Theme.lightThemeBG
            };


            Label instruction1 = new()
            {
                Text = "Fill out the form.",
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                Font = new Font(Theme.universalFont, 14),
                AutoSize = true,
            };

            Label instruction2 = new()
            {
                Text = "Enter what your task should be:",
                Font = new Font(Theme.universalFont, 12),
                AutoSize = true,
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,

            };

            TextBox task = new()
            {
                Width = 540,
                Height = 35,
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 4, 0, 12),
                Font = new Font(Theme.universalFont, 12),
            };

            Label instruction3 = new()
            {
                Text = "How much To-do coins should you get for this task? (MAX. 100)",
                Font = new Font(Theme.universalFont, 12),
                AutoSize = true,
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG
            };

            NumericUpDown amountOfPTS = new()
            {
                Minimum = 0,
                Maximum = 100,
                Width = 540,
                Height = 35,
                Margin = new Padding(0, 4, 0, 12),
                Font = new Font(Theme.universalFont, 12),
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG
            };

            Label instruction4 = new()
            {
                Text = "Explain the task, or leave it blank",
                Font = new Font(Theme.universalFont, 12),
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                AutoSize = true
            };

            TextBox briefDescription = new()
            {
                Width = 540,
                Height = 80,
                Font = new Font(Theme.universalFont, 12),
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true,
                Margin = new Padding(0, 4, 0, 12)
            };

            Button submitButton = new()
            {
                Text = "Submit Data",
                Font = new Font(Theme.universalFont, 12),
                ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG,
                BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Height = 40,
                Width = 540,

            };

            submitButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#7c3aed");

            submitButton.Click += (s, e) =>
            {
                if(string.IsNullOrWhiteSpace(task.Text))
                {
                    MessageBox.Show("Task cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string[] lines_task = File.ReadAllLines("ApplicationData/tasks.txt");
                bool run = true;
                foreach(string line in lines_task)
                {
                    if (line.ToLower() == task.Text.ToLower())
                    {
                        run = false;
                        break;
                    }
                }

                if (run)
                {
                    File.AppendAllText("ApplicationData/tasks.txt", task.Text + "\n");
                    File.AppendAllText("ApplicationData/pts.txt", amountOfPTS.Value + "\n");
                    File.AppendAllText("ApplicationData/desc.txt", briefDescription.Text + "\n"); // if briefDescription.Text is empty, it will just add a newline
                    
                    task.Text = "";
                    amountOfPTS.Value = 0;
                    briefDescription.Text = "";
                    
                    MessageBox.Show("Success!");
                } else
                {
                    MessageBox.Show("Task already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            };

            panel.Controls.Add(instruction1);
            panel.Controls.Add(instruction2);
            panel.Controls.Add(task);
            panel.Controls.Add(instruction3);
            panel.Controls.Add(amountOfPTS);
            panel.Controls.Add(instruction4);
            panel.Controls.Add(briefDescription);
            panel.Controls.Add(submitButton);

            at.Controls.Add(panel);
        }

        public static BadgeData LoadBadgeData()
        {
            string path = @"ApplicationData/badges.json";
            // load the data from badges.json
            if(File.Exists(path))
            {
                string json = File.ReadAllText(path);
                BadgeData JSONdata = JsonSerializer.Deserialize<BadgeData>(json);
                return JSONdata;
            } else
            {
                MessageBox.Show("ApplicationData/badges.json doesn't exist. If you moved the directory on purpose, please move it back, or change the source code to point at its current location.");
                return new BadgeData();
            }
        }
        
        //* these functions just load the badges

        public static void LoadBadgeBeginnerTasker(Form parentForm, Label ultimateTooltip)
        {
            PictureBox badgeBeginnerTasker = new()
            {
                Image = Image.FromFile("assets/badge_beginnerTasker.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 24,
                Height = 24,
                Location = new Point(10, 50)
            };

            //* The MouseEnter and MouseLeave events, aswell as the click event for further information about the badge
            badgeBeginnerTasker.MouseEnter += (s, e) =>
            {
                ultimateTooltip.Text = "Beginner Tasker: Successfully Completed 10 Tasks.";
                badgeBeginnerTasker.Cursor = Cursors.Hand;
            };
            badgeBeginnerTasker.MouseLeave += (s, e) =>
            {
                badgeBeginnerTasker.Cursor = Cursors.Default;
                ultimateTooltip.Text = "";
            };
            badgeBeginnerTasker.Click      += (s, e) =>
            {
                MessageBox.Show("To obtain this badge, you must complete 10 tasks.", "Badge Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            parentForm.Controls.Add(badgeBeginnerTasker);
        }
        public static void LoadBadgeLowerUpperClass(Form parentForm, Label ultimateTooltip)
        {
            PictureBox badgeLowerUpperClass = new()
            {
                Image = Image.FromFile("assets/lower_upper_class.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 24,
                Height = 24,
                Location = new Point(40, 50)
            };

            badgeLowerUpperClass.MouseEnter += (s, e) => 
            {
                ultimateTooltip.Text = "Lower-Upper Class: Collect 250 coins.";
                badgeLowerUpperClass.Cursor = Cursors.Hand;
            };
            badgeLowerUpperClass.MouseLeave += (s, e) =>
            {
                badgeLowerUpperClass.Cursor = Cursors.Default;
                ultimateTooltip.Text = "";
            };
            badgeLowerUpperClass.Click      += (s, e) =>
            {
                MessageBox.Show("To obtain this badge, you must collect 250 coins by completing tasks.", "Badge Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            parentForm.Controls.Add(badgeLowerUpperClass);
        }
        public static void LoadBadgeMiddleLowerClass(Form parentForm, Label ultimateTooltip)
        {
            PictureBox badgeMiddleLowerClass = new()
            {
                Image = Image.FromFile("assets/middle_lower_class.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 24,
                Height = 24,
                Location = new Point(70, 50)
            };

            badgeMiddleLowerClass.MouseEnter += (s, e) =>
            {
                ultimateTooltip.Text = "Middle-Lower Class: Collect 400 coins.";
                badgeMiddleLowerClass.Cursor = Cursors.Hand;
            };
            badgeMiddleLowerClass.MouseLeave += (s, e) =>
            {
                badgeMiddleLowerClass.Cursor = Cursors.Default;
                ultimateTooltip.Text = "";
            };
            badgeMiddleLowerClass.Click      += (s, e) =>
            {
                MessageBox.Show("To obtain this badge, you must collect 400 coins by completing tasks.", "Badge Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            parentForm.Controls.Add(badgeMiddleLowerClass);
        }
        
        public static void LoadBadgeUpperClass(Form parentForm, Label ultimateTooltip)
        {
            PictureBox badgeUpperClass = new()
            {
                Image = Image.FromFile("assets/upper_class.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 24,
                Height = 24,
                Location = new Point(100, 50)
            };

            badgeUpperClass.MouseEnter += (s, e) =>
            {
                ultimateTooltip.Text = "Upper Class: Collect 1000 coins.";
                badgeUpperClass.Cursor = Cursors.Hand;
            };
            badgeUpperClass.MouseLeave += (s, e) =>
            {
                badgeUpperClass.Cursor = Cursors.Default;
                ultimateTooltip.Text = "";
            };
            badgeUpperClass.Click      += (s, e) =>
            {
                MessageBox.Show("To obtain this badge, you must collect 1000 coins by completing tasks.", "Badge Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };


            parentForm.Controls.Add(badgeUpperClass);
        }

        public static void ProfileFunction(object s, EventArgs e)
        {
            Form profileForm = new()
            {
                Text = "Your Profile",
                Height = 800,
                Width = 1000,
                StartPosition = FormStartPosition.CenterScreen
            };
            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            BadgeData badgeData = LoadBadgeData();

            profileForm.Show();

            Label userName = new()
            {
                Text = "YikeBones",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 6)
            };
            

            Label ultimateTooltip = new()
            {
                Text = "",
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 94)
            };

            // Checking for badges
            if(badgeData.hasBadgeBeginnerTasker)
            {
                LoadBadgeBeginnerTasker(profileForm, ultimateTooltip);
            }
            if(badgeData.hasBadgeLowerUpperClass)
            {
                LoadBadgeLowerUpperClass(profileForm, ultimateTooltip);
            }
            if(badgeData.hasBadgeMiddleLowerClass)
            {
                LoadBadgeMiddleLowerClass(profileForm, ultimateTooltip);
            }
            if(badgeData.hasBadgeUpperClass)
            {
                LoadBadgeUpperClass(profileForm, ultimateTooltip);
            }





            bool dark = data.DarkOrLight == "dark";
            if(dark)
            {
                profileForm.BackColor = Theme.darkThemeBG;
                userName.BackColor = ultimateTooltip.BackColor = Theme.darkThemeBG;
                userName.ForeColor = ultimateTooltip.ForeColor = Theme.darkThemeFG;
                
            } else
            {
                profileForm.BackColor = Theme.lightThemeBG;
                userName.BackColor = ultimateTooltip.BackColor = Theme.lightThemeBG;
                userName.ForeColor = ultimateTooltip.ForeColor = Theme.lightThemeFG;
            }
    
            profileForm.Controls.Add(ultimateTooltip);
            profileForm.Controls.Add(userName);
        }
        public static void ShopFunction(object s, EventArgs e)
        {
            Form shopForm = new()
            {
                Text = "Shop",
                Width = 900,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };

            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            bool dark = data.DarkOrLight == "dark";

            shopForm.BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG;
            shopForm.Show();

            FlowLayoutPanel mainPanel = new()
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock          = DockStyle.Fill,
                WrapContents  = true,
                AutoScroll    = true,
                Padding       = new Padding(10)
            };

            // A dictionary of items you can buy
            var items = new(string name, string icon, string category, int cost_points, int cost_ttc)[] // ttc - total tasks completed
            {
                //? The themes
                ("Dark Rose Theme"      , "🎨", "theme", 300 , 0),
                ("Black and Gold Theme" , "🎨", "theme", 1500, 0),
                ("Black and Green Theme", "🎨", "theme", 100 , 0),

                //? The titles
                ("'The Beginner Grinder'"    , "🏆", "title", 150,   5 ),
                ("'The Intermediate Grinder'", "🏆", "title", 300,   10),
                ("'The Pro Grinder'"         , "🏆", "title", 500,   20),
                ("'The Ultimate Grinder'"    , "🏆", "title", 1000,  50),
                ("'Thousandare'"             , "🏆", "title", 1000,  0 ),
                ("'Multi-Thousandare'"       , "🏆", "title", 10000, 0 ),


                //? The username colors
                ("Golden", "🖊️", "uc", 500, 0),
                ("Green" , "🖊️", "uc", 150, 0),
                ("Red"   , "🖊️", "uc", 150, 0)
            };

            var itemActions = new Dictionary<string, Action<ShopItemsData>>()
            {
                { "Dark Rose Theme"           ,(d) => d.ownsDarkRoseTheme         = true },
                { "Black and Gold Theme"      ,(d) => d.ownsBlackAndGoldTheme     = true },
                { "Black and Green Theme"     ,(d) => d.ownsBlackAndGreenTheme    = true },
                { "'The Beginner Grinder'"    ,(d) => d.ownsTBGTitle              = true },
                { "'The Intermediate Grinder'",(d) => d.ownsTIGTitle              = true },
                { "'The Pro Grinder'"         ,(d) => d.ownsTPGTitle              = true },
                { "'The Ultimate Grinder'"    ,(d) => d.ownsTUGTitle              = true },
                { "'Thousandare'"             ,(d) => d.ownsThousandareTitle      = true },
                { "'Multi-Thousandare'"       ,(d) => d.ownsMultiThousandareTitle = true },
                { "Golden"                    ,(d) => d.ownsUCGolden              = true },
                { "Green"                     ,(d) => d.ownsUCGreen               = true },
                { "Red"                       ,(d) => d.ownsUCRed                 = true },
            };

            


            var itemOwned = new Dictionary<string, Func<ShopItemsData, bool>>()
            {
                { "Dark Rose Theme"           , (d) => d.ownsDarkRoseTheme         },
                { "Black and Gold Theme"      , (d) => d.ownsBlackAndGoldTheme     },
                { "Black and Green Theme"     , (d) => d.ownsBlackAndGreenTheme    },
                { "'The Beginner Grinder'"    , (d) => d.ownsTBGTitle              },
                { "'The Intermediate Grinder'", (d) => d.ownsTIGTitle              },
                { "'The Pro Grinder'"         , (d) => d.ownsTPGTitle              },
                { "'The Ultimate Grinder'"    , (d) => d.ownsTUGTitle              },
                { "'Thousandare'"             , (d) => d.ownsThousandareTitle      },
                { "'Multi-Thousandare'"       , (d) => d.ownsMultiThousandareTitle },
                { "Golden"                    , (d) => d.ownsUCGolden              },
                { "Green"                     , (d) => d.ownsUCGreen               },
                { "Red"                       , (d) => d.ownsUCRed                 },
            };
            
            //? Action<dataType>(); basically stores a functions like Action<ShopitemsData> something = (d) => {your function}; and then you can just call it.

            foreach (var item in items)
            {
                var currentItem = item;
                Panel card = new()
                {
                    Width     = 220,
                    Height    = 200,
                    BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                    Margin    = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label icon = new Label()
                {
                    Text = item.icon,
                    Font = new Font("Segoe UI Emoji", 24),
                    AutoSize = true,
                    Location = new Point(85, 15)
                };

                Label name = new()
                {
                    Text = item.name,
                    Font = new Font(Theme.universalFont, 10),
                    AutoSize = true,
                    Location = new Point(10, 75)
                };

                Label cost = new()
                {
                    Text = item.cost_points + " coins and " + item.cost_ttc + " TTC",
                    Font = new Font(Theme.universalFont, 10, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(10, 100),
                    ForeColor = ColorTranslator.FromHtml("#7c3aed")
                };

                Button buyBtn = new()
                {
                    Text = "Buy",
                    Font = new Font(Theme.universalFont, 10),
                    Width = 200,
                    Height = 35,
                    Location = new Point(10, 135),
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = dark ? Theme.darkThemeBG : Theme.lightThemeBG,
                    ForeColor = dark ? Theme.darkThemeFG : Theme.lightThemeFG
                };
                buyBtn.FlatAppearance.BorderSize = 1;
                buyBtn.FlatAppearance.BorderColor = dark ? Theme.darkThemeBorderColor : Theme.lightThemeBorderColor;
                name.BackColor = cost.BackColor   = dark ? Theme.darkThemeBG : Theme.lightThemeBG;
                name.ForeColor = cost.ForeColor   = dark ? Theme.darkThemeFG : Theme.lightThemeFG;

                if(currentItem.category == "theme")
                {
                    card.Height = 275;
                    LoadThemePreview(currentItem.name, card);
                }


                buyBtn.Click += (s, e) =>
                {
                    UserStats userData   = LoadUserStats();
                    ShopItemsData SIData = LoadShopItemsData();
                    if(userData.currency_points >= item.cost_points && userData.total_tasks_completed >= item.cost_ttc)
                    {
                        if(itemActions.ContainsKey(item.name) && itemOwned.ContainsKey(item.name))
                        {
                            //* Check if user has bought the item already
                            if(itemOwned[item.name](SIData) == false)
                            {
                                MessageBox.Show("You already own this item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } else
                            {
                                itemActions[item.name](SIData);
                                OverwriteShopItems(SIData);
                                MessageBox.Show("Successfully Bought " + item.name + "!", "Successful Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                OverwriteUserStats(new UserStats
                                {
                                    currency_points       = userData.currency_points - item.cost_points,
                                    total_tasks_completed = userData.total_tasks_completed
                                });
                                // Not removing item.cost_ttc from total_tasks_completed cause im a generous dude
                            }
                            
                        } else
                        {
                            MessageBox.Show("An Error Occured: " + item.name + " not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("You don't have enough TTC (Total Tasks Completed) or To-do Coins to buy this item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                card.Controls.Add(icon);
                card.Controls.Add(name);
                card.Controls.Add(cost);
                card.Controls.Add(buyBtn);
                mainPanel.Controls.Add(card);

            }
            shopForm.Controls.Add(mainPanel);

        }

        public static void SettingsFunction(object s, EventArgs e)
        {
            Form settingsForm = new()
            {
                Text = "Settings",
                Width = 1200,
                Height = 500
            };
            settingsForm.Show();

            /*
            Available settings: Themes (dark or light + the bought themes)
            Fonts (Only bought ones)
            Profile Titles
            Change username
            */
            ShopItemsData shopItems = LoadShopItemsData();
            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            bool dark = data.DarkOrLight == "dark";
            
            // Declaring the panels
            
            Panel Gap() => new Panel()
            {
                Width     = 8,
                Dock      = DockStyle.Right,
                BackColor = data.DarkOrLight switch
                {
                    "dark"          => Theme.darkThemeBG,
                    "darkrose"      => Theme.darkRoseThemeBG,
                    "blackandgreen" => Theme.blackAndGreenThemeBG,
                    "blackandgold"  => Theme.blackAndGoldThemeBG,
                    _               => Theme.lightThemeBG // default to light
                }
            };

            Panel themePanel = new()
            {
                Width       = 1185,
                Height      = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Padding     = new Padding(10)
            };


            Panel fonts = new()
            {
                Width       = 1185,
                Height      = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Padding     = new Padding(10)
            };

            Panel profileTitles = new()
            {
                Width       = 1185,
                Height      = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Padding     = new Padding(10)
            };

            Panel changeUsername = new()
            {
                Width       = 1185,
                Height      = 100,
                BorderStyle = BorderStyle.FixedSingle,
                Padding     = new Padding(10)
            };

            //! Widgets for the themePanel panel
            Label themeInform = new()
            {
                Text     = "Themes",
                Font     = new Font(Theme.universalFont, 12),
                Dock     = DockStyle.Left,
                AutoSize = true
            };

            //? Generic Themes: Dark, Light
            //? For the other ones we need to check the shop_items.json file to check whether the user has them or not, and only display it if the user has it
            Button themeDarkBtn = new()
            {
                Text      = "Dark",
                Font      = new Font(Theme.universalFont, 12),
                Dock      = DockStyle.Right,
                BackColor = Theme.darkThemeBG,
                ForeColor = Theme.darkThemeFG,
                FlatStyle = FlatStyle.Flat,
                Margin    = new Padding(0, 10, 0, 0),
                Cursor    = Cursors.Hand
                
            };

            Button themeDarkRoseBtn      = new Button();
            Button themeBlackAndGreenBtn = new Button();
            Button themeBlackAndGoldBtn  = new Button();

            Button themeLightBtn = new()
            {
                Text      = "Light",
                Font      = new Font(Theme.universalFont, 12),
                Dock      = DockStyle.Right,
                BackColor = Theme.lightThemeBG,
                ForeColor = Theme.lightThemeFG,
                FlatStyle = FlatStyle.Flat,
                Margin    = new Padding(0, 10, 0, 0),
                Cursor    = Cursors.Hand
                
            };

            if(shopItems.ownsDarkRoseTheme)
            {
                themeDarkRoseBtn.Text      = "Dark Rose";
                themeDarkRoseBtn.Font      = new Font(Theme.universalFont, 12);
                themeDarkRoseBtn.Dock      = DockStyle.Right;
                themeDarkRoseBtn.BackColor = Theme.darkRoseThemeBG;
                themeDarkRoseBtn.ForeColor = Theme.darkRoseThemeFG;
                themeDarkRoseBtn.FlatStyle = FlatStyle.Flat;
                themeDarkRoseBtn.Margin    = new Padding(0, 10, 0, 0);
                themeDarkRoseBtn.Cursor    = Cursors.Hand;
                themeDarkRoseBtn.MouseEnter += Form1.darkRoseMouseEnter;
                themeDarkRoseBtn.MouseLeave += Form1.darkRoseMouseLeave;
                themeDarkRoseBtn.Click += (s, e) =>
                {
                    ApplicationData write = new ApplicationData()
                    {
                        LoggedBefore = data.LoggedBefore,
                        DarkOrLight = "darkrose"
                    };

                    OverwriteData(write);
                    // TODO
                };
            }
            if(shopItems.ownsBlackAndGreenTheme)
            {
                themeBlackAndGreenBtn.Text      = "Black And Green";
                themeBlackAndGreenBtn.Font      = new Font(Theme.universalFont, 12);
                themeBlackAndGreenBtn.Dock      = DockStyle.Right;
                themeBlackAndGreenBtn.BackColor = Theme.blackAndGreenThemeBG;
                themeBlackAndGreenBtn.ForeColor = Theme.blackAndGreenThemeFG;
                themeBlackAndGreenBtn.FlatStyle = FlatStyle.Flat;
                themeBlackAndGreenBtn.Margin    = new Padding(0, 10, 0, 0);
                themeBlackAndGreenBtn.Cursor    = Cursors.Hand;
                themeBlackAndGreenBtn.MouseEnter += Form1.blackAndGreenMouseEnter;
                themeBlackAndGreenBtn.MouseLeave += Form1.blackAndGreenMouseLeave;

            }

            if(shopItems.ownsBlackAndGoldTheme)
            {
                themeBlackAndGoldBtn.Text      = "Black And Gold";
                themeBlackAndGoldBtn.Font      = new Font(Theme.universalFont, 12);
                themeBlackAndGoldBtn.Dock      = DockStyle.Right;
                themeBlackAndGoldBtn.BackColor = Theme.blackAndGoldThemeBG;
                themeBlackAndGoldBtn.ForeColor = Theme.blackAndGoldThemeFG;
                themeBlackAndGoldBtn.FlatStyle = FlatStyle.Flat;
                themeBlackAndGoldBtn.Margin    = new Padding(0, 10, 0, 0);
                themeBlackAndGoldBtn.Cursor    = Cursors.Hand;
                themeBlackAndGoldBtn.MouseEnter += Form1.blackAndGoldMouseEnter;
                themeBlackAndGoldBtn.MouseLeave += Form1.blackAndGoldMouseLeave;

            }

            themeDarkBtn.FlatAppearance.BorderSize           = themeLightBtn.FlatAppearance.BorderSize = themeDarkRoseBtn.FlatAppearance.BorderSize = themeBlackAndGreenBtn.FlatAppearance.BorderSize = themeBlackAndGoldBtn.FlatAppearance.BorderSize = 1;
            themeDarkBtn.FlatAppearance.BorderColor          = Theme.darkThemeBorderColor;
            themeLightBtn.FlatAppearance.BorderColor         = Theme.lightThemeBorderColor;
            themeDarkRoseBtn.FlatAppearance.BorderColor      = Theme.darkRoseThemeBorderColor;
            themeBlackAndGreenBtn.FlatAppearance.BorderColor = Theme.blackAndGreenThemeBorderColor;
            themeBlackAndGoldBtn.FlatAppearance.BorderColor  = Theme.blackAndGoldThemeBorderColor;

            themeDarkBtn.MouseEnter += Form1.darkMouseEnter;
            themeLightBtn.MouseEnter += Form1.lightMouseEnter;

            themeDarkBtn.MouseLeave += Form1.darkMouseLeave;
            themeLightBtn.MouseLeave += Form1.lightMouseLeave;
            
            


            if(dark)
            {
                settingsForm.BackColor = themePanel.BackColor = fonts.BackColor = profileTitles.BackColor = changeUsername.BackColor = Theme.darkThemeBG;
                themeInform.BackColor = Theme.darkThemeBG;
                themeInform.ForeColor = Theme.darkThemeFG;
            } else
            {
                settingsForm.BackColor = themePanel.BackColor = fonts.BackColor = profileTitles.BackColor = changeUsername.BackColor = Theme.lightThemeBG;
                themeInform.BackColor = Theme.lightThemeBG;
                themeInform.ForeColor = Theme.lightThemeFG;
            }

            themePanel.Controls.Add(themeInform);
            if(themeBlackAndGoldBtn.Text != "")
            {
                // When this case is triggered, it means the themeBlackAndGoldBtn button widget has been modified, which also means that
                // ShopItems.ownsBlackAndGoldTheme is true.
                themePanel.Controls.Add(Gap());
                themePanel.Controls.Add(themeBlackAndGoldBtn);
            }
            if(themeBlackAndGreenBtn.Text != "")
            {
                themePanel.Controls.Add(Gap());
                themePanel.Controls.Add(themeBlackAndGreenBtn);
            }
            if(themeDarkRoseBtn.Text != "")
            {
                themePanel.Controls.Add(Gap());
                themePanel.Controls.Add(themeDarkRoseBtn);
            }
            themePanel.Controls.Add(Gap());
            themePanel.Controls.Add(themeLightBtn);
            themePanel.Controls.Add(Gap());
            themePanel.Controls.Add(themeDarkBtn);








            settingsForm.Controls.Add(themePanel);

        }
        public static void MainContentTaskOverView(object s, EventArgs e, string task, string pts, string description, Label currentTask, Label PTSAmount)
        {
            Form TaskInfo = new()
            {
                Width = 800,
                Height = 500,
                StartPosition = FormStartPosition.CenterScreen,
                Text = task + ": More Details"
            };
            FlowLayoutPanel panel = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                WrapContents = false
            };

            TaskInfo.Show();
            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            Label thePoints = new()
            {
                Text = "Reward after completion: " + pts + " points",
                AutoSize = true,
                Font = new Font(Theme.universalFont, 15)
            };

            Label givenDescriptionInform = new()
            {
                Text = "Description:",
                AutoSize = true,
                Font = new Font(Theme.universalFont, 15)
            };

            Label givenDescription = new()
            {
                Text = description,
                Width = 750,
                Height = 50,
                Font = new Font(Theme.universalFont, 11),
                Location = new Point(0, 50)
            };

            Button completionButton = new()
            {
                Text = "Complete",
                Width = 750,
                Height = 50,
                Font = new Font(Theme.universalFont, 14),
                Cursor = Cursors.Hand
            };


            if(data.DarkOrLight == "dark")
            {
                thePoints.BackColor = TaskInfo.BackColor = givenDescriptionInform.BackColor = givenDescription.BackColor = Theme.darkThemeBG;
                thePoints.ForeColor = TaskInfo.ForeColor = givenDescriptionInform.ForeColor = givenDescription.ForeColor = Theme.darkThemeFG;
                completionButton.BackColor = Color.DarkGreen;
                completionButton.ForeColor = Color.White;
                completionButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#00c753");

                completionButton.MouseEnter += Form1.darkMouseEnter;
                completionButton.MouseLeave += (s, e) =>
                {
                    completionButton.BackColor = Color.DarkGreen;
                    completionButton.ForeColor = Color.White;
                    completionButton.FlatStyle = FlatStyle.Flat;
                    completionButton.FlatAppearance.BorderSize = 2;
                };
            } else
            {
                thePoints.BackColor = TaskInfo.BackColor = givenDescriptionInform.BackColor = givenDescription.BackColor = Theme.lightThemeBG;
                thePoints.ForeColor = TaskInfo.ForeColor = givenDescriptionInform.ForeColor = givenDescription.ForeColor = Theme.lightThemeFG;
                completionButton.BackColor = Color.Green;
                completionButton.ForeColor = Color.Black;
                completionButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#00c753");

                completionButton.MouseEnter += Form1.lightMouseEnter;
                completionButton.MouseLeave += (s, e) =>
                {
                    completionButton.BackColor = Color.Green;
                    completionButton.ForeColor = Color.White;
                    completionButton.FlatStyle = FlatStyle.Flat;
                    
                    completionButton.FlatAppearance.BorderSize = 2;
                };
            }

           
            completionButton.Click += (s, e) =>
            {
                // The completion algorithm
                //? Stage 1: stealing all the data in the world cause im evil
                UserStats userStatistics = LoadUserStats();
                

                // TODO
                /*
                ! DIFFICULTY: EXTREMELY HARD
                ? THINGS TO DO:
                ? - Add +{points} to user_stats.json/pts (as a reward for completing the task)
                */
                TaskInfo.Close();

                int reward = int.Parse(PTSAmount.Text);                         //* Reward the user gets in integer value


                string[] lines_task = File.ReadAllLines("ApplicationData/tasks.txt");
                string[] lines_points = File.ReadAllLines("ApplicationData/pts.txt");
                string[] lines_desc = File.ReadAllLines("ApplicationData/desc.txt");

                int lineCounter_Giver = 0;
                int lineCounter_Receiver = 0;

                List<string> filteredTasks = new();
                List<string> filteredPTS = new();
                List<string> filteredDesc = new();
                foreach(string line in lines_task)
                {
                    if(line.Trim() != currentTask.Text)
                    {
                        filteredTasks.Add(line);
                        lineCounter_Giver++;
                    } else
                    {
                        // if the line we dont want in our text file is found, then carve its value into the variable `lineCounter_Receiver`
                        lineCounter_Receiver = lineCounter_Giver;
                        // Also, since you can't implement 2 tasks with the same name (e.g. task 1: taking out the trash, task 2: taking out the trash),
                        // this case will only be hit ONCE.
                        // Getting the line of the filtered task is important because we also need to remove the displayed point value that task gave,
                        // and the tasks given displayed point value is located on the same line on pts.txt as the task we filtered in tasks.txt.
                        // e.g. if `Take out the trash` is on the 4th line inside tasks.txt, then the amount of points you'll get for completing that task
                        // is also located on the 4th line inside pts.txt
                    }
                }

                int lineCounter_PTS = 0;

                foreach(string line in lines_points)
                {
                    if(lineCounter_PTS != lineCounter_Receiver)
                    {
                        filteredPTS.Add(line);
                    }
                    lineCounter_PTS++;
                }

                int lineCounter_Desc = 0;
                foreach(string line in lines_desc)
                {
                    if(lineCounter_Desc != lineCounter_Receiver)
                    {
                        filteredDesc.Add(line);
                    }
                    lineCounter_Desc++;
                }

                File.WriteAllLines("ApplicationData/tasks.txt", filteredTasks);
                File.WriteAllLines("ApplicationData/pts.txt", filteredPTS);
                File.WriteAllLines("ApplicationData/desc.txt", filteredDesc);

                Form1? mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

                if(mainForm != null)
                {
                    mainForm.LoadTasks();
                }

                UserStats UserStatisticsOverwriteData = new UserStats
                {
                    currency_points = userStatistics.currency_points + reward,
                    total_tasks_completed = userStatistics.total_tasks_completed + 1
                };

                OverwriteUserStats(UserStatisticsOverwriteData);



            };
            panel.Controls.Add(thePoints);
            panel.Controls.Add(givenDescriptionInform);
            panel.Controls.Add(givenDescription);
            panel.Controls.Add(completionButton);

            TaskInfo.Controls.Add(panel);
            
        }
    }
}