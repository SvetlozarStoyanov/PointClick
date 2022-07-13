using PointClick.CustomElements.Buttons;

namespace PointClick
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_time = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.label_highscore = new System.Windows.Forms.Label();
            this.timer_game = new System.Windows.Forms.Timer(this.components);
            this.timer_target = new System.Windows.Forms.Timer(this.components);
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_target = new PointClick.CustomElements.Buttons.ButtonCircle();
            this.btn_background = new PointClick.CustomElements.Buttons.ButtonBackground();
            this.btn_sound = new System.Windows.Forms.Button();
            this.btn_difficulty = new System.Windows.Forms.Button();
            this.btn_time_limit = new System.Windows.Forms.Button();
            this.label_live_count = new System.Windows.Forms.Label();
            this.btn_reset_highscore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(93, 33);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(61, 15);
            this.label_time.TabIndex = 0;
            this.label_time.Tag = "label_time";
            this.label_time.Text = "label_time";
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Location = new System.Drawing.Point(446, 33);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(65, 15);
            this.label_score.TabIndex = 1;
            this.label_score.Tag = "label_score";
            this.label_score.Text = "label_score";
            // 
            // label_highscore
            // 
            this.label_highscore.AutoSize = true;
            this.label_highscore.Location = new System.Drawing.Point(647, 33);
            this.label_highscore.Name = "label_highscore";
            this.label_highscore.Size = new System.Drawing.Size(89, 15);
            this.label_highscore.TabIndex = 2;
            this.label_highscore.Tag = "label_highscore";
            this.label_highscore.Text = "label_highscore";
            // 
            // timer_game
            // 
            this.timer_game.Enabled = true;
            this.timer_game.Tag = "timer_game";
            this.timer_game.Tick += new System.EventHandler(this.timer_game_Tick);
            // 
            // timer_target
            // 
            this.timer_target.Enabled = true;
            this.timer_target.Tag = "timer_target";
            this.timer_target.Tick += new System.EventHandler(this.timer_target_Tick);
            // 
            // btn_start
            // 
            this.btn_start.AutoSize = true;
            this.btn_start.Location = new System.Drawing.Point(30, 415);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 25);
            this.btn_start.TabIndex = 3;
            this.btn_start.Tag = "btn_start";
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.AutoSize = true;
            this.btn_stop.Location = new System.Drawing.Point(121, 415);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 25);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Tag = "btn_stop";
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_target
            // 
            this.btn_target.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_target.FlatAppearance.BorderSize = 0;
            this.btn_target.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_target.ForeColor = System.Drawing.Color.Red;
            this.btn_target.Image = ((System.Drawing.Image)(resources.GetObject("btn_target.Image")));
            this.btn_target.Location = new System.Drawing.Point(295, 162);
            this.btn_target.Name = "btn_target";
            this.btn_target.Size = new System.Drawing.Size(150, 150);
            this.btn_target.TabIndex = 5;
            this.btn_target.TabStop = false;
            this.btn_target.Tag = "btn_target";
            this.btn_target.UseVisualStyleBackColor = true;
            this.btn_target.Click += new System.EventHandler(this.btn_target_Click);
            // 
            // btn_background
            // 
            this.btn_background.AutoSize = true;
            this.btn_background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_background.BackgroundImage")));
            this.btn_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_background.FlatAppearance.BorderSize = 0;
            this.btn_background.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_background.Location = new System.Drawing.Point(12, 65);
            this.btn_background.Name = "btn_background";
            this.btn_background.Size = new System.Drawing.Size(776, 344);
            this.btn_background.TabIndex = 6;
            this.btn_background.TabStop = false;
            this.btn_background.Tag = "btn_background";
            this.btn_background.UseVisualStyleBackColor = true;
            this.btn_background.Click += new System.EventHandler(this.btn_background_Click);
            // 
            // btn_sound
            // 
            this.btn_sound.AutoSize = true;
            this.btn_sound.Location = new System.Drawing.Point(386, 415);
            this.btn_sound.Name = "btn_sound";
            this.btn_sound.Size = new System.Drawing.Size(75, 25);
            this.btn_sound.TabIndex = 7;
            this.btn_sound.Tag = "btn_sound";
            this.btn_sound.Text = "Sound";
            this.btn_sound.UseVisualStyleBackColor = true;
            this.btn_sound.Click += new System.EventHandler(this.btn_sound_Click);
            // 
            // btn_difficulty
            // 
            this.btn_difficulty.AutoSize = true;
            this.btn_difficulty.Location = new System.Drawing.Point(226, 415);
            this.btn_difficulty.Name = "btn_difficulty";
            this.btn_difficulty.Size = new System.Drawing.Size(124, 25);
            this.btn_difficulty.TabIndex = 8;
            this.btn_difficulty.Tag = "btn_difficulty";
            this.btn_difficulty.Text = "Difficulty: ";
            this.btn_difficulty.UseVisualStyleBackColor = true;
            this.btn_difficulty.Click += new System.EventHandler(this.btn_difficulty_Click);
            // 
            // btn_time_limit
            // 
            this.btn_time_limit.AutoSize = true;
            this.btn_time_limit.Location = new System.Drawing.Point(500, 415);
            this.btn_time_limit.Name = "btn_time_limit";
            this.btn_time_limit.Size = new System.Drawing.Size(126, 25);
            this.btn_time_limit.TabIndex = 9;
            this.btn_time_limit.Tag = "btn_time_limit";
            this.btn_time_limit.Text = "Time Limit";
            this.btn_time_limit.UseVisualStyleBackColor = true;
            this.btn_time_limit.Click += new System.EventHandler(this.btn_time_limit_Click);
            // 
            // label_live_count
            // 
            this.label_live_count.AutoSize = true;
            this.label_live_count.Location = new System.Drawing.Point(266, 33);
            this.label_live_count.Name = "label_live_count";
            this.label_live_count.Size = new System.Drawing.Size(70, 15);
            this.label_live_count.TabIndex = 10;
            this.label_live_count.Tag = "label_live_count";
            this.label_live_count.Text = "label misses";
            // 
            // btn_reset_highscore
            // 
            this.btn_reset_highscore.AutoSize = true;
            this.btn_reset_highscore.Location = new System.Drawing.Point(660, 415);
            this.btn_reset_highscore.Name = "btn_reset_highscore";
            this.btn_reset_highscore.Size = new System.Drawing.Size(113, 25);
            this.btn_reset_highscore.TabIndex = 11;
            this.btn_reset_highscore.Tag = "btn_reset_highscore";
            this.btn_reset_highscore.Text = "Reset Highscore";
            this.btn_reset_highscore.UseVisualStyleBackColor = true;
            this.btn_reset_highscore.Click += new System.EventHandler(this.btn_reset_highscore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_reset_highscore);
            this.Controls.Add(this.label_live_count);
            this.Controls.Add(this.btn_time_limit);
            this.Controls.Add(this.btn_difficulty);
            this.Controls.Add(this.btn_sound);
            this.Controls.Add(this.btn_target);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label_highscore);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.btn_background);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "PointClick";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_time;
        private Label label_score;
        private Label label_highscore;
        private System.Windows.Forms.Timer timer_game;
        private System.Windows.Forms.Timer timer_target;
        private Button btn_start;
        private Button btn_stop;
        private ButtonCircle btn_target;
        private ButtonBackground btn_background;
        private Button btn_sound;
        private Button btn_difficulty;
        private Button btn_time_limit;
        private Label label_live_count;
        private Button btn_reset_highscore;
    }
}