namespace Download_Manager
{
    public partial class DownloadManagerForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadManagerForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadButton = new System.Windows.Forms.Button();
            this.percentLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.categoriesPanel = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.programsPanel = new System.Windows.Forms.Panel();
            this.selectedPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDropDownButton,
            this.helpButton,
            this.aboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(196, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileDropDownButton
            // 
            this.fileDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateMenuItem,
            this.exitMenuItem});
            this.fileDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("fileDropDownButton.Image")));
            this.fileDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDropDownButton.Name = "fileDropDownButton";
            this.fileDropDownButton.Size = new System.Drawing.Size(46, 24);
            this.fileDropDownButton.Text = "File";
            // 
            // updateMenuItem
            // 
            this.updateMenuItem.Name = "updateMenuItem";
            this.updateMenuItem.Size = new System.Drawing.Size(181, 26);
            this.updateMenuItem.Text = "Update";
            this.updateMenuItem.Click += new System.EventHandler(this.updateMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(45, 24);
            this.helpButton.Text = "Help";
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(54, 24);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgressBar.Location = new System.Drawing.Point(51, 398);
            this.downloadProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(700, 23);
            this.downloadProgressBar.Step = 1;
            this.downloadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.downloadProgressBar.TabIndex = 2;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Enabled = false;
            this.downloadButton.Location = new System.Drawing.Point(759, 395);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(91, 28);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // percentLabel
            // 
            this.percentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.percentLabel.AutoSize = true;
            this.percentLabel.Location = new System.Drawing.Point(7, 401);
            this.percentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(28, 17);
            this.percentLabel.TabIndex = 4;
            this.percentLabel.Text = "0%";
            this.percentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.descriptionTextBox.Location = new System.Drawing.Point(391, 27);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(267, 344);
            this.descriptionTextBox.TabIndex = 6;
            this.descriptionTextBox.Text = "";
            // 
            // categoriesPanel
            // 
            this.categoriesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.categoriesPanel.AutoScroll = true;
            this.categoriesPanel.BackColor = System.Drawing.SystemColors.Window;
            this.categoriesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.categoriesPanel.Location = new System.Drawing.Point(8, 27);
            this.categoriesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoriesPanel.Name = "categoriesPanel";
            this.categoriesPanel.Size = new System.Drawing.Size(173, 344);
            this.categoriesPanel.TabIndex = 7;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(7, 377);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(363, 17);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Select what programs to download and press the button.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // programsPanel
            // 
            this.programsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.programsPanel.AutoScroll = true;
            this.programsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.programsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.programsPanel.Location = new System.Drawing.Point(187, 27);
            this.programsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.programsPanel.Name = "programsPanel";
            this.programsPanel.Size = new System.Drawing.Size(198, 344);
            this.programsPanel.TabIndex = 8;
            // 
            // selectedPanel
            // 
            this.selectedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedPanel.AutoScroll = true;
            this.selectedPanel.BackColor = System.Drawing.SystemColors.Window;
            this.selectedPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectedPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.selectedPanel.Location = new System.Drawing.Point(664, 27);
            this.selectedPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectedPanel.Name = "selectedPanel";
            this.selectedPanel.Size = new System.Drawing.Size(186, 344);
            this.selectedPanel.TabIndex = 10;
            this.selectedPanel.WrapContents = false;
            // 
            // DownloadManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 431);
            this.Controls.Add(this.selectedPanel);
            this.Controls.Add(this.programsPanel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.categoriesPanel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.percentLabel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(699, 202);
            this.Name = "DownloadManagerForm";
            this.Text = "Download Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadManagerForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton fileDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem updateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Panel categoriesPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.Panel programsPanel;
        private System.Windows.Forms.FlowLayoutPanel selectedPanel;
    }
}

