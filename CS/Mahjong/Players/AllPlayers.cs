using System;
using System.Collections.Generic;
using System.Text;
using Mahjong.Players;
using Mahjong.Brands;
using Mahjong.Control;
using System.Windows.Forms;

namespace Mahjong.Control
{
    [Serializable]
    public class AllPlayers
    {
        /// <summary>
        /// 玩家存放
        /// </summary>
        BrandPlayer[] players;
        /// <summary>
        /// 桌面牌存放
        /// </summary>
        BrandPlayer table;
        /// <summary>
        /// 準備要顯示的桌面牌
        /// </summary>
        BrandPlayer show_table;
        /// <summary>
        /// 牌工廠
        /// </summary>
        BrandFactory factory;
        /// <summary>
        /// 每個玩家分多少張
        /// </summary>
        int dealnumber;
        /// <summary>
        /// 計算多少個玩家
        /// </summary>
        int countplayers;
        /// <summary>
        /// 總牌數
        /// </summary>
        internal int sumBrands;
        /// <summary>
        /// 目前玩家
        /// </summary>
        public int state;
        /// <summary>
        /// 玩家組別計算
        /// </summary>
        int[] teamCount;
        /// <summary>
        /// 上一張牌
        /// </summary>
        internal Brand lastBrand;
        /// <summary>
        /// 方位
        /// </summary>
        Location lo;
        /// <summary>
        /// 玩家所有的錢
        /// </summary>
        double[] money;
        /// <summary>
        /// 連莊次數
        /// </summary>
        int win_Times;
        /// <summary>
        /// 玩家姓名
        /// </summary>
        string[] names;
        /// <summary>
        /// 底台
        /// </summary>
        public int basic_tai;
        /// <summary>
        /// 第幾次摸牌
        /// </summary>
        int barnd_count;

