using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Mahjong.Control
{
    public partial class ProgramControl
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream output, input;
        public void openfile()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = ".";
            o.Filter = "�±N�s�� (*.mahjong)|*.mahjong|�Ҧ��ɮ� (*.*)|*.*";
            o.ShowDialog();
            try
            {
                //�]�w�ɮ׬y
                input = new FileStream(o.FileName, FileMode.Open, FileAccess.ReadWrite);
                //Ū�ɨåB�ѧǦC��                
                this.all = (AllPlayers)formatter.Deserialize(input);
                //�����ɮ�
                input.Close();
                //��s�]�w�e��
                table.cleanAll();
                table.Setup(all);
                table.addImage();
                setInforamtion();
            }
            catch
            {
                MessageBox.Show("�}���ɮ׿��~�I", "ĵ�i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public virtual void savefile()
        {
            SaveFileDialog s = new SaveFileDialog();
            s.InitialDirectory = ".";
            s.Filter = "�±N�s�� (*.mahjong)|*.mahjong|�Ҧ��ɮ� (*.*)|*.*";
            s.ShowDialog();
            try
            {
                output = new FileStream(s.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                formatter.Serialize(output, all);
                output.Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�ɮצW�ٿ��~�I", "ĵ�i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}