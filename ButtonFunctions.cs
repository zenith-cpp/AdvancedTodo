namespace AdvancedTodo
{
    public static class BtnFunc // `static` so it can be used in other files. this is a util file after all
    {
        public static void AddTaskFunction(object s, EventArgs e)
        {
            Form at = new()
            {
                Text = "AdvancedTodo - Add Task",
                Width = 800,
                Height = 500,
                StartPosition = FormStartPosition.CenterScreen
            };

            ApplicationData data = QuestionForm.LoadData(QuestionForm.dataJSONpath);
            at.Show();
            Label instruction1 = new()
            {
                Text = "Fill out the form.",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font("Consolas", 14),
            };

            // TODO: the form


            // apply theme
            if(data.DarkOrLight == "dark")
            {
                at.BackColor = Color.Black;
                at.ForeColor = Color.White;
            } else
            {
                at.BackColor = Color.White;
                at.ForeColor = Color.Black;
            }
            at.Controls.Add(instruction1);
        }
    }
}