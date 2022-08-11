namespace WSN_Simulation_attempt_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.area = new System.Windows.Forms.PictureBox();
            this.spawn = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.sybilSpawn = new System.Windows.Forms.Button();
            this.sybilConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.area)).BeginInit();
            this.SuspendLayout();
            // 
            // area
            // 
            this.area.BackColor = System.Drawing.Color.Transparent;
            this.area.Location = new System.Drawing.Point(0, 0);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(782, 612);
            this.area.TabIndex = 0;
            this.area.TabStop = false;
            // 
            // spawn
            // 
            this.spawn.Location = new System.Drawing.Point(12, 618);
            this.spawn.Name = "spawn";
            this.spawn.Size = new System.Drawing.Size(140, 50);
            this.spawn.TabIndex = 1;
            this.spawn.Text = "Spawn Nodes";
            this.spawn.UseVisualStyleBackColor = true;
            this.spawn.Click += new System.EventHandler(this.spawn_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(12, 674);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(140, 50);
            this.connect.TabIndex = 2;
            this.connect.Text = "Connect Nodes";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // sybilSpawn
            // 
            this.sybilSpawn.Location = new System.Drawing.Point(158, 618);
            this.sybilSpawn.Name = "sybilSpawn";
            this.sybilSpawn.Size = new System.Drawing.Size(140, 50);
            this.sybilSpawn.TabIndex = 3;
            this.sybilSpawn.Text = "Spawn Sybil Node";
            this.sybilSpawn.UseVisualStyleBackColor = true;
            this.sybilSpawn.Click += new System.EventHandler(this.sybilSpawn_Click);
            // 
            // sybilConnect
            // 
            this.sybilConnect.Location = new System.Drawing.Point(158, 674);
            this.sybilConnect.Name = "sybilConnect";
            this.sybilConnect.Size = new System.Drawing.Size(140, 50);
            this.sybilConnect.TabIndex = 4;
            this.sybilConnect.Text = "Connect Sybil Node";
            this.sybilConnect.UseVisualStyleBackColor = true;
            this.sybilConnect.Click += new System.EventHandler(this.sybilConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 733);
            this.Controls.Add(this.sybilConnect);
            this.Controls.Add(this.sybilSpawn);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.spawn);
            this.Controls.Add(this.area);
            this.Name = "Form1";
            this.Text = "Wireless Sensor Network";
            ((System.ComponentModel.ISupportInitialize) (this.area)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox area;
        private System.Windows.Forms.Button spawn;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button sybilSpawn;
        private System.Windows.Forms.Button sybilConnect;

        #endregion
    }
}