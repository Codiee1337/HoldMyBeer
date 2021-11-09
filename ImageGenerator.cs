using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ImageGenerator
    {
        private static Random rand = new Random();

        /// <summary>This method generates a number of random images based on the provided count.
        /// <example>For example:
        /// <code>
        ///    
        /// GenerateXNumberOfRandomImage(10);
        ///    
        /// </code>
        /// results in 10 randomly generated picture in the resolutions:
        /// 2560x1440,
        /// 1920x1080,
        /// 1366x768,
        /// 640,480
        /// It can result in either png or jpg or JPEG or bmp.
        /// </example>
        /// </summary>
        public static void GenerateXNumberOfRandomImage(int count)
        {
            List<String> subFolders = new List<String>();
           
            String originalPath = Directory.GetCurrentDirectory();

            for(int i = 0; i < rand.Next(4,8); i++)
            {
                string pathString = System.IO.Path.Combine(originalPath, getRandomDirectoryName(8));
                subFolders.Add(pathString);
                System.IO.Directory.CreateDirectory(pathString);
            }

            subFolders.Add(originalPath);

            var result = Parallel.For(1, count, (i, state) =>
            {
                Console.WriteLine($"Beginning iteration {i}");

                int randomForWhichDirectory = rand.Next(0, subFolders.Count());

                

                RandomImageGenerator().Save(subFolders.ElementAt(randomForWhichDirectory) + "/"+new StringBuilder().Append(Path.GetRandomFileName()).Append(i).Append(ChooseYourSide()).ToString());



                Console.WriteLine($"Completed iteration {i}");
            });
            
                
                
            

            

            GC.Collect();



        }
        /// <summary>This method generates random string based on the provided length.
        /// <example>For example:
        /// <code>
        ///    
        /// String asd = RandomString(5);
        ///    
        /// </code>
        /// results in a String which is random and has a length of 5.
        /// </example>
        /// </summary>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        
        public static string getRandomDirectoryName(int length) 
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        public static string ChooseYourSide()
        {
            String[] fileTypes = {"jpg","png","bmp","jpeg"};

            switch (rand.Next(0, 3))
            {
                case 0:return ".jpg";break;
                case 1:return ".png";break;
                case 2:return ".bmp";break;
                case 3: return ".jpeg";break;
                default: return ".jpg";break;
            }
            
        }


        public static Bitmap RandomImageGenerator()
        {
            //random number
            Random rand1 = new Random();

            int size = rand1.Next(0, 4);

            int width = 0, height = 0;

            switch (size)
            {
                case 1: width = 640; height = 480;break;
                case 2: width = 1920; height = 1080;break;
                case 3: width = 2560; height = 1440;break;
                case 4: width = 1366; height = 768;break;
                default: width = 1920; height = 1080;break;
            }



            //bitmap
            Bitmap bmp = new Bitmap(width, height);

           
            

            

            //create random pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //generate random ARGB value
                    int a = rand1.Next(256);
                    int r = rand1.Next(256);
                    int g = rand1.Next(256);
                    int b = rand1.Next(256);

                    //set ARGB value
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    
                }
            }

            //load bmp in picturebox1


            //save (write) random pixel image
            return bmp;
        }

    }
}
