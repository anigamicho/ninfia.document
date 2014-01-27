using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AIGT.leafia_engine2
{
    class narc
    {
        public int Entrys;
        public FileEntry[] fe;
        public FileStream fs;
        private string m_sFileName;
        public long size;

        public narc(string strFileName)
        {
            this.m_sFileName = strFileName;
            this.fs = new FileStream(strFileName, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(this.fs);
            byte[] buffer = new byte[0x10];
            reader.Read(buffer, 0, 0x10);
            this.size = BitConverter.ToUInt32(buffer, 8);
            int num = BitConverter.ToInt16(buffer, 12);
            this.fs.Seek((long) num, SeekOrigin.Begin);
            buffer = new byte[12];
            reader.Read(buffer, 0, 12);
            int num2 = BitConverter.ToInt32(buffer, 4);
            this.Entrys = BitConverter.ToInt32(buffer, 8);
            this.fe = new FileEntry[this.Entrys];
            for (int i = 0; i < this.Entrys; i++)
            {
                this.fe[i].Ofs = reader.ReadInt32();
                this.fe[i].Size = reader.ReadInt32() - this.fe[i].Ofs;
            }
            this.fs.Seek((long) (num + num2), SeekOrigin.Begin);
            buffer = new byte[0x10];
            reader.Read(buffer, 0, 0x10);
            int num4 = BitConverter.ToInt32(buffer, 4);
            num4 = ((num + num4) + num2) + 8;
            for (int j = 0; j < this.Entrys; j++)
            {
                this.fe[j].Ofs += num4;
            }
            this.fs.Close();
        }

        public void Close()
        {
            this.fs.Close();
        }

        public void DeleteFromEnd(long size)
        {
            this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
            if ((this.fs.Length - size) > 0L)
            {
                this.fs.SetLength(this.fs.Length - size);
            }
            this.fs.Close();
        }

        public int OpenEntry(int id)
        {
            this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
            this.fs.Seek((long) this.fe[id].Ofs, SeekOrigin.Begin);
            return 0;
        }

        public void ReplaceEntry(int index, int newsize, byte[] replacement)
        {
            int num = newsize - this.fe[index].Size;
            this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
            this.fs.Seek(8L, SeekOrigin.Begin);
            new BinaryWriter(this.fs).Write((int) (((int) this.size) + num));
            this.Close();
            if (num > 0)
            {
                for (int i = this.Entrys - 1; i > index; i--)
                {
                    this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                    this.fs.Seek((long) this.fe[i].Ofs, SeekOrigin.Begin);
                    BinaryReader reader = new BinaryReader(this.fs);
                    BinaryWriter writer2 = new BinaryWriter(this.fs);
                    byte[] buffer = new byte[this.fe[i].Size];
                    reader.Read(buffer, 0, this.fe[i].Size);
                    this.fs.Seek((long) (-this.fe[i].Size + num), SeekOrigin.Current);
                    writer2.Write(buffer, 0, this.fe[i].Size);
                    this.fs.Close();
                }
                this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                this.fs.Seek((long) this.fe[index].Ofs, SeekOrigin.Begin);
                new BinaryWriter(this.fs).Write(replacement);
                this.fs.Close();
                for (int j = index; j < this.Entrys; j++)
                {
                    this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                    this.fs.Seek((long) (0x1c + (j * 8)), SeekOrigin.Begin);
                    BinaryWriter writer4 = new BinaryWriter(this.fs);
                    BinaryReader reader2 = new BinaryReader(this.fs);
                    if (j == index)
                    {
                        this.fs.Seek(4L, SeekOrigin.Current);
                        long num4 = reader2.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer4.Write((int) (((int) num4) + num));
                        this.fe[index].Size += num;
                    }
                    else
                    {
                        long num5 = reader2.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer4.Write((int) (((int) num5) + num));
                        num5 = reader2.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer4.Write((int) (((int) num5) + num));
                        this.fe[j].Ofs += num;
                    }
                    this.fs.Close();
                }
            }
            else if (num < 0)
            {
                for (int k = index + 1; k < this.Entrys; k++)
                {
                    this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                    this.fs.Seek((long) this.fe[k].Ofs, SeekOrigin.Begin);
                    BinaryReader reader3 = new BinaryReader(this.fs);
                    BinaryWriter writer5 = new BinaryWriter(this.fs);
                    byte[] buffer2 = new byte[this.fe[k].Size];
                    reader3.Read(buffer2, 0, this.fe[k].Size);
                    this.fs.Seek((long) (-this.fe[k].Size + num), SeekOrigin.Current);
                    writer5.Write(buffer2, 0, this.fe[k].Size);
                    this.fs.Close();
                }
                this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                this.fs.Seek((long) this.fe[index].Ofs, SeekOrigin.Begin);
                new BinaryWriter(this.fs).Write(replacement);
                this.fs.Close();
                for (int m = index; m < this.Entrys; m++)
                {
                    this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                    this.fs.Seek((long) (0x1c + (m * 8)), SeekOrigin.Begin);
                    BinaryWriter writer7 = new BinaryWriter(this.fs);
                    BinaryReader reader4 = new BinaryReader(this.fs);
                    if (m == index)
                    {
                        this.fs.Seek(4L, SeekOrigin.Current);
                        long num8 = reader4.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer7.Write((int) (((int) num8) + num));
                        this.fe[index].Size += num;
                    }
                    else
                    {
                        long num9 = reader4.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer7.Write((int) (((int) num9) + num));
                        num9 = reader4.ReadUInt32();
                        this.fs.Seek(-4L, SeekOrigin.Current);
                        writer7.Write((int) (((int) num9) + num));
                        this.fe[m].Ofs += num;
                    }
                    this.fs.Close();
                }
            }
            else
            {
                this.fs = new FileStream(this.m_sFileName, FileMode.Open, FileAccess.ReadWrite);
                this.fs.Seek((long) this.fe[index].Ofs, SeekOrigin.Begin);
                new BinaryWriter(this.fs).Write(replacement);
                this.fs.Close();
            }
        }

    }
}
