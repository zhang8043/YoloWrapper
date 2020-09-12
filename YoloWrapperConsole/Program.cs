using ConsoleTables;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using YoloWrapper;

namespace YoloWrapperConsole
{
    class Program
    {
        private const string configurationFilename = @".\Cfg\yolov4.cfg";
        private const string weightsFilename = @".\Weights\yolov4.weights";
        private const string namesFile = @".\Data\coco.names";

        private static Dictionary<int, string> _namesDic = new Dictionary<int, string>();

        private static YoloWrapper.YoloWrapper _wrapper;

        static void Main(string[] args)
        {
            Initilize();

            Console.Write("ImagePath：");
            string imagePath = Console.ReadLine();
            var bbox = _wrapper.Detect(imagePath);

            Convert(bbox);

            Console.ReadKey();
        }

        private static void Initilize()
        {
            _wrapper = new YoloWrapper.YoloWrapper(configurationFilename, weightsFilename, 0);

            var lines = File.ReadAllLines(namesFile);
            for (var i = 0; i < lines.Length; i++)
                _namesDic.Add(i, lines[i]);
        }


        private static void Convert(BoundingBox[] bbox)
        {
            Console.WriteLine("Result：");
            var table = new ConsoleTable("Type", "Confidence", "X", "Y", "Width", "Height");
            foreach (var item in bbox.Where(o => o.h > 0 || o.w > 0))
            {
                var type = _namesDic[(int)item.obj_id];
                table.AddRow(type, item.prob, item.x, item.y, item.w, item.h);
            }
            table.Write(Format.MarkDown);
        }
    }
}
