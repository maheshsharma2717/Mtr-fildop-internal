namespace FieldOpsAdmin.Components.Model
{
    public class FileUploadRes
    {
        public FileUploadResult? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";


    }
    public class FileUploadResult
    {
        public string Key { get; set; }
        public string FileUrl { get; set; }
    }

}
