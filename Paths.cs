namespace AdvancedTodo;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.Json;

public static class Paths
{
    public static readonly string pathToDataJSON = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/data.json");
    public static readonly string pathToBadgesJSON = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/badges.json");
    public static readonly string pathToDescTXT = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/desc.txt");
    public static readonly string pathToPtsTXT = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/pts.txt");
    public static readonly string pathToShopItemsJSON = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/shop_items.json");
    public static readonly string pathToTasksTXT = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/tasks.txt");
    public static readonly string pathToUserDataJSON = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/user_data.json");
    public static readonly string pathToUserStatsJSON = Path.Combine(AppContext.BaseDirectory, @"ApplicationData/user_stats.json");

    //* Assets

    public static readonly string pathToBadgeBeginnerTaskerPNG = Path.Combine(AppContext.BaseDirectory, @"assets/badge_beginnerTasker.png");
    public static readonly string pathToLowerUpperClassPNG = Path.Combine(AppContext.BaseDirectory, @"assets/lower_upper_class.png");
    public static readonly string pathToMiddleLowerClassPNG = Path.Combine(AppContext.BaseDirectory, @"assets/middle_lower_class.png");
    public static readonly string pathToUpperClassPNG = Path.Combine(AppContext.BaseDirectory, @"assets/upper_class.png");
}