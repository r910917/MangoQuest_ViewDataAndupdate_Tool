namespace MangoQuest
{
    partial class MangoQuest
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.PDID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.another = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.command = new System.Windows.Forms.TextBox();
            this.RewardTaken = new System.Windows.Forms.TextBox();
            this.LastFinishTime = new System.Windows.Forms.TextBox();
            this.FinishedTimes = new System.Windows.Forms.TextBox();
            this.questID = new System.Windows.Forms.TextBox();
            this.questfqid = new System.Windows.Forms.TextBox();
            this.questPDID = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.Button();
            this.fqidtext = new System.Windows.Forms.TextBox();
            this.deletefinishbutton = new System.Windows.Forms.Button();
            this.deletefinish = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.QPID = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.pgt2 = new System.Windows.Forms.TextBox();
            this.pgt = new System.Windows.Forms.TextBox();
            this.QID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.finishquestText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LogText = new System.Windows.Forms.TextBox();
            this.clearlog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.selecttable = new System.Windows.Forms.ComboBox();
            this.inputID = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "輸入玩家ID";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(26, 137);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(199, 38);
            this.search.TabIndex = 2;
            this.search.Text = "執行查詢";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // PDID
            // 
            this.PDID.Location = new System.Drawing.Point(125, 34);
            this.PDID.Name = "PDID";
            this.PDID.ReadOnly = true;
            this.PDID.Size = new System.Drawing.Size(103, 29);
            this.PDID.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.another);
            this.groupBox1.Controls.Add(this.insert);
            this.groupBox1.Controls.Add(this.command);
            this.groupBox1.Controls.Add(this.RewardTaken);
            this.groupBox1.Controls.Add(this.LastFinishTime);
            this.groupBox1.Controls.Add(this.FinishedTimes);
            this.groupBox1.Controls.Add(this.questID);
            this.groupBox1.Controls.Add(this.questfqid);
            this.groupBox1.Controls.Add(this.questPDID);
            this.groupBox1.Controls.Add(this.select);
            this.groupBox1.Controls.Add(this.fqidtext);
            this.groupBox1.Controls.Add(this.deletefinishbutton);
            this.groupBox1.Controls.Add(this.deletefinish);
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.QPID);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.pgt2);
            this.groupBox1.Controls.Add(this.pgt);
            this.groupBox1.Controls.Add(this.QID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.progress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.finishquestText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PDID);
            this.groupBox1.Location = new System.Drawing.Point(618, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1279, 804);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // another
            // 
            this.another.Location = new System.Drawing.Point(512, 138);
            this.another.Multiline = true;
            this.another.Name = "another";
            this.another.ReadOnly = true;
            this.another.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.another.Size = new System.Drawing.Size(704, 176);
            this.another.TabIndex = 26;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(1028, 15);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(188, 30);
            this.insert.TabIndex = 25;
            this.insert.Text = "輸入";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // command
            // 
            this.command.Location = new System.Drawing.Point(512, 103);
            this.command.Name = "command";
            this.command.ReadOnly = true;
            this.command.Size = new System.Drawing.Size(704, 29);
            this.command.TabIndex = 24;
            // 
            // RewardTaken
            // 
            this.RewardTaken.Location = new System.Drawing.Point(1124, 50);
            this.RewardTaken.Name = "RewardTaken";
            this.RewardTaken.ReadOnly = true;
            this.RewardTaken.Size = new System.Drawing.Size(92, 29);
            this.RewardTaken.TabIndex = 23;
            // 
            // LastFinishTime
            // 
            this.LastFinishTime.Location = new System.Drawing.Point(950, 50);
            this.LastFinishTime.Name = "LastFinishTime";
            this.LastFinishTime.ReadOnly = true;
            this.LastFinishTime.Size = new System.Drawing.Size(92, 29);
            this.LastFinishTime.TabIndex = 22;
            // 
            // FinishedTimes
            // 
            this.FinishedTimes.Location = new System.Drawing.Point(839, 50);
            this.FinishedTimes.Name = "FinishedTimes";
            this.FinishedTimes.Size = new System.Drawing.Size(92, 29);
            this.FinishedTimes.TabIndex = 21;
            // 
            // questID
            // 
            this.questID.Location = new System.Drawing.Point(729, 50);
            this.questID.Name = "questID";
            this.questID.Size = new System.Drawing.Size(92, 29);
            this.questID.TabIndex = 20;
            // 
            // questfqid
            // 
            this.questfqid.Location = new System.Drawing.Point(619, 50);
            this.questfqid.Name = "questfqid";
            this.questfqid.ReadOnly = true;
            this.questfqid.Size = new System.Drawing.Size(92, 29);
            this.questfqid.TabIndex = 19;
            // 
            // questPDID
            // 
            this.questPDID.Location = new System.Drawing.Point(512, 50);
            this.questPDID.Name = "questPDID";
            this.questPDID.ReadOnly = true;
            this.questPDID.Size = new System.Drawing.Size(92, 29);
            this.questPDID.TabIndex = 18;
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(512, 15);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(199, 30);
            this.select.TabIndex = 17;
            this.select.Text = "選擇";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // fqidtext
            // 
            this.fqidtext.Location = new System.Drawing.Point(376, 15);
            this.fqidtext.Name = "fqidtext";
            this.fqidtext.ReadOnly = true;
            this.fqidtext.Size = new System.Drawing.Size(117, 29);
            this.fqidtext.TabIndex = 16;
            // 
            // deletefinishbutton
            // 
            this.deletefinishbutton.Location = new System.Drawing.Point(376, 50);
            this.deletefinishbutton.Name = "deletefinishbutton";
            this.deletefinishbutton.Size = new System.Drawing.Size(117, 34);
            this.deletefinishbutton.TabIndex = 15;
            this.deletefinishbutton.Text = "執行刪除";
            this.deletefinishbutton.UseVisualStyleBackColor = true;
            this.deletefinishbutton.Click += new System.EventHandler(this.deletefinishbutton_Click);
            // 
            // deletefinish
            // 
            this.deletefinish.FormattingEnabled = true;
            this.deletefinish.Location = new System.Drawing.Point(245, 34);
            this.deletefinish.Name = "deletefinish";
            this.deletefinish.Size = new System.Drawing.Size(125, 29);
            this.deletefinish.TabIndex = 14;
            this.deletefinish.SelectedIndexChanged += new System.EventHandler(this.deletefinish_SelectedIndexChanged);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(6, 548);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(116, 36);
            this.delete.TabIndex = 13;
            this.delete.Text = "刪除選取任務";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // QPID
            // 
            this.QPID.Location = new System.Drawing.Point(535, 632);
            this.QPID.Name = "QPID";
            this.QPID.ReadOnly = true;
            this.QPID.Size = new System.Drawing.Size(103, 29);
            this.QPID.TabIndex = 12;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(6, 588);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(116, 38);
            this.update.TabIndex = 5;
            this.update.Text = "修改任務內容進度";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // pgt2
            // 
            this.pgt2.Location = new System.Drawing.Point(125, 548);
            this.pgt2.Multiline = true;
            this.pgt2.Name = "pgt2";
            this.pgt2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.pgt2.Size = new System.Drawing.Size(850, 78);
            this.pgt2.TabIndex = 11;
            // 
            // pgt
            // 
            this.pgt.Location = new System.Drawing.Point(426, 632);
            this.pgt.Name = "pgt";
            this.pgt.ReadOnly = true;
            this.pgt.Size = new System.Drawing.Size(103, 29);
            this.pgt.TabIndex = 10;
            // 
            // QID
            // 
            this.QID.FormattingEnabled = true;
            this.QID.Location = new System.Drawing.Point(125, 632);
            this.QID.Name = "QID";
            this.QID.Size = new System.Drawing.Size(281, 29);
            this.QID.TabIndex = 9;
            this.QID.SelectedIndexChanged += new System.EventHandler(this.QID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "任務進度：";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(125, 320);
            this.progress.Multiline = true;
            this.progress.Name = "progress";
            this.progress.ReadOnly = true;
            this.progress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progress.Size = new System.Drawing.Size(1091, 220);
            this.progress.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "完成任務：";
            // 
            // finishquestText
            // 
            this.finishquestText.Location = new System.Drawing.Point(125, 90);
            this.finishquestText.Multiline = true;
            this.finishquestText.Name = "finishquestText";
            this.finishquestText.ReadOnly = true;
            this.finishquestText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.finishquestText.Size = new System.Drawing.Size(368, 224);
            this.finishquestText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "PDID：";
            // 
            // LogText
            // 
            this.LogText.Location = new System.Drawing.Point(26, 208);
            this.LogText.Multiline = true;
            this.LogText.Name = "LogText";
            this.LogText.ReadOnly = true;
            this.LogText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogText.Size = new System.Drawing.Size(579, 497);
            this.LogText.TabIndex = 13;
            // 
            // clearlog
            // 
            this.clearlog.Location = new System.Drawing.Point(231, 137);
            this.clearlog.Name = "clearlog";
            this.clearlog.Size = new System.Drawing.Size(131, 38);
            this.clearlog.TabIndex = 14;
            this.clearlog.Text = "清除log資料";
            this.clearlog.UseVisualStyleBackColor = true;
            this.clearlog.Click += new System.EventHandler(this.clearlog_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "選擇資料表";
            // 
            // selecttable
            // 
            this.selecttable.FormattingEnabled = true;
            this.selecttable.Items.AddRange(new object[] {
            "quest",
            "questk1"});
            this.selecttable.Location = new System.Drawing.Point(380, 87);
            this.selecttable.Name = "selecttable";
            this.selecttable.Size = new System.Drawing.Size(225, 29);
            this.selecttable.TabIndex = 14;
            this.selecttable.Text = "quest";
            this.selecttable.SelectedIndexChanged += new System.EventHandler(this.selecttable_SelectedIndexChanged);
            // 
            // inputID
            // 
            this.inputID.FormattingEnabled = true;
            this.inputID.Location = new System.Drawing.Point(26, 90);
            this.inputID.Name = "inputID";
            this.inputID.Size = new System.Drawing.Size(336, 29);
            this.inputID.TabIndex = 16;
            this.inputID.Click += new System.EventHandler(this.inputID_Click);
            // 
            // MangoQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1661, 770);
            this.Controls.Add(this.inputID);
            this.Controls.Add(this.selecttable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clearlog);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MangoQuest";
            this.Text = "新原空伺服器任務資料查詢";
            this.Activated += new System.EventHandler(this.MangoQuest_Activated);
            this.Load += new System.EventHandler(this.MangoQuest_Load);
            this.Shown += new System.EventHandler(this.MangoQuest_Shown);
            this.Resize += new System.EventHandler(this.MangoQuest_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox PDID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox finishquestText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox progress;
        private System.Windows.Forms.ComboBox QID;
        private System.Windows.Forms.TextBox pgt2;
        private System.Windows.Forms.TextBox pgt;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox QPID;
        private System.Windows.Forms.TextBox LogText;
        private System.Windows.Forms.Button clearlog;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox selecttable;
        private System.Windows.Forms.Button deletefinishbutton;
        private System.Windows.Forms.ComboBox deletefinish;
        private System.Windows.Forms.TextBox fqidtext;
        private System.Windows.Forms.ComboBox inputID;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.TextBox questPDID;
        private System.Windows.Forms.TextBox questfqid;
        private System.Windows.Forms.TextBox RewardTaken;
        private System.Windows.Forms.TextBox LastFinishTime;
        private System.Windows.Forms.TextBox FinishedTimes;
        private System.Windows.Forms.TextBox questID;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.TextBox another;
    }
}

