using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace Mahjong.Brands
{
    [Serializable]
    /// <summary>
    /// 索子牌
    /// </summary>
    public class RopeBrand : Brand
    {
        private int Number;
        private bool See;
        /// <summary>
        /// 索牌
        /// </summary>
        /// <param name="number">牌面大小</param>
        public RopeBrand(int number)
        {
            this.Number = number;
            See = false;
        }
       
        /// <summary>
        /// 索牌的值的大小
        /// </summary>   
        public int getNumber()
        {
            return Number;
        }
        /// <summary>
        /// 牌的類別
        /// </summary>   
        public string getClass()
        {
            return Mahjong.Properties.Settings.Default.Bamboos;
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

        private int source = 0;
        /// <summary>
        /// 牌的分數
        /// </summary>
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

        Mahjong.Control.location from;
        /// <summary>
        /// 那個方位打了這張牌
        /// </summary>
        public Mahjong.Control.location WhoPush
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }
        void setBrand(Brand brand)
        {
            from = brand.WhoPush;
            Number = brand.getNumber();
            IsCanSee = brand.IsCanSee;

        }
        public Brand copyBrand(Brand brand)
        {
            Brand newBrand = new RopeBrand(brand.getNumber());
            newBrand.WhoPush = brand.WhoPush;
            newBrand.IsCanSee = brand.IsCanSee;
            return newBrand;
        }
    }
}
