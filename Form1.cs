using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Media;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;
using PointClick.CustomElements.Buttons;

namespace PointClick
{
    public partial class Form1 : Form
    {
        private SoundPlayer targetHitSound;
        private SoundPlayer backgroundClickSound;
        private Stopwatch watch = new Stopwatch();
        private Random rng = new Random();
        private int targetTimerInterval;
        private int gameTimerInterval = 100;
        private int totalTimeInSeconds;
        private int score;
        private int highscore;
        private int previousHighscore;
        private int lives;
        private int maxLives;
        private bool soundToggle;
        private string[] difficultyArray = new string[] { "Easy", "Normal", "Hard", "Very Hard" };
        private string currDiff;
        private int currDiffIndex;
        private bool highScoreHasBeenImproved;

        private Rectangle btn_start_OriginalRectangle;
        private Rectangle btn_stop_OriginalRectangle;
        private Rectangle btn_difficulty_OriginalRectangle;
        private Rectangle btn_reset_highscore_OriginalRectangle;
        private Rectangle btn_target_OriginalRectangle;
        private Rectangle btn_background_OriginalRectangle;
        private Rectangle btn_time_limit_OriginalRectangle;
        private Rectangle btn_sound_OriginalRectangle;
        private Rectangle label_time_OriginalRectangle;
        private Rectangle label_score_OriginalRectangle;
        private Rectangle label_highscore_OriginalRectangle;
        private Rectangle label_live_count_OriginalRectangle;
        private Rectangle originalFormSize;

        public Form1()
        {
            InitializeComponent();
            //MaximizeBox = false;
            label_score.Text = $"Score";
            totalTimeInSeconds = 60;
            btn_time_limit.Text = $"Time Limit: {totalTimeInSeconds}";
            TimeSpan span = new TimeSpan(0, 0, totalTimeInSeconds);
            label_time.Text = span.ToString("mm\\:ss\\:ff");
            StopTimers();
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            btn_target.Hide();
            btn_stop.Enabled = false;

            ActiveControl = null;
            SetupSounds();
            btn_background.Enabled = false;
            btn_sound.Text = "Sound: On";
            currDiffIndex = 1;
            Set_ParametersAccordingToDifficulty(difficultyArray[currDiffIndex]);
            SetupHighScore();
            label_live_count.Text = $"Lives: {lives}";
        }
        private void timer_game_Tick(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan(0, 0, totalTimeInSeconds);
            TimeSpan calculatedTime = span - watch.Elapsed;
            if (calculatedTime.TotalSeconds <= 0)
            {
                btn_stop_Click(sender, e);
                label_time.Text = "00:00:00";
                return;
            }
            label_time.Text = calculatedTime.ToString("mm\\:ss\\:ff");
        }
        private void timer_target_Tick(object sender, EventArgs e)
        {
            target_Move();
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            watch.Start();
            timer_game.Enabled = true;
            timer_game.Start();
            timer_target.Enabled = true;
            timer_target.Start();
            btn_target.Enabled = true;
            target_Move();
            //btn_target.Show();
            btn_background.Enabled = true;
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            btn_stop.TabStop = false;
            btn_sound.TabStop = false;
            btn_difficulty.Enabled = false;
            btn_time_limit.Enabled = false;
            btn_reset_highscore.Enabled = false;
            label_score.Text = $"Score: {score}";
            previousHighscore = highscore;
            //label_highscore.Text = "Highscore";

            //btn_background.TabStop=false;
            //btn_background.Show();
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            watch.Stop();
            StopTimers();
            btn_target.Enabled = false;
            btn_target.Hide();
            watch.Reset();
            label_time.Text = "00:00:00";
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            btn_background.Enabled = false;
            btn_difficulty.Enabled = true;
            btn_time_limit.Enabled = true;
            btn_reset_highscore.Enabled = true;
            lives = maxLives;
            label_live_count.Text = $"Lives: {lives}";
            //UpdateHighScore(score);
            if (highScoreHasBeenImproved)
            {
                if (score == 1 && highscore - previousHighscore == 1)
                    MessageBox.Show($"Game over! Your score is {score} point! You have improved the highscore by {highscore - previousHighscore} point!");
                else if (score > 1)
                    MessageBox.Show($"Game over! Your score is {score} points! You have improved the highscore by {highscore - previousHighscore} point!");
                else
                    MessageBox.Show($"Game over! Your score is {score} points. You have improved the highscore by {highscore - previousHighscore} points!");
            }
            else
            {
                if (score == 1)
                    MessageBox.Show($"Game over! Your score is {score} point!");
                else
                    MessageBox.Show($"Game over! Your score is {score} points!");
            }

            score = 0;
            //label_score.Text = "Score";

        }


        

