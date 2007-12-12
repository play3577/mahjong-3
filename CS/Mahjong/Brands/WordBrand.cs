using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Mahjong.Brands
{
    /// <summary>
    /// 字牌
    /// </summary>
    public class WordBrand : Brand
    {
        private int Number;
        private bool See;
        /// <summary>
        /// 字牌
        /// </summary>
        /// <param name="number">牌面大小</param>
        public WordBrand(int number)
        {
            this.Number = number;
            See = false;
        }
        /// <summary>
        /// 字牌
        /// </summary>
        /// <param name="number">牌面大小</param>
        /// <param name="image">圖片</param>
        public WordBrand(int number,Image image)
        {
            this.Number = number;
            See = false;
            photo = image;
        }
        /// <summary>
        /// 字牌的值
        /// </summary>
        /// <returns></returns>
        public int getNumber()
        {
            return Number;
        }
        /// <summary>
        /// 牌的類別
        /// </summary>
        /// <returns></returns>
        public string getClass()
        {
            return Mahjong.Properties.Settings.Default.Wordtiles;
        }
        /// <summary>
        /// 是否可見
        /// </summary>
        public bool IsCanSee
        {
            get
            {
                return See;
            }
            set
            {
                See = value;
            }
        }
        private Image photo;
        /// <summary>
        /// 牌的圖片位置
        /// </summary>
        public Image image
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        private int teamNumber;
        /// <summary>
        /// 牌的組別
        /// </summary>
        public int Team
        {
            get
            {
                return teamNumber;
            }
            set
            {
                teamNumber = value;
            }
        }
        /// <summary>
        /// 牌的分數
        /// </summary>
        private int source = 0;
        public int Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
    }
}
