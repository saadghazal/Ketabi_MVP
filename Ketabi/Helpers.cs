using Azure.Core;

namespace Ketabi
{
    public class Helpers
    {
       public string GetFileNameAfterUploading(HttpRequest Request,string folderName) {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(folderName, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

             return fileName;
        }
    }
}