        private void btn_target_Click(object sender, EventArgs e)
        {
            if (soundToggle)
                targetHitSound.Play();
            btn_target.Hide();
            score++;
            label_score.Text = $"Score: {score}";
            if (score > highscore)
            {
                highscore = score;
                UpdateHighScore(score);
                highScoreHasBeenImproved = true;
            }
        }

        private void btn_background_Click(object sender, EventArgs e)
        {
            if (soundToggle)
                backgroundClickSound.Play();
            lives--;
            label_live_count.Text = $"Lives: {lives}";
            if (lives == 0)
            {
                btn_stop_Click(sender, e);
                //btn_background.Enabled = false;
                //btn_background.TabStop = false;
                //UpdateHighScore(score);
                //Environment.Exit(0);
            }

        }

        private void btn_sound_Click(object sender, EventArgs e)
        {
            if (soundToggle)
            {
                soundToggle = false;
                btn_sound.Text = "Sound: Off";
            }
            else
            {
                soundToggle = true;
                btn_sound.Text = "Sound: On";
            }
        }

        private void btn_difficulty_Click(object sender, EventArgs e)
        {
            if (currDiffIndex < 3)
                currDiffIndex++;
            else
                currDiffIndex = 0;
            Set_ParametersAccordingToDifficulty(difficultyArray[currDiffIndex]);
        }

        private void btn_time_limit_Click(object sender, EventArgs e)
        {
            string time = Interaction.InputBox("Set Time Limit in Seconds (Range[30-3600])", "Time Limit", $"{totalTimeInSeconds}", -1, -1);
            int tempTime = totalTimeInSeconds;
            while (time != "" && (!int.TryParse(time, out int number) || !(number >= 30 && number <= 3600)))
            {
                MessageBox.Show("Input an integer in range [30-3600]!");
                time = Interaction.InputBox("Set Time Limit in Seconds (Range[30-3600])", "Time Limit", $"{totalTimeInSeconds}", -1, -1);
            }
            if (time == "")
                time = $"{totalTimeInSeconds}";
            totalTimeInSeconds = int.Parse(time);
            btn_time_limit.Text = $"Time limit: {totalTimeInSeconds}";
            TimeSpan span = new TimeSpan(0, 0, totalTimeInSeconds);

            label_time.Text = span.ToString("mm\\:ss\\:ff");
            btn_time_limit.TabStop = false;
        }

