using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hrsmedia_player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = trackBar1.Value;
            lbl_volume.Text = trackBar1.Value.ToString() + "%";
        }

        string[] paths, files;

        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
                player.URL = paths[track_list.SelectedIndex];
                player.Ctlcontrols.play();
                lbl_msg.Text = "Playing...";
                timer1.Start();
                trackBar1.Value = 15;
                lbl_volume.Text = trackBar1.Value.ToString() + "%";
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.play();
            lbl_msg.Text = "Проигрывается...";
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.pause();
            lbl_msg.Text = "Пауза";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
            lbl_msg.Text = "Плеер";
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if(track_list.SelectedIndex<track_list.Items.Count-1)
            {
                track_list.SelectedIndex = track_list.SelectedIndex + 1;
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex > 0)
            {
                track_list.SelectedIndex = track_list.SelectedIndex - 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying) ;
            {
                progressBar1.Maximum = (int)player.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)player.Ctlcontrols.currentPosition;
            }
            lbl__track_start.Text = player.Ctlcontrols.currentPositionString;
            lbl_track_end.Text = player.Ctlcontrols.currentItem.durationString;
        }

        private void lbl_volume_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void player_Enter(object sender, EventArgs e)
        {

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for(int x=0;x<files.Length; x++)
                {
                    track_list.Items.Add(files[x]);
                }
            }
        }
    }
}
