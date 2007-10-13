using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Mahjong.Brands
{
    /// <summary>
    /// 索子牌
    /// </summary>
    public class RopeBrand : Brand
    {
        private int Number;
        private bool See;
        public RopeBrand(int number)
        {
            this.Number = number;
            See = true;
        }
        public RopeBrand(int number, Image image)
        {
            this.Number = number;
            See = true;
            photo = image;
        }
        /// <summary>
        /// 索牌的值的大小
        /// </summary>   
        public int getNumber()
        {
            return Number;
        }
        /// <summary>
        /// 索牌的類別
        /// </summary>   
        public string getClass()
        {
            return "Rope Brand";
        }
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
    }
}