        private void btn_reset_highscore_Click(object sender, EventArgs e)
        {
            UpdateHighScore(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            btn_start_OriginalRectangle = new Rectangle(btn_start.Location.X, btn_start.Location.Y, btn_start.Width, btn_start.Height);
            btn_stop_OriginalRectangle = new Rectangle(btn_stop.Location.X, btn_stop.Location.Y, btn_stop.Width, btn_stop.Height);
            btn_sound_OriginalRectangle = new Rectangle(btn_sound.Location.X, btn_sound.Location.Y, btn_sound.Width, btn_sound.Height);
            btn_difficulty_OriginalRectangle = new Rectangle(btn_difficulty.Location.X, btn_difficulty.Location.Y, btn_difficulty.Width, btn_difficulty.Height);
            btn_target_OriginalRectangle = new Rectangle(btn_target.Location.X, btn_target.Location.Y, btn_target.Width, btn_target.Height);
            btn_background_OriginalRectangle = new Rectangle(btn_background.Location.X, btn_background.Location.Y, btn_background.Width, btn_background.Height);
            btn_reset_highscore_OriginalRectangle = new Rectangle(btn_reset_highscore.Location.X, btn_reset_highscore.Location.Y, btn_reset_highscore.Width, btn_reset_highscore.Height);
            btn_time_limit_OriginalRectangle = new Rectangle(btn_time_limit.Location.X, btn_time_limit.Location.Y, btn_time_limit.Width, btn_time_limit.Height);
            label_time_OriginalRectangle = new Rectangle(label_time.Location.X, label_time.Location.Y, label_time.Width, label_time.Height);
            label_score_OriginalRectangle = new Rectangle(label_score.Location.X, label_score.Location.Y, label_score.Width, label_score.Height);
            label_highscore_OriginalRectangle = new Rectangle(label_highscore.Location.X, label_highscore.Location.Y, label_highscore.Width, label_highscore.Height);
            label_live_count_OriginalRectangle = new Rectangle(label_live_count.Location.X, label_live_count.Location.Y, label_live_count.Width, label_live_count.Height);
        }
        private void ResizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);
            //int newX = (int)(r.Width * xRatio);
            //int newY = (int)(r.Height * yRatio);
            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeControl(btn_background_OriginalRectangle, btn_background);
            ResizeControl(btn_start_OriginalRectangle, btn_start);
            ResizeControl(btn_stop_OriginalRectangle, btn_stop);
            ResizeControl(btn_sound_OriginalRectangle, btn_sound);
            ResizeControl(btn_difficulty_OriginalRectangle, btn_difficulty);
            ResizeControl(btn_target_OriginalRectangle, btn_target);
            ResizeControl(btn_reset_highscore_OriginalRectangle, btn_reset_highscore);
            ResizeControl(btn_time_limit_OriginalRectangle, btn_time_limit);
            ResizeControl(btn_start_OriginalRectangle, btn_start);
            ResizeControl(label_time_OriginalRectangle, label_time);
            ResizeControl(label_score_OriginalRectangle, label_score);
            ResizeControl(label_highscore_OriginalRectangle, label_highscore);
            ResizeControl(label_live_count_OriginalRectangle, label_live_count);
            Set_ParametersAccordingToDifficulty(currDiff);
        }
        private void target_Move()
        {
            int targetButtonTempTop = 0;
            int targetButtonTempLeft = 0;
            do
            {
                targetButtonTempTop = rng.Next(btn_background.Top + btn_target.Height, btn_background.Bottom - btn_target.Height);
                //targetButtonTempTop = rng.Next(label_time.Top + 25, btn_stop.Top - 80);
                targetButtonTempLeft = rng.Next(btn_background.Left + btn_target.Width, btn_background.Right - btn_target.Width);
                //targetButtonTempLeft = rng.Next(30, this.Width - 160);
            } while (targetButtonTempTop >= btn_background.Top + btn_target.Height && targetButtonTempTop >= btn_background.Bottom - btn_target.Height);
            btn_target.Top = targetButtonTempTop;
            btn_target.Left = targetButtonTempLeft;
            btn_target.Enabled = true;
            btn_target.Show();
        }
        private void Set_ParametersAccordingToDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "Easy":
                    btn_target.SetSize(btn_background.Width / 10);
                    targetTimerInterval = 2000;
                    maxLives = 8;
                    break;
                case "Normal":
                    btn_target.SetSize(btn_background.Width / 15);
                    targetTimerInterval = 1500;
                    maxLives = 5;
                    break;
                case "Hard":
                    btn_target.SetSize(btn_background.Width / 18);
                    targetTimerInterval = 1250;
                    maxLives = 4;
                    break;
                case "Very Hard":
                    btn_target.SetSize(btn_background.Width / 20);
                    targetTimerInterval = 1000;
                    maxLives = 3;
                    break;
                default:
                    break;
            }
            SetupTimers();
            currDiff = difficulty;
            lives = maxLives;
            label_live_count.Text = $"Lives: {lives}";
            btn_difficulty.Text = $"Difficulty: {difficultyArray[currDiffIndex]}";
        }
        private void SetupTimers()
        {
            timer_game.Interval = gameTimerInterval;
            timer_target.Interval = targetTimerInterval;
        }
        private void SetupHighScore()
        {
            string[] highscoreAsArray = File.ReadAllLines("../../../Highscore/Highscore.txt");
            highscore = int.Parse(highscoreAsArray[0]);
            label_highscore.Text = $"Highscore: {highscore}";
        }
        private void SetupSounds()
        {
            targetHitSound = new SoundPlayer("../../../Sounds/Pop sound.wav");
            backgroundClickSound = new SoundPlayer("../../../Sounds/Miss sound.wav");
            soundToggle = true;
        }
        private void StopTimers()
        {
            timer_game.Stop();
            timer_target.Stop();
        }
        private void UpdateHighScore(int currentScore)
        {
            File.WriteAllText("../../../Highscore/Highscore.txt", currentScore.ToString());
            highscore = currentScore;
            label_highscore.Text = $"Highscore: {currentScore}";
        }
    }
}