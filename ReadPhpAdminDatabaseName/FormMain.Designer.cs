namespace ReadPhpAdminDatabaseName
{
    partial class FormMain
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
            this.btn_load = new System.Windows.Forms.Button();
            this.txt_load = new System.Windows.Forms.TextBox();
            this.btn_begin = new System.Windows.Forms.Button();
            this.lb_host = new System.Windows.Forms.ListBox();
            this.lb_db = new System.Windows.Forms.ListBox();
            this.lb_table = new System.Windows.Forms.ListBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lb_timeout = new System.Windows.Forms.ListBox();
            this.lab_num = new System.Windows.Forms.Label();
            this.lab_pb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(317, 12);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 0;
            this.btn_load.Text = "导入";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // txt_load
            // 
            this.txt_load.Location = new System.Drawing.Point(12, 12);
            this.txt_load.Name = "txt_load";
            this.txt_load.ReadOnly = true;
            this.txt_load.Size = new System.Drawing.Size(299, 20);
            this.txt_load.TabIndex = 1;
            // 
            // btn_begin
            // 
            this.btn_begin.Location = new System.Drawing.Point(398, 12);
            this.btn_begin.Name = "btn_begin";
            this.btn_begin.Size = new System.Drawing.Size(75, 23);
            this.btn_begin.TabIndex = 2;
            this.btn_begin.Text = "开始";
            this.btn_begin.UseVisualStyleBackColor = true;
            this.btn_begin.Click += new System.EventHandler(this.btn_begin_Click);
            // 
            // lb_host
            // 
            this.lb_host.FormattingEnabled = true;
            this.lb_host.Location = new System.Drawing.Point(12, 38);
            this.lb_host.Name = "lb_host";
            this.lb_host.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_host.Size = new System.Drawing.Size(253, 316);
            this.lb_host.TabIndex = 3;
            this.lb_host.SelectedValueChanged += new System.EventHandler(this.lb_host_SelectedValueChanged);
            this.lb_host.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_host_MouseDoubleClick);
            // 
            // lb_db
            // 
            this.lb_db.FormattingEnabled = true;
            this.lb_db.Location = new System.Drawing.Point(271, 38);
            this.lb_db.Name = "lb_db";
            this.lb_db.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_db.Size = new System.Drawing.Size(253, 316);
            this.lb_db.TabIndex = 4;
            this.lb_db.SelectedValueChanged += new System.EventHandler(this.lb_db_SelectedValueChanged);
            // 
            // lb_table
            // 
            this.lb_table.FormattingEnabled = true;
            this.lb_table.Location = new System.Drawing.Point(530, 38);
            this.lb_table.Name = "lb_table";
            this.lb_table.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_table.Size = new System.Drawing.Size(253, 316);
            this.lb_table.TabIndex = 5;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(479, 12);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(304, 23);
            this.pb.Step = 1;
            this.pb.TabIndex = 6;
            // 
            // lb_timeout
            // 
            this.lb_timeout.FormattingEnabled = true;
            this.lb_timeout.Location = new System.Drawing.Point(816, 38);
            this.lb_timeout.Name = "lb_timeout";
            this.lb_timeout.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_timeout.Size = new System.Drawing.Size(156, 316);
            this.lb_timeout.TabIndex = 7;
            // 
            // lab_num
            // 
            this.lab_num.AutoSize = true;
            this.lab_num.Location = new System.Drawing.Point(813, 17);
            this.lab_num.Name = "lab_num";
            this.lab_num.Size = new System.Drawing.Size(13, 13);
            this.lab_num.TabIndex = 8;
            this.lab_num.Text = "0";
            // 
            // lab_pb
            // 
            this.lab_pb.AutoSize = true;
            this.lab_pb.Location = new System.Drawing.Point(608, 17);
            this.lab_pb.Name = "lab_pb";
            this.lab_pb.Size = new System.Drawing.Size(30, 13);
            this.lab_pb.TabIndex = 9;
            this.lab_pb.Text = "0 / 0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 369);
            this.Controls.Add(this.lab_pb);
            this.Controls.Add(this.lab_num);
            this.Controls.Add(this.lb_timeout);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lb_table);
            this.Controls.Add(this.lb_db);
            this.Controls.Add(this.lb_host);
            this.Controls.Add(this.btn_begin);
            this.Controls.Add(this.txt_load);
            this.Controls.Add(this.btn_load);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox txt_load;
        private System.Windows.Forms.Button btn_begin;
        private System.Windows.Forms.ListBox lb_host;
        private System.Windows.Forms.ListBox lb_db;
        private System.Windows.Forms.ListBox lb_table;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.ListBox lb_timeout;
        private System.Windows.Forms.Label lab_num;
        private System.Windows.Forms.Label lab_pb;
    }
}

