using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadPhpAdminDatabaseName
{
    public partial class FormMain : Form
    {
        // host -> dbs -> tables
        private readonly Dictionary<string, Dictionary<string, List<string>>> dic =
            new Dictionary<string, Dictionary<string, List<string>>>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
                txt_load.Text = ofd.FileName;
        }

        private void btn_begin_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(txt_load.Text);
            lb_host.Items.Clear();
            pb.Maximum = lines.Length;
            int[] taskNum = {0};
            Task.Factory.StartNew(() =>
            {
                foreach (var line in lines)
                {
                    while (taskNum[0] > 100)
                    {
                        Thread.Sleep(1000);
                    }
                    taskNum[0]++;
                    Task.Factory.StartNew(() =>
                    {
                        var php = new PhpAdmin();
                        var arr = line.Split('|');
                        php.Login(arr[0], arr[1], arr[2]);
                        var dbs = php.ReadDatabasesName();
                        if (dbs.Count == 0)
                        {
                            Invoke(new Action(() =>
                            {
                                lb_timeout.Items.Add(line);
                            }));
                            return;
                        }


                        var dicDbTable = new Dictionary<string, List<string>>();
                        foreach (var db in dbs)
                        {
//                            Console.WriteLine(db);
                            dicDbTable.Add(db, php.ReadTablesName(db));
                        }
                        

                        Invoke(new Action(() =>
                        {
                            if (!dic.Keys.Contains(line))
                                dic.Add(line, dicDbTable);
                            lb_host.Items.Add(line);
                            
                        }));
                    }).ContinueWith((task =>
                    {
                        Invoke(new Action(() =>
                        {
                            pb.Increment(1);
                            lab_pb.Text = $"{pb.Value} / {pb.Maximum}";
                            lab_num.Text = (--taskNum[0]).ToString();
                        }));

                    }));
                }
            });
        }

        private void lb_host_SelectedValueChanged(object sender, EventArgs e)
        {
            lb_db.Items.Clear();
            lb_table.Items.Clear();
            if (dic.Keys.Contains(lb_host.SelectedItem))
                foreach (var key in dic[lb_host.SelectedItem.ToString()].Keys)
                    lb_db.Items.Add(key);
            else
                lb_db.Items.Add("无");
        }

        private void lb_db_SelectedValueChanged(object sender, EventArgs e)
        {
            lb_table.Items.Clear();
            try
            {
                if (dic.ContainsKey(lb_host.SelectedItem.ToString()))
                    foreach (var s in dic[lb_host.SelectedItem.ToString()][lb_db.SelectedItem.ToString()])
                        lb_table.Items.Add(s);
            }
            catch (Exception)
            {
            }
            
        }

        private void lb_host_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetText(lb_host.SelectedItem.ToString());
        }
    }
}