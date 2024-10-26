namespace DockerTryOut
{
    internal sealed class Request
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    internal sealed class Response
    {
        public string Message => "This endpoint hasn't been implemented yet!";
    }
}
