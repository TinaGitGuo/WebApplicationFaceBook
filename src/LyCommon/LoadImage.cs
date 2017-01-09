using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


public static class LoadImage
{

    public static byte[] GetPictureData(string imagePath)
    {
        FileStream fs = new FileStream(imagePath, FileMode.Open);
        byte[] byteData = new byte[fs.Length];
        fs.Read(byteData, 0, byteData.Length);
        fs.Close();
        return byteData;
    }
    //将Image转换成流数据，并保存为byte[]   
    public static byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
    {
        MemoryStream mstream = new MemoryStream();
        imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
        byte[] byData = new Byte[mstream.Length];
        mstream.Position = 0;
        mstream.Read(byData, 0, byData.Length); mstream.Close();
        return byData;
    }
    public static System.Drawing.Image ReturnPhoto(byte[] streamByte)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        return img;
    }
    public static void WritePhoto(byte[] streamByte)
    {
        // Response.ContentType 的默认值为默认值为“text/html”  
        //Response.ContentType = "image/GIF";
        ////图片输出的类型有: image/GIF     image/JPEG  
        //Response.BinaryWrite(streamByte);
    }
}
