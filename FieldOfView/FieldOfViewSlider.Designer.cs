namespace FieldOfView
{
    partial class FieldOfViewSlider
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrackBarFieldOfView = new System.Windows.Forms.TrackBar();
            this.CheckBoxDefault = new System.Windows.Forms.CheckBox();
            this.LabelFieldOfVIew = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFieldOfView)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBarFieldOfView
            // 
            this.TrackBarFieldOfView.BackColor = System.Drawing.SystemColors.Window;
            this.TrackBarFieldOfView.Cursor = System.Windows.Forms.Cursors.Default;
            this.TrackBarFieldOfView.LargeChange = 20;
            this.TrackBarFieldOfView.Location = new System.Drawing.Point(0, 0);
            this.TrackBarFieldOfView.Margin = new System.Windows.Forms.Padding(0);
            this.TrackBarFieldOfView.Maximum = 130;
            this.TrackBarFieldOfView.Minimum = 10;
            this.TrackBarFieldOfView.Name = "TrackBarFieldOfView";
            this.TrackBarFieldOfView.Size = new System.Drawing.Size(314, 45);
            this.TrackBarFieldOfView.SmallChange = 5;
            this.TrackBarFieldOfView.TabIndex = 0;
            this.TrackBarFieldOfView.TickFrequency = 10;
            this.TrackBarFieldOfView.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarFieldOfView.Value = 30;
            // 
            // CheckBoxDefault
            // 
            this.CheckBoxDefault.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.CheckBoxDefault.AutoSize = true;
            this.CheckBoxDefault.Checked = true;
            this.CheckBoxDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxDefault.Location = new System.Drawing.Point(317, 25);
            this.CheckBoxDefault.Name = "CheckBoxDefault";
            this.CheckBoxDefault.Size = new System.Drawing.Size(66, 20);
            this.CheckBoxDefault.TabIndex = 1;
            this.CheckBoxDefault.Text = "Default";
            this.CheckBoxDefault.UseVisualStyleBackColor = true;
            // 
            // LabelFieldOfVIew
            // 
            this.LabelFieldOfVIew.AutoSize = true;
            this.LabelFieldOfVIew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFieldOfVIew.Location = new System.Drawing.Point(327, 2);
            this.LabelFieldOfVIew.Name = "LabelFieldOfVIew";
            this.LabelFieldOfVIew.Size = new System.Drawing.Size(32, 20);
            this.LabelFieldOfVIew.TabIndex = 2;
            this.LabelFieldOfVIew.Text = "30°";
            // 
            // FieldOfViewSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LabelFieldOfVIew);
            this.Controls.Add(this.CheckBoxDefault);
            this.Controls.Add(this.TrackBarFieldOfView);
            this.Name = "FieldOfViewSlider";
            this.Size = new System.Drawing.Size(389, 45);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarFieldOfView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.CheckBox CheckBoxDefault;
        private System.Windows.Forms.Label LabelFieldOfVIew;
        internal System.Windows.Forms.TrackBar TrackBarFieldOfView;
    }
}
