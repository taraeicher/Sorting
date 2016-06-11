namespace SortApplication
{
    partial class SortForm
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
            this.grpBxSorts = new System.Windows.Forms.GroupBox();
            this.radBtnNoSort = new System.Windows.Forms.RadioButton();
            this.radBtnHeap = new System.Windows.Forms.RadioButton();
            this.radBtnQuick = new System.Windows.Forms.RadioButton();
            this.radBtnRadix = new System.Windows.Forms.RadioButton();
            this.radBtnBucket = new System.Windows.Forms.RadioButton();
            this.radBtnBubble = new System.Windows.Forms.RadioButton();
            this.radBtnMerge = new System.Windows.Forms.RadioButton();
            this.radBtnInsertion = new System.Windows.Forms.RadioButton();
            this.radBtnSelection = new System.Windows.Forms.RadioButton();
            this.grpBxDataType = new System.Windows.Forms.GroupBox();
            this.radBtnNoData = new System.Windows.Forms.RadioButton();
            this.radBtnString = new System.Windows.Forms.RadioButton();
            this.radBtnInt = new System.Windows.Forms.RadioButton();
            this.lblNumObjects = new System.Windows.Forms.Label();
            this.txtBxNumObjects = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.txtBxOutput = new System.Windows.Forms.RichTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpBxSorts.SuspendLayout();
            this.grpBxDataType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxSorts
            // 
            this.grpBxSorts.Controls.Add(this.radBtnNoSort);
            this.grpBxSorts.Controls.Add(this.radBtnHeap);
            this.grpBxSorts.Controls.Add(this.radBtnQuick);
            this.grpBxSorts.Controls.Add(this.radBtnRadix);
            this.grpBxSorts.Controls.Add(this.radBtnBucket);
            this.grpBxSorts.Controls.Add(this.radBtnBubble);
            this.grpBxSorts.Controls.Add(this.radBtnMerge);
            this.grpBxSorts.Controls.Add(this.radBtnInsertion);
            this.grpBxSorts.Controls.Add(this.radBtnSelection);
            this.grpBxSorts.Location = new System.Drawing.Point(12, 12);
            this.grpBxSorts.Name = "grpBxSorts";
            this.grpBxSorts.Size = new System.Drawing.Size(278, 127);
            this.grpBxSorts.TabIndex = 0;
            this.grpBxSorts.TabStop = false;
            this.grpBxSorts.Text = "Type of Sort";
            // 
            // radBtnNoSort
            // 
            this.radBtnNoSort.AutoSize = true;
            this.radBtnNoSort.Checked = true;
            this.radBtnNoSort.Location = new System.Drawing.Point(82, 102);
            this.radBtnNoSort.Name = "radBtnNoSort";
            this.radBtnNoSort.Size = new System.Drawing.Size(85, 17);
            this.radBtnNoSort.TabIndex = 8;
            this.radBtnNoSort.TabStop = true;
            this.radBtnNoSort.Text = "radioButton1";
            this.radBtnNoSort.UseVisualStyleBackColor = true;
            this.radBtnNoSort.Visible = false;
            this.radBtnNoSort.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnHeap
            // 
            this.radBtnHeap.AutoSize = true;
            this.radBtnHeap.Location = new System.Drawing.Point(164, 81);
            this.radBtnHeap.Name = "radBtnHeap";
            this.radBtnHeap.Size = new System.Drawing.Size(73, 17);
            this.radBtnHeap.TabIndex = 7;
            this.radBtnHeap.Text = "&Heap Sort";
            this.radBtnHeap.UseVisualStyleBackColor = true;
            this.radBtnHeap.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnQuick
            // 
            this.radBtnQuick.AutoSize = true;
            this.radBtnQuick.Location = new System.Drawing.Point(164, 60);
            this.radBtnQuick.Name = "radBtnQuick";
            this.radBtnQuick.Size = new System.Drawing.Size(75, 17);
            this.radBtnQuick.TabIndex = 6;
            this.radBtnQuick.Text = "&Quick Sort";
            this.radBtnQuick.UseVisualStyleBackColor = true;
            this.radBtnQuick.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnRadix
            // 
            this.radBtnRadix.AutoSize = true;
            this.radBtnRadix.Enabled = false;
            this.radBtnRadix.Location = new System.Drawing.Point(164, 39);
            this.radBtnRadix.Name = "radBtnRadix";
            this.radBtnRadix.Size = new System.Drawing.Size(74, 17);
            this.radBtnRadix.TabIndex = 5;
            this.radBtnRadix.Text = "&Radix Sort";
            this.radBtnRadix.UseVisualStyleBackColor = true;
            this.radBtnRadix.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnBucket
            // 
            this.radBtnBucket.AutoSize = true;
            this.radBtnBucket.Location = new System.Drawing.Point(164, 18);
            this.radBtnBucket.Name = "radBtnBucket";
            this.radBtnBucket.Size = new System.Drawing.Size(81, 17);
            this.radBtnBucket.TabIndex = 4;
            this.radBtnBucket.Text = "Bu&cket Sort";
            this.radBtnBucket.UseVisualStyleBackColor = true;
            this.radBtnBucket.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnBubble
            // 
            this.radBtnBubble.AutoSize = true;
            this.radBtnBubble.Location = new System.Drawing.Point(9, 81);
            this.radBtnBubble.Name = "radBtnBubble";
            this.radBtnBubble.Size = new System.Drawing.Size(80, 17);
            this.radBtnBubble.TabIndex = 3;
            this.radBtnBubble.Text = "&Bubble Sort";
            this.radBtnBubble.UseVisualStyleBackColor = true;
            this.radBtnBubble.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnMerge
            // 
            this.radBtnMerge.AutoSize = true;
            this.radBtnMerge.Location = new System.Drawing.Point(9, 60);
            this.radBtnMerge.Name = "radBtnMerge";
            this.radBtnMerge.Size = new System.Drawing.Size(128, 17);
            this.radBtnMerge.TabIndex = 2;
            this.radBtnMerge.Text = "Recursive &Merge Sort";
            this.radBtnMerge.UseVisualStyleBackColor = true;
            this.radBtnMerge.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnInsertion
            // 
            this.radBtnInsertion.AutoSize = true;
            this.radBtnInsertion.Location = new System.Drawing.Point(9, 39);
            this.radBtnInsertion.Name = "radBtnInsertion";
            this.radBtnInsertion.Size = new System.Drawing.Size(87, 17);
            this.radBtnInsertion.TabIndex = 1;
            this.radBtnInsertion.Text = "&Insertion Sort";
            this.radBtnInsertion.UseVisualStyleBackColor = true;
            this.radBtnInsertion.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // radBtnSelection
            // 
            this.radBtnSelection.AutoSize = true;
            this.radBtnSelection.Location = new System.Drawing.Point(9, 18);
            this.radBtnSelection.Name = "radBtnSelection";
            this.radBtnSelection.Size = new System.Drawing.Size(91, 17);
            this.radBtnSelection.TabIndex = 0;
            this.radBtnSelection.Text = "&Selection Sort";
            this.radBtnSelection.UseVisualStyleBackColor = true;
            this.radBtnSelection.CheckedChanged += new System.EventHandler(this.SortType_CheckedChanged);
            // 
            // grpBxDataType
            // 
            this.grpBxDataType.Controls.Add(this.radBtnNoData);
            this.grpBxDataType.Controls.Add(this.radBtnString);
            this.grpBxDataType.Controls.Add(this.radBtnInt);
            this.grpBxDataType.Location = new System.Drawing.Point(311, 12);
            this.grpBxDataType.Name = "grpBxDataType";
            this.grpBxDataType.Size = new System.Drawing.Size(105, 127);
            this.grpBxDataType.TabIndex = 1;
            this.grpBxDataType.TabStop = false;
            this.grpBxDataType.Text = "Data Type";
            // 
            // radBtnNoData
            // 
            this.radBtnNoData.AutoSize = true;
            this.radBtnNoData.Checked = true;
            this.radBtnNoData.Location = new System.Drawing.Point(10, 60);
            this.radBtnNoData.Name = "radBtnNoData";
            this.radBtnNoData.Size = new System.Drawing.Size(85, 17);
            this.radBtnNoData.TabIndex = 2;
            this.radBtnNoData.TabStop = true;
            this.radBtnNoData.Text = "radioButton1";
            this.radBtnNoData.UseVisualStyleBackColor = true;
            this.radBtnNoData.Visible = false;
            this.radBtnNoData.CheckedChanged += new System.EventHandler(this.DataType_CheckedChanged);
            // 
            // radBtnString
            // 
            this.radBtnString.AutoSize = true;
            this.radBtnString.Location = new System.Drawing.Point(11, 39);
            this.radBtnString.Name = "radBtnString";
            this.radBtnString.Size = new System.Drawing.Size(52, 17);
            this.radBtnString.TabIndex = 1;
            this.radBtnString.Text = "S&tring";
            this.radBtnString.UseVisualStyleBackColor = true;
            this.radBtnString.CheckedChanged += new System.EventHandler(this.DataType_CheckedChanged);
            // 
            // radBtnInt
            // 
            this.radBtnInt.AutoSize = true;
            this.radBtnInt.Location = new System.Drawing.Point(11, 18);
            this.radBtnInt.Name = "radBtnInt";
            this.radBtnInt.Size = new System.Drawing.Size(37, 17);
            this.radBtnInt.TabIndex = 0;
            this.radBtnInt.Text = "I&nt";
            this.radBtnInt.UseVisualStyleBackColor = true;
            this.radBtnInt.CheckedChanged += new System.EventHandler(this.DataType_CheckedChanged);
            // 
            // lblNumObjects
            // 
            this.lblNumObjects.AutoSize = true;
            this.lblNumObjects.Location = new System.Drawing.Point(9, 161);
            this.lblNumObjects.Name = "lblNumObjects";
            this.lblNumObjects.Size = new System.Drawing.Size(155, 13);
            this.lblNumObjects.TabIndex = 2;
            this.lblNumObjects.Text = "Number of objects to be sorted:";
            // 
            // txtBxNumObjects
            // 
            this.txtBxNumObjects.Enabled = false;
            this.txtBxNumObjects.Location = new System.Drawing.Point(170, 158);
            this.txtBxNumObjects.Name = "txtBxNumObjects";
            this.txtBxNumObjects.Size = new System.Drawing.Size(100, 20);
            this.txtBxNumObjects.TabIndex = 3;
            this.txtBxNumObjects.TextChanged += new System.EventHandler(this.txtBxNumObjects_TextChanged);
            // 
            // btnSort
            // 
            this.btnSort.Enabled = false;
            this.btnSort.Location = new System.Drawing.Point(311, 156);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(75, 23);
            this.btnSort.TabIndex = 4;
            this.btnSort.Text = "S&ort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // txtBxOutput
            // 
            this.txtBxOutput.Location = new System.Drawing.Point(17, 195);
            this.txtBxOutput.Name = "txtBxOutput";
            this.txtBxOutput.ReadOnly = true;
            this.txtBxOutput.Size = new System.Drawing.Size(414, 149);
            this.txtBxOutput.TabIndex = 5;
            this.txtBxOutput.Text = "";
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Location = new System.Drawing.Point(241, 350);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "R&eset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(331, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SortForm
            // 
            this.AcceptButton = this.btnSort;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(444, 378);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtBxOutput);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.txtBxNumObjects);
            this.Controls.Add(this.lblNumObjects);
            this.Controls.Add(this.grpBxDataType);
            this.Controls.Add(this.grpBxSorts);
            this.Name = "SortForm";
            this.Text = "Sort Chooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortForm_FormClosing);
            this.grpBxSorts.ResumeLayout(false);
            this.grpBxSorts.PerformLayout();
            this.grpBxDataType.ResumeLayout(false);
            this.grpBxDataType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxSorts;
        private System.Windows.Forms.RadioButton radBtnNoSort;
        private System.Windows.Forms.RadioButton radBtnHeap;
        private System.Windows.Forms.RadioButton radBtnQuick;
        private System.Windows.Forms.RadioButton radBtnRadix;
        private System.Windows.Forms.RadioButton radBtnBucket;
        private System.Windows.Forms.RadioButton radBtnBubble;
        private System.Windows.Forms.RadioButton radBtnMerge;
        private System.Windows.Forms.RadioButton radBtnInsertion;
        private System.Windows.Forms.RadioButton radBtnSelection;
        private System.Windows.Forms.GroupBox grpBxDataType;
        private System.Windows.Forms.RadioButton radBtnNoData;
        private System.Windows.Forms.RadioButton radBtnString;
        private System.Windows.Forms.RadioButton radBtnInt;
        private System.Windows.Forms.Label lblNumObjects;
        private System.Windows.Forms.TextBox txtBxNumObjects;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.RichTextBox txtBxOutput;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
    }
}

