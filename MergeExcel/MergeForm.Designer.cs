namespace MergeExcel
{
    partial class MergeForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Up = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_Down = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(12, 17);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(807, 289);
            this.listBox.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 327);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(139, 41);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "添 加";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(179, 327);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(139, 41);
            this.button_Remove.TabIndex = 2;
            this.button_Remove.Text = "移 除";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Up
            // 
            this.button_Up.Location = new System.Drawing.Point(346, 327);
            this.button_Up.Name = "button_Up";
            this.button_Up.Size = new System.Drawing.Size(139, 41);
            this.button_Up.TabIndex = 3;
            this.button_Up.Text = "↑";
            this.button_Up.UseVisualStyleBackColor = true;
            this.button_Up.Click += new System.EventHandler(this.button_Up_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(680, 327);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(139, 41);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "合 并";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel文档|*.xls;*.xlsx";
            this.openFileDialog.Multiselect = true;
            // 
            // button_Down
            // 
            this.button_Down.Location = new System.Drawing.Point(513, 327);
            this.button_Down.Name = "button_Down";
            this.button_Down.Size = new System.Drawing.Size(139, 41);
            this.button_Down.TabIndex = 5;
            this.button_Down.Text = "↓";
            this.button_Down.UseVisualStyleBackColor = true;
            this.button_Down.Click += new System.EventHandler(this.button_Down_Click);
            // 
            // MergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 380);
            this.Controls.Add(this.button_Down);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Up);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.listBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(849, 425);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(849, 425);
            this.Name = "MergeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel合并工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Up;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_Down;
    }
}

