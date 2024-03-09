using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Helpers;

public class FileHelper
{
    public static string Add(IFormFile file, string basePath)
    {
        try
        {
            var result = newPath(file, basePath);
            var sourcePath = Path.GetTempFileName();

            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            File.Move(sourcePath, result.newPath);
            return result.Path2;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static string Update(string sourcePath, IFormFile file, string basePath)
    {
        var result = newPath(file, basePath);
        try
        {
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            Delete(sourcePath);
        }
        catch (Exception e)
        {
            throw e;
        }
        return result.Path2;
    }

    public static IDataResult<string> Delete(string path)
    {
    //\wwwroot\Images\Bootcamp\a5b51531f9924ddbbaf4d3ad4bd7893f.jpg
    //\wwwroot\Images\Bootcamp\e89fa0127bcf480499a4586ac840094b.jpg
    //\wwwroot\Images\Bootcamp\9b88ff9750f7476f9dbcdecdca2226dd.jpg
        try
        {
            File.Delete(@$"wwwroot" + path);
            //File.Delete(path);
            return new SuccessDataResult<string>("Successfully deleted file");
        }
        catch (Exception e)
        {

            return new ErrorDataResult<string>("File couldn't be deleted. Exception: " + e.Message);
        }
    }

    private static (string newPath, string Path2) newPath(IFormFile file, string basePath)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        var creatingFileName = Guid.NewGuid().ToString("N") + fileExtension;
        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot\Images\" + basePath + $@"\");

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        var result = directoryPath + creatingFileName;
        return (result, $@"\Images\{basePath}\{creatingFileName}");
    }
}
