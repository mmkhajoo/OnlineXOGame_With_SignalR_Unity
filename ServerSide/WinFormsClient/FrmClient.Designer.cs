namespace WinFormsClient
{
    partial class FrmClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpMessaging = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpMembership = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLeaveGroup = new System.Windows.Forms.Button();
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.grpMessaging.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpMembership.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(537, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(105, 55);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(321, 22);
            this.txtUserName.TabIndex = 9;
            this.txtUserName.Text = "user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "User name";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(284, 87);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(144, 28);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(105, 23);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(321, 22);
            this.txtUrl.TabIndex = 6;
            this.txtUrl.Text = "http://localhost:8080/signalr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Url";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(105, 87);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 28);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "nonymuea";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpMessaging
            // 
            this.grpMessaging.Controls.Add(this.btnSend);
            this.grpMessaging.Controls.Add(this.label2);
            this.grpMessaging.Controls.Add(this.txtMessage);
            this.grpMessaging.Enabled = false;
            this.grpMessaging.Location = new System.Drawing.Point(16, 154);
            this.grpMessaging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMessaging.Name = "grpMessaging";
            this.grpMessaging.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMessaging.Size = new System.Drawing.Size(537, 97);
            this.grpMessaging.TabIndex = 1;
            this.grpMessaging.TabStop = false;
            this.grpMessaging.Text = "Messaging";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(101, 55);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(319, 28);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(103, 23);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(316, 22);
            this.txtMessage.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(16, 368);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(537, 258);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(8, 23);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(520, 227);
            this.txtLog.TabIndex = 5;
            // 
            // grpMembership
            // 
            this.grpMembership.Controls.Add(this.label4);
            this.grpMembership.Controls.Add(this.btnLeaveGroup);
            this.grpMembership.Controls.Add(this.btnJoinGroup);
            this.grpMembership.Controls.Add(this.txtGroupName);
            this.grpMembership.Enabled = false;
            this.grpMembership.Location = new System.Drawing.Point(16, 258);
            this.grpMembership.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMembership.Name = "grpMembership";
            this.grpMembership.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMembership.Size = new System.Drawing.Size(537, 103);
            this.grpMembership.TabIndex = 3;
            this.grpMembership.TabStop = false;
            this.grpMembership.Text = "Group Membership";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Group name";
            // 
            // btnLeaveGroup
            // 
            this.btnLeaveGroup.Location = new System.Drawing.Point(283, 65);
            this.btnLeaveGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeaveGroup.Name = "btnLeaveGroup";
            this.btnLeaveGroup.Size = new System.Drawing.Size(136, 28);
            this.btnLeaveGroup.TabIndex = 10;
            this.btnLeaveGroup.Text = "Leave";
            this.btnLeaveGroup.UseVisualStyleBackColor = true;
            this.btnLeaveGroup.Click += new System.EventHandler(this.btnLeaveGroup_Click);
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.Location = new System.Drawing.Point(100, 65);
            this.btnJoinGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(148, 28);
            this.btnJoinGroup.TabIndex = 9;
            this.btnJoinGroup.Text = "Join";
            this.btnJoinGroup.UseVisualStyleBackColor = true;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(101, 33);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(316, 22);
            this.txtGroupName.TabIndex = 8;
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 639);
            this.Controls.Add(this.grpMembership);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpMessaging);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmClient";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMessaging.ResumeLayout(false);
            this.grpMessaging.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpMembership.ResumeLayout(false);
            this.grpMembership.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpMessaging;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpMembership;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLeaveGroup;
        private System.Windows.Forms.Button btnJoinGroup;
        private System.Windows.Forms.TextBox txtGroupName;
    }
}

