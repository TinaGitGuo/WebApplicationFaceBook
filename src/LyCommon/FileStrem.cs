using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;


public static class FileStrem
{
    static IFileProvider provider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    static IDirectoryContents contents = provider.GetDirectoryContents(""); // the applicationRoot contents
    static IFileInfo fileInfo = provider.GetFileInfo("wwwroot/js/site.js");
    //  string 
    /// <summary>
    /// 输入相对路径，获得绝对路径
    /// </summary>
    /// <param name="relativepath">"TextFile.txt"</param>
    /// <returns></returns>
    public static string GetFilePath(string relativepath)
    {
        return Path.Combine(Directory.GetCurrentDirectory(), relativepath); 
    }
}

