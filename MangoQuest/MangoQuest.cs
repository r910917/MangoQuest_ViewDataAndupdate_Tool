using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;

namespace MangoQuest
{
    public partial class MangoQuest : Form
    {
        public MangoQuest()
        {
            InitializeComponent();
            this.CenterToScreen();
            isLoaded = false;
        }
        private float X;//當前窗體的寬度
        private float Y;//當前窗體的高度
        bool isLoaded;  // 是否已設定各控制的尺寸資料到Tag屬性
        string[] pg = new string[100];
        string[] pg2 = new string[100];
        string[] qid = new string[100];
        string[] fqid = new string[100];

        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    SetTag(con);
            }
        }

        private void SetControls(float newx, float newy, Control cons)
        {
            if (isLoaded)
            {
                //遍歷窗體中的控制項，重新設置控制項的值
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//獲取控制項的Tag屬性值，並分割後存儲字元串數組
                    float a = System.Convert.ToSingle(mytag[0]) * newx;//根據窗體縮放比例確定控制項的值，寬度
                    con.Width = (int)a;//寬度
                    a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                    con.Height = (int)(a);
                    a = System.Convert.ToSingle(mytag[2]) * newx;//左邊距離
                    con.Left = (int)(a);
                    a = System.Convert.ToSingle(mytag[3]) * newy;//上邊緣距離
                    con.Top = (int)(a);
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字體大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx, newy, con);
                    }
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            QID.Items.Clear();
            deletefinish.Items.Clear();
            if (!string.IsNullOrWhiteSpace(inputID.Text) && !string.IsNullOrWhiteSpace(selecttable.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=" + selecttable.Text + ";User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * From mq_playerdata Where LastKnownID= @ID";
                cmd.Parameters.AddWithValue("ID", inputID.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t Select* From mq_playerdata Where LastKnownID = " + inputID.Text.Trim() + "\r\n";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    PDID.Text = dr[0].ToString();
                    LogText.Text += System.DateTime.Now + "已找到玩家ID對應的PDID..." + PDID.Text + "\r\n";
                }
                else
                {
                    MessageBox.Show("查無此玩家ID","錯誤",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    LogText.Text += System.DateTime.Now + "未找到玩家ID...\r\n";
                }
                dr.Close();
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
                //查詢玩家完成的任務
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                cmd.Connection = conn;
                cmd.CommandText = "select * from mq_finishedquest where PDID = @PDID order by QuestID desc";
                cmd.Parameters.AddWithValue("PDID", PDID.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t Select* From mq_finishedquest Where LastKnownID = " + PDID.Text.Trim() + "\r\n";
                MySqlDataReader finishquest = cmd.ExecuteReader();
                finishquestText.Text = "完成任務ID\t" + "完成次數\r\n";
                int finishQcount = 0;
                while (finishquest.Read())
                {
                    finishquestText.Text += finishquest[2].ToString() + "\t\t" + finishquest[3].ToString() + "\r\n";
                    deletefinish.Items.Add(finishquest[2].ToString());
                    fqid[finishQcount] = finishquest[0].ToString();
                    finishQcount++;
                }
                LogText.Text += System.DateTime.Now + "已成功查詢玩家資料...總共 " + finishQcount.ToString() + "筆已完成任務\r\n";
                finishquest.Close();
                
                LogText.Text += System.DateTime.Now + "資料庫關閉查詢...\r\n";
                join();
                if (selecttable.Text == "questk1")
                {
                    conn.Close();
                    MySqlConnection conn2 = new MySqlConnection("Server=220.132.246.187;Database=quest;User ID=orsp0118;Password=orsp0118;");
                    try
                    {
                        conn2.Open();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "連線資料庫失敗");
                        return;
                    }
                    
                    cmd.Connection = conn2;
                    cmd.CommandText = "select * from mq_finishedquest where PDID = @anPDID order by QuestID desc";
                    cmd.Parameters.AddWithValue("anPDID", questPDID.Text.Trim());
                    LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t Select* From mq_finishedquest Where LastKnownID = " + questPDID.Text.Trim() + "\r\n";
                    MySqlDataReader quest = cmd.ExecuteReader();
                    another.Text = "完成任務ID\t" + "完成次數\r\n";
                    while (quest.Read())
                    {
                        another.Text += quest[2].ToString() + "\t\t" + quest[3].ToString() + "\r\n";
                    }
                    quest.Close();
                    conn2.Close();
                    LogText.Text += System.DateTime.Now + "資料庫關閉查詢...\r\n";
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "連線資料庫失敗");
                        return;
                    }
                }

                //查詢玩家任務進度
                cmd.Connection = conn;
                cmd.CommandText = "select * from mq_questprogress where PDID =  @PDID";
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t select * from mq_questprogress where PDID =  " + PDID.Text.Trim() + "\r\n";
                MySqlDataReader progressquest = cmd.ExecuteReader();
                progress.Text = "任務ID\t" + "執行階段\t" + "任務內容進度(已完成1就會顯示1，或已完成0就會顯示0)\r\n";
                int pgid = 0;
                while (progressquest.Read())
                {
                    QID.Items.Add(progressquest[2].ToString());
                    progress.Text += progressquest[2].ToString() + "\t" + progressquest[3].ToString() + "\t";
                    string jsonString = progressquest[6].ToString();
                    pg[pgid] = progressquest[3].ToString();
                    pg2[pgid] = progressquest[6].ToString();
                    qid[pgid] = progressquest[0].ToString();
                    pgid++;
                    //任務內容進度
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    for (int i = 0; i <= 20; i++)
                    {
                        string key = i.ToString();
                        if (jsonObject.ContainsKey(key))
                        {
                            string value = jsonObject[key].ToString();
                            result.Add(key, value);
                        }
                    }
                    foreach (var kvp in result)
                    {
                        progress.Text += kvp.Key + " : " + kvp.Value + "\t";
                        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    }
                    progress.Text += "\r\n";
                }
                LogText.Text += System.DateTime.Now + "已成功查詢玩家資料...總共 " + pgid.ToString() + "筆執行中任務\r\n";
                progressquest.Close();
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請輸入玩家ID或資料表", "未輸入玩家ID");
            }
        }

        public void join()
        {
            if (!string.IsNullOrWhiteSpace(inputID.Text) && !string.IsNullOrWhiteSpace(selecttable.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=quest;User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from mq_playerdata WHERE LastKnownID = @playerID";
                cmd.Parameters.AddWithValue("playerID", inputID.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\tselect from mq_playerdata WHERE LastKnownID = " + inputID.Text.Trim() + "\r\n";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    questPDID.Text = dr[0].ToString();
                    LogText.Text += System.DateTime.Now + "已找到玩家ID對應的PDID..." + PDID.Text + "\r\n";
                }
                else
                {
                    MessageBox.Show("查無此玩家ID", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogText.Text += System.DateTime.Now + "未找到玩家ID...\r\n";
                }
                dr.Close();
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }

            if (!string.IsNullOrWhiteSpace(questPDID.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=quest;User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select FQID from mq_finishedquest order by FQID desc limit 1;";
                //cmd.Parameters.AddWithValue("playerID", inputID.Text.Trim());
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    questfqid.Text = (Convert.ToDecimal(dr[0]) + 1).ToString();
                    LogText.Text += System.DateTime.Now + "已找到最後的FQID" + questfqid.Text + "\r\n";
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
                dr.Close();
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }


        private void QID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = QID.SelectedIndex;
            pgt.Text = pg[index].ToString();
            pgt2.Text = pg2[index].ToString();
            QPID.Text = qid[index].ToString();
            LogText.Text += System.DateTime.Now + "搜尋指定資料內容...\r\n";
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QID.Text) && !string.IsNullOrWhiteSpace(selecttable.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database="+selecttable.Text+";User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE mq_questprogress SET QuestObjectProgress = @PG WHERE QPDID = @QPID";
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\tUPDATE mq_questprogress SET QuestObjectProgress = " + pgt2.Text.Trim() + "WHERE QPDID= " + PDID.Text.Trim() + "\r\n";
                cmd.Parameters.AddWithValue("PG", pgt2.Text.Trim());
                cmd.Parameters.AddWithValue("QPID", QPID.Text.Trim());
                try
                {
                    int rec = cmd.ExecuteNonQuery();
                    LogText.Text += System.DateTime.Now + "執行修改資料成功...總共完成" + rec.ToString() + "筆資料修改\r\n";
                }
                catch(Exception ex)
                {
                    MessageBox.Show("錯誤訊息：" + ex.Message + "\r\n查詢字串：" + cmd.CommandText.ToString(), "錯誤");
                    LogText.Text += System.DateTime.Now + "執行修改資料失敗...錯誤訊息" + ex.ToString() + "\r\n";
                }
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }

        private void clearlog_Click(object sender, EventArgs e)
        {
            LogText.Text = "";
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QID.Text) && !string.IsNullOrWhiteSpace(selecttable.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database="+selecttable.Text+";User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete from mq_questprogress WHERE QPDID = @QPID";
                cmd.Parameters.AddWithValue("QPID", QPID.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\tDelete from mq_questprogress WHERE QPDID = " + QPID.Text.Trim() + "\r\n";
                try
                {
                    int rec = cmd.ExecuteNonQuery();
                    LogText.Text += System.DateTime.Now + "執行刪除資料成功...總共完成" + rec.ToString() + "筆資料刪除\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤訊息：" + ex.Message + "\r\n查詢字串：" + cmd.CommandText.ToString(), "錯誤");
                    LogText.Text += System.DateTime.Now + "執行刪除資料失敗...錯誤訊息" + ex.ToString() + "\r\n";
                }
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }

        private void deletefinishbutton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fqidtext.Text) && !string.IsNullOrWhiteSpace(selecttable.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=" + selecttable.Text + ";User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Delete from mq_finishedquest WHERE FQID = @FQID";
                cmd.Parameters.AddWithValue("FQID", fqidtext.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\tDelete from mq_finishedquest WHERE FQID = " + fqidtext.Text.Trim() + "\r\n";
                try
                {
                    int rec = cmd.ExecuteNonQuery();
                    LogText.Text += System.DateTime.Now + "執行刪除資料成功...總共完成" + rec.ToString() + "筆資料刪除\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤訊息：" + ex.Message + "\r\n查詢字串：" + cmd.CommandText.ToString(), "錯誤");
                    LogText.Text += System.DateTime.Now + "執行刪除資料失敗...錯誤訊息" + ex.ToString() + "\r\n";
                }
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }

        private void deletefinish_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = deletefinish.SelectedIndex;
            fqidtext.Text = fqid[index].ToString();

            if (!string.IsNullOrWhiteSpace(questPDID.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=questk1;User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from mq_finishedquest where FQID = @questfqid;";
                cmd.Parameters.AddWithValue("questfqid", fqidtext.Text.Trim());
                MySqlDataReader drdata = cmd.ExecuteReader();
                if (drdata.HasRows)
                {
                    drdata.Read();
                    questID.Text = drdata[2].ToString();
                    FinishedTimes.Text = drdata[3].ToString();
                    LastFinishTime.Text = drdata[4].ToString();
                    RewardTaken.Text = drdata[5].ToString();
                    LogText.Text += System.DateTime.Now + "已將資料輸入\r\n";
                    command.Text = "INSERT INTO mq_finishedquest(FQID, PDID, QuestID, FinishedTimes, LastFinishTime, RewardTaken) VALUES ("+ questfqid.Text +", "+ questPDID.Text +"," + questID.Text + ", " + FinishedTimes.Text +"," + LastFinishTime.Text + ", "+ RewardTaken.Text +");";
                }
                drdata.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }

        private void MangoQuest_Activated(object sender, EventArgs e)
        {
            
        }

        private void MangoQuest_Load(object sender, EventArgs e)
        {
            X = this.Width;//獲取窗體的寬度
            Y = this.Height;//獲取窗體的高度
            isLoaded = true;// 已設定各控制項的尺寸到Tag屬性中
            SetTag(this);//調用方法
        }

        private void MangoQuest_Shown(object sender, EventArgs e)
        {
        }

        private void MangoQuest_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = (this.Height) / Y;
            SetControls(newx, newy, this);
        }

        private void select_Click(object sender, EventArgs e)
        {
            
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(command.Text))
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=quest;User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    return;
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO mq_finishedquest VALUES (@qfqid,@qpdid,@qid,@qtimes,@lft,@rt);";
                cmd.Parameters.AddWithValue("qfqid", questfqid.Text.Trim());
                cmd.Parameters.AddWithValue("qpdid", questPDID.Text.Trim());
                cmd.Parameters.AddWithValue("qid", questID.Text.Trim());
                cmd.Parameters.AddWithValue("qtimes", FinishedTimes.Text.Trim());
                cmd.Parameters.AddWithValue("lft", LastFinishTime.Text.Trim());
                cmd.Parameters.AddWithValue("rt", RewardTaken.Text.Trim());
                LogText.Text += System.DateTime.Now + "執行新增...\r\n";
                try
                {
                    int rec = cmd.ExecuteNonQuery();
                    LogText.Text += System.DateTime.Now + "執行新增資料成功...總共完成" + rec.ToString() + "筆資料\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("錯誤訊息：" + ex.Message + "\r\n查詢字串：" + cmd.CommandText.ToString(), "錯誤");
                    LogText.Text += System.DateTime.Now + "執行新增資料失敗...錯誤訊息" + ex.ToString() + "\r\n";
                }
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
                questfqid.Text = (Convert.ToInt32(questfqid.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show("請先選取任務或資料表", "未選取資料");
            }
        }

        private void inputID_Click(object sender, EventArgs e)
        {
            if (inputID.Items.Count == 0)
            {
                MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database="+ selecttable.Text.Trim() +";User ID=orsp0118;Password=orsp0118;");
                //查詢玩家PDID
                try
                {
                    conn.Open();
                    LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "連線資料庫失敗");
                    LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                    this.Close();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select * From mq_playerdata;";
                LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t Select * From mq_playerdata;\r\n";
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inputID.Items.Add(dr[1].ToString());
                }
                LogText.Text += System.DateTime.Now + "已將所有玩家資料加入輸入框格..." + PDID.Text + "\r\n";
                dr.Close();
                conn.Close();
                LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
            }
        }

        private void selecttable_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputID.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Server=220.132.246.187;Database=" + selecttable.Text.Trim() + ";User ID=orsp0118;Password=orsp0118;");
            //查詢玩家PDID
            try
            {
                conn.Open();
                LogText.Text += System.DateTime.Now + "資料庫連線成功...\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "連線資料庫失敗");
                LogText.Text += System.DateTime.Now + "資料庫連線失敗...\r\n";
                this.Close();
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * From mq_playerdata;";
            LogText.Text += System.DateTime.Now + "執行查詢...\r\n\t Select * From mq_playerdata;\r\n";
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                inputID.Items.Add(dr[1].ToString());
            }
            LogText.Text += System.DateTime.Now + "已將所有玩家資料加入輸入框格..." + PDID.Text + "\r\n";
            dr.Close();
            conn.Close();
            LogText.Text += System.DateTime.Now + "資料庫關閉連線...\r\n";
        }
    }
}