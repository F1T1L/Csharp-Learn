namespace REST_API_client
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //ебать не лагает!
        //this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
        // this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };
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
            this.cmdGO = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGO
            // 
            this.cmdGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGO.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.cmdGO.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cmdGO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SpringGreen;
            this.cmdGO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.cmdGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGO.Font = new System.Drawing.Font("Arial", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.cmdGO.Location = new System.Drawing.Point(595, 21);
            this.cmdGO.Name = "cmdGO";
            this.cmdGO.Size = new System.Drawing.Size(110, 34);
            this.cmdGO.TabIndex = 1;
            this.cmdGO.Text = "GO!";
            this.cmdGO.UseVisualStyleBackColor = false;
            this.cmdGO.Click += new System.EventHandler(this.cmdGO_Click);
            // 
            // txtURL
            // 
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.HideSelection = false;
            this.txtURL.Location = new System.Drawing.Point(192, 21);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(404, 34);
            this.txtURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(-1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "REST API URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtResponse);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Location = new System.Drawing.Point(-1, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(706, 302);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Response:";
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(0, 27);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(0);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(706, 275);
            this.txtResponse.TabIndex = 2;
            this.txtResponse.Text = "";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.cmdGO;
            this.AccessibleDescription = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 353);
            this.Controls.Add(this.cmdGO);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(725, 400);
            this.Name = "MainWindow";
            this.Text = "GrabMyJson";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.MySuspendLayout);
            this.ResizeEnd += new System.EventHandler(this.MyResizeEnd);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdGO;
        private TextBox txtURL;
        private Label label1;
        private GroupBox groupBox1;
        public RichTextBox txtResponse;
    }
}