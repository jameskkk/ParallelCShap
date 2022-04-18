using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelCShap
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private string GetFixedLengthString(int len)
        {
            const string possibleAllChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            Random randomNumber = new Random();
            for (int i = 0; i < len; i++)
            {
                sb.Append(possibleAllChars[randomNumber.Next(0, possibleAllChars.Length)]);
            }
            return sb.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // 產生測試資料
            List<string> testData = new List<string>();

            // 產生亂數字串
            for (int i = 0; i < 100000; i++)
            {
                testData.Add(GetFixedLengthString(10));
            }

            ConcurrentStack<string> resultData = new ConcurrentStack<string>();

            Parallel.ForEach(testData, (item, loopState) =>
            {
                if (item.Contains("a") || item.Contains("abc"))
                {
                    resultData.Push(item);
                }
            });

            foreach (string data in resultData)
            {
                Console.WriteLine("data: " + data);
            }
        }

        private void btnColor2Grey_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            string pathImage = Path.Combine(Directory.GetCurrentDirectory(), "CEO1.jpg");
            picResult.Image = ConvertToGrey(pathImage);
            stopWatch.Stop();
            Console.WriteLine("Color2Grey() Time: " + stopWatch.ElapsedMilliseconds + " ms");
        }

        private void btnColor2GreyTPL_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            string pathImage = Path.Combine(Directory.GetCurrentDirectory(), "CEO1.jpg");
            picResult.Image = ConvertToGreyWithParallel(pathImage);
            stopWatch.Stop();
            Console.WriteLine("Color2GreyTPL() Time: " + stopWatch.ElapsedMilliseconds + " ms");
        }

        /// 
        /// 轉換成灰階圖檔
        /// 
        public static Bitmap ConvertToGrey(string filePath)
        {
            // 來源圖檔
            Bitmap bmp = new Bitmap(filePath);
            // 建立新的Bitmap物件,用來存放轉換後的圖片
            Bitmap newBmp = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);

            BitmapData newData = newBmp.LockBits(new Rectangle(0, 0, newBmp.Width, newBmp.Height),
                ImageLockMode.WriteOnly,
                bmp.PixelFormat);

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            // 循序轉換
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int offset = i * bmpData.Stride + j * (bmpData.Stride / bmpData.Width);
                    // 直接在記憶體讀寫像素的RGB值
                    int r = Marshal.ReadByte(bmpData.Scan0, offset + 2);
                    int g = Marshal.ReadByte(bmpData.Scan0, offset + 1);
                    int b = Marshal.ReadByte(bmpData.Scan0, offset);

                    int grey = (r * 77 + g * 151 + b * 28) >> 8;
                    Marshal.WriteByte(newData.Scan0, offset, (byte)grey);
                    Marshal.WriteByte(newData.Scan0, offset + 1, (byte)grey);
                    Marshal.WriteByte(newData.Scan0, offset + 2, (byte)grey);
                }
            }

            newBmp.UnlockBits(newData);
            bmp.UnlockBits(bmpData);

            return newBmp;
        }

        ///
        /// 透過TPL轉換成灰階圖檔
        ///
        public static Bitmap ConvertToGreyWithParallel(string filePath)
        {
            // 來源圖檔
            Bitmap bmp = new Bitmap(filePath);
            // 建立新的Bitmap物件,用來存放轉換後的圖片
            Bitmap newBmp = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);

            BitmapData newData = newBmp.LockBits(new Rectangle(0, 0, newBmp.Width, newBmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);

            int height = bmp.Height;
            int width = bmp.Width;

            // 平行轉換
            Parallel.For(0, height, i =>
                Parallel.For(0, width, j =>
                {
                    int offset = i * bmpData.Stride + j * (bmpData.Stride / bmpData.Width);
                    // 直接在記憶體讀寫像素的RGB值
                    int r = Marshal.ReadByte(bmpData.Scan0, offset + 2);
                    int g = Marshal.ReadByte(bmpData.Scan0, offset + 1);
                    int b = Marshal.ReadByte(bmpData.Scan0, offset);

                    int grey = (r * 77 + g * 151 + b * 28) >> 8;
                    Marshal.WriteByte(newData.Scan0, offset, (byte)grey);
                    Marshal.WriteByte(newData.Scan0, offset + 1, (byte)grey);
                    Marshal.WriteByte(newData.Scan0, offset + 2, (byte)grey);
                }));


            newBmp.UnlockBits(newData);
            bmp.UnlockBits(bmpData);
            return newBmp;
        }
    }
}
