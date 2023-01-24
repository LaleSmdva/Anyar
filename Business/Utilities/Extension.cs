using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities;
public static class Extension
{
    public static  async Task<string> CopyFileAsync(this IFormFile file,string wwwroot,params string[] folders)
    {
        var path = wwwroot;
        var fileName=Guid.NewGuid().ToString()+file.FileName;
        foreach (var folder in folders)
        {
            path = Path.Combine(path, folder);
        }
        path=Path.Combine(path, fileName);
        using(FileStream stream=new(path,FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return fileName;
    }

    public static bool CheckFileSize(this IFormFile file, int kByte)
    {
        return file.Length > kByte;
    }
    //public static bool CheckFileType(this IFormFile file, string type)
    //{
    //    return file.C
    //}
}
