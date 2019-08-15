using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace DmcSupport.DI
{
    public class FileHelper
    {
        public static async Task scanExcel(IFormFile file, int minHeader, Func<IRow, IRow, Task> func)
        {
            var sFileExtension = Path.GetExtension(file.FileName);
            if (file.Length > 0)
            {
                ISheet sheet;
                using (var stream = file.OpenReadStream())
                {
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }

                    //Read header
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;

                    if (cellCount < minHeader)
                        throw new Exception();

                    //Read cells
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        await func.Invoke(headerRow, sheet.GetRow(i));
                    }
                }
            }
        }
        public static Dictionary<string, string> GetDeviceFunctions()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("Create", "Thêm");
            dic.Add("Edit", "Cập nhật");
            dic.Add("Upgrade", "Nâng cấp");
            dic.Add("Replace", "Thay thế");
            dic.Add("Disassembly", "Tháo");
            dic.Add("Allocate", "Phân bổ");

            return dic;
        }

        public static bool IsNullOrEmptyCell(ICell cell)
        {
            return cell == null || cell.CellType == CellType.Blank;
        }

        public static MemoryStream CompressImagesToStream(List<Bitmap> images, List<string> imagesname)
        {
            var rsstream = new MemoryStream();
            using (var archive = new ZipArchive(rsstream, ZipArchiveMode.Create, true))
            {
                for(int i=0; i<images.Count; i++)
                {
                    using (var outputStream = new MemoryStream())
                    {
                        images[i].Save(outputStream, ImageFormat.Jpeg);
                        outputStream.Seek(0, SeekOrigin.Begin);
                        var entry = archive.CreateEntry(imagesname[i]);
                        using (var os = entry.Open())
                        using (var ws = new StreamWriter(os))
                        {
                            ws.Write(outputStream.ToString().ToCharArray());
                        }
                    }
                }
                rsstream.Seek(0, SeekOrigin.Begin);
            }
            return rsstream;
        }

        public static string BitmapToBase64String(Bitmap bitmap)
        {
            string result;
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);
                result = Convert.ToBase64String(ms.ToArray());
            }
            return result;
        }
    }
}
