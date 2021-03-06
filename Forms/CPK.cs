using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mahjong.Control;
using Mahjong.Brands;
using System.Media;
using Mahjong.Properties;

namespace Mahjong.Forms
{
    public partial class CPK : Form
    {
        ProgramControl pc;
        //Brand brand;
        bool network = false;
        CheckUser checkuser;
        SoundPlayer soundplayer=new SoundPlayer();
        public CPK(ProgramControl pc,CheckUser check)
        {
            InitializeComponent();
            this.pc = pc;
            this.checkuser = check;
        }

        private void CPK_Load(object sender, EventArgs e)
        {
            Chow.Text = Mahjong.Properties.Settings.Default.Chow;
            Pong.Text = Mahjong.Properties.Settings.Default.Pong;
            Kong.Text = Mahjong.Properties.Settings.Default.Kong;
            Win.Text = Mahjong.Properties.Settings.Default.Win;
            Pass.Text = Mahjong.Properties.Settings.Default.Pass;
            DarkKong.Text = Mahjong.Properties.Settings.Default.DarkKong;

            if (checkuser.Brand.getClass() == Mahjong.Properties.Settings.Default.Wordtiles)
            {
                WordBrand w = (WordBrand)checkuser.Brand;
                this.Text = pc.all.Name[pc.all.state] + " - " + w.getWordClass();
            }
            else
                this.Text = pc.all.Name[pc.all.state] + " - " + checkuser.Brand.getNumber() + checkuser.Brand.getClass();
        }
        /// <summary>
        /// 取得或設定是否是網路
        /// </summary>
        public bool Network
        {
            set
            {
                network = value;
            }
            get
            {
                return network;
            }
        }

        public CheckUser Checkuser
        {
            set
            {
                checkuser = value;
            }
            get
            {
                return checkuser;
            }
        }

        /// <summary>
        /// 設定按鈕狀態
        /// </summary>
        /// <param name="chow">吃按鈕</param>
        /// <param name="pong">碰按鈕</param>
        /// <param name="kong">槓按鈕</param>
        /// <param name="win">胡按鈕</param>
        public void Enabled_Button(bool chow,bool pong,bool kong,bool darkong,bool win)
        {
            this.Chow.Enabled = chow;
            this.Pong.Enabled = pong;
            this.Kong.Enabled = kong;
            this.Win.Enabled = win;
            this.DarkKong.Enabled = darkong;
        }
        public void Enabled_Button(CheckUser check)
        {
            this.Chow.Enabled = check.Chow;
            this.Pong.Enabled = check.Pong;
            this.Kong.Enabled = check.Kong;
            this.Win.Enabled = check.Win;
            this.DarkKong.Enabled = check.DarkKong;
            this.Pass.Enabled = check.Pass;
        }
        private void Chow_Click(object sender, EventArgs e)
        {
            if (pc.PlayerSound)
            {
                soundplayer.Stream = Resources.chow;
                soundplayer.Play();
            }
            if (network)
            {
                checkuser.Chow = true;
                checkuser.Pong = false;
                checkuser.Kong = false;
                checkuser.DarkKong = false;
                checkuser.Win = false;
                checkuser.Pass = false;
                
                pc.chat.SendObject(checkuser);
            }
            else
                pc.chow(checkuser.Brand);
            this.Close();
        }

        private void Pong_Click(object sender, EventArgs e)
        {
            if (pc.PlayerSound)
            {
                soundplayer.Stream = Resources.pon;
                soundplayer.Play();
            }
            if (network)
            {
                checkuser.Chow = false;
                checkuser.Pong = true;
                checkuser.Kong = false;
                checkuser.DarkKong = false;
                checkuser.Win = false;
                checkuser.Pass = false;

                pc.chat.SendObject(checkuser);
            }
            else
                pc.pong(checkuser.Brand);
            this.Close();
        }

        private void Kong_Click(object sender, EventArgs e)
        {
            if (pc.PlayerSound)
            {
                soundplayer.Stream = Resources.kong;
                soundplayer.Play();
            }
            if (network)
            {
                checkuser.Chow = false;
                checkuser.Pong = false;
                checkuser.Kong = true;
                checkuser.DarkKong = false;
                checkuser.Win = false;
                checkuser.Pass = false;

                pc.chat.SendObject(checkuser);
            }
            else
                pc.kong(checkuser.Brand);
            this.Close();
        }

        private void Win_Click(object sender, EventArgs e)
        {
            if (pc.PlayerSound)
            {
                soundplayer.Stream = Resources.win;
                soundplayer.Play();
            }
            if (network)
            {
                checkuser.Chow = false;
                checkuser.Pong = false;
                checkuser.Kong = false;
                checkuser.DarkKong = false;
                checkuser.Win = true;
                checkuser.Pass = false;

                pc.chat.SendObject(checkuser);
            }
            else
                pc.win(checkuser.Brand);
            this.Close();
        }

        private void Pass_Click(object sender, EventArgs e)
        {
            if (network)
            {
                checkuser.Chow = false;
                checkuser.Pong = false;
                checkuser.Kong = false;
                checkuser.DarkKong = false;
                checkuser.Win = false;
                checkuser.Pass = true;

                pc.chat.SendObject(checkuser);
            }
            else
                pc.pass(checkuser.Brand);
            this.Close();
        }

        private void DarkKong_Click(object sender, EventArgs e)
        {
            if (pc.PlayerSound)
            {
                soundplayer.Stream = Resources.kong;
                soundplayer.Play();
            }
            if (network)
            {
                checkuser.Chow = false;
                checkuser.Pong = false;
                checkuser.Kong = false;
                checkuser.DarkKong = true;
                checkuser.Win = false;
                checkuser.Pass = false;

                pc.chat.SendObject(checkuser);
            }
            else
                pc.dark_kong(checkuser.Brand);
            this.Close();
        }        
    }
}