        /// <summary>
        /// 全部玩家集合
        /// </summary>
        /// <param name="playernumber">設定有多少個玩家</param>
        /// <param name="deal">一個玩家有多少張</param>
        public AllPlayers(int playernumber,int deal)
        {
            this.players = new BrandPlayer[playernumber];
            this.lo = new Location();
            this.table = new BrandPlayer();
            this.show_table = new BrandPlayer();
            this.factory = new BrandFactory();            
            this.dealnumber = deal;
            this.countplayers = playernumber;
            this.sumBrands = factory.SumBrands;
            this.state = 1;
            this.barnd_count = 0;
            this.basic_tai = Mahjong.Properties.Settings.Default.BasicTai;            
            this.teamCount = new int[playernumber];
            this.names = new string[playernumber];
            for (int i = 0; i < playernumber;i++ )
                teamCount[i]=0;            
            money = new double[playernumber];
            setBasicMoney(Mahjong.Properties.Settings.Default.Money);
            win_Times = 0;
            names[0] = Mahjong.Properties.Settings.Default.Player1;
            names[1] = Mahjong.Properties.Settings.Default.Player2;
            names[2] = Mahjong.Properties.Settings.Default.Player3;
            names[3] = Mahjong.Properties.Settings.Default.Player4;
        }
        /// <summary>
        /// 玩家陣列
        /// </summary>
        public BrandPlayer[] Players
        {
            get
            {
                return players;
            }
        }
        /// <summary>
        /// 桌面
        /// </summary>
        public BrandPlayer Table
        {
            get
            {
                return table;
            }
        }
        /// <summary>
        /// 第幾次摸牌
        /// </summary>
        public int Brand_Count
        {
            get
            {
                return barnd_count;
            }
        }
        /// <summary>
        /// 顯示的桌面
        /// </summary>
        public BrandPlayer Show_Table
        {
            get
            {
                return show_table;
            }
        }
        /// <summary>
        /// 玩家姓名
        /// </summary>
        public string[] Name
        {
            set
            {
                names = value;
            }
            get
            {
                return names;
            }
        }
        /// <summary>
        /// 現在的玩家
        /// </summary>
        public BrandPlayer NowPlayer
        {
            get
            {
                return players[state];
            }
        }
        /// <summary>
        /// 連莊次數
        /// </summary>
        public int Win_Times
        {
            set
            {
                win_Times = value;
            }
            get
            {
                return win_Times;
            }
        }
        /// <summary>
        /// 傳回玩家的金錢
        /// </summary>
        public double[] Money
        {
            get
            {
                return money;
            }
        }
        /// <summary>
        /// 建立牌,並分配牌
        /// </summary>
        public void creatBrands()
        {
            factory.createBrands();
            factory.randomBrands();
            table = factory.getBrands();
            dealbrands();
        }
        /// <summary>
        /// 傳回一個玩家設定多少張
        /// </summary>
        public int Dealnumber
        {
            get
            {
                return dealnumber;
            }
        }
        /// <summary>
        /// 分配牌
        /// </summary>
        void dealbrands()
        {
            Deal deal = new Deal(dealnumber, countplayers, table);
            deal.DealBrands();
            // get Players
            players = deal.Player;
            // get Table
            table = deal.Table;
        }
        /// <summary>
        /// 換下一家
        /// </summary>
        public void next()
        {
            state++;
            if (state % countplayers == 0)
                state = 0;
        }
        /// <summary>
        /// 摸牌
        /// </summary>
        /// <returns>牌</returns>
        public Brand nextBrand()
        {
            if (table.getCount() == 8) // 保留8張不摸
                throw new GameOverException();
            else
            {
                Brand b = nextTableBrand();
                barnd_count++;
                return b;
            }            
        }
        Brand nextTableBrand()
        {
            Brand b = table.getBrand(0);
            table.remove(b);
            lastBrand = b;
            return b;
        }
        /// <summary>
        /// 傳回方位
        /// </summary>
        /// <returns>方位</returns>
        public Location getLocation()
        {
            return lo;
        }
        /// <summary>
        /// 下一莊
        /// </summary>
        public void nextRound(bool aby)
        {
            if (aby)
                lo.next();
            this.table = new BrandPlayer();
            this.factory = new BrandFactory();
            this.state = 0;
            for (int i = 0; i < countplayers; i++)
                teamCount[i] = 0;   
        }
        /// <summary>
        /// 設定玩家的基本金錢
        /// </summary>
        /// <param name="number"></param>
        public void setBasicMoney(double number)
        {
            for (int i = 0; i < money.Length; i++)
                money[i] = number;
        }
        /// <summary>
        /// 吃、碰
        /// </summary>
        public void chow_pong(BrandPlayer player)
        {
            set_Team(player,true);
            //lastBrand = brand;            
        }
        /// <summary>
        /// 槓
        /// </summary>
        public void kong(BrandPlayer player)
        {            
            // 明槓,最後一張牌等於傳出來的牌的話為暗槓
            if (lastBrand==player.getBrand(0))
                set_Team(player, true);
            else // 暗槓
                set_Team(player, false);
            // 槓要補一張
            NowPlayer.add(nextBrand());
        }
        /// <summary>
        /// 設定群組號碼
        /// </summary>
        /// <param name="player">玩家</param>
        private void set_Team(BrandPlayer player,bool isCanSee)
        {
            teamCount[state]++;
            for (int i = 0; i < player.getCount(); i++)
                NowPlayer.remove(player.getBrand(i));
            for (int i = 0; i < player.getCount(); i++)
            {
                player.getBrand(i).IsCanSee = isCanSee;
                player.getBrand(i).Team = teamCount[state];
                NowPlayer.add(player.getBrand(i));
            }
        }
        /// <summary>
        /// 現在的玩家補花
        /// </summary>
        public bool setFlower()
        {
            bool ans = false;
            int f_count = 0;
            for (int i = 0; i < NowPlayer.getCount(); i++)
                if (NowPlayer.getBrand(i).getClass() == Mahjong.Properties.Settings.Default.Flower &&
                    !NowPlayer.getBrand(i).IsCanSee) // 花牌而且不可見
                {
                    NowPlayer.getBrand(i).IsCanSee = true;
                    NowPlayer.getBrand(i).Team = 1;
                    f_count++;
                    ans = true;
                }
            // 補上少的牌數
            for (int i = 0; i < f_count; i++)
                NowPlayer.add( nextTableBrand() );
            return ans;
        }
        /// <summary>
        /// 現在的玩家排序
        /// </summary>
        public void sortNowPlayer()
        {
            PlayerSort bs = new PlayerSort(players[state]);
            players[state] = bs.getPlayer();
        }
        /// <summary>
        /// 把牌打到桌面上
        /// </summary>
        /// <param name="brand"></param>
        public void PushToTable(Brand brand)
        {
            brand.IsCanSee = true;
            //NowPlayer.remove(brand);
            show_table.add(brand);
        }
    }
}
