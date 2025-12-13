namespace Framework
{
    public class ApiRequest
    {
        public string UserToken { get; set; }
        public bool IsAuthorized { get; set; }
        public int RequestCount { get; set; }
        public bool IsValid { get; set; }

        public string Response { get; set; }
    }
}
