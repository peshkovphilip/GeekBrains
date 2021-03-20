
namespace Part1_Lesson8
{
    partial class formEditor
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.ItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.quizList = new System.Windows.Forms.CheckedListBox();
            this.textQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.checkQuestion = new System.Windows.Forms.CheckBox();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemMain});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(516, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // ItemMain
            // 
            this.ItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemNew,
            this.ItemLoad,
            this.ItemSave,
            this.ItemSaveAs,
            this.ItemExit});
            this.ItemMain.Name = "ItemMain";
            this.ItemMain.Size = new System.Drawing.Size(46, 20);
            this.ItemMain.Text = "Main";
            // 
            // ItemNew
            // 
            this.ItemNew.Name = "ItemNew";
            this.ItemNew.Size = new System.Drawing.Size(112, 22);
            this.ItemNew.Text = "New";
            this.ItemNew.Click += new System.EventHandler(this.ItemNew_Click);
            // 
            // ItemLoad
            // 
            this.ItemLoad.Name = "ItemLoad";
            this.ItemLoad.Size = new System.Drawing.Size(112, 22);
            this.ItemLoad.Text = "Load";
            this.ItemLoad.Click += new System.EventHandler(this.ItemLoad_Click);
            // 
            // ItemSave
            // 
            this.ItemSave.Name = "ItemSave";
            this.ItemSave.Size = new System.Drawing.Size(112, 22);
            this.ItemSave.Text = "Save";
            this.ItemSave.Click += new System.EventHandler(this.ItemSave_Click);
            // 
            // ItemSaveAs
            // 
            this.ItemSaveAs.Name = "ItemSaveAs";
            this.ItemSaveAs.Size = new System.Drawing.Size(112, 22);
            this.ItemSaveAs.Text = "Save as";
            this.ItemSaveAs.Click += new System.EventHandler(this.ItemSaveAs_Click);
            // 
            // ItemExit
            // 
            this.ItemExit.Name = "ItemExit";
            this.ItemExit.Size = new System.Drawing.Size(180, 22);
            this.ItemExit.Text = "Close";
            this.ItemExit.Click += new System.EventHandler(this.ItemExit_Click);
            // 
            // quizList
            // 
            this.quizList.BackColor = System.Drawing.Color.MistyRose;
            this.quizList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quizList.CheckOnClick = true;
            this.quizList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quizList.FormattingEnabled = true;
            this.quizList.Location = new System.Drawing.Point(22, 38);
            this.quizList.Name = "quizList";
            this.quizList.Size = new System.Drawing.Size(469, 254);
            this.quizList.TabIndex = 1;
            this.quizList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.quizList_ItemCheck);
            // 
            // textQuestion
            // 
            this.textQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textQuestion.Location = new System.Drawing.Point(20, 331);
            this.textQuestion.Name = "textQuestion";
            this.textQuestion.Size = new System.Drawing.Size(430, 26);
            this.textQuestion.TabIndex = 2;
            this.textQuestion.TextChanged += new System.EventHandler(this.textQuestion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "True?";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(20, 363);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightSalmon;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(279, 365);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(103, 34);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(388, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 34);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkQuestion
            // 
            this.checkQuestion.AutoSize = true;
            this.checkQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkQuestion.Location = new System.Drawing.Point(463, 336);
            this.checkQuestion.Margin = new System.Windows.Forms.Padding(10);
            this.checkQuestion.Name = "checkQuestion";
            this.checkQuestion.Size = new System.Drawing.Size(15, 14);
            this.checkQuestion.TabIndex = 8;
            this.checkQuestion.UseVisualStyleBackColor = true;
            // 
            // formEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 417);
            this.Controls.Add(this.checkQuestion);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textQuestion);
            this.Controls.Add(this.quizList);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.Name = "formEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz Editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formEditor_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem ItemMain;
        private System.Windows.Forms.ToolStripMenuItem ItemNew;
        private System.Windows.Forms.ToolStripMenuItem ItemLoad;
        private System.Windows.Forms.ToolStripMenuItem ItemSave;
        private System.Windows.Forms.ToolStripMenuItem ItemExit;
        private System.Windows.Forms.CheckedListBox quizList;
        private System.Windows.Forms.TextBox textQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox checkQuestion;
        private System.Windows.Forms.ToolStripMenuItem ItemSaveAs;
    }
}

