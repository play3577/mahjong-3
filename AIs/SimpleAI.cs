﻿using System;
using System.Collections.Generic;
using System.Text;
using Mahjong.Players;
using Mahjong.Brands;

namespace Mahjong.AIs
{
    public class SimpleAI : MahjongAI
    {
        private BrandPlayer brandplayer;

        public SimpleAI(BrandPlayer player)
        {
            this.brandplayer = player;
        }

        /// <summary>
        /// 設定玩家
        /// </summary>
        /// <param name="brandplayer">傳入玩家</param>
        public void setPlayer(BrandPlayer player)
        {
            this.brandplayer = player;
        }
        /// <summary>
        /// 取得準備要出手的牌
        /// </summary>
        /// <returns>牌</returns>
        public Brand getReadyBrand()
        {
            return brandplayer.getBrand(0);
        }
        public BrandPlayer getReadyBrandPlayer()
        {
            return null;
        }

        public void setPlayer(Brand brand, BrandPlayer player)
        {
            this.brandplayer = player;
        }


        public bool Chow
        {
            get { return true; }
        }

        public bool Pong
        {
            get { return true; }
        }

        public bool Kong
        {
            get { return true; }
        }

        public bool Win
        {
            get { return true; }
        }

    }
}
