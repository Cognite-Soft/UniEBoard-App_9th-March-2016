using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace UniEBoard.Model.Adapters.Files
{
    /// <summary>
    /// FileManager Adapter class
    /// </summary>
    public class FileManagerAdapter : UniEBoard.Model.Interfaces.Adapter.IFileManagerAdapter
    {
        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="uploadPathlocation">The upload pathlocation.</param>
        /// <returns>the path of the uploaded file</returns>
        public string Save(HttpPostedFileBase file, string uploadPathlocation)
        {
            string path = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = string.Empty;
                path = Path.Combine(HttpContext.Current.Server.MapPath(uploadPathlocation), Path.GetFileName(file.FileName));
                if (File.Exists(path))
                    fileName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.ToString().Replace("/", "_").Replace(":", "_") + Path.GetExtension(file.FileName);
                else
                    fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(HttpContext.Current.Server.MapPath(uploadPathlocation), fileName);
                file.SaveAs(path);
            }
            return path;
        }

        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public string GetContentType(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                return file.ContentType;
            }
            return string.Empty;
        }
    }
